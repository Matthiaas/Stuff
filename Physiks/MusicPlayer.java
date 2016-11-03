/**
    
    Author: Matthias Bun
	File: MusicPlayer.java
    Description: Too Lazy
 */   
package Physiks;

import java.io.IOException;

import javax.sound.sampled.AudioFormat;
import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;
import javax.sound.sampled.DataLine;
import javax.sound.sampled.FloatControl;
import javax.sound.sampled.LineUnavailableException;
import javax.sound.sampled.UnsupportedAudioFileException;

public  final class MusicPlayer {
	private static Clip clipM;

	public int  soundVolume = 100;
	public int  ContinuouslyVolume = 100;




	public void playContinuously(String name)
	{
		
		 try{
			 Thread thread;
				AudioInputStream audioInputStream = AudioSystem.getAudioInputStream(MusicPlayer.class.getResource(name));            
	         	clipM = AudioSystem.getClip();
	         	clipM.open(audioInputStream);
	        	thread = (new Thread (new Runnable() {
					public void run() {
		              	
		              	clipM.start();
		              	clipM.loop(Clip.LOOP_CONTINUOUSLY);
		              	setSound(ContinuouslyVolume);
		              	try {
							Thread.sleep(9999999);
						} catch (InterruptedException e) {
						} 
		              	
		              	
		              	
					}
					
				}));
				thread.start();
	           
	        }catch(Exception e){ e.printStackTrace(); }
		 
		 
		
	}


	
	public void playSound(String name, int lengthInMillis)
	{

		Clip clip;
		AudioInputStream audioInputStream;
		try {
			audioInputStream = AudioSystem.getAudioInputStream(MusicPlayer.class.getResource(name));
		
	        AudioFormat af     = audioInputStream.getFormat();
	        int size      = (int) (af.getFrameSize() * audioInputStream.getFrameLength());
	        byte[] audio       = new byte[size];
	        DataLine.Info info      = new DataLine.Info(Clip.class, af, size);
	        audioInputStream.read(audio, 0, size);
	        
	        
		    clip = (Clip) AudioSystem.getLine(info);
		    clip.open(af, audio, 0, size);
		    FloatControl gainControl = 
		    	    (FloatControl) clip.getControl(FloatControl.Type.MASTER_GAIN);
		    float volume = (float)(soundVolume );
		    volume = volume / 2;
		    volume = volume -44;
		    gainControl.setValue(volume);	
		    clip.start();
		    new Thread(()->{
		    	try {
		    		
					Thread.sleep(lengthInMillis);
				} catch (Exception e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
		    	clip.close();
		    });
            	
		} catch (UnsupportedAudioFileException | IOException | LineUnavailableException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		 
	}
	

	public void setSound (int x)
	{
		ContinuouslyVolume = x;
		float volume = (float)(x);
		volume = volume / 2;
        volume = volume -44;
		FloatControl gainControl = 
        	    (FloatControl) clipM.getControl(FloatControl.Type.MASTER_GAIN);
        	gainControl.setValue(volume);
		
	}
}
     