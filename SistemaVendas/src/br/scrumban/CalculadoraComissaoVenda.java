package br.scrumban;

public class CalculadoraComissaoVenda {

	public static Double calcular(Double entrada) {
		
		Double comissao;
		
		if(entrada < 0d)
			comissao =  0d;
		else if(entrada <= 10000d)
			comissao = entrada * 0.05d;
		else
			comissao = entrada * 0.06d;
	
		comissao *= 100d;
		comissao = Math.floor(comissao)/100d;
		
		return comissao;
	}

	
	
}
