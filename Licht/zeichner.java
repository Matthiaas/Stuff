package Licht;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.util.LinkedList;

import javax.imageio.ImageIO;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JRadioButton;
import javax.swing.JSlider;
import javax.swing.JSpinner;
import javax.swing.event.ChangeEvent;






public class zeichner extends JPanel {

	// Einstiegspunkt 
	public static void main(String[] args)
	{  
		//Startet die Simulation 
		new zeichner();
	}
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 4068054973756996100L;
	
	private final long c = 299792458; // Lichtgeschwindigkeit als Konstante
	private static Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
	public static final int breite = (int)(Math.round(screenSize.getWidth())); // Bildschirm Breite in Pixel
	public static final int hoehe = (int)(Math.round(screenSize.getHeight())); // Bildschirm Höhe in Pixel
	private long time; // wird benötigt um Frames pro Sekunde zu zählen
	private BufferedImage spigel; // Bild des Spiegels
	private JFrame fenster;
	private JSlider slider , sliderPercent; 
	private JButton btnWeiter;
	private JLabel lblFrames;
	private LinkedList<JLabel> positionLabel = new LinkedList<JLabel>(); // Speichert Positions-Textfelder
	private JRadioButton rdStopONVergleich ,rdSychronisieren;
	private int oldSpinner;
	private Clock[] clocksLeft , clocksRigth;
	private int v = (int)(c/2); // x-Geschwindigkeit der Uhren
	private boolean systemStopLeft, systemStopRigth , isSystemStoped;
	
	private static double framer = 0.00000000000005; // t wird jedes frame um framer erhöht
	private static double size = 0.00000000000001;
	public static double getFramer()
	{
		return framer;
	}
	
	private Sync syncLeft ,syncRigth;
	private boolean stop = true;
	
	public zeichner()
	{
		time = System.currentTimeMillis();
		try {
			spigel = ImageIO.read(zeichner.class.getResource("spiegel.jpg")); // Setzt Bild des Spiegels auf Spiegel
		} catch (IOException e) {e.printStackTrace();}	
		initclocksLeft();
		fenster = new JFrame("Game");
		fenster.setSize(breite, hoehe);
		fenster.setUndecorated(true);
		fenster.setVisible(true);	
		fenster.add(this);
		setSize(breite, hoehe);
		init();
		startAnmin();
		

	}
	
	// Erstellt die Lichtuhren an den Start-Positionen und Setzt sie in einen Array
	private final void initclocksLeft()
	{
		
		// Höhe und breite in Prozentsätzen um die Simulation an jede Bildschirmgröße anzupassen. 
		
		clocksLeft = 
				new Clock[] 
				{
					new LichtUhrV0(hoehe/4  , breite/2 - breite/8  , spigel.getHeight() , 1 ), 
					new LichtUhrV0(hoehe/4 , breite/2 + breite/8, spigel.getHeight() , 1 ), 
					new LichtUhrVx(hoehe/4 ,v ,0 -3*( breite/8)   ,spigel.getHeight() , 2 ),
					new LichtUhrVx(hoehe/4  , v,0 - breite/8 , spigel.getHeight() , 2 )
				};
		
		double l = (breite/8.0)*2.0  * Math.sqrt(1.0- ((double)v *(double) v) /((double)c *(double)c ));
		double ll = ((breite/8.0)*2.0) /( Math.sqrt(1.0- ((double)v *(double) v) /((double)c *(double)c )));
		
		
		
		
		
		clocksRigth = 
				new Clock[] 
				{
					new LichtUhrV0(hoehe/4 , breite/2 - (int) ll/2  , spigel.getHeight() , 2 ), 
					new LichtUhrV0(hoehe/4 , breite/2 +  (int) ll/2, spigel.getHeight() , 2 ), 
					new LichtUhrVx(hoehe/4  , -v ,breite +(int) l   + (int)l/2   ,spigel.getHeight() , 1 ),
					new LichtUhrVx(hoehe/4  , -v ,breite  +(int) l - (int) l/2  , spigel.getHeight() , 1 )
				};
		
		restart();
	}
	
	

