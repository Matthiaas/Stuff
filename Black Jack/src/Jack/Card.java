package Jack;

public class Card {

	private int cardNumber;
	private char zeichen;
	
	public Card(int num)
	{
		num++;
		
		if (num > 52 && num < 104 )
		{
			 num = num / 2;
		}
		if (num > 104 && num < 156 )
		{
			 num = num / 3;
		}
		if (num > 156 && num < 209  )
		{
			 num = num / 4;
		}

		 
		if(num <= 13)
		{
			cardNumber = num;
			zeichen = 'c';
		}
		else if ( num <= 26)
		{
			cardNumber = num - 13;
			zeichen = 'd';
		}
		else if (num <= 39 )
		{
			cardNumber = num - 13*2;	
			zeichen = 'h';
		}
		else if (num <= 52 )
		{
			cardNumber = num - 13*3;
			zeichen = 's';
		}
		
	}
	
	public int getNum()
	{
		if (cardNumber ==  1) {return 11 ;}
		if (cardNumber > 10) {return 10 ;}
		return cardNumber;
	}
	
	public char getChar()
	{
		return zeichen;
	}
	
	public String getPath()
	{
		if(cardNumber < 10){return ("0" + cardNumber + zeichen + ".gif" );}
		return ("" + cardNumber + zeichen + ".gif" );
	}
}
