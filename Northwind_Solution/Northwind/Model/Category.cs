﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    class Category
    {
        private string _name;
        private string _description;
        private string _picture; // must be something else
        public Category(string name, string description, string picture)
        {
            _name = name;
            _description = description;
            _picture = picture;
        }
    }
}