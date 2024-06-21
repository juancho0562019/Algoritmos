using Cliente.ConsultaAPI.Client;
using Cliente.ConsultaAPI.Commons;
using Cliente.ConsultaAPI.Orchestrator;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Cliente
{
    public partial class FrmConsumo : Form
    {
        private readonly IApiClient _apiClient;
        private readonly IConfiguration _configuration;
        private Context _context = null;
        public FrmConsumo(IApiClient apiClient, IConfiguration configuration)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _configuration = configuration;
        }

        private async void btnConsulta_Click(object sender, EventArgs e)
        {
            txtSalida.Clear();
            btnConsulta.Enabled = false;
            pgbProgreso.Show();

            var token = _context?.Token ?? "";
            var fechaVencimiento = _context?.TokenExpiration ?? DateTime.MinValue ;
            var usuario = _configuration.GetValue<string>("User");
            var clave = _configuration.GetValue<string>("Password");
            _context = new Context 
            {
                Usuario = usuario,
                Clave = clave,
                Cadena = txtInput.Text,
                Token = token,
                TokenExpiration = fechaVencimiento
            };
            var progress = new Progress<string>();

            progress.ProgressChanged += (s, message) => 
            {
                if (!txtSalida.IsDisposed)
                    txtSalida.AppendText(message + Environment.NewLine);
            };
            ConsultaOrchestrator orchestrator = new ConsultaOrchestrator(_apiClient, progress, _context);

            await Task.Run(() => orchestrator.ExecuteProcess());

            btnConsulta.Enabled = true;
            pgbProgreso.Hide();
            if (!txtSalida.IsDisposed)
                txtSalida.AppendText("**** PROCESO FINALIZADO ****");
        }
    }
}
