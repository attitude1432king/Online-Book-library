using Npgsql;
using Online__Book_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online__Book_library.Bal
{
    public class CategoryHelper :Helper
    {
        #region Get All Category
        public List<CategoryModel> GetAllCategory()
        {
            List<CategoryModel> CategoryList = new List<CategoryModel>();
            try
            {
                NpgsqlCommand cm = new NpgsqlCommand("SELECT * FROM category", con);
                con.Open();
                NpgsqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    var category = new CategoryModel();
                    category.c_category_id = Convert.ToInt32(dr["c_category_id"]);
                    category.c_category_name = dr["c_category_name"].ToString();
                    category.c_category_desc = dr["c_category_desc"].ToString();
                    CategoryList.Add(category);
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
            return CategoryList;
        }

        #endregion


        #region Get One Category
        public CategoryModel GetOneCategory(int id)
        {

            var category = new CategoryModel();
            try
            {
                NpgsqlCommand cm = new NpgsqlCommand("SELECT * FROM category WHERE c_category_id =@c_category_id ", con);
                cm.Parameters.AddWithValue("@c_category_id ", id);
                con.Open();
                NpgsqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    category.c_category_id = Convert.ToInt32(dr["c_category_id"]);
                    category.c_category_name = dr["c_category_name"].ToString();
                    category.c_category_desc = dr["c_category_desc"].ToString();
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
            return category;
        }

        #endregion


        #region Add Category
        public bool AddCategory(CategoryModel data)
        {
            bool category_check = false;
            try
            {
                NpgsqlCommand cm = new NpgsqlCommand("INSERT INTO category (c_category_name,c_category_desc) VALUES(@c_category_name,@c_category_desc)", con);
                cm.Parameters.AddWithValue("@c_category_name", data.c_category_name);
                cm.Parameters.AddWithValue("@c_category_desc", data.c_category_desc);
                con.Open();
                int n = cm.ExecuteNonQuery();
                if (n > 0)
                {
                    category_check = true;

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
            return category_check;
        }

        #endregion


        #region Update Category

        
        public bool UpdateCategory(CategoryModel data)
        {
            bool category_check = false;
            try
            {
                NpgsqlCommand cm = new NpgsqlCommand("UPDATE category SET c_category_name=@c_category_name,c_category_desc=@c_category_desc WHERE c_category_id=@c_category_id", con);
                cm.Parameters.AddWithValue("@c_category_id", data.c_category_id);
                cm.Parameters.AddWithValue("@c_category_name", data.c_category_name);
                cm.Parameters.AddWithValue("@c_category_desc", data.c_category_desc);
                con.Open();
                int n = cm.ExecuteNonQuery();
                if (n > 0)
                {
                    category_check = true;

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
            return category_check;
        }

        #endregion

        #region Delete Cateogory
        public bool DeleteCategory(int id)
        {
            bool category_check = false;
            try
            {
                NpgsqlCommand cm = new NpgsqlCommand("DELETE FROM category  WHERE c_category_id=@c_category_id", con);
                cm.Parameters.AddWithValue("@c_category_id", id);
                con.Open();
                int n = cm.ExecuteNonQuery();
                if (n > 0)
                {
                    category_check = true;

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
            return category_check;
        }
        #endregion
    }
}