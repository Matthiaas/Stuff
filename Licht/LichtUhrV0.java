package Licht;

import java.awt.image.BufferedImage;
import java.io.IOException;

import javax.imageio.ImageIO;


public class LichtUhrV0 implements Clock
{
	// Beschreibungen siehe LichtUhrVx
	
	private double 	y, // y- Position
	 				x; // x- Position
	private int lenth ,  // Abstand der beiden Spiegel
				abstand; // Abstand zum Bildschirm Rand
	private final long c = 299792458; // Lichtgeschwindigkeit als Konstante
	private double frame; // Ist t für die y Bewegung Steigt und sinkt wieder  
	private boolean stop, // Ist die Uhr gestoppt?
					var,  // Regelt ob sich das Photon auf oder ab bewegt
					isAlreadyReseted ;// wurde die Uhr schon auf null gesetzt
	private  BufferedImage ligthPoint; // Bild des Photons
	
	private Kollision rect; // Kollisons Objekt
	public Kollision getBoundig()
	{
		return rect;
	}
	
	
	public LichtUhrV0(int lenth , int startx , int abstand, int color  )
	{
		this.lenth = lenth;
		this.abstand = abstand;
		
		try {
        	ligthPoint = ImageIO.read(zeichner.class.getResource("ligth"+color+".png"));	    
        } catch (IOException e) {e.printStackTrace();}
		
		x = startx ;
		
		rect = new Kollision( startx ,0); // Erstellt neues Kollions Object mit der Größe null
	}
	
	
	
	public final void update()
	{
		if(stop) return; // Beendet die Methode wenn die Uhr gestoppt ist
		y = (c * frame);

		
		if(!var && y < lenth) // Überprüft ob man den Unteren Spiegel berührt 
		{
			// Vergrößert frame solange bis es am Unteren Spiegel ankommt
			frame = frame + zeichner.getFramer() ;	

				
		}else
		{
			// Verkleinert framey solange bis es am Oberen Spiegel ankommt
			frame = frame -	zeichner.getFramer() ;	
			if(!var)
			{
				var = true;
			}
			if(y<=abstand)// Überprüft ob das Photon den Oberen Spiegel berührt 
			{	
				var =false;
			}
			
		}
		
	}

	// Stellt die Uhr auf Null
	public final void reset() 
	{
		if(!isAlreadyReseted)
		{
			isAlreadyReseted = true;
			frame =  (double) lenth /(double) c;
		}
		
	}
	// Stoppt die Uhr
	public final void stop()
	{
		if(!stop)
			System.out.println(y);
		stop = true;
	}
	// Startet die Uhr	
	public final void start()
	{
		stop = false;
	}
	
	public final int getLength()
	{
		return lenth;
	}
	
	public final double gety()
	{
		return y;
	}
	
	public final double getx()
	{
		return x;
	}
	public final BufferedImage getImg()
	{
		return ligthPoint;
	}
	
	
}
