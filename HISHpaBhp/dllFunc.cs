using System.Runtime.InteropServices;

namespace HISHpaBhp
{
    public class dllFunc
    {

        [DllImport("HpaBhp.dll", EntryPoint = "hpaGetBhpDllVersion")]
        public static extern string GetBhpDllVersion();

        [DllImport("HpaBhp.dll", EntryPoint = "hpaGetBhpApiToken")]
        public static extern string GetBhpApiToken();

        [DllImport("HpaBhp.dll", EntryPoint = "csOpenCom")]
        public static extern int NHIcsOpenCom(int Comport);

        [DllImport("HpaBhp.dll", EntryPoint = "csCloseCom")]
        public static extern int NHIcsCloseCom();

        [DllImport("HpaBhp.dll", EntryPoint = "csGetCardNo")]
        public static extern int NHIcsGetCardNo(int CardType, byte[] pBuffer, ref int iBufferLen);

        [DllImport("HpaBhp.dll", EntryPoint = "csGetHospID")]
        public static extern int NHIcsGetHospID(byte[] pBuffer, ref int iBufferLen);

        [DllImport("HpaBhp.dll", EntryPoint = "hisGetBasicData")]
        public static extern int NHIhisGetBasicData(byte[] pBuffer, ref int iBufferLen);

        [DllImport("HpaBhp.dll", EntryPoint = "hisGetRegisterPrevent")]
        public static extern int NHIhisGetRegisterPrevent(byte[] pBuffer, ref int intpBufferLen);

    }
}
