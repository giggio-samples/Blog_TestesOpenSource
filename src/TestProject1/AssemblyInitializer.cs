using System.Configuration;
using ClassLibrary1;
using MbUnit.Framework;

namespace TestProject1
{
    [Test]
    public class AssemblyInitializer
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            var baseDir = testContext.TestDeploymentDir;
            ConfiguracaoDeTestes.InicializarVariaveisDeTeste(baseDir, StringDeConexao, EstaRodandoViaMSTest(testContext));

            FazerBackupDoBancoAtualEmDisco();
            ConfigurarNHibernateESubirEsquemaDoBancoDeDadosDeDominio();
            SubirBancoDeDadosDeTeste();

        }

        [AssemblyCleanup]
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

        private static bool EstaRodandoViaMSTest(TestContext testContext)
        {
            return testContext.Properties.Contains("AgentName");
        }
 
    }
}