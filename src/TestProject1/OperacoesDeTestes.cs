using System.Data;
using System.Data.SqlClient;
using NDbUnit.Core.SqlClient;
using NDbUnit.Core;

namespace TestProject1
{
    public class OperacoesDeTestes
    {
        public void CarregarBancoDeDados(
            string esquema,
            string dados)
        {
            var baseDeDados = ObterBaseDeDados();
            baseDeDados.ReadXmlSchema(esquema);
            baseDeDados.ReadXml(dados);
            InserirDeAcordoComBanco(baseDeDados);
        }


        public void SalvarBancoDeDadosEmDisco(
            string schemaFilePathName,
            string datasetFilePathName)
        {
            var baseDeDados = ObterBaseDeDados();
            baseDeDados.ReadXmlSchema(schemaFilePathName);
            baseDeDados.GetDataSetFromDb().WriteXml(datasetFilePathName);
        }


        public static OperacoesDeTestes Atual
        {
            get
            {
                return new OperacoesDeTestes();
            }
        }


        protected void InserirDeAcordoComBanco(INDbUnitTest baseDeDados)
        {
            baseDeDados.PerformDbOperation(DbOperationFlag.CleanInsertIdentity);
        }

        public IDbCommand CriarCommand()
        {
            return new SqlCommand { Connection = new SqlConnection(ConfiguracaoDeTestes.StringDeConexao) };
        }
        protected INDbUnitTest ObterBaseDeDados()
        {
            var baseDeDados = new SqlDbUnitTest(ConfiguracaoDeTestes.StringDeConexao);
            return baseDeDados;
        }

    }
}
