namespace leiloFlash_backend.DTO.MercadoPago
{
    public class MercadoPagoPreferenceResponseDTO
    {
        // URL de Checkout do Mercado Pago
        public string InitPoint { get; set; }

        // ID da preferência criada no Mercado Pago
        public string PreferenceId { get; set; }
    }
}
