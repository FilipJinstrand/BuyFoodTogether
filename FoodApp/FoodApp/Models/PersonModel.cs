using System;
using System.Collections.Generic;
using System.Text;
using FoodApp.ViewModels;

namespace FoodApp.Models
{
    public class Person : ItemViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
