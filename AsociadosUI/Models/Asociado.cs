using System.ComponentModel.DataAnnotations;

namespace AsociadosUI.Models
{
    public class Asociado
    {
        public int Id { get; set; }
        public int Num_asciado { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre")]
        public  string Nombre { get; set; }
        public int Salario { get; set; }
        public int Id_depto { get; set; }
        public int anio_ingreso { get; set; }
        public int Id_logico { get; set; }

    }
}
