using ClassLibrary1;
using MbUnit.Framework;
using NHibernate;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteExclusao : TesteBase
    {
        private const int IdParaExcluir = 1;
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
        }

        private void Act()
        {
            var produtoParaExcluir = _session.Get<Produto>(IdParaExcluir);
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(produtoParaExcluir);
                tran.Commit();
            }
        }

        [Test]
        public void NaoEstaNoBD()
        {
            _session.Clear();
            var produtoExcluido = _session.Get<Produto>(IdParaExcluir);
            Assert.IsNull(produtoExcluido);
        }
    }
}