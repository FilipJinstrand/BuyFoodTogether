using System;
using System.Collections.Generic;
using System.Text;

namespace FoodApp.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Person { get; set; }
        public bool IsCompleted { get; set; }
    }
}