	private final void init()
	{
		// Erstellt die Lichtsignale in der Mitte der sich nicht bewegenden Uhren
		syncLeft = new Sync(breite/2 , hoehe/4 + clocksLeft[0].getImg().getHeight() - spigel.getHeight()/2 );
		syncRigth = new Sync(breite/2   , clocksLeft[0].getLength()*2 + spigel.getHeight() *4 );
		
		// Setzt das Layout auf Null um Buttons genau positionieren zu können
		setLayout(null);
		
		
		JButton bntRestart = new JButton("NeuStart"); // Neustart Button 
		btnWeiter = new JButton("Starten");	  // Start/Pause Button
		
		// Lamda Ausdruck ((ActionEvent arg0) -> {code();}) gibt hier ActionListener zurück
		btnWeiter.addActionListener((ActionEvent arg0) ->
			{
				System.out.println(stop);
				stop= ! stop;
				bntRestart.setVisible(true);
				removePositions();
				btnWeiter.setText(stop ? "Weiter":"Pause");
			});
		btnWeiter.setBounds(0, hoehe-134, 134, 56); // Setzt die 4 Eck-Punnkte
		btnWeiter.setVisible(true);					// Macht es Sichtbar
		btnWeiter.setFont(new Font( "Serif", Font.BOLD, 24 ) );
        add(btnWeiter); // Fügt den Button zum JPanel hinzu
        
        JButton bntEnd = new JButton("Ende"); 
        bntEnd.addActionListener((ActionEvent arg0) ->
			{
				System.exit(1); // Beendet Java Virtual Machine (um Sicher zu gehen das alle Prozesse beendet werden)
			});
        bntEnd.setBounds(134*2, hoehe-134, 134, 56);
        bntEnd.setVisible(true);
        bntEnd.setFont(new Font( "Serif", Font.BOLD, 24 ) );
        add(bntEnd); 
        
        
       
        bntRestart.setVisible(false);
        bntRestart.addActionListener((ActionEvent arg0) ->
			{
				
				btnWeiter.setText("Starten");
				stop = true;
				initclocksLeft();
				restart();
				removePositions();
			});
        bntRestart.setBounds(134, hoehe-134, 134, 56);
        bntRestart.setVisible(true);
        bntRestart.setFont(new Font( "Serif", Font.BOLD, 24 ) );
        add(bntRestart); 
        
        lblFrames = new JLabel();
        lblFrames.setFont(new Font( "Serif", Font.BOLD, 24 ) );
        lblFrames.setBounds(0, hoehe/2 + 44, 800, 44);
		add(lblFrames); 
		
		// Sollen die Uhren beim Vergleich angehalten werden?
		rdStopONVergleich = new JRadioButton("Stoppen bei Vergleich");
		rdStopONVergleich.setOpaque(false);
		rdStopONVergleich.setBackground(new Color(0,0,0,0));
		rdStopONVergleich.setBorder(null);
		rdStopONVergleich.setContentAreaFilled(false);
		rdStopONVergleich.setBounds(0, hoehe/2 + 44*2, 800, 44);
        add(rdStopONVergleich);
        
        // Sollen die Uhren Sychronisiert werden?
        rdSychronisieren = new JRadioButton("Sychronisieren");
        // Macht den Hintergrund Durchsichtig 
        rdSychronisieren.setOpaque(false);
        rdSychronisieren.setBackground(new Color(0,0,0,0));
        rdSychronisieren.setBorder(null);
        rdSychronisieren.setContentAreaFilled(false);
        //
        rdSychronisieren.setBounds(0, hoehe/2 + 44*3, 800, 44);
        add(rdSychronisieren);
        
        // Slider Um die Geschwindigkeit der Simulation genau anzupassen 
        slider = new JSlider(1,10);
		slider.setBounds(0, hoehe/2 + 44*3+30, breite, 100);
		slider.setBackground(new Color(0,0,0,0));
		slider.setOpaque(false);
		slider.setBorder(null);;
		JSpinner spinner = new JSpinner();
		slider.addChangeListener((ChangeEvent arg0) -> {framer = slider.getValue()*size;	});
		add(slider);
		
		JLabel lblPrecent = new JLabel("X-Geschwindikeit = 50% der Lichtgescwindigkeit");
		lblPrecent.setFont(new Font( "Serif", Font.BOLD, 14 ) );
		lblPrecent.setBounds(0, hoehe/2 + 44*5, 500, 44);
		add(lblPrecent);
		
		sliderPercent = new JSlider(1,99); // spanne 10% - 90% 
		sliderPercent.setBounds(0, hoehe/2 + 44*5, breite, 100);
		sliderPercent.setBackground(new Color(0,0,0,0));
		sliderPercent.setOpaque(false);
		sliderPercent.setBorder(null);;
		sliderPercent.addChangeListener((ChangeEvent arg0) -> {v = (int) (sliderPercent.getValue()/100.0 *c );
		lblPrecent.setText("X-Geschwindikeit = " + sliderPercent.getValue()+"% der Lichtgescwindigkeit" );
		
		// Simulation neu Starten um X-Geschwindigkeit zu ändern
		btnWeiter.setText("Starten");
		stop = true;
		initclocksLeft();
		syncLeft.reset();
		syncRigth.reset();
		
		});
		add(sliderPercent);
		
		
		
		JLabel lblMulti = new JLabel("Multiplikator");
		lblMulti.setFont(new Font( "Serif", Font.BOLD, 14 ) );
		lblMulti.setBounds(breite/2 -100, hoehe/2 + 44*2 +10, 100, 44);
		add(lblMulti);
		
		// Spinner Um die Geschwindigkeit der Simulation grob anzupassen 
		spinner.setBounds(breite/2 , hoehe/2 + 44*2 +10 , 100, 44);
		spinner.addChangeListener
		(
			(ChangeEvent arg0) ->
			{
		
				slider.setValue(oldSpinner > (int)spinner.getValue() ? 10:0);
				
				if((int)spinner.getValue() == 0)
				{
					size = 0.0000000000001;
				}else
				{
					size = 0.0000000000001  *  (((double)(int)spinner.getValue() > 0)  ? 10.0*(double)(int)spinner.getValue():1.0/(10.0*(double)(int)spinner.getValue())) ;
				}
				size = Math.abs(size);
				framer = slider.getValue()*size;
				oldSpinner =(int)spinner.getValue();

				
			}
		);
		add(spinner);
	}
	
