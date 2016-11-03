package Licht;

import java.awt.Shape;
import java.awt.geom.Ellipse2D;

public class Sync 
{
	private Ellipse2D circle; // Lichtkreis
	private double D;		// Durchmesser des Lichtsignals
	private int x,y;	// x- und y-Position
	private final long c = 299792458;	// Lichtgeschwindigkeit als Konstante
	private Kollision rect ;	// Kollisons Objekt
	private boolean isVisible = false , isStartet;
	
	public Sync(int x , int y)
	{
		this.x = x;
		this.y = y;
		D = 0;
		
	}
	public final void Update()
	{
		if(isStartet )
		{
			isVisible = true;
			D += zeichner.getFramer() * c *2; //Erhöht den Radius in Lichtgeschwindigkeit
			circle = new Ellipse2D.Double( x - D/2, y -25, D, 100); // Erstellt eine Neue Ellipse mit den richtigen Maßen
			rect.size = D; // Setzt die Größe des Kollosions Objektes
		}
		
	}
	
	// Startet das Lichtsignal
	public final void Start()
	{
		
		isStartet = true;
		circle = new Ellipse2D.Double( x - D/2, y -25 , D, 100);
		rect = new Kollision( (x - D/2), 0);
	}
	
	public final void stop()
	{
		isStartet = false;
	}
	
	// Setzt das Lichtsignal auf den Anfangs zustand 
	public final void reset()
	{
		isStartet = false;
		D=0;
		circle = new Ellipse2D.Double( x - D/2, y -25 , D, 100);
		rect = new Kollision( (x - D/2), 0);
		isVisible = false;

	}
	public final double getx()
	{
		return x;
		
	}
	public final boolean isStarted()
	{
		return isStartet;
	}
	
	public final boolean isVisible()
	{
		return isVisible;
	}
	
	public final Shape getShape()
	{
		return circle;
	}
	public final Kollision getBoundig()
	{
		return rect;
	}

}
