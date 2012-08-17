package br.scrumban;

import java.util.List;

import br.scrumban.dao.VendaRepository;
import br.scrumban.modelo.entidade.Venda;

public class CalculadoraRoyalties {

	private VendaRepository vendaRepository;
	private CalculadoraComissaoVenda calculadoraComissaoVenda;
	
	public CalculadoraRoyalties(VendaRepository repository,
			CalculadoraComissaoVenda calculadoraComissao) {
		this.vendaRepository = repository;
		this.calculadoraComissaoVenda = calculadoraComissao;
	}

	public Double calcular(int ano, int mes) {
		List<Venda> vendas = vendaRepository.obterVendasPorMesEAno(ano, mes);
		
		Double valorLiquido = 0d;
		
		for(Venda v : vendas)
		{
			valorLiquido += v.getValor() - calculadoraComissaoVenda.calcular(v.getValor());
		}
		
		Double royalties = valorLiquido * 0.2;
		
		return royalties;
	}

}
