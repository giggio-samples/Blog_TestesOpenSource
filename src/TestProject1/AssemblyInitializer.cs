using System.Configuration;
using System.IO;
using System.Reflection;
using ClassLibrary1;
using MbUnit.Framework;

namespace TestProject1
{
    [AssemblyFixture]
    public class AssemblyInitializer
    {
        [SetUp]
        public static void AssemblyInitialize()
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ConfiguracaoDeTestes.InicializarVariaveisDeTeste(baseDir, StringDeConexao);

            FazerBackupDoBancoAtualEmDisco();
            ConfigurarNHibernateESubirEsquemaDoBancoDeDadosDeDominio();
            SubirBancoDeDadosDeTeste();

        }

        [TearDown]
        public static void AssemblyCleanup()
        {
            OperacoesDeTestes.Atual.CarregarBancoDeDados(ConfiguracaoDeTestes.Esquema, ConfiguracaoDeTestes.DadosDeBackup);
            Contexto.SessionFactory.Dispose();
        }

        private static void SubirBancoDeDadosDeTeste()
        {
            OperacoesDeTestes.Atual.CarregarBancoDeDados(ConfiguracaoDeTestes.Esquema, ConfiguracaoDeTestes.DadosDeTeste);
        }

        private static void ConfigurarNHibernateESubirEsquemaDoBancoDeDadosDeDominio()
        {
            Configurador.Configurar(
                true,
                true);
        }

        private static void FazerBackupDoBancoAtualEmDisco()
        {
            try { OperacoesDeTestes.Atual.SalvarBancoDeDadosEmDisco(ConfiguracaoDeTestes.Esquema, ConfiguracaoDeTestes.DadosDeBackup); }
            catch { }
        }

        public static string StringDeConexao
        {
            get
            {
                var connectionString = ConfigurationManager.ConnectionStrings["ExemploBlog"].ConnectionString;
                return connectionString;
            }
        }
    }
}