package br.scrumban;

import static org.junit.Assert.*;

import java.util.ArrayList;
import java.util.List;


import org.junit.Before;
import org.junit.Test;
import static org.mockito.Mockito.*;

import br.scrumban.dao.VendaRepository;
import br.scrumban.modelo.entidade.Venda;

public class TesteCalcularRoyalties {

	@Before
	public void preTeste(){
		
	}
	
	@Test
	public void teste_calcula_zero_vendas_retorno_0() {
		Double esperado = 0d;
		
		VendaRepository repository = mock(VendaRepository.class);
		CalculadoraComissaoVenda calculadoraComissao = mock(CalculadoraComissaoVenda.class);
		
		when(repository.obterVendasPorMesEAno(2012, 8)).thenReturn(new ArrayList<Venda>());
		
		CalculadoraRoyalties calculadora = new CalculadoraRoyalties(repository, calculadoraComissao);
		Double retorno = calculadora.calcular(2012, 8);
		
		assertEquals(esperado, retorno);
		
		verify(calculadoraComissao, times(0)).calcular(anyDouble());
	}

	@Test
	public void teste_calculo_com_uma_venda_100_reais_retorna_20()
	{
		Double esperado = 20d;
		
		Venda venda = new Venda(1, 1, 8, 2012, 100d);
		List<Venda> vendas = new ArrayList<Venda>();
		vendas.add(venda);
		
		VendaRepository repository = mock(VendaRepository.class);

		when(repository.obterVendasPorMesEAno(2012, 8)).thenReturn(vendas);
		
		CalculadoraComissaoVenda calculadoraComissao = mock(CalculadoraComissaoVenda.class);
		when(calculadoraComissao.calcular(100d)).thenReturn(0d);
		
		
		CalculadoraRoyalties calculadora = new CalculadoraRoyalties(repository, calculadoraComissao);
		Double retorno = calculadora.calcular(2012, 8);
		
		assertEquals(esperado, retorno);
		
		verify(repository).obterVendasPorMesEAno(2012, 8);
	}
}
