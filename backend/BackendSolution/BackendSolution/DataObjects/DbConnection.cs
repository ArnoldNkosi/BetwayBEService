
using MySql.Data.MySqlClient;
namespace BackendSolution.DataObjects
{
	public class DbConnection
	{
		static MySqlConnection connection;
		public static void Connect()
		{
			connection = new MySqlConnection();

			try
			{
                connection.ConnectionString = "server = localhost; User Id = root" +
					"Persist Security Info = True; database = hello; Password =Nkosi11za ";
                connection.Open();
                Console.WriteLine("Succesfully connected!");

            }
            catch (Exception e)
			{
				Console.WriteLine("Connection not successful" + e.Message);
			}
		}
	}
}

