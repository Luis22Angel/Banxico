using System.Data.SqlClient;
using Web.Models;
using System.Data;

namespace Web.Conexion
{
	public class TipoCambioDatos
	{
		public List<TipoCambioModel> ListarCambio()
		{
			var lista = new List<TipoCambioModel>();

			var con = new Conexion();

			using (var conexion = new SqlConnection(con.ObtenerCadenaSql()))
			{
				conexion.Open();
				SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
				cmd.CommandType = CommandType.StoredProcedure;

				using (var dr = cmd.ExecuteReader())
				{
						while (dr.Read())
						{
							lista.Add(new TipoCambioModel()
							{
								Id = Convert.ToInt32(dr["Id_tipo_cambio"]),
								Fecha = Convert.ToDateTime(dr["Fecha"]),
								Determinacion = dr["Determinacion"].ToString(),
								Dof = dr["DOF"].ToString(),
								Obligaciones = Convert.ToDouble(dr["Obligaciones"])

							});
						}
					
				}
				
			}
			return lista;
		}
		public TipoCambioModel ObtenerTipoCambio(int IdTipoCambio)
		{
			var tipoCambio = new TipoCambioModel();

			var con = new Conexion();

			using (var conexion = new SqlConnection(con.ObtenerCadenaSql()))
			{
				conexion.Open();
				SqlCommand cmd = new SqlCommand("sp_ObtenerCambio", conexion);
				cmd.Parameters.AddWithValue("IdTipoCambio", IdTipoCambio);
				cmd.CommandType = CommandType.StoredProcedure;

				using (var dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						tipoCambio.Id = Convert.ToInt32(dr["Id_tipo_cambio"]);
						tipoCambio.Fecha = Convert.ToDateTime(dr["Fecha"]);
						tipoCambio.Determinacion = dr["Determinacion"].ToString();
						tipoCambio.Dof = dr["DOF"].ToString();
						tipoCambio.Obligaciones = Convert.ToDouble(dr["Obligaciones"]);

					}

				}

			}
			return tipoCambio;
		}

		public bool Guardar(TipoCambioModel tipoCambio)
		{
			bool respuesta;

			try
			{
				var con = new Conexion();

				using (var conexion = new SqlConnection(con.ObtenerCadenaSql()))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("sp_GuardarCambio", conexion);
                       
                    cmd.Parameters.AddWithValue("Fecha",tipoCambio.Fecha);
					cmd.Parameters.AddWithValue("Determinacion", tipoCambio.Determinacion);
					cmd.Parameters.AddWithValue("DOF", tipoCambio.Dof);
					cmd.Parameters.AddWithValue("Obligaciones", tipoCambio.Obligaciones);
					cmd.CommandType= CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();
									
				}
				respuesta = true;
			}
			catch (Exception e)
			{
				string eror = e.Message;
				respuesta = false;
			}   

			return respuesta;

		}

		public bool Editar(TipoCambioModel tipoCambio)
		{
			bool respuesta;

			try
			{
				var con = new Conexion();

				using (var conexion = new SqlConnection(con.ObtenerCadenaSql()))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("sp_EditarCambio", conexion);
					cmd.Parameters.AddWithValue("IdCambio", tipoCambio.Id);
					cmd.Parameters.AddWithValue("Fecha", tipoCambio.Fecha);
					cmd.Parameters.AddWithValue("Determinacion", tipoCambio.Determinacion);
					cmd.Parameters.AddWithValue("Dof", tipoCambio.Dof);
					cmd.Parameters.AddWithValue("Obligaciones", tipoCambio.Obligaciones);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();

				}
				respuesta = true;
			}
			catch (Exception e)
			{
				string eror = e.Message;
				respuesta = false;
			}

			return respuesta;

		}

		public bool Eliminar(int idCambio)
		{
			bool respuesta;

			try
			{
				var con = new Conexion();

				using (var conexion = new SqlConnection(con.ObtenerCadenaSql()))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
					cmd.Parameters.AddWithValue("IdTipoCambio", idCambio);
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();

				}
				respuesta = true;
			}
			catch (Exception e)
			{
				string eror = e.Message;
				respuesta = false;
			}

			return respuesta;

		}
	}
}
