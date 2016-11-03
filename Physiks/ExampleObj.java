package Physiks;


public class ExampleObj extends Ph
{

	boolean notJumped = true;

	public ExampleObj(int x , int y){
		super();
		this.x = x;
		this.y = y;
	}
	

	@Override
	public void Start()
	{
		weigth = 10;
		bounce = 0.4;
	
		imageName = "st.png";
		tag = "obj";
		
	}
	
	
}