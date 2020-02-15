using System.Collections.Generic;

namespace TestTask
{
    public class ErrorCodes
    {
        public List<ErrorCode> ListErrorCodes = new List<ErrorCode>();

        public class ErrorCode
        {
            public string Code { get; set; }
            public string Text { get; set; }
        }
    }
}
