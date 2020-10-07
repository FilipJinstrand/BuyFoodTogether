using FoodApp.ViewModels;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodApp.Models
{
    public class Item : ItemViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Person { get; set; }
        private bool IsCompleted { get; set; }

        public bool isCompleted
        {
            get
            {
                return IsCompleted;
            }
            set
            {
                IsCompleted = value;
                StatusChanged(nameof(isCompleted));
            }
        }
    }
}
