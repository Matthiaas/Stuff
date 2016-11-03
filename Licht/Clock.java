package Licht;


import java.awt.image.BufferedImage;

public interface Clock 
{
	public BufferedImage getImg();// ,,Bild" des Photons
	public void update(); // Update
	public double getx(); // x-Position
	public double gety(); // y-Position
	public Kollision getBoundig(); // Gibt das Kollisions Objekt zurück
	public void reset(); // Setzt t = 0
	public int getLength(); // Gibt den Abstand der Spiegel zurück
	public void stop(); // Stoppt die Uhr
	public void start();// Startet die Uhr		
	public default double getMid(Clock cl)// Gibt die Mitte von zwei Uhren zurück (Muss nicht mehr Implementiert werden)
	{
		return Math.abs((getx() + cl.getx() )/2);
	};
	
}
