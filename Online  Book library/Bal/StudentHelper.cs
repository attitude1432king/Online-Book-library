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
        public List<BookModel> GetStudentBook()
        {
            List<BookModel> BookList = new List<BookModel>();
            try
            {
                NpgsqlCommand cm = new NpgsqlCommand("select * from book", con);
                con.Open();
                NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    var book = new BookModel();
                    book.c_book_id = Convert.ToInt32(dr["c_book_id"]);
                    book.c_book_name = dr["c_book_name"].ToString();
                    book.c_book_author = dr["c_book_author"].ToString();
                    book.c_book_price = Convert.ToDecimal(dr["c_book_price"]);
                    BookList.Add(book);
                }

            }
            catch (Exception)
            {
                throw; ;
            }

            finally
            {
                con.Close();
            }
            return BookList;
        }


        public List<BookModel> GetCategoryByBook(string category)
        {
            List<BookModel> BookList = new List<BookModel>();
            try
            {
                NpgsqlCommand cm = new NpgsqlCommand("select * from book where c_book_category =@c_book_category ", con);
                cm.Parameters.AddWithValue("c_book_category", category);
                con.Open();
                NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    var book = new BookModel();
                    book.c_book_id = Convert.ToInt32(dr["c_book_id"]);
                    book.c_book_name = dr["c_book_name"].ToString();
                    book.c_book_author = dr["c_book_author"].ToString();
                    book.c_book_price = Convert.ToDecimal(dr["c_book_price"]);
                    BookList.Add(book);
                }

            }
            catch (Exception)
            {
                throw; ;
            }

            finally
            {
                con.Close();
            }
            return BookList;
        }
    }
}