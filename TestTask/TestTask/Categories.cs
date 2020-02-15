﻿using System.Collections.Generic;

namespace TestTask
{
    public class Categories
    {
        public List<Category> ListCategories = new List<Category>();

        public class Category
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Parent { get; set; }
            public string Image { get; set; }
        }
    }
}
