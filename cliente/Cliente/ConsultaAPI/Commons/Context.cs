namespace Cliente.ConsultaAPI.Commons
{
    public class Context
    {
        public bool Retry { get; set; } = false;
        public string Token { get; set; } = string.Empty;
        public DateTime TokenExpiration { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string Cadena { get; set; } = string.Empty;
    }
}
