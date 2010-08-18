using System.IO;

namespace TestProject1
{
    public class ConfiguracaoDeTestes
    {
        private static bool _variaveisDeTesteInicializadas;
        public static string DiretorioDeDados;
        public static string DadosDeBackup;
        public static string DadosDeTeste;
        public static string Esquema;
        public static string StringDeConexao;

        public static void InicializarVariaveisDeTeste(
            string basedir,
            string stringDeConexao)
        {
            if (_variaveisDeTesteInicializadas) return;

            StringDeConexao = stringDeConexao;
            DiretorioDeDados = Path.Combine(basedir, @"Dados\");
            DadosDeBackup = Path.Combine(DiretorioDeDados, "DadosBackup.xml");
            DadosDeTeste = Path.Combine(DiretorioDeDados, "Dados.xml");
            Esquema = Path.Combine(DiretorioDeDados, "Schema.xsd");
            _variaveisDeTesteInicializadas = true;
        }
    }
}
