using System.Data;
using System.Data.SqlClient;

namespace TestTask
{
    public class DataBase
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection = null;

        // Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        public DataBase() : this(@"Data Source = localhost\SQLEXPRESS;Integrated Security=true;Initial Catalog=TestTask")
        {
        }

        public DataBase(string connectionString) => _connectionString = connectionString;

        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection { ConnectionString = _connectionString };
            _sqlConnection.Open();
        }

        private void CloseConnection()
        {
            if (_sqlConnection?.State != ConnectionState.Closed)
            {
                _sqlConnection?.Close();
            }
        }

        public void InsertCategory(Categories.Category category)
        {
            OpenConnection();

            using (var command = new SqlCommand("AddCategories", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = category.Id,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = category.Name,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 255
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Parent",
                    Value = category.Parent,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Image",
                    Value = category.Image,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 255
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
                CloseConnection();
            }
        }

        public void InsertErrorCode(ErrorCodes.ErrorCode errorCode)
        {
            OpenConnection();

            using (var command = new SqlCommand("AddErrorCodes", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter
                {
                    ParameterName = "@Code",
                    Value = errorCode.Code,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@TextIn",
                    Value = errorCode.Text,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 255
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
                CloseConnection();
            }
        }
    }
}
