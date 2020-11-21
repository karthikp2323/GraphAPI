using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrystalReportDemo.Models
{
    public class UserListViewModel
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string LastLogin { get; set; }
        //public string AzureUserStatus { get; set; }

    }
}