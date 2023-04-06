using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online__Book_library.Bal
{
    public class Helper
    {
        // Connection String
        public NpgsqlConnection con = new NpgsqlConnection("Server =localhost;Port=5432;Database=library;User Id=postgres;Password=143256");

    }
}