	// startet die Unendlich lange While schleife 
	private final void startAnmin()
	{
		
		int framesPerSecond = 0;
		while(true)
		{
			// Zählt die an Frames pro Sekunde
			if(time + 1000 <  System.currentTimeMillis())
			{
				time = System.currentTimeMillis();
				lblFrames.setText("Simulationen pro Sekunde:" +framesPerSecond );
				framesPerSecond = 0;
			}
			framesPerSecond++;	
				
				if(!stop)
				{
					
					// Uhren aus System A (obere Uhren)
					for(int x = 0; x< clocksLeft.length ; x++)
					{
						clocksLeft[x].update(); // Update Methode
						if(syncLeft.isStarted()) // 
						{
							// Überprüft Kollision mit dem Lichtsignal wenn das Lichtsignal gestartet wurde.
							if(clocksLeft[x].getBoundig().collidesWith((syncLeft.getBoundig())))
							{
								clocksLeft[x].reset();
								//stop = true;
							}
						}
					}
					
					// Uhren aus System B (untere Uhren)
					for(int x = 0; x< clocksRigth.length ; x++)
					{
						clocksRigth[x].update(); 
						if(syncRigth.isStarted())
						{
							if(clocksRigth[x].getBoundig().collidesWith((syncRigth.getBoundig())))
							{
								clocksRigth[x].reset();
								//stop = true;
							}
						}
					}
					
					//Update der Lichtsignale
					syncLeft.Update();	
					syncRigth.Update();
					
					// Überprüft ob die Position der Mitte der Bewegten Uhren größer gleich 
					// der die Position der Mitte der Unbewegten Uhren ist
					// denn syncLeft wurde in der Mitte beider ruhenden Uhren erstellt.
					
					//System A
					if(clocksLeft[2].getMid(clocksLeft[3]) >= syncLeft.getx() && !syncLeft.isStarted() && rdSychronisieren.isSelected())//1111 !! 1 clocksLeft[2]
					{
						syncLeft.Start();
					}
					//System B
					if(clocksRigth[2].getMid(clocksRigth[3]) <= syncRigth.getx() && !syncRigth.isStarted() && rdSychronisieren.isSelected())//1111 !! 1 clocksLeft[2]
					{
						syncRigth.Start();
					}
					
					// Stoppt die Uhren eines Systems beim Vergleich der Uhren B1 und A2
					if(!systemStopLeft && (int)clocksLeft[2].getx()==(int) clocksLeft[1].getx()  && rdStopONVergleich.isSelected()) // &&   syncLeft.isStarted()
					{
						for(int x = 0; x< clocksLeft.length ; x++)
						{
							clocksLeft[x].stop();
							printPosition(clocksLeft[x].getx(),clocksLeft[x].gety() ,0 );
						}
						syncLeft.stop();
						systemStopLeft = true;

					}
					if(!systemStopRigth && (int)clocksRigth[0].getx()==(int) clocksRigth[2].getx() && rdStopONVergleich.isSelected())//&&  syncRigth.isStarted() 
					{
						for(int x = 0; x< clocksRigth.length ; x++)
						{
							clocksRigth[x].stop();
							int l = clocksLeft[0].getLength() + spigel.getHeight() *4;
							printPosition(clocksRigth[x].getx(),clocksRigth[x].gety() , l );
						}
						syncRigth.stop();
						systemStopRigth = true;
					}
					
					if(systemStopRigth && systemStopLeft && !isSystemStoped ) // Starten nach vergleich mit weiter Button
					{
						isSystemStoped = true;
						stop = true;
						btnWeiter.setText("Weiter");
						for(int x = 0; x< clocksRigth.length ; x++)
							clocksRigth[x].start();
						for(int x = 0; x< clocksLeft.length ; x++)
							clocksLeft[x].start();
						
					}
					
				}
				// Ruft die Zeichen Methode auf um die Uhren dazustellen
				repaint(); 
			}
		
	}
	
