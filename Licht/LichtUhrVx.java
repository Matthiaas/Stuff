package Licht;

import java.awt.image.BufferedImage;
import java.io.IOException;

import javax.imageio.ImageIO;

public class LichtUhrVx implements Clock
{
	
	private double x; // x- Position
	private double y; // y- Position
	private double Startx; // Start x-Position
	private double v; // x-Geschwindigkeit der Uhr
	private double VY;// y-Geschwindigkeit des Photons
	private boolean stop; // Ist die Uhr gestoppt?
	private int lenth ,  // Abstand der beiden Spiegel
				abstand; // Abstand zum Bildschirm Rand
	private double framex // Ist t für die x Bewegung Steigt immer
				, framey; // Ist t für die y Bewegung Steigt und sinkt wieder  
							// Ausweiche Möglichkeit wäre Abänderung der Funktion arcsin(sin(x))
	
	private final long c = 299792458 ;   // Lichtgeschwindigkeit als Konstante
	private boolean var ,	// Regelt ob sich das Photon auf oder ab bewegt
					isAlreadyReseted; // wurde die Uhr schon auf null gesetzt
	private  BufferedImage ligthPoint;// Bild des Photons
	private Kollision rect;	// Kollisons Objekt
	
	public Kollision getBoundig()
	{
		return rect;
	}
	
	public LichtUhrVx(int lenth, long v ,int Startx , int abstand , int color )
	{
		rect = new Kollision( Startx ,0 ); // Erstellt neues Kollions Object mit der Größe null
		this.lenth = lenth;
		this.v = v;
		this.abstand = abstand;
		this.Startx = Startx;
		x = Startx;

		VY =  (long)Math.sqrt( Math.abs((c*c) - (v*v)) );	
		try {
        	ligthPoint = ImageIO.read(zeichner.class.getResource("ligth"+color+".png"));	    
        } catch (IOException e) {e.printStackTrace();}
	}
	
	public final void update()
	{
	
		if(stop) return; // Beendet die Methode wenn die Uhr gestoppt ist
		
		
		y = (VY * framey) ;	// Berechnet die y-Geschwindigkeit des Photons
		x = v *framex + Startx; // Berechnet die x-Geschwindigkeit der Uhr
		rect.x =  x ;			// Ändert die Position des Kollisions Objekt
		
		framex += zeichner.getFramer() ;	
		if(!var && y < lenth) // Überprüft ob das Photon den Unteren Spiegel berührt 
		{
			// Vergrößert framey solange bis es am Unteren Spiegel ankommt
			framey += zeichner.getFramer() ;	

				
		}else
		{
			// Verkleinert framey solange bis es am Oberen Spiegel ankommt
			framey -= zeichner.getFramer() ;	
			if(!var)
			{
				var = true;
			}
			if(y<=abstand) // Überprüft ob das Photon den Oberen Spiegel berührt 
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
			framey =  (double) lenth /(double) VY;
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
	
	public final double getx()
	{
		
		return x;
	}
	
	public final double gety()
	{
		return y;
	}
	

	
	
	public final int getLength()
	{
		return lenth;
	}

	public final BufferedImage getImg()
	{
		return ligthPoint;
	}
	
	
	
}
