using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    
    [TestClass]
    public abstract class TesteBase 
    {
        [TestInitialize]
        public virtual void TestInitialize() 
        {
            OperacoesDeTestes.Atual.CarregarBancoDeDados(ConfiguracaoDeTestes.Esquema, ConfiguracaoDeTestes.DadosDeTeste);
        }
    }
    

}