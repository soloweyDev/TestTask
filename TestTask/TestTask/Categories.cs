using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestTask
{
    [Serializable]
    [XmlRoot]
    public class Categories
    {
        [XmlArray]
        public IEnumerable<Category> categories;

        [Serializable]
        public class Category
        {
            [XmlAttribute]
            public string id;
            [XmlAttribute]
            public string name;
            [XmlAttribute]
            public string parent;
            [XmlAttribute]
            public string image;
        }
    }
}
