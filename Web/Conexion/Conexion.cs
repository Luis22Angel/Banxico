//Se agrega referencia al paquete que se instalo
using System.Data.SqlClient;


namespace Web.Conexion
{
	public class Conexion
	{
		// Creacion de variable coon y se asigna el valor de cadena vacia
		private string conn = string.Empty;

		 public Conexion(){
			var construir = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

			//aceder al builder
			conn = construir.GetSection("ConnectionStrings:CadenaSQL").Value;
		}

		public string ObtenerCadenaSql()
		{
			return conn;	
		}

	}
}
