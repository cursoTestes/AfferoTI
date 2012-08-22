using FluentNHibernate.Mapping;
using SistemaVendas.Model;

namespace SistemaVendas.Negocio
{
    public class VendaMap : ClassMap<Venda>
    {
        public VendaMap()
        {
            Id(x => x.IdVenda).GeneratedBy.HiLo("ProdutoId", "NextHi", "2");
            Map(x => x.dataVenda);
            Map(x => x.valor);
        }
    }

    public class VendaVendedorMap : ClassMap<VendaVendedor>
    {
        public VendaVendedorMap()
        {
            Id(x => x.IdVendaVendedor).GeneratedBy.Identity();
            Map(x => x.IdVendedor);
            Map(x => x.IdVenda);
            Map(x => x.Valor);
        }
    }
}