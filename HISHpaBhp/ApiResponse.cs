namespace HISHpaBhp
{
    internal class ApiResponse
    {
        /// <summary>
        /// 回傳狀態
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 回傳代碼
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}