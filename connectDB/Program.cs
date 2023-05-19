using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DBConnection
{
    public class MysqlDAO
    {
        public MySqlConnection GetConnection()
        {
            var stringBuilder = new MySqlConnectionStringBuilder();
            stringBuilder["Server"] = "127.0.0.1";
            stringBuilder["Database"] = "spring_social";
            stringBuilder["User Id"] = "root";
            stringBuilder["Password"] = "b17dccn160";
            stringBuilder["Port"] = "3306";

            string connectionString = stringBuilder.ToString();
            var sqlConnection = new MySqlConnection(connectionString);
            return sqlConnection;
        }


        static void Main(string[] args)
        {
            MysqlDAO mysqlDAO = new MysqlDAO();
            MySqlConnection mySqlConnection = mysqlDAO.GetConnection();
            try
            {
                mySqlConnection.Open();
                Console.WriteLine(mySqlConnection.State);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { mySqlConnection.Close(); }
        }
    }

    public class UserRepository : MysqlDAO
    {

        public  class User{
            public long id;
            public string? email;
            public string? password;
            public int? emailVerify;
            public string? imageUrl;
            public string? provider;

            public override string ToString()
            {
                return $"id: {id},  email: {email},  password: {password} , emailVeridy: {emailVerify} , imageUrl: {imageUrl} , provider: {provider} ";
            }
        } 

        public enum PROVIDER{
            LOCAL, FACEBOOK, GITHUB, GOOGLE

        }

        public UserRepository(){ }

        public List<User> GetUsers()
        {
            var users = new List<User>();
            MySqlConnection connection = null;
            try
            {
                connection = GetConnection();
                connection.Open();
                // Dùng SqlCommand thi hành SQL  - sẽ  tìm hiểu sau
                using (DbCommand command = connection.CreateCommand())
                {
                    // Câu truy vấn SQL
                    command.CommandText = "select * from users";
                    var reader = command.ExecuteReader();
                    // Đọc kết quả truy vấn
                   
                    while (reader.Read())
                    {
                        User u = new User();
                        u.email = reader.IsDBNull("email") ? null : reader.GetString("email");
                        u.password = reader.IsDBNull("password") ? null : reader.GetString("password");  
                        u.emailVerify = reader.IsDBNull("email_verified") ? null : reader.GetInt32("email_verified");
                        u.provider = reader.IsDBNull("provider") ? null : reader.GetString("provider");
                        u.imageUrl = reader.IsDBNull("image_url") ? null : reader.GetString("image_url");
                        users.Add(u);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if(connection != null ) connection.Close();
            }
            return users;
        }
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();
            List<User> users = userRepository.GetUsers();

            foreach(User u in users)
            {
                Console.WriteLine(u.ToString());
            }
        }
    }
}