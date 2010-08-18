using FluentNHibernate.Mapping;

namespace ClassLibrary1
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("ProdutoId", "NextHi", "2");
            Map(x => x.Nome);
        }
    }
}