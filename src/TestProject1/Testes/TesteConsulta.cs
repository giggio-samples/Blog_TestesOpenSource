using ClassLibrary1;
using NHibernate;
using MbUnit.Framework;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteConsulta : TesteBase
    {
        private const int IdParaConsultar = 1;
        private ISession _session;
        private Produto _produtoEncontrado;

        [SetUp]
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

        [Test]
        public void ExisteNoBD()
        {
            Assert.IsNotNull(_produtoEncontrado);
        }
        [Test]
        public void TemNomeCorreto()
        {
            Assert.AreEqual("meu nome", _produtoEncontrado.Nome);
        }
    }
}
