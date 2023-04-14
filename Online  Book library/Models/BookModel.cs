using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online__Book_library.Models
{
    public class BookModel
    {
        public int c_book_id { get; set; }
        public string c_book_name { get; set; }
        public string c_book_author { get; set; }
        public string c_book_category { get; set; }
        public decimal c_book_price { get; set; }
        public int c_book_quantity { get; set; }
    }
}