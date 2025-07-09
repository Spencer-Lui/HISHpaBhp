using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Newtonsoft.Json;

namespace HISHpaBhp
{
    public partial class Form1 : Form
    {
        // string myVer = "20240822V1";
        string apiUrl = "https://apcvpn.hpa.gov.tw/bhpapi/api";  // 新版 Api指向位置(正式網址)
        public string new_idno = "";

        public Form1(String idno)
        {
            new_idno = idno;
            InitializeComponent();
        }

        private string ByToString(byte[] bytes, int Start, int Num)
        {
            string data = Encoding.GetEncoding(950).GetString(bytes, Start, Num);
            return data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (getHcData())
            {
                if (textID.Text == null)
                {
                    SelectedData = "{\"status\":true,\"code\":\"9002\",\"description\":\"請插入健保卡或重新讀取健保卡。\"}";
                    this.DialogResult = DialogResult.OK;
                    this.Close(); // 自動關閉窗體並回傳結果
                    return;
                }

                if (textID.Text == new_idno)
                {
                    try
                    {
                        // 第一次呼叫，只用來判斷是否需要知情同意，不處理回傳值   //20250507 new
                        ApiResponse firstResp = requestApi("/All/Valid");

                        if (firstResp.Status && (firstResp.Code.Substring(0, 2) == "04" || firstResp.Code.Substring(2, 2) == "04" || firstResp.Code.Substring(0, 2) == "94" || firstResp.Code.Substring(2, 2) == "94"))
                        {
                            //DialogResult result = MessageBox.Show(firstResp.Description, "知情同意", MessageBoxButtons.YesNo);
                            //bool agree = (result == DialogResult.Yes);
                            bool agree = true;

                            // 第二次呼叫，並使用 agree 結果
                            ApiResponse secondResp = requestApi("/All/Valid", agree);
                            SelectedData = textMsg.Text;
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            return;
                        }

                        // 若不需知情同意，也回傳第一次的 textMsg.Text
                        if (!string.IsNullOrEmpty(textMsg.Text))
                        {
                            SelectedData = textMsg.Text;
                            this.DialogResult = DialogResult.OK;
                            this.Close(); // 自動關閉窗體並回傳結果
                            return;
                        }
                    }
                    catch (Exception EX)
                    {

                        throw;
                    }
                }
                else
                {
                    SelectedData = "{\"status\":true,\"code\":\"9999\",\"description\":\"輸入身份證字號與健保卡身分證字號不同。\"}";
                    this.DialogResult = DialogResult.OK;
                    this.Close(); // 自動關閉窗體並回傳結果
                }
            }
            else
            {
                SelectedData = "{\"status\":true,\"code\":\"9999\",\"OpenCom失敗\":\"。\"}";
                this.DialogResult = DialogResult.OK; 
                this.Close(); // 自動關閉窗體並回傳結果
            }
        }

        private bool getHcData()
        {
            byte[] bBuffer = new byte[256];
            int iLen = 0;
            if (dllFunc.NHIcsOpenCom(0) == 0)
            {
                iLen = 10;
                dllFunc.NHIcsGetHospID(bBuffer, ref iLen);
                textHospID.Text = ByToString(bBuffer, 0, iLen);

                iLen = 12;
                dllFunc.NHIcsGetCardNo(1, bBuffer, ref iLen);
                textSamID.Text = ByToString(bBuffer, 0, iLen);

                iLen = 72;
                dllFunc.NHIhisGetBasicData(bBuffer, ref iLen);
                textHCSN.Text = ByToString(bBuffer, 0, 12);
                textID.Text = ByToString(bBuffer, 32, 10);
                textBirthYM.Text = ByToString(bBuffer, 42, 7);

                iLen = 126;
                dllFunc.NHIhisGetRegisterPrevent(bBuffer, ref iLen);
                textPreventData.Text = ByToString(bBuffer, 0, iLen);

                dllFunc.NHIcsCloseCom();

                return true;
            }
            else
            {
                textMsg.Text = "無法開啟COM";
                return false;
            }

        }

        private ApiResponse requestApi(string action, bool? agree = null)
        {
            try
            {
                // 設定 TLS 1.2 並忽略 SSL 憑證錯誤
                Tls12();

                MessageBox.Show("取action看內容: " + action);
                string token = dllFunc.GetBhpApiToken();
                MessageBox.Show("取token看內容: " + token);

                WebRequest request = WebRequest.Create(apiUrl + action);
                MessageBox.Show("取request看內容: " + request);
                request.Method = "POST";
                request.ContentType = "application/json";

                Request data = new Request()
                {
                    Token = token,
                    Agree = agree,
                    Person = new Person()
                    {
                        HospId = textHospID.Text,   // 醫療院所代號
                        SamId = textSamID.Text,     // 安全模組卡號
                        CardId = textHCSN.Text,     // 民眾健保卡號
                        Birth = textBirthYM.Text,   // 民眾出生日期
                        Pid = textID.Text,          // 民眾身分證號
                        RegisterPrevent = textPreventData.Text    // 預防保健註記
                    }
                };
                MessageBox.Show("取Person看內容，HospId: " + data.Person.HospId);
                MessageBox.Show("取Person看內容，SamId: " + data.Person.SamId);
                MessageBox.Show("取Person看內容，CardId: " + data.Person.CardId);
                MessageBox.Show("取Person看內容，Birth: " + data.Person.Birth);
                MessageBox.Show("取Person看內容，Pid: " + data.Person.Pid);
                MessageBox.Show("取Person看內容，RegisterPrevent: " + data.Person.RegisterPrevent);

                byte[] dataByte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(dataByte, 0, dataByte.Length);
                }
                // 印出 byte[] 的內容（轉成字串）
                string bodyContent = Encoding.UTF8.GetString(dataByte);
                MessageBox.Show("取stream看內容:\n" + bodyContent);

                using (WebResponse response = request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    string json = reader.ReadToEnd();
                    MessageBox.Show("取json看內容: " + json);
                    textMsg.Text = json;
                    ApiResponse resp = JsonConvert.DeserializeObject<ApiResponse>(json);
                    MessageBox.Show("取resp看內容: " + resp);
                    return resp;
                }
                //return new ApiResponse();
            }
            catch (WebException ex)
            {
                // 記錄 WebException 的狀態
                var status = ex.Status;
                textMsg.Text = $"WebException Status: {status} - 連線異常：" + ex.Message;

                if (status == WebExceptionStatus.NameResolutionFailure)
                {
                    textMsg.Text = "無法解析伺服器名稱，請檢查網路連接或 DNS 設置。";
                }
                else if (status == WebExceptionStatus.ConnectFailure)
                {
                    textMsg.Text = "無法連接到伺服器，請確認伺服器地址是否正確以及伺服器是否可用。";
                }
                else if (status == WebExceptionStatus.Timeout)
                {
                    textMsg.Text = "連接伺服器超時，請稍後再試。";
                }
                else
                {
                    textMsg.Text = "連線異常：" + ex.Message;
                }
                return null;
            }
            catch (Exception ex)
            {
                // 處理非 WebException 的其他異常
                textMsg.Text = "發生未預期的錯誤：" + ex.Message;
                return null;
            }
        }

        void Tls12()
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateCertificate);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        private bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // 返回 true 以强制接受证书。
            return true;
        }
        public string SelectedData { get; private set; }
    }
}
