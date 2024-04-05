namespace API.Core.Domain
{
    public class TarjetasCredito
    {
        public long IdTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroTarjeta { get; set; }
        public decimal MontoOtorgado { get; set; }
        public decimal PorceInteres { get; set; }
        public decimal PorceInteresMinimo { get; set; }

    }
}
