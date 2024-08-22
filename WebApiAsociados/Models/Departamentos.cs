namespace WebApiAsociados.Models
{
    public class Departamentos
    {
        public int Id { get; set; }
        public int Id_depto { get; set; }
        public required string Nombre_departamento { get; set; }
        public int Id_logico { get; set; }
    }

}
