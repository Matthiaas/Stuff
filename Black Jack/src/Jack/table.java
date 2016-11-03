package Jack;

import java.awt.Color;
import java.awt.EventQueue;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JButton;
import javax.swing.JRadioButton;

import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class table {

	private JFrame frame;
	private JLabel me_1,me_2,me_3,me_4,me_5,me_6;
	private JLabel midLeft_1,midLeft_2,midLeft_3,midLeft_4,midLeft_5,midLeft_6;
	private JLabel midrigth_1,midrigth_2,midrigth_3,midrigth_4,midrigth_5,midrigth_6;
	private JLabel rigth_1,rigth_2,rigth_3,rigth_4,rigth_5,rigth_6;
	private JLabel left_1,left_2,left_3,left_4,left_5,left_6;
	private JLabel dealer_1,dealer_2,dealer_3,dealer_4,dealer_5,dealer_6;
	private JLabel[]  nums;
	
	private JLabel rigthn,midrigthn,men,leftn,midLeftn,dealern;
	private JButton btnPlay;
	private JButton btnAdd;
	private JButton btnStay;
	
	private int[] me = new int[6]; 
	private int[] midLeft = new int[6]; 
	private int[] midrigth = new int[6]; 
	private int[] rigth = new int[6]; 
	private int[] left = new int[6]; 
	private int[] dealer = new int[6]; 
	private boolean isGiving ,isPlaying , lStay,rStay ,mlStay,mrStay ,meStay , isCleared = true;
	
	//isGiving = isPlaying = lStay =rStay =mlStay = mrStay =meStay = false;
	
	private Card[] cards;
	private JButton bett,casht;
	private int card = 1;
	private String dealerPath;
	private int bet, cash = 10000;
	private JButton btnClear;
	private JButton btnInsure;
	private JLabel lblText;
	

	
	public static void main(String[] args) {
		
		
		
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					table window = new table();
					window.frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public table() {
		deckErstellen();
		initialize();
		
		
		
		
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frame = new JFrame();
		frame.setBounds(100, 100, 661, 408);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		// 1
		JButton button = new JButton("");
		button.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				repaint(1);
			}
		});
		button.setBounds(10, 294, 27, 23);
		button.setOpaque(false);
		button.setBackground(new Color(0,0,0,0));
		button.setBorder(null);
		button.setContentAreaFilled(false);
		frame.getContentPane().add(button);
		
		
		// 5
		JButton button_1 = new JButton("");
		button_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				repaint(5);
			}
		});
		button_1.setBounds(53, 294, 27, 23);
		button_1.setOpaque(false);
		button_1.setBackground(new Color(0,0,0,1));
		button_1.setBorder(null);
		button_1.setContentAreaFilled(false);
		frame.getContentPane().add(button_1);
		
		//25
		JButton button_2 = new JButton("");
		button_2.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				repaint(25);
			}
		});
		button_2.setBounds(10, 335, 27, 23);
		button_2.setOpaque(false);
		button_2.setBackground(new Color(0,0,0,0));
		button_2.setBorder(null);
		button_2.setContentAreaFilled(false);
		frame.getContentPane().add(button_2);
		
		//100
		JButton button_3 = new JButton("");
		button_3.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				repaint(100);
			}
		});
		button_3.setBounds(53, 335, 27, 23);
		button_3.setOpaque(false);
		button_3.setBackground(new Color(0,0,0,1));
		button_3.setBorder(null);
		button_3.setContentAreaFilled(false);
		frame.getContentPane().add(button_3);
		
		//500
		JButton button_4 = new JButton("");
		button_4.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				repaint(500);
			}
		});
		button_4.setBounds(91, 335, 27, 23);
		button_4.setOpaque(false);
		button_4.setBorder(null);
		button_4.setBackground(new Color(0,0,0,1));
		
		button_4.setContentAreaFilled(false);
		frame.getContentPane().add(button_4);
		
		
		
		JRadioButton radioButton = new JRadioButton("");
		radioButton.setBounds(63, 188, 27, 31);
		radioButton.setBackground(new Color(0,0,0,1));
		radioButton.setContentAreaFilled(false);
		frame.getContentPane().add(radioButton);
		
		JRadioButton radioButton_1 = new JRadioButton("");
		radioButton_1.setBackground(new Color(0, 0, 0, 1));
		radioButton_1.setBounds(172, 257, 27, 31);
		radioButton_1.setContentAreaFilled(false);
		frame.getContentPane().add(radioButton_1);
		
		JRadioButton radioButton_2 = new JRadioButton("");
		radioButton_2.setBackground(new Color(0, 0, 0, 1));
		radioButton_2.setBounds(300, 280, 36, 31);
		radioButton_2.setContentAreaFilled(false);
		frame.getContentPane().add(radioButton_2);
		
		JRadioButton radioButton_3 = new JRadioButton("");
		radioButton_3.setBackground(new Color(0, 0, 0, 1));
		radioButton_3.setBounds(438, 257, 27, 31);
		radioButton_3.setContentAreaFilled(false);
		frame.getContentPane().add(radioButton_3);
		
		JRadioButton radioButton_4 = new JRadioButton("");
		radioButton_4.setBackground(new Color(0, 0, 0, 1));
		radioButton_4.setBounds(540, 188, 27, 31);
		radioButton_4.setContentAreaFilled(false);
		frame.getContentPane().add(radioButton_4);

		//left
		
		left_1 = new JLabel();
		left_1.setBounds(42, 124, 113, 108);
		frame.getContentPane().add(left_1);
		left_2 = new JLabel();
		left_2.setBounds(44, 134, 113, 108);
		frame.getContentPane().add(left_2);
		left_3 = new JLabel();
		left_3.setBounds(46, 144, 113, 108);
		frame.getContentPane().add(left_3);
		left_4 = new JLabel();
		left_4.setBounds(48, 154, 113, 108);
		frame.getContentPane().add(left_4);
		left_5 = new JLabel();
		left_5.setBounds(50, 164, 113, 108);
		frame.getContentPane().add(left_5);
		left_6 = new JLabel();
		left_6.setBounds(52, 174, 113, 108);
		frame.getContentPane().add(left_6);
		
		//rigth
		rigth_1 = new JLabel();
		rigth_1.setBounds(475, 124, 113, 108);
		frame.getContentPane().add(rigth_1);
		rigth_2 = new JLabel();
		rigth_2.setBounds(488, 124, 113, 108);
		frame.getContentPane().add(rigth_2);
		rigth_3 = new JLabel();
		rigth_3.setBounds(506, 124, 113, 108);
		frame.getContentPane().add(rigth_3);
		rigth_4 = new JLabel();
		rigth_4.setBounds(524, 124, 113, 108);
		frame.getContentPane().add(rigth_4);
		rigth_5 = new JLabel();
		rigth_5.setBounds(542, 124, 113, 108);
		frame.getContentPane().add(rigth_5);
		rigth_6 = new JLabel();
		rigth_6.setBounds(560, 124, 113, 108);
		frame.getContentPane().add(rigth_6);
		
		
		
		//midrigth
		midrigth_1 = new JLabel();
		midrigth_1.setBounds(396, 188, 113, 108);
		frame.getContentPane().add(midrigth_1);
		midrigth_2 = new JLabel();
		midrigth_2.setBounds(406, 198, 113, 108);
		frame.getContentPane().add(midrigth_2);
		midrigth_3 = new JLabel();
		midrigth_3.setBounds(416, 208, 113, 108);
		frame.getContentPane().add(midrigth_3);
		midrigth_4 = new JLabel();
		midrigth_4.setBounds(426, 218, 113, 108);
		frame.getContentPane().add(midrigth_4);
		midrigth_5 = new JLabel();
		midrigth_5.setBounds(436, 228, 113, 108);
		frame.getContentPane().add(midrigth_5);
		midrigth_6 = new JLabel();
		midrigth_6.setBounds(446, 238, 113, 108);
		frame.getContentPane().add(midrigth_6);
		
		//midLeft
		midLeft_1 = new JLabel();
		midLeft_1.setBounds(140, 188, 113, 108);
		frame.getContentPane().add(midLeft_1);
		midLeft_2= new JLabel();
		midLeft_2.setBounds(140, 198, 113, 108);
		frame.getContentPane().add(midLeft_2);
		midLeft_3= new JLabel();
		midLeft_3.setBounds(140, 208, 113, 108);
		frame.getContentPane().add(midLeft_3);
		midLeft_4= new JLabel();
		midLeft_4.setBounds(140, 218, 113, 108);
		frame.getContentPane().add(midLeft_4);
		midLeft_5= new JLabel();
		midLeft_5.setBounds(140, 228, 113, 108);
		frame.getContentPane().add(midLeft_5);
		midLeft_6= new JLabel();
		midLeft_6.setBounds(140, 238, 113, 108);
		frame.getContentPane().add(midLeft_6);
		
		
		
		//me
		me_1 = new JLabel();
		me_1.setBounds(282, 209, 113, 108);
		frame.getContentPane().add(me_1);
		me_2 = new JLabel();
		me_2.setBounds(287, 220, 113, 108);
		frame.getContentPane().add(me_2);
		me_3 = new JLabel();
		me_3.setBounds(293, 229, 113, 108);
		frame.getContentPane().add(me_3);
		me_4 = new JLabel();
		me_4.setBounds(298, 240, 113, 108);
		frame.getContentPane().add(me_4);
		me_5 = new JLabel();
		me_5.setBounds(305, 250, 113, 108);
		frame.getContentPane().add(me_5);
		me_6 = new JLabel();
		me_6.setBounds(313, 260, 113, 108);
		frame.getContentPane().add(me_6);
		
		//dealer 
		dealer_1 = new JLabel();
		dealer_1.setBounds(255, 43, 113, 108);
		frame.getContentPane().add(dealer_1);
		dealer_2 = new JLabel();
		dealer_2.setBounds(260, 52, 113, 108);
		frame.getContentPane().add(dealer_2);
		dealer_3 = new JLabel();
		dealer_3.setBounds(265, 61, 113, 108);
		frame.getContentPane().add(dealer_3);
		dealer_4 = new JLabel();
		dealer_4.setBounds(270, 70, 113, 108);
		frame.getContentPane().add(dealer_4);
		dealer_5 = new JLabel();
		dealer_5.setBounds(275, 79, 113, 108);
		frame.getContentPane().add(dealer_5);
		dealer_6 = new JLabel();
		dealer_6.setBounds(280, 88, 113, 108);
		frame.getContentPane().add(dealer_6);
		
		
		bett = new JButton();
		bett.setBackground(new Color(255, 69, 0));
		bett.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if(!isPlaying)
					clearBet ();
			}
		});
		bett.setBounds(10, 99, 76, 23);
		bett.setBorder(null);
		bett.setText(""+ bet);
		frame.getContentPane().add(bett);
		
		casht = new JButton();
		casht.setBackground(new Color(50, 205, 50));
		casht.setBounds(10, 54, 76, 23);
		casht.setBorder(null);
		casht.setText(""+ cash);
		frame.getContentPane().add(casht);
	
		
		btnPlay = new JButton("PLAY");
		btnPlay.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if(!isPlaying)
				try	{clear(); }catch(NullPointerException e1){}
				if (isCleared)
				{
					isCleared = false;
					kartenAusteilen();
				}
				
			}
		});
		btnPlay.setOpaque(false);
		btnPlay.setBackground(new Color(0,0,0,0));
		btnPlay.setBorder(null);
		btnPlay.setContentAreaFilled(false);
		btnPlay.setBounds(513, 68, 67, 45);
		frame.getContentPane().add(btnPlay);
		
		leftn = new JLabel("0");
		leftn.setBounds(125, 134, 46, 14);
		frame.getContentPane().add(leftn);
		
		midLeftn = new JLabel("0");
		midLeftn.setBounds(195, 183, 46, 14);
		frame.getContentPane().add(midLeftn);
		
		men = new JLabel("0");
		men.setBounds(290, 198, 46, 14);
		frame.getContentPane().add(men);
		
		midrigthn = new JLabel("0");
		midrigthn.setBounds(395, 183, 46, 14);
		frame.getContentPane().add(midrigthn);
		
		rigthn = new JLabel("0");
		rigthn.setBounds(475, 130, 46, 14);
		frame.getContentPane().add(rigthn);
		
		dealern = new JLabel("0");
		dealern.setBounds(214, 83, 46, 14);
		//dealern.setVisible(false);
		frame.getContentPane().add(dealern);
		
		btnAdd = new JButton("Add");
		btnAdd.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if(!isGiving && isPlaying )
				{
					btnInsure.setVisible(false);
					sleep(100);
					give("m");
					play(false);
				}
			}
		});
		btnAdd.setBounds(500, 327, 67, 31);
		frame.getContentPane().add(btnAdd);
		
		btnStay = new JButton("Stay");
		btnStay.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if(!isGiving && isPlaying)
				{
					btnInsure.setVisible(false);
					meStay = true;
					play(false);
				}
			}
		});
		btnStay.setBounds(569, 327, 68, 31);
		frame.getContentPane().add(btnStay);
		
		btnClear = new JButton("Clear");
		btnClear.setBackground(Color.RED);
		btnClear.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if(!isPlaying)
				clear();
			}
		});
		btnClear.setBounds(10, 10, 76, 23);
		frame.getContentPane().add(btnClear);
		
		btnInsure = new JButton("Insure");
		btnInsure.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				cash = cash - bet/2;
				
				isGiving = true;
				int var = card;
				card = cards[dealer[0]].getNum();
				give(dealer_2 , 0 );
				int ten = cards[card].getNum();
				card = var;
				if (ten == 10)
				{
					cash = cash + bet;
				}
			}
		});
		btnInsure.setForeground(new Color(0, 128, 0));
		btnInsure.setBackground(new Color(178, 34, 34));
		btnInsure.setBounds(276, 175, 76, 23);
		frame.getContentPane().add(btnInsure);
		btnInsure.setVisible(false);
		
		lblText = new JLabel();
		lblText.setForeground(new Color(255, 255, 0));
		lblText.setBounds(243, 8, 125, 27);
		frame.getContentPane().add(lblText);
		
		JLabel label = new JLabel();
		label.setIcon(new ImageIcon("media/Black-Jack-2003.png"));
		label.setBounds(0, 0, 658, 368);
		frame.getContentPane().add(label);
		
		
		
		
		
		
		
	}
	public void clear()
	{
		lblText.setText("");
		isCleared = true;
		me = new int[6]; 
		midLeft = new int[6]; 
		midrigth = new int[6]; 
		rigth = new int[6]; 
		left = new int[6]; 
		dealer = new int[6]; 
		isGiving = isPlaying = lStay = rStay = mlStay = mrStay  = meStay = false;
		JLabel[] x = ( new JLabel[]  { dealer_1,dealer_2,dealer_3,dealer_4,dealer_5,dealer_6 , me_1,me_2,me_3,me_4,me_5,me_6
				,left_1,left_2,left_3,left_4,left_5,left_6 , rigth_1,rigth_2,rigth_3,rigth_4,rigth_5,rigth_6
				,midrigth_1,midrigth_2,midrigth_3,midrigth_4,midrigth_5,midrigth_6,midLeft_1,midLeft_2,midLeft_3,midLeft_4,midLeft_5,midLeft_6} );
		
		for(int i = 0; i< x.length; i++)
		{
			x[i].setIcon(null);
		}
		for(int i = 0; i< nums.length; i++)
		{
			nums[i].setText("0");
		}
		dealern.setVisible(false);
		
	}
	
	public void removeCard( JLabel[] class1 )
	{
		for(int i = 0; i< class1.length; i++)
		{
			class1[i].setIcon(null);
		}
	}
	
	public void findWinner()
	{
		int dealerCount = Integer.parseInt(dealern.getText());
		if (( dealerCount < Integer.parseInt(men.getText()) || dealerCount > 21 ) && Integer.parseInt(men.getText()) <=21 )
		{
			cash = cash + bet*2;
			lblText.setText("You won: " + bet*2);
			bet = 0;
			
			
		}else if  ( dealerCount == Integer.parseInt(men.getText()) && dealerCount <= 21)
		{
			cash = cash + bet;
			lblText.setText("You won: " + bet);
			bet = 0;
		}else
		{
			bet = 0;
			lblText.setText("You lost: " + bet );
		}
		repaint(0);
		isPlaying = false;
		//Integer.parseInt(midrigthn.getText()); 
		//Integer.parseInt(rigthn.getText()); 
		//Integer.parseInt(dealern.getText()); 
		//Integer.parseInt(midLeftn.getText()); 
		//Integer.parseInt(leftn.getText());
	}
	public void unmark()
	{
		Color color = new Color(255, 127, 80);
		nums = new JLabel[] {leftn,midLeftn,	men ,	midrigthn ,	rigthn,	dealern};
		nums[0].setForeground(new Color(255, 127, 80));
		nums[1].setForeground(color);
		nums[2].setForeground(color);
		nums[3].setForeground(color);
		nums[4].setForeground(color);
	}
	public void mark(String z )
	{
		unmark();
		Color color =  new Color(124, 252, 0);
		
		switch (z)    
		{
			case "l":
				nums[0].setForeground(color);
				break;
			case "r":
				nums[4].setForeground(color);
				break;
			case "mr":
				nums[3].setForeground(color);
				break;
			case "ml":
				nums[1].setForeground(color);
				break;
			case "m":
				nums[2].setForeground(color);
				break;
		}
	}
	
	public void play(boolean left)
	{
		
		(new Thread (new Runnable() {
			public void run() {
				isGiving = true;
				if(meStay && lStay && rStay && mlStay && mrStay) 
				{
					dealer(true);
					return;
				}
				if (left)
				{
					if(!lStay)
					{
						mark("l");
						sleep(2000);
						KI("l");
					}
					if(!mlStay)
					{
						mark("ml");
						sleep(1500);
						KI("ml");
					}
					isGiving = false;
					if(meStay )
					{
						play(false);
					}else
					{
						mark("m");
					}
				}
				else
				{
					if(!mrStay)
					{
						mark("mr");
						sleep(1800);
						KI("mr");
					}
					if(!rStay)
					{
						mark("r");
						sleep(1500);
						KI("r");
						
					}
					play(true);
				}
				
			}
			
		})).start();
	}
	
	public void KI(String z)
	{
		JLabel l;
		l = leftn;
		boolean hasStoped = false ;
		switch (z)    
		{
			case "l":
				l = leftn;
				hasStoped = lStay;
				break;
			case "r":
				l = rigthn;
				hasStoped = rStay;
				break;
			case "mr":
				l = midrigthn;
				hasStoped = mrStay;
				break;
			case "ml":
				l = midLeftn; 
				hasStoped= mlStay;
				break;									
		}
		if(!hasStoped)
		{
			int have = Integer.parseInt(l.getText());
			if (have <=  11)
			{
				give(z);
			}
			if (have >  20)
			{
				hasStoped = true;
			}
			int ran = (int) (Math.random() * 100);
			switch(have)
			{
				case 12:
					if (ran > 12 ){give(z); } else{hasStoped = true;}
					break;
				case 13:
					if (ran > 20 ){give(z); } else{hasStoped = true;}
					break;
				case 14:
					if (ran > 40 ){give(z); } else{hasStoped = true;}
					break;
				case 15:
					if (ran > 50 ){give(z); } else{hasStoped = true;}
					break;
				case 16:
					if (ran > 60 ){give(z); } else{hasStoped = true;}
					break;
				case 17:
					if (ran > 75 ){give(z); } else{hasStoped = true;}
					break;
				case 18:
					if (ran > 90 ){give(z); } else{hasStoped = true;}
					break;
				case 19:
					if (ran > 95 ){give(z); } else{hasStoped = true;}
					break;
				case 20:
					if (ran > 98 ){give(z); } else{hasStoped = true;}
					break;
					
			}
			
			switch (z)    
			{
				case "l":
					lStay = hasStoped;
					break;
				case "r":
					rStay = hasStoped;
					break;
				case "mr":
					mrStay = hasStoped;
					break;
				case "ml":
					mlStay = hasStoped;
					break;									
			}
		}
		
	}
	
	public void dealer(boolean first)
	{
		if(first)
		{
			isGiving = true;			
			dealer_2.setIcon(new RotatedIcon(new ImageIcon(dealerPath), 0));
		}
		
		
		int have = Integer.parseInt(dealern.getText());
		dealern.setVisible(true);
		if(have <= 16)
		{
			(new Thread (new Runnable() {
				public void run() 
				{
					
					sleep(600);
					give("d");
					dealer(false);
				}
				
			})).start();
		}else
		{
			findWinner();
		}
	}
	
	public void repaint(int x)
	{
		if(!isPlaying){
			bet= bet + x;
			cash= cash- x;
			casht.setText(""+ cash);
			bett.setText(""+ bet);
		}
		
	}
	public void clearBet ()
	{
		if(!isPlaying)
		{
			int oldBet = Integer.parseInt(bett.getText());
			
			bet=0;
			cash= cash + oldBet;
			casht.setText(""+ cash);
			bett.setText("0");
		}
		
	}
	public void deckErstellen()
	{
		cards = new Card[208];

		for(int i = 0; i< 208; i++)
		{
			cards[i] = new Card(i );
		}
		
		
		for (int Z = 0; Z < 20; Z++) 
		{
			for (int i = 0; i < cards.length; i++) 
			{
				
			      int index = (int)(Math.random() * cards.length);
			      Card temp = cards[i];
			      cards[i] = cards[index];
			      cards[index] = temp;
			}
		}
		
		
		
		
	}
	public void kartenAusteilen()
	{
		if(!isPlaying)
		{
			(new Thread (new Runnable() {
				public void run() {
					isGiving = true;
					isPlaying = true;
					give("l");
					sleep(600);
					give("ml");
					sleep(600);
					give("m");
					sleep(600);
					give("mr");
					sleep(600);
					give("r");
					sleep(600);
					give("d");
					sleep(600);
					give("l");
					sleep(600);
					give("ml");
					sleep(600);
					give("m");
					sleep(600);
					give("mr");
					sleep(600);
					give("r");
					sleep(600);
					give("d");
					isGiving = false;
					play(true);
				
					
	
	
				}
				
			})).start();
		}
		
		
	}
	
	//rigth: -45 left: 45 midleft/rigth: 25 / -25
	public void give(JLabel x, double Angle)
	{
		if(Angle == 360)
		{
			x.setIcon(new ImageIcon("cards/back01.gif"));
			dealerPath = ("cards/" + cards[card].getPath());
		}else
		{
			x.setIcon(new RotatedIcon(new ImageIcon("cards/" + cards[card].getPath()), Angle));
	
		}
	}
	public int addCard (int[] f ,String z )
	{
		boolean unFound = true;
		
		for(int i = 0; i < f.length && unFound; i++)
		{	
			if(f[i] == 0 && unFound)
			{
				unFound = false;
				switch (z)
				{
					case "l":
						left[i] = card;
						setText(leftn ,cards[card].getNum());
						if ( (Integer.parseInt(leftn.getText()) )> 21 ) { lStay = true;}
						break;
					case "r":
						rigth[i] = card;
						setText(rigthn , cards[card].getNum());
						if ( (Integer.parseInt(rigthn.getText()) )> 21 ) { rStay = true;}
						break;
					case "m":
						me[i] = card;
						setText(men, cards[card].getNum());
						if ( (Integer.parseInt(men.getText()) )> 21 ) { meStay = true;}
						break;
					case "mr":
						midrigth[i] = card;
						setText(midrigthn , cards[card].getNum());
						
						if ( (Integer.parseInt(midrigthn.getText()) )> 21 ) { mrStay = true;}
						break;
					case "ml":
						midLeft[i] = card;
						setText(midLeftn , cards[card].getNum());
						if ( (Integer.parseInt(midLeftn.getText()) )> 21 ) { mlStay = true;}
						break;
					case "d":
						dealer[i] = card;
						setText(dealern , cards[card].getNum());
						break;
				}
				return i;
			}	
		}
		return 0;
	}
	 
	public void setText(JLabel l, int add)
	{
		int have = Integer.parseInt(l.getText());
		if(add == 11 && (add + have) > 21 )
		{
			add = 1;
		}
		l.setText( "" + (have + add));
		
	}
	
	
	
	public void give(String z)
	{
		int place;
		switch (z)
		{
			case "l":
				place =  addCard(left , z);
				switch (place)
				{
					case 0:
						give(left_1,45);
						break;
					case 1:
						give(left_2,45);
						break;
					case 2:
						give(left_3,45);
						break;
					case 3:
						give(left_4,45);
						break;
					case 4:
						give(left_5,45);
						break;
					case 5:
						give(left_6,45);
						break;
				}
				break;
			case "r":
				place =  addCard(rigth , z);
				switch (place)
				{
					case 0:
						give(rigth_1,-45);
						break;
					case 1:
						give(rigth_2,-45);
						break;
					case 2:
						give(rigth_3,-45);
						break;
					case 3:
						give(rigth_4,-45);
						break;
					case 4:
						give(rigth_5,-45);
						break;
					case 5:
						give(rigth_6,-45);
						break;
				}
				break;
			case "m":
				
				place =  addCard(me , z );
					switch (place)
					{
						case 0:
							give(me_1,0);
							break;
						case 1:
							give(me_2,0);
							break;
						case 2:
							give(me_3,0);
							break;
						case 3:
							give(me_4,0);
							break;
						case 4:
							give(me_5,0);
							break;
						case 5:
							give(me_6,0);
							break;
					}
			
				break;
			case "mr":
				
				place =  addCard(midrigth , z );
				switch (place)
				{
					case 0:
						give(midrigth_1,-25);
						break;
					case 1:
						give(midrigth_2,-25);
						break;
					case 2:
						give(midrigth_3,-25);
						break;
					case 3:
						give(midrigth_4,-25);
						break;
					case 4:
						give(midrigth_5,-25);
						break;
					case 5:
						give(midrigth_6,-25);
						break;
				}
				
				break;
			case "ml":
				
				place =  addCard(midLeft , z );
				switch (place)
				{
					case 0:
						give(midLeft_1,25);
						break;
					case 1:
						give(midLeft_2,25);
						break;
					case 2:
						give(midLeft_3,25);
						break;
					case 3:
						give(midLeft_4,25);
						break;
					case 4:
						give(midLeft_5,25);
						break;
					case 5:
						give(midLeft_6,25);
						break;
				}
				
				break;
				
			case "d":
				
				place =  addCard(dealer, z);
				
				switch (place)
				{
					case 0:
						give(dealer_2,360);
					break;
					
					case 1:
						give(dealer_1,0);
						if(dealer[1] == 11 )
						btnInsure.setVisible(true);
						
						break;
					
					case 2:
						give(dealer_3,0);
						break;
					case 3:
						give(dealer_4,0);
						break;
					case 4:
						give(dealer_5,0);
						break;
					case 5:
						give(dealer_6,0);
						break;
				}
				
				break;
		}
	}
	public void sleep(int sec)
	{
		try {
			Thread.sleep(sec);
			
		} catch (InterruptedException e) {
		}
		card++;
	}
}
