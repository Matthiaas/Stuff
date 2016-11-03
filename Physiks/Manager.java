/**
 * Author: Matthias Bungeroth
 * Created: 2016
 * Filename: Manager.java
 * Description: Too Lazy
 */
package Physiks;

import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Toolkit;
import java.awt.event.KeyListener;
import java.util.LinkedList;

import javax.swing.JFrame;
import javax.swing.JPanel;



/**
 * @author Matthias Bungeroth
 * Class: Manager
 */

public class Manager extends JPanel
{
	
	private static final long serialVersionUID = -4631429951340207550L;
	
	private JFrame fenster;
	private static Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
	public static final int breite = (int)(Math.round(screenSize.getWidth()));
	public static final int hoehe = (int)(Math.round(screenSize.getHeight()));
	private LinkedList<Ph> gameObjects = new LinkedList<Ph>();
	public static KeyListener Tasten = new Keyboard();
	private static long timeSiceLastFrame = 0;
	private static double framesPerSecondReal = 0;
	
	
	public static double DeltaTime()
	{
		return  (framesPerSecondReal/1000);	
	}
	public static double getFramesPerSecond()
	{
		return framesPerSecondReal;
	}
	
	public Manager()
	{
		
		fenster = new JFrame("Game");
		fenster.setSize(breite, hoehe);
		fenster.setUndecorated(true);
		fenster.setVisible(true);	
		fenster.add(this);
		setSize(breite, hoehe);
		fenster.addKeyListener(Tasten);
		new Thread (() -> start() ).start();
	
	}
	

	private final void start()
	{
		boolean started = true ;
		long time = System.currentTimeMillis(); ;
		while (true)
		{
			
			timeSiceLastFrame = System.currentTimeMillis() - time;
			if(timeSiceLastFrame > 1)
			{
				framesPerSecondReal = timeSiceLastFrame;
				time = System.currentTimeMillis();
				
				if(started)
				{			
					Update();
				}
				repaint();
			}
		}
		
	}

	public final void add(Ph gameObject)
	{
		gameObjects.add(gameObject);
	}
	
	public final void Update()
	{
		for(int x = 0; x< gameObjects.size() ; x++)
		{
			if(gameObjects.get(x).getStarted())
			{
				gameObjects.get(x).INUpdate();
				
				
				for(int z = 0; z< gameObjects.size() ; z++)
				{
					if(gameObjects.get(z).getStarted() && z!=x )
						
					{
						// Pixel by Pixel
						if(gameObjects.get(x).getBounding().intersects(gameObjects.get(z).getBounding()))
						{
							Collider [] colliders = gameObjects.get(x).collides(gameObjects.get(z)) ;
							if( colliders != null)
							//if(gameObjects.get(x).rand.intersects(gameObjects.get(z).rand))
							{
								gameObjects.get(z).coll(colliders[0]);
								gameObjects.get(x).coll(colliders[1]);
							}else
							{
								gameObjects.get(x).collEnd(gameObjects.get(z));
								gameObjects.get(z).collEnd(gameObjects.get(x));
							}
						}
					}
				}
			}
		}
		repaint();
	}
	
	
	public final void paint (Graphics g)
	{		
		super.paint(g);
		Graphics2D g2d = (Graphics2D) g;	
		
		for(int x = 0; x< gameObjects.size() ; x++)
		{
			g2d.drawImage( gameObjects.get(x).getImg()  ,(int)  (gameObjects.get(x).getx())  ,(int)(gameObjects.get(x).gety()) ,null);	
		}
		
		
	}
	
	public final void remove(Ph x)
	{
		gameObjects.remove(x);
	}

}
