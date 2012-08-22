using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using SistemaVendas.Negocio;
using NHibernate;

namespace TestProject1.Testes
{
    [TestFixture]
    public class TesteRelatorioDeVenda : TesteBase
    {
        private ISession _session;
        private RelatorioVendas _relatorioVendas;

        [SetUp]
        public void Initialize()
        {
            //colocar codigo comum a varios testes dentro deste metodo. Ele é rodado antes dos testes.
            _session = Contexto.SessionFactory.OpenSession();
            _relatorioVendas = new RelatorioVendas(_session);
        }
        [Test]
        public void teste_consulta_vendedor_inexistente()
        {
            decimal valorEsperado = 0;
            int idVendedor = 0;
            int ano = 2011;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);
            
            Assert.AreEqual(valorEsperado, valorAnual);
        }


        [Test]
        public void teste_venda_com_vendedor_1_ano_2011_com_uma_venda_retorno_30()
        {
            decimal valorEsperado = 30;
            int idVendedor = 1;
            int ano = 2011;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_venda_com_vendedor_2_ano_2011_com_duas_vendas_retorno_110()
        {
            decimal valorEsperado = 110;
            int idVendedor = 2;
            int ano = 2011;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }


        [Test]
        public void teste_venda_com_vendedor_1_ano_2012_sem_vendas_retorno_0()
        {
            decimal valorEsperado = 0;
            int idVendedor = 1;
            int ano = 2012;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_venda_compartilhada_com_vendedor_3_vendedor_4_ano_2012_com_vendas_retorno_vendedor_3_valor_50()
        {
            decimal valorEsperado = 50;
            int idVendedor = 3;
            int ano = 2012;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_venda_compartilhada_e_sozinho_com_vendedor_3_vendedor_4_ano_2012_com_vendas_retorno_vendedor_4_valor_150()
        {
            decimal valorEsperado = 150;
            int idVendedor = 4;
            int ano = 2012;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }

        [Test]
        public void teste_venda_com_vendedor_4_ano_2011_com_vendas_retorno_vendedor_4_valor_100()
        {
            decimal valorEsperado = 100;
            int idVendedor = 4;
            int ano = 2011;

            decimal valorAnual = _relatorioVendas.ObterVendaAnualVendedor(idVendedor, ano);

            Assert.AreEqual(valorEsperado, valorAnual);
        }
    }
}
