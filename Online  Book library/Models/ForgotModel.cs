using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online__Book_library.Models
{
    public class ForgotModel
    {
        [Display(Name = "Email")]
        public string c_admin_email { get; set; }
    }
}