	private void printPosition( double  x , double y , int plus) // Zeigt die Y-Position eines Photons an
	{															 // Und fügt sie zur Liste hinzu um sie wieder zu finden
		JLabel f = new JLabel();
	    f.setFont(new Font( "Serif", Font.BOLD, 15 ) );
	    f.setText("Pos:" + y);
	    f.setBounds((int)x,(int)y + plus, 200, 44);
	    f.setVisible(true);
		add(f); 
		positionLabel.add(f);
	}
	
	// Entfernt alle Textfelder mit Position.
	private  final void removePositions() // Löscht alles angezeigten Positionen auf dem Bildschirm
	{
		for (int i = positionLabel.size() -1 ; i >= 0 ; i--)
		{
			remove(positionLabel.get(i));
			positionLabel.remove(i);
		}
	}
	
	private final void restart()
	{
		removePositions();
		if(syncLeft != null)
			syncLeft.reset();
		if(syncRigth != null)
			syncRigth.reset();
		systemStopLeft = false;
		systemStopRigth = false;
		isSystemStoped = false;
	}
	
	
	
	// wird von repaint aufgerufen
	public final void paint (Graphics g)
	{		
		super.paint(g);
		Graphics2D g2d = (Graphics2D) g;	
		
		// System A
		for(int x = 0; x< clocksLeft.length ; x++)
		{
			//Photon
			g2d.drawImage( clocksLeft[x].getImg()  , (int) (clocksLeft[x].getx())-clocksLeft[x].getImg().getWidth()/2  , (int) (clocksLeft[x].gety()) ,null);
			// Bild wird um clocksLeft[x].getImg().getWidth()/2 also die halbe  
			// breite des Bildes des Photons nach Links verschoben.
			// Da die x Position des Bildes sonst der Linke Rand und nicht die
			// Mitte wäre
			
			
			
			// Oberer Spiegel
			g2d.drawImage( spigel , (int) (clocksLeft[x].getx()) - spigel.getWidth()/2, 0 ,null);
			// Unterer Spiegel
			g2d.drawImage( spigel , (int) (clocksLeft[x].getx()) - spigel.getWidth()/2 , clocksLeft[x].getLength() + spigel.getHeight() +clocksLeft[x].getImg().getHeight()/2 ,null);
		
		
		}
		
		int l = clocksLeft[0].getLength() + spigel.getHeight() *4; // System b wird Um l Pixel nach Unten verschoben.
		
		
		// System B
		for(int x = 0; x< clocksRigth.length ; x++)
		{
			//Photon
			g2d.drawImage( clocksRigth[x].getImg()  , (int) (clocksRigth[x].getx())-clocksRigth[x].getImg().getWidth()/2  , (int) (clocksRigth[x].gety()) + l,null);
			// Oberer Spiegel
			g2d.drawImage( spigel , (int) (clocksRigth[x].getx()) - spigel.getWidth()/2, l ,null);
			// Unterer Spiegel
			g2d.drawImage( spigel , (int) (clocksRigth[x].getx()) - spigel.getWidth()/2 , clocksLeft[x].getLength() + l + clocksRigth[x].getImg().getWidth() ,null);
					
		}
		// Zeichnet die Lichtsignale
		if(syncLeft.isVisible())
		{
			g2d.draw(syncLeft.getShape());
		}
		if(syncRigth.isVisible())
		{
			g2d.draw(syncRigth.getShape());
		}
	}   
}



