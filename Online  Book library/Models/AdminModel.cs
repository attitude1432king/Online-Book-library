using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online__Book_library.Models
{
    public class AdminModel
    {
        public int c_admin_id { get; set; }

        public string c_admin_name { get; set; }

        public string c_admin_email { get; set; }
        public string c_admin_gender { get; set; }
        public string c_admin_pass { get; set; }
    }
}