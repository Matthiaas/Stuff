package Physiks;

import java.awt.event.KeyEvent;
/**
 * @author Matthias Bungeroth
 * Class: PlayerExample
 */

public class ExamplePlayer extends Ph
{
	
	boolean notJumped = true;
	
	@Override
	public void Start()
	{
		weigth = 10;
		imageName = "pic.png";
		x = 800;
		tag = "player";
		bounce = 0.1;
		stepHigth = 10;
	}
	
	@Override
	public void Update()
	{
		if(Keyboard.isKeyDown(KeyEvent.VK_RIGHT))
		{
			//x = x + Manager.DeltaTime()*100;
			walk(300);
			
		}
		
		if(Keyboard.isKeyDown(KeyEvent.VK_LEFT))
		{
			walk(-300);
			//x = x - Manager.DeltaTime()*100;
			
		}
		if(Keyboard.keyPressed(KeyEvent.VK_UP) && canStand() )
		{
			VecDown  = -800;
			
		}
	}
	
	public void KollosionStart(Collider obj)
	{
			
	}
	
}
