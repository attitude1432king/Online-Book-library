using Npgsql;
using Online__Book_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online__Book_library.Bal
{
    public class StudentHelper : Helper
    {
        public bool Register(StudentModel data)
        {
            NpgsqlCommand cm=new NpgsqlCommand("Insert into student(c_student_name,c_student_email,c_student_gender,c_student_college,c_student_department,c_student_contact,c_student_pass) VALUES(@c_student_name,@c_student_email,@c_student_gender,@c_student_college,@c_student_department,@c_student_contact,@c_student_pass)", con);
            cm.Parameters.AddWithValue("@c_student_name", data.c_student_name);
            cm.Parameters.AddWithValue("@c_student_email", data.c_student_email);
            cm.Parameters.AddWithValue("@c_student_gender", data.c_student_gender);
            cm.Parameters.AddWithValue("@c_student_college", data.c_student_college);
            cm.Parameters.AddWithValue("@c_student_department", data.c_student_department);
            cm.Parameters.AddWithValue("@c_student_contact", data.c_student_contact);
            cm.Parameters.AddWithValue("@c_student_pass", data.c_student_pass);
            con.Open();
            int i = cm.ExecuteNonQuery();
            if (i > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }


        public bool Login(LoginModel data)
        {
            bool auth = false;
            NpgsqlCommand cm = new NpgsqlCommand("select c_student_email,c_student_pass from student where c_student_email=@c_student_email AND c_student_pass=@c_student_pass ", con);

            cm.Parameters.AddWithValue("@c_student_email", data.c_admin_email);
            cm.Parameters.AddWithValue("@c_student_pass", data.c_admin_pass);
            con.Open();
            NpgsqlDataReader dr = cm.ExecuteReader();
            if (dr.Read())
            {
                auth = true;
                con.Close();
                return auth;
            }
            else
            {
                auth = false;
                con.Close();
                return auth;
            }

        }
    }
}