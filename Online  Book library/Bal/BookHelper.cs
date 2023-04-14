using Online__Book_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
namespace Online__Book_library.Bal
{
    public class BookHelper :Helper
    {
        public List<BookModel> GetAllBook()
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
                    book.c_book_category = dr["c_book_category"].ToString();
                    book.c_book_price = Convert.ToDecimal(dr["c_book_price"]);
                    book.c_book_quantity = Convert.ToInt32(dr["c_book_quantity"]);
                    BookList.Add(book);
                }

            }
            catch (Exception )
            {
                throw; ;                
            }

            finally
            {
                con.Close();
            }
            return BookList; 
        }


        public BookModel GetOneBook(int id)
        {
            
            var book = new BookModel();
            try
            {
                NpgsqlCommand cm = new NpgsqlCommand("select * from book where c_book_id =@c_book_id ", con);
                cm.Parameters.AddWithValue("@c_book_id ", id);
                con.Open();
                NpgsqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    book.c_book_id = Convert.ToInt32(dr["c_book_id"]);
                    book.c_book_name = dr["c_book_name"].ToString();
                    book.c_book_author = dr["c_book_author"].ToString();
                    book.c_book_category = dr["c_book_category"].ToString();
                    book.c_book_price = Convert.ToDecimal(dr["c_book_price"]);
                    book.c_book_quantity = Convert.ToInt32(dr["c_book_quantity"]);                    
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
            return book;
        }

        public bool AddBook(BookModel data)
        {
            bool book_check = false;
            try
            {
                NpgsqlCommand cm = new NpgsqlCommand("INSERT INTO book (c_book_name,c_book_author,c_book_category,c_book_price,c_book_quantity) VALUES(@c_book_name,@c_book_author,@c_book_category,@c_book_price,@c_book_quantity)", con);
                cm.Parameters.AddWithValue("@c_book_name", data.c_book_name);
                cm.Parameters.AddWithValue("@c_book_author", data.c_book_author);
                cm.Parameters.AddWithValue("@c_book_category", data.c_book_category);
                cm.Parameters.AddWithValue("@c_book_price", data.c_book_price);
                cm.Parameters.AddWithValue("@c_book_quantity", data.c_book_quantity);
                con.Open();
                int n = cm.ExecuteNonQuery();
                if (n > 0)
                {
                    book_check = true;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return book_check;
        }


        public bool UpdateBook(BookModel data)
        {
            bool book_check = false;
            try
            {
                NpgsqlCommand cm = new NpgsqlCommand("Update book set c_book_name=@c_book_name,c_book_author=@c_book_author,c_book_category=@c_book_category,c_book_price=@c_book_price,c_book_quantity=@c_book_quantity where c_book_id=@c_book_id", con);
                cm.Parameters.AddWithValue("@c_book_id", data.c_book_id);
                cm.Parameters.AddWithValue("@c_book_name", data.c_book_name);
                cm.Parameters.AddWithValue("@c_book_author", data.c_book_author);
                cm.Parameters.AddWithValue("@c_book_category", data.c_book_category);
                cm.Parameters.AddWithValue("@c_book_price", data.c_book_price);
                cm.Parameters.AddWithValue("@c_book_quantity", data.c_book_quantity);
                con.Open();
                int n = cm.ExecuteNonQuery();
                if (n > 0)
                {
                    book_check = true;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return book_check;
        }


        public bool DeleteBook(int id)
        {
            bool book_check = false;
            try
            {
                NpgsqlCommand cm = new NpgsqlCommand("DELETE FROM book  WHERE c_book_id=@c_book_id", con);
                cm.Parameters.AddWithValue("@c_book_id",id);
                con.Open();
                int n = cm.ExecuteNonQuery();
                if (n > 0)
                {
                    book_check = true;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return book_check;
        }
    }
}