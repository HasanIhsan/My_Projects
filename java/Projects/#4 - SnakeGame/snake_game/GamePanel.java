//FIle Name: GamePanel.java
//Purpose: holds majority of the logic and implementation for the game
//Programmer: Hiro (Hassan Ihsan)
//Date: N/A

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

import javax.swing.JPanel;
import javax.swing.Timer;

import java.awt.Graphics;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;
import java.util.Random;
import java.awt.FontMetrics;


public class GamePanel extends JPanel implements ActionListener 
{
    //the size of the JFrame
    static final int S_WIDTH = 600;  //SCREEN WIDTH
    static final int S_HEIGHT = 600; //SCREEN HEIGHT

    static final int UNIT_SIZE = 25; //grid size
    static final int GAME_UNITS = (S_WIDTH * S_HEIGHT) / UNIT_SIZE;
    
    //game delay used for next apple creation
    static final int DELAY = 75;  
    
    final int x[] = new int[GAME_UNITS];
    final int y[] = new int[GAME_UNITS];

    int B_Parts = 6; //body parts
    int A_eaten; //apples eaten
    int A_X; //apple x
    int A_Y; //apple y
    
    char direction = 'R';
    boolean running = false;
    Timer timer;
    Random random;

    GamePanel() 
    {
        random = new Random();
        this.setPreferredSize(new Dimension(S_WIDTH, S_HEIGHT));
        this.setBackground(Color.BLACK);
        this.setFocusable(true);
        this.addKeyListener(new myKeyAdapter());
        startGame();
    }

    //game start method
    public void startGame() 
    {
        newApple();
        running = true;
        timer = new Timer(DELAY, this);
        timer.start();
    }

    //painting the components onto the screen
    public void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        draw(g);
    }

    //draw method: draws the snake, gird, apple
    public void draw(Graphics g)
    {
        if(running) 
        {
            //drawing the grid
            for(int i = 0; i < S_HEIGHT / UNIT_SIZE; ++i)
            {
                g.drawLine(i * UNIT_SIZE, 0, i * UNIT_SIZE, S_HEIGHT);
                g.drawLine(0, i * UNIT_SIZE, S_WIDTH, i * UNIT_SIZE);
            }
    
            //drawing the apple
            g.setColor(Color.red);
            g.fillOval(A_X, A_Y, UNIT_SIZE, UNIT_SIZE);
    
            //drawing the snake
            for(int i = 0; i < B_Parts; ++i)
            {
                if(i == 0)
                {
                    //the head of snake
                    g.setColor(Color.green);
                    g.fillRect(x[i], y[i], UNIT_SIZE, UNIT_SIZE);
                }
                else
                {
                    //the body of snake
                    g.setColor(new Color(45, 180, 0));
                  //g.setColor(new Color(random.nextInt(255), random.nextInt(255), random.nextInt(255))); //rainbow snake
                    g.fillRect(x[i], y[i], UNIT_SIZE, UNIT_SIZE);
                }
            }

            // display score at top of screen
            g.setColor(Color.yellow);
            g.setFont(new Font("Ink Free", Font.BOLD, 30));
            FontMetrics metrics = getFontMetrics(g.getFont());
            g.drawString("Score: " + A_eaten, (S_WIDTH - metrics.stringWidth("Score: " + A_eaten)) /2, g.getFont().getSize());

        }
        else 
        {
            gameOver(g); //if game not running (if hit wall or snake bodu)
        }
        
    }

    //radomly create an apple anywhere on the grid
    public void newApple() 
    {
        A_X = random.nextInt((int)(S_WIDTH / UNIT_SIZE)) * UNIT_SIZE;
        A_Y = random.nextInt((int)(S_HEIGHT / UNIT_SIZE)) * UNIT_SIZE;
    }

    //movement
    public void move()
    {
        for(int i  = B_Parts; i > 0; --i)
        {
            x[i] = x[i  - 1];
            y[i] = y[i - 1];
        }

        switch(direction)
        {
            case 'U':
                y[0] = y[0] - UNIT_SIZE;
                break;
            case 'D':
                y[0] = y[0] + UNIT_SIZE;
                break;
            case 'L':
                x[0] = x[0] - UNIT_SIZE;
                break;
            case 'R':
                x[0] = x[0] + UNIT_SIZE;
                break;
        }
    }
    
    //check apple (if eathen or not)
    public void checkApple() 
    {
        //if eaten create a new apple
        if((x[0] == A_X) && (y[0] == A_Y))
        {
            B_Parts++;
            A_eaten++;
            newApple();
        }
    }

    //check snake collisions
    public void checkCOllisions()
    {
        //checks if head collides with body
        for(int i = B_Parts; i > 0; --i)
        {
            if((x[0] == x[i]) && (y[0] == y[i]))
            {
                running = false;
            }
        }

        //checks if head touches left border
        if(x[0] < 0)
        {
            running = false;
        }

        //checks if head touches right border
        if(x[0] > S_WIDTH)
        {
            running = false;
        }

        //check if head touches top border
        if(y[0] < 0)
        {
            running = false;
        }

        //check if head touches bottom border
        if(y[0] > S_HEIGHT)
        {
            running = false;
        }

        //stops timer if game over
        if(!running)
        {
            timer.stop();
        }
    }

    public void gameOver(Graphics g)
    {
        //disply score text  
        g.setColor(Color.blue);
        g.setFont(new Font("Ink Free", Font.BOLD, 30));
        FontMetrics metrics1 = getFontMetrics(g.getFont());
        g.drawString("Score: " + A_eaten, (S_WIDTH - metrics1.stringWidth("Score: " + A_eaten)) /2, S_HEIGHT / 2 + 30);

        //display game over text
        g.setColor(Color.red);
        g.setFont(new Font("Ink Free", Font.BOLD, 75));
        FontMetrics metrics2 = getFontMetrics(g.getFont());
        g.drawString("Game Over", (S_WIDTH - metrics2.stringWidth("Game Over")) /2, S_HEIGHT / 2);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if(running)
        {
            move();
            checkApple();
            checkCOllisions();
        }
        repaint();
    }

    //user input for controls with arrow keys
    public class myKeyAdapter extends KeyAdapter 
    {
        @Override
        public void keyPressed(KeyEvent e)
        {
            switch(e.getKeyCode())
            {
                case KeyEvent.VK_LEFT:
                    if(direction != 'R')
                    {
                        direction = 'L';
                    }
                    break;
                case KeyEvent.VK_RIGHT:
                    if(direction != 'L')
                    {
                        direction = 'R';
                    }
                    break;
                case KeyEvent.VK_UP:
                    if(direction != 'D')
                    {
                        direction = 'U';
                    }
                    break;
                case KeyEvent.VK_DOWN:
                    if(direction != 'U')
                    {
                        direction = 'D';
                    }
                    break;
            }
        }

    }
}
