/*
    !programName: H_I_TheatreTickets
    *purpose: the purpose is to calculate the cost of tickets for adults childern and senior
    *programmer: hassan ihsan
    *date: 4/15/2020

*/ 

//?imports
import java.awt.*;
import javax.swing.*;
import  java.awt.event.KeyAdapter;

import java.awt.event.*;

//?class implemting jFrame
public class H_I_TheatreTickets extends JFrame 
{
    
    //?variables
    JLabel label1, label2, label3, totalcost, title;
    JTextArea area1, area2, area3, totalscosts;
    JButton button1, button2, button;
    JPanel panel, panel2;
    double adult,  children, Seniors;

    //?setting up JFrames
    H_I_TheatreTickets()
    {
        super("Bill's Tjeatre Toclets App");
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setSize(350, 250);
        this.setLocationRelativeTo(null);
        this.setLayout(new GridLayout(1,1));
        this.setResizable(false);
        this.setVisible(true);

        buildPanel();
        add(panel);
        
    }

    //?setting up panel could not get working (but everything seem correct)
    public void buildPanel()
    {
        panel. setBackground(Color.GREEN); 
        panel = new JPanel();
        title = new JLabel("enter # of tickets for each age group");

        
      
        button1 = new JButton("calculate");
        button2 = new JButton("clear");

        

        panel.setLayout(new GridLayout(11,1));
        
        label1 = new JLabel("# of adultss @ $9.75:");
        label2 = new JLabel("# of children @ $6.50:");
        label3 = new JLabel("# of Seniors @ $4.00:");
        totalcost = new JLabel("ticket cost: $");

        area1 = new JTextArea();
        area2 = new JTextArea();
        area3 = new JTextArea();
        totalscosts = new JTextArea();

        panel.add(title);
        panel.add(label1);
        panel.add(area1);
        panel.add(label2);
        panel.add(area2);
        panel.add(label3);
        panel.add(area3);
        panel.add(button1);
        panel.add(button2);

        //?action listner for buttons
        button1.addActionListener(new ActionListener(){  
            public void actionPerformed(ActionEvent e){  
                adult = 0;
                children = 0;
                Seniors = 0;

                 adult = Double.parseDouble(area1.getText());
                 children = Double.parseDouble(area2.getText());
                 Seniors = Double.parseDouble(area3.getText());

                double total = adult + children + Seniors;
                    totalscosts.setText(Double.toString(total));

                    System.out.println("totalCost: " + total);

            }  });  

            button2.addActionListener(new ActionListener(){  
                public void actionPerformed(ActionEvent e){  
                   area1.setText(" ");
                   area2.setText(" ");
                   area3.setText(" ");
    
                }  });  
    }

    //?starting the progra
    public static void main(String[] args)
    {
        new H_I_TheatreTickets();
    }
  
}