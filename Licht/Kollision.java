package Licht;

public class Kollision 
{
	public double x ; // Sollte Public sein um position einfach �ndern zu k�nnen
	public double size; // Gr��e der Kollisons liene
	
	public Kollision(double posx , double size)
	{
		x = posx;
		this.size = size;
	}
	
	public boolean collidesWith(Kollision coll)// Um herasu�zufinden ob ein Kollider mit einem anderen kollidiert 
	{
		double a = x - size/2; // Linie A links
		double b = x + size/2; // Linie A Rechts
		
		double y = coll.x - coll.getSize()/2; // Linie B rechts
		double z = coll.x + coll.getSize()/2; // Linie B rechts
		
		if((y > a && y < b  ) || (z > a && z < b  ) ||  (a > y && a < z  ) || (b > y && b < z  ) )
		
		{
			return true; // gibt true zur�ck wenn die beide Kollisions Objekte miteinander Kollidieren 
		}else
		{
			return false;
		}
	}
	
	public double getSize()// Gibt die Gr��e des  Colliders zur�ck
	{
		return size;
	}
}
