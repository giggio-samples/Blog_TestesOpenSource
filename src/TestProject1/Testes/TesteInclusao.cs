using ClassLibrary1;
using MbUnit.Framework;
using NHibernate;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteInclusao : TesteBase
    {
        private Produto _produtoParaIncluir;
        private ISession _session;

        [SetUp]
        public void Initialize()
        {
            Arrange();

            Act();
        }

        private void Arrange()
        {
            _session = Contexto.SessionFactory.OpenSession();
            _produtoParaIncluir = new Produto
                                      {
                                          Nome = "um"
                                      };
        }

        private void Act()
        {
            using (var trans = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(_produtoParaIncluir);
                trans.Commit();
            }
        }

        [Test]
        public void NaoEhIgualAZero()
        {
            Assert.AreNotEqual(0, _produtoParaIncluir.Id);
        }

        [Test]
        public void EstaNoBD()
        {
            _session.Clear();
            var produtoIncluido = _session.Get<Produto>(_produtoParaIncluir.Id);
            Assert.AreEqual("um", produtoIncluido.Nome);
        }
    }
}