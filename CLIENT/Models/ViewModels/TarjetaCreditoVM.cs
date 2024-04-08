namespace CLIENT.Models.ViewModels
{
    public class TarjetaCreditoVM
    {
        public int id { get; set; }
        public string? nombreTitular { get; set; }

        public string? numeroTarjeta { get; set; }

        public decimal montoOtorgado { get; set; }

        public decimal? porceInteres { get; set; }

        public decimal? porceInteresMinimo { get; set; }
    }
}
