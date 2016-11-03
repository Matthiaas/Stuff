package Physiks;
/**
 * @author Matthias Bungeroth
 * Class: PlayerExample
 */
public class Collider 
{
	public Collider (MaxMin a  , Ph partner ,MaxMin b )
	{
		maxMin = a;
		collisonPartner = new collision(a, partner );
	}
	
	private  MaxMin  maxMin;
	public collision collisonPartner;
	
	public MaxMin maxMin()
	{
		return maxMin;
	}

	
	class collision
	{
		public collision(MaxMin a , Ph obj)
		{
			maxMin = a;
			gameObject = obj;
		}
		private Ph gameObject = null;
		private  MaxMin  maxMin;
		public MaxMin maxMin()
		{
			return maxMin;
		}
		public Ph gameObject()
		{
			return gameObject;
		}

	}
	
}
