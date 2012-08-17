package br.scrumban;

import static org.junit.Assert.*;

import org.junit.Test;

public class TesteCalcularComissao {

	
	
	@Test
	public void teste_calcula_comissao_venda_10000_retorna_500() {
		Double entrada = 10000d;
		Double esperado = 500d;
		
		Double retorno = new CalculadoraComissaoVenda().calcular(entrada);
		
		assertEquals(esperado, retorno);
	}
	
	@Test
	public void teste_calcula_comissao_venda_100_retorna_5() {
		Double entrada = 100d;
		Double esperado = 5d;
		
		Double retorno = new CalculadoraComissaoVenda().calcular(entrada);
		
		assertEquals(esperado, retorno);
	}
	
	@Test
	public void teste_calcula_comissao_venda_20000_retorna_1200() {
		Double entrada = 20000d;
		Double esperado = 1200d;
		
		Double retorno = new CalculadoraComissaoVenda().calcular(entrada);
		
		assertEquals(esperado, retorno);
	}

	@Test
	public void teste_calcula_comissao_venda_negativa_20000_retorna_0() {
		Double entrada = -20000d;
		Double esperado = 0d;
		
		Double retorno = new CalculadoraComissaoVenda().calcular(entrada);
		
		assertEquals(esperado, retorno);
	}


	@Test
	public void teste_calcula_comissao_venda_fracionada_55_reais_59_centavos_retorna_2_reais_77_centavos() {
		Double entrada = 55.59d;
		Double esperado = 2.77d;
		
		Double retorno = new CalculadoraComissaoVenda().calcular(entrada);
		
		assertEquals(esperado, retorno);
	}
	
}
