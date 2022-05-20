namespace WebApiCrud.DTO
{
    public class VeiculoDTO
    {
        public int? VeiculoId { get; set; } = null!;

        public string Placa { get; set; }

        public string Marca { get; set; }

        public int AnoFabricacao { get; set; }
    }
}
