using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace TestProject1.Testes
{
    [TestClass]
    public class TesteConsulta : TesteBase
    {
        private const int IdParaConsultar = 1;
        private ISession _session;
        private Produto _produtoEncontrado;

        [TestInitialize]
        public void Initialize()
        {
            Arrange();

            Act();
        }

        private void Arrange()
        {
            _session = Contexto.SessionFactory.OpenSession();
        }

        private void Act()
        {
            _produtoEncontrado = _session.Get<Produto>(IdParaConsultar);
        }

        [TestMethod]
        public void ExisteNoBD()
        {
            Assert.IsNotNull(_produtoEncontrado);
        }
        [TestMethod]
        public void TemNomeCorreto()
        {
            Assert.AreEqual("meu nome", _produtoEncontrado.Nome);
        }
    }
}
