package br.scrumban;

import junit.framework.Assert;

import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

import br.scrumban.infraestrutura.BaseAcceptanceTest;

public class CalculadoraTest extends BaseAcceptanceTest {

	@Test
	public void teste_soma_entrando_com_numero_1_e_2_espera_3_como_saida() {
		int entrada1 = 1;
		int entrada2 = 2;
		int esperado = 3;
		
		int retorno = Calculadora.soma(entrada1, entrada2);
		
		Assert.assertEquals(esperado, retorno);
		
	}
	
	@Test
	public void teste_soma_entrando_com_numero_2_e_4_espera_6_como_saida() {
		int entrada1 = 2;
		int entrada2 = 4;
		int esperado = 5;
		
		int retorno = Calculadora.soma(entrada1, entrada2);
		
		Assert.assertEquals(esperado, retorno);
		
	}
}
