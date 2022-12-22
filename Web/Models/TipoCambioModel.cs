using System.ComponentModel.DataAnnotations;
namespace Web.Models
{
	public class TipoCambioModel
	{
         
		//Creacion de propiedades
		public int  Id { get; set; }

        [Required(ErrorMessage ="El campo Fecha es obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="0:yyyy-MM-dd")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo Determinacion es obligatorio")]
        public string Determinacion { get; set; }

        [Required(ErrorMessage = "El campo DOF es obligatorio")]
        public string Dof { get; set;  }

        [Required(ErrorMessage = "El campo Obligaciones es obligatorio")]
        public double Obligaciones { get; set; }

	}
}
