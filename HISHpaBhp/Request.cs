namespace HISHpaBhp
{
    internal class Request
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 民眾知情同意
        /// </summary>
        public bool? Agree { get; set; }

        public Person Person { get; set; }
    }

    public class Person
    {

        /// <summary>
        /// 院所代碼
        /// </summary>
        public string HospId { get; set; }

        /// <summary>
        /// SAM代碼
        /// </summary>
        public string SamId { get; set; }

        /// <summary>
        /// 健保卡號碼
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 民眾出生日期(yyyyMMdd)
        /// </summary>
        public string Birth { get; set; }

        /// <summary>
        /// 民眾證號
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// 健保卡預防保健紀錄
        /// </summary>
        public string RegisterPrevent { get; set; }

    }
}