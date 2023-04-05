using Npgsql;
using Online__Book_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online__Book_library.Bal
{
    public class AdminHelper:Helper
    {
        public bool AdminRegister(AdminModel data)
        {
            bool register = false;
            NpgsqlCommand cm = new NpgsqlCommand("insert into admin (c_admin_name,c_admin_email,c_admin_gender,c_admin_pass)values(@c_admin_name,@c_admin_email,@c_admin_gender,@c_admin_pass)", con);
            cm.Parameters.AddWithValue("@c_admin_name", data.c_admin_name);
            cm.Parameters.AddWithValue("@c_admin_email", data.c_admin_email);
            cm.Parameters.AddWithValue("@c_admin_gender", data.c_admin_gender);
            cm.Parameters.AddWithValue("@c_admin_pass", data.c_admin_pass);
            con.Open();
            int i = cm.ExecuteNonQuery();
            if (i>0)
            {
                register = true;
                con.Close();
                return register;
            }
            else
            {
                register = false;
                con.Close();
                return register;
            }
            
        }
    }
}