package Physiks;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class Keyboard implements KeyListener 
{
    private static final boolean[] keys = new boolean[512];
    private static final boolean[] keyPressed = new boolean[512];
    private static final boolean[] keyReleased = new boolean[512];
    
    public static boolean isKeyDown (int keyCode)
    {
        return keys[keyCode];
    }
    
    public static boolean keyPressed (int keyCode)
    {
    	boolean x = keyPressed[keyCode];
    	keyPressed[keyCode] = false;
        return x;
    }
    


    
    public static int getArrayLength (){
        return keys.length;
    }

    @Override
    public void keyTyped(KeyEvent e) {}

    @Override
    public void keyPressed(KeyEvent e) {
    	
        int keyCode = e.getKeyCode();
        
        keys[keyCode] = true;
        keyPressed[keyCode] = true;

    }

    @Override
    public void keyReleased(KeyEvent e) {
        int keyCode = e.getKeyCode();
        keys[keyCode] = false;
        keyPressed[keyCode] = false;
    }
    
}
