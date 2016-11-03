package Physiks;

/**
 * @author Matthias Bungeroth
 * Class: MaxMin
 */
public class MaxMin
{
	/**
	 * @param maxX
	 * @param minX
	 * @param maxY
	 * @param minY
	 */
	public MaxMin(int maxX , int minX ,int maxY ,int minY )
	{
		this.maxX = maxX;
		this.minX = minX;
		
		this.maxY = maxY;
		this.minY = minY;
		//System.out.println(this.maxX);
		//System.out.println(this.minX);
		
		//System.out.println(this.maxY);
		//System.out.println(this.minY);
		//System.out.println();
	}
	private int maxX ,maxY , minX , minY;
	
	public int minX()
	{
		return minX;
	}
	public int maxX()
	{
		return maxX;
	}
	
	public int minY()
	{
		return minY;
	}
	public int maxY()
	{
		return maxY;
	}
	
}
