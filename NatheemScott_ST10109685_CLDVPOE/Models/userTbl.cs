using NuGet.Protocol.Plugins;
using System.Data.SqlClient;

namespace NatheemScott_ST10109685_CLDVPOE.Models
{
    public class userTbl
    {
        //scottyDCBXXRS //Cnatheemonelife99!
        public static string con_string = "Server=tcp:cldvsqlserver.database.windows.net,1433;Initial Catalog=CLDV-DB;Persist Security Info=False;User ID=scottyDCBXXRS;Password=Cnatheemonelife99!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public SqlConnection con = new SqlConnection(con_string);

        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

        public int insert_User(userTbl m)
        {
            String sql = "INSERT INTO userTbl (userName, userSurname, userEmail, userPassword) VALUES (@Name, @Surname, @Email, @Password)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", m.Name);
            cmd.Parameters.AddWithValue("@Surname", m.Surname);
            cmd.Parameters.AddWithValue("@Email", m.Email);
            cmd.Parameters.AddWithValue("@Password", m.Password);

            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }

        public userTbl GetUserByEmailAndPassword(string email, string password)
        {
            userTbl user = null;
            string sql = "SELECT * FROM userTbl WHERE userEmail = @Email AND userPassword = @Password";

            using (SqlConnection connection = new SqlConnection(con_string))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user = new userTbl
                    {
                        Name = reader["userName"].ToString(),
                        Surname = reader["userSurname"].ToString(),
                        Email = reader["userEmail"].ToString(),
                        Password = reader["userPassword"].ToString()
                    };
                }

                connection.Close();
            }

            return user;
        }
    }
}