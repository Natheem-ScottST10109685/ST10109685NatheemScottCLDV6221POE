using Humanizer;
using System.Data.SqlClient;

namespace NatheemScott_ST10109685_CLDVPOE.Models
{
    public class userProduct
    {
        //scottyDCBXXRS //Cnatheemonelife99!
        public static string con_string = "Server=tcp:cldvsqlserver.database.windows.net,1433;Initial Catalog=CLDV-DB;Persist Security Info=False;User ID=scottyDCBXXRS;Password=Cnatheemonelife99!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public SqlConnection con = new SqlConnection(con_string);

        public string Name { get; set; }

        public string Price { get; set; }

        public string Category { get; set; }

        public string Availability { get; set; }

        public int insert_product(userProduct p)
        {
            string sql = "INSERT INTO userProduct (productname, productPrice, productCategory, productAvailability) VALUES(@Name,@Price,@Category,@Availability)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Price", p.Price);
            cmd.Parameters.AddWithValue("@Category", p.Category);
            cmd.Parameters.AddWithValue("@Availability", p.Availability);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
    }
}