/*
    !program name: Hassan_ihsan_tempconverter
    *purpose: converts the temps
    *programmer: hassan Ihsan
    *date 4/21/2020
*/

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;


import  java.awt.event.KeyAdapter;


public class Hassan_ihsan_TempConverter extends JFrame
{

    //neded values
    JLabel spce;
    JTextField field1, field2, field3;
    JButton clearbutton, calcButton;
    
    //main method opens the frame
    public static void main(String[] args)
    {
        new Hassan_ihsan_TempConverter();
    }

    //the frame with panels
    public Hassan_ihsan_TempConverter()
    {
        super("hassan ihsans temperature converter");

        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setSize(400,200);
        this.setLocationRelativeTo(null);
        
        this.setLayout(new BorderLayout());
        
        buildpanels();
        
        this.pack();

        this.setVisible(true);
    }

    public void buildpanels()
    {
        JLabel title = new JLabel("enter a tenoerature in any field and ten press the calculate button");
        title.setHorizontalAlignment(SwingConstants.CENTER);
        this.add(title, BorderLayout.NORTH);
        title.setBackground(Color.BLUE);


       	//build three panels for left, right, center
		JPanel leftPnl = new JPanel();
		leftPnl.setLayout(new GridLayout(5,0));
		this.add(leftPnl, BorderLayout.WEST);
		
		JPanel centerPnl = new JPanel();
		centerPnl.setLayout(new GridLayout(5,1));
	    this.add(centerPnl, BorderLayout.CENTER);
		
		JPanel rightPnl = new JPanel();
		rightPnl.setLayout(new GridLayout(3,1));
        this.add(rightPnl, BorderLayout.EAST);
        rightPnl.setBackground(Color.CYAN);

        //adding to panels
        //note the spce labes is to add space between values
        JLabel frache = new JLabel("Fahrenheit Temp:");
        leftPnl.add(frache);
        spce = new JLabel();
        leftPnl.add(spce);
        JLabel cels = new JLabel("Celsius Temp:");
        leftPnl.add(cels);
        spce = new JLabel();
        leftPnl.add(spce);
        JLabel kelventemp = new JLabel("Kelvin Temp");
        leftPnl.add(kelventemp);
        
        //central penal
        field1 = new JTextField();
        centerPnl.add(field1);
        spce = new JLabel();
        centerPnl.add(spce);
         field2 = new JTextField();
        centerPnl.add(field2);
        spce = new JLabel();
        centerPnl.add(spce);
         field3 = new JTextField();
        centerPnl.add(field3);

        //right panel
         clearbutton = new JButton("clear");
        rightPnl.add(clearbutton);
         spce = new JLabel();
        rightPnl.add(spce);
         calcButton = new JButton("Calculate");
        rightPnl.add(calcButton);
          
        //sending buttons to innerclass
        calcButton.addActionListener(new cals());
        clearbutton.addActionListener(new cals());

    }

    //innner class
    public class cals implements Hassan_ihsan_TempConvertable,  ActionListener 
    {

        double fra, cels, kel;
        

        //actopm ;ostmer
        public void actionPerformed(ActionEvent e)
        {
            //buttons
            if(e.getSource() == calcButton)
            {
                fra = Double.parseDouble(field1.getText());
                cels = Double.parseDouble(field2.getText());
                kel = Double.parseDouble(field3.getText());
   
                //validation maybe u wanted exceptions?
                if(fra < ABS_ZERO_F)
                {
                    field1.setText("This value is below avsolutezero.. plase re-enter" + ABS_ZERO_F);
                   
                }
                else if(cels < ABS_ZERO_C)
                {
                    field2.setText("This value is below avsolute zero.. plase re-enter" + ABS_ZERO_C);
                   
                }
                else if(kel < ABS_ZERO_K)
                {
                    field3.setText("This value is below avsolutezero.. plase re-enter" + ABS_ZERO_K);
                  
                }
                else
                {
                    //i didn't know whihc ones u wanted
                    //calculating c to f
                    double  c  = convertCtoF(fra);
                    field2.setText(Double. toString(c));
           
                    //f to c
                    double f = convertFtoC(fra);
                    field1.setText(Double.toString(f));
       
                    //k to c
                    double k = convertKtoC(kel);
                    field3.setText(Double.toString(k));
    
                }

            }
            else if(e.getSource() == clearbutton)
            {
                field1.setText(" ");
                field2.setText(" ");
                field3.setText(" ");
            }

            
            
        }


        //methods from interface
        public  double convertFtoC(double fTemp)
        {
            double fratocel =  5 / 9 * (fTemp - 32);
            return fratocel;
        }
        public  double convertCtoF(double cTemp)
        {
            double celtofra = 9 / 5 * cTemp + 32;
            return celtofra;
        }
        public  double convertCtoK(double cTemp)
        {
            double celstokel = cTemp + 273.15;
            return celstokel;
        }
        public  double convertKtoC(double kTemp)
        {
            double keltocel = kTemp - 273.15;
            return keltocel;
        }

         public  double convertFtoK(double FTemp)
        {
            double ftocel = convertFtoC(FTemp);
            double csltokel = convertCtoK(ftocel);
            return csltokel;
        }
        public  double convertKtoF(double kTemp)
        {
            double ketotcel =   convertKtoC(kTemp);
            double celtofra = convertCtoF( ketotcel);
            return celtofra;
        }
    }
}
