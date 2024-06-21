namespace Domain.Entities
{
    public class Algoritmo : BaseAuditableEntity<int>
    {
        public DateTimeOffset FechaRequest { get; set; }
        public string Request { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
        public DateTimeOffset FechaResponse { get; set; }
    }
}
