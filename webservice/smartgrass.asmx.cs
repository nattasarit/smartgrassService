using System;
using System.Web;
using System.Web.Services;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace webservice
{
	public class smartgrass : System.Web.Services.WebService
	{
		string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlServerConnectionString"].ConnectionString;

		[WebService(Namespace = "http://tempuri.org/")]
		[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

		public class CustomerWebService : System.Web.Services.WebService
		{
			[WebMethod]
			public string getGrassDetail()
			{
				return "ID.CUSTOMER";
			}
		}


		[WebMethod]
		public void TEST()
		{
			HttpContext.Current.Response.Write("{property: value}");
		}

		[WebMethod]
		public void getGrassDetail()
		{
			MySqlConnection conn = new MySqlConnection(connString);
			MySqlCommand command = conn.CreateCommand();
			command.CommandText = "SELECT * FROM ArtificialGrass";
			try
			{
				conn.Open();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			MySqlDataReader reader = command.ExecuteReader();
			String name = "";
			String id = "";
			while (reader.Read())
			{
				//Console.WriteLine(reader["ArtificailGrassName"].ToString());
				name = reader["ArtificialGrassName"].ToString();
				id = reader["ArtificialGrassID"].ToString();
			}
			Console.ReadLine();

			//get grass detail
			HttpContext.Current.Response.Write("{ID: '"+ id +"', Name: '"+ name +"'}");
		}

	}
}
