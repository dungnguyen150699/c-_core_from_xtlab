
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace net
{
    class Program
    {
        static void Main(string[] arg)
        {
            string sqlconnectStr = "Data Source=localhost,1433;Initial Catalog=xtlab;User ID=SA;Password=Password123";
            DbConnection connection = new SqlConnection(sqlconnectStr);

            connection.Open();                      // Mở kết nối - hoặc  connection.OpenAsync(); nếu dùng async

            //..                                    // thực hiện cá tác  vụ truy vấn CSDL (CRUD - Insert, Select, Update, Delete)

            connection.Close();                     // Đóng kết nối

        }
    }
}