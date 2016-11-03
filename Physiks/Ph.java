/**
 * Author: Matthias Bungeroth
 * Created: 2016
 * Filename: Ph.java
 * Description: Too Lazy
 */
package Physiks;

import java.awt.Rectangle;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.util.LinkedList;

import javax.imageio.ImageIO;

/**
 * @author Matthias Bungeroth
 * Class: Ph
 */
public abstract class Ph 

{
	private static Manager man = null;
	
	protected double x , y ;
	protected Rectangle bounding;
	protected BufferedImage image;
	protected double VecDown = 0.95248544f , JumpImpulse;
	private boolean isStarted , isGrounded;
	public boolean Fest = false;
	private boolean canFall = true;
	private LinkedList<Collider> collsWith = new LinkedList<Collider>();
	protected String imageName;
	protected String tag;
	protected boolean Jump;
	protected double weigth , bounce;
	protected int stepHigth;
	
	public  Ph ()
	{
		if (man == null)
			man = new Manager();
		man.add(this);
		Start();
		INStart();
	}
	
	public final void walk(double x)
	{
		if( collsWith.size() == 0  )
		{
			//this.x = this.x + Manager.DeltaTime()*x ;
			this.x = this.x + Manager.DeltaTime()*x ;
		}
		
		for(int i = 0; i < collsWith.size() ; i++)
		{
			if (collsWith.get(i).maxMin().minY() > 3 && collsWith.get(i).maxMin().maxY() -  collsWith.get(i).maxMin().minY() < stepHigth)
			{
				this.y = this.y -   (bounding.height - collsWith.get(i).maxMin().minY()) ;
				this.x = this.x + Manager.DeltaTime()*x ;
			}else if ( (collsWith.get(i).maxMin().minX() < 4 )&& x > 0 )
			{
				this.x = this.x + Manager.DeltaTime()*x ;
			}
			else if ((collsWith.get(i).maxMin().maxX() >= bounding.width-  4)  && x < 0 )
			{
				this.x = this.x + Manager.DeltaTime()*x ;
			}
			 

			
		}
		
		
	}
	
	public final void coll(Collider obj)
	{
	
		for(int i = 0; i < collsWith.size() ; i++)
		{
			if(collsWith.get(i).collisonPartner.gameObject() == obj.collisonPartner.gameObject())
			{
				INKollosion(obj);
				return;
			}
		}
		
		collsWith.add(obj);
		INKollosionStart(obj);
		
	}

	
	public final void collEnd(Ph obj)
	{
		
		for(int i = 0; i < collsWith.size() ; i++)
		{
			if(collsWith.get(i).collisonPartner.gameObject() == obj)
			{
				collsWith.remove(i);
				INKollosionStop(obj);
				Fest =false;
				canFall = true;
				return;
			}
		}
	}

	
	public void KollosionStart(Collider obj){}
	public  final void INKollosionStart(Collider obj)
	{
		
		KollosionStart(obj);
		INKollosion(obj);
	
		
	}
	
	public void Kollosion(Collider obj){}
	public final void INKollosion(Collider obj)
	{	
		Kollosion(obj);
		
	}
	
	public void KollosionStop(Ph obj){}
	public final void INKollosionStop(Ph obj)
	{
		canFall = true;
		
		KollosionStop(obj);
	}
	
	
	public void Start() {}
	private final void INStart()
	{
		
		if(image == null)
		{
			try {
				image  = ImageIO.read(this.getClass().getResource(imageName));
			} catch (IOException e) {}
		}
		bounding = new Rectangle((int) x ,(int) y , image.getWidth() , image.getHeight() );
		isStarted = true;
	}
	
	public void Update() {}
	public final void INUpdate()
	{
		bounding.x = (int) x;
		bounding.y = (int) y;
		Update();

		try {
			fall();
		} catch (IOException e) {}

		
		
	}
	
