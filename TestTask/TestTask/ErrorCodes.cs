using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestTask
{
    [Serializable]
    [XmlRoot]
    public class ErrorCodes
    {
        [XmlArray]
        public IEnumerable<ErrorCode> errorCodes;

        [Serializable]
        public class ErrorCode
        {
            [XmlAttribute]
            public string code;
            [XmlAttribute]
            public string text;
        }
    }
}
