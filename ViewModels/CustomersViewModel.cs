using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class CustomersViewModel
    {
        private List<Customer> customerList { get; set; }
        public CustomersViewModel(List<Customer> list)
        {
            this.customerList = list;
        }
        public List<Customer> getList()
        {
            return this.customerList;
        }
        
    }
}