	private final void fall() throws IOException
	{
		for(int i = 0; i < collsWith.size() ; i++)
		{
			
			
			if ( collsWith.get(i).maxMin().minY() < 10   )
			{
				if (VecDown < 0)
				{
					VecDown = VecDown*bounce / -1.0 ;
				}
				
			}
			if ( collsWith.get(i).maxMin().maxY() > image.getHeight() - 10 )
			{
				//this.x = this.x + Manager.DeltaTime()*x ;
				canFall= false;
				Fest = true;
				isGrounded = true;

			}

		}
		
				
		//System.out.println(VecDown);
		if( (Manager.hoehe - (20 + image.getHeight() )) <= y  && VecDown >= 0 )
		{
			isGrounded = true;
			canFall= false;
			if(bounce > 1 ){throw new IOException();  }
			if(bounce > 0.01 && VecDown > 20)
			{
				VecDown = -bounce  * VecDown;
				isGrounded = false;
			}else
			{
				VecDown = 0.95248544f;
			
			}
			
			
			
		}else if(Jump )
		{
			Jump = false;
			VecDown = -JumpImpulse;
			VecDown = VecDown + Manager.DeltaTime()*9.81*10.0 * weigth;
			y = y + VecDown*Manager.DeltaTime() ;
			isGrounded = false;
		}
		else if(VecDown < 0 && !canFall )
		{
			canFall= true;
			Fest = false;
			VecDown = VecDown + Manager.DeltaTime()*9.81*10.0 * weigth;
			y = y + VecDown*Manager.DeltaTime() ;
		
		}
		else if( canFall)
		{
			VecDown = VecDown + Manager.DeltaTime()*9.81*10.0 * weigth;
			y = y + VecDown*Manager.DeltaTime() ;
		
			
		}
	}
	
	public final void Destroy()
	{
		man.remove(this);
	}
	public final boolean isGrounded()
	{
		return canFall ? isGrounded:false ;
	}
	
	public final boolean canStand()
	{
		return canFall ? isGrounded:true ;
	}
	
	public final double gety()
	{
		return y;
	}
	
	public final boolean getStarted()
	{
		return isStarted;
	}
	public final Rectangle getBounding()
	{
		return bounding;
	}
	public final double getx()
	{
		return x;
	}
	public final BufferedImage getImg()
	{
		return image;
	}
	
	public final Collider[] collides(Ph obj )
	{
		return (bounding.intersects(obj.bounding)) ? isPixelCollide(x , y  , image , obj.getx(), obj.gety() , obj.getImg() , obj ): null ;
		
	}
	public boolean collides( Rectangle bounding)
	{
		return bounding.intersects(bounding);
	}
	
	private final  Collider[] isPixelCollide(double x1, double y1, BufferedImage image1,
		            double x2, double y2, BufferedImage image2 , Ph obj) 
	{
		
		// initialization
		double width1 = x1 + image1.getWidth() -1,
		height1 = y1 + image1.getHeight() -1,
		width2 = x2 + image2.getWidth() -1,
		height2 = y2 + image2.getHeight() -1;
		
		int xstart = (int) Math.max(x1, x2),
		ystart = (int) Math.max(y1, y2),
		xend   = (int) Math.min(width1, width2),
		yend   = (int) Math.min(height1, height2);
		
		// intersection rect
		int toty = Math.abs(yend - ystart);
		int totx = Math.abs(xend - xstart);
		boolean collide = false;
		
		
		int maxy = 0 , maxx = 0 , miny = Integer.MAX_VALUE  , minx = Integer.MAX_VALUE ;
		int maxy1 = 0 , maxx1 = 0, miny1= Integer.MAX_VALUE   , minx1 = Integer.MAX_VALUE ;
		
		for (int y=1;y < toty-1;y++)
		{
			int ny = Math.abs(ystart - (int) y1) + y;
			int ny1 = Math.abs(ystart - (int) y2) + y;
			for (int x=1;x < totx-1;x++) 	
			{
				int nx = Math.abs(xstart - (int) x1) + x;
				int nx1 = Math.abs(xstart - (int) x2) + x;
				try 
				{
					if (((image1.getRGB(nx,ny) & 0xFF000000) != 0x00) && ((image2.getRGB(nx1,ny1) & 0xFF000000) != 0x00)) 
					{
						if(ny > maxy)
							maxy = ny;
						if(ny < miny)
							miny = ny;
						
						if(ny1 > maxy1)
							maxy1 = ny1;
						if(ny1 < miny1)
							miny1 = ny1;
						
						if(nx > maxx)
							maxx = nx;
						if(nx < minx)
							minx =nx;
						
						if(nx1 > maxx1)
							maxx1 = nx1;
						if(nx1 < minx1)
							minx1 =nx1;
						
						
						collide = true;
					}
				} catch (Exception e) {
					//System.out.println("s1 = "+nx+","+ny+"  -  s2 = "+nx1+","+ny1);
				}
			}
		}

		if(!collide) return null;
		
		MaxMin a = new MaxMin(maxx, minx ,maxy , miny);
		MaxMin b = new MaxMin(maxx1, minx1 ,maxy1 , miny1);
		
		Collider one  = new Collider(b, this  , a);
		Collider two  = new Collider(a, obj  , b);

		return new Collider[] {one, two };

	}
	
	
	

}
