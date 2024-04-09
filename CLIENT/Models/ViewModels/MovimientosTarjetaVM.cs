namespace CLIENT.Models.ViewModels
{
    public class MovimientosTarjetaVM
    {
        public int id { get; set; }
        public int idTarjeta { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaMovimiento { get; set; }
        public decimal monto { get; set; }
        public string tipoMovimiento { get; set; }
    }
}
