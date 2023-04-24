//File Name: GameFrame.java
//purpose: creates the GUI Jframe for the game
//Programmer: Hiro (Hassan Ihsan)
//Date: N/A

import javax.swing.JFrame;

public class GameFrame extends JFrame 
{
    //default construtor holding the code to create a JFrame
    GameFrame()
    { 
        this.add(new GamePanel());
        this.setTitle("Snake_game");
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setResizable(false);
        this.pack();
        this.setVisible(true);
        this.setLocationRelativeTo(null);
    }
}