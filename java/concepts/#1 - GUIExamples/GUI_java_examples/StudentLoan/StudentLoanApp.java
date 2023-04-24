/*
!program name: StudentloanApp
*purpose: this is the gui of the program
*programmer: hassan 

NOTE this is really sloppy code.

*/


import java.util.ArrayList;

import java.awt.*;
import javax.swing.*;
import  java.awt.event.KeyAdapter;

import java.awt.event.*;

public  class StudentLoanApp extends JFrame  implements ActionListener
{
    double intrates;
    JPanel rightpanel;
    JPanel buttonpanel;
    JTextField  aramortizationperoid;
    JLabel studentIDlabel;
    JList title;
    JLabel first, sur, middle, studentidd, cslamout, oslamout;
    private JButton [] buttons;
    JTextField firstName , surName , middleName, aptnumber,streetnum, streetname, City, Province, postalCode , studentID, cslLOANAmount, oslLOANAmount;
  
    JButton button;
    double pcsl;
    double posl;

    ArrayList<Student> student = new ArrayList<Student>();

    public static void main(String[] args)
    {
        new StudentLoanApp();
        
    }

    StudentLoanApp()
    {
        super("loan calcutlator");
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setSize(800, 600);
        this.setLocationRelativeTo(null);
        this.setLayout(new GridLayout(1,1));
        this.setResizable(false);
        this.setVisible(true);

       
  
    buildListPanel();

    
    
    add(rightpanel);
    add(buttonpanel);
    
    }

    public void buildListPanel()
    {
         rightpanel = new JPanel();
        String [] data = {"This is hassan's student loan calculator"};
        String[] petStrings = { "4.25", "4.50", "" };

        JComboBox petList = new JComboBox(petStrings);
        petList.setSelectedIndex(2);
        petList.addActionListener(this);

        title = new JList(data);
    
        

        title.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);

        buttonpanel = new JPanel();

        button = new JButton("submit");

        buttons = new JButton[1];		
  
        for (int x = 0; x < buttons.length; x++)
        {
            buttons[x] = new JButton(""+ x);
            
        }	
               
        for(int x = 0; x < buttons.length; x++)
        {
            buttons[x].addActionListener(new ButtonHandler());		
             button.addActionListener(new ButtonHandler());
        }
             

        first = new JLabel("fullname");
        studentidd = new JLabel("#######");
        cslamout = new JLabel("0");
        oslamout = new JLabel("0");
      //  rightpanel.setLayout(new GridLayout(1,1));
        rightpanel.setLayout(new GridLayout(11, 0));
       // rightpanel.add(title);
        //rightpanel.add(first);
        //rightpanel.add(studentidd);
        //rightpanel.add(cslamout);
        //rightpanel.add(oslamout);

        JPanel leftPanel = new JPanel();
        leftPanel.setLayout(new GridLayout(2,0));
        this.add(leftPanel);
    
        leftPanel.setBorder(BorderFactory.createTitledBorder(
        BorderFactory.createEtchedBorder(), "loan calculator"));

        //These break the left panel into to halves
        JPanel topPanel = new JPanel();
        JPanel bottomPanel = new JPanel();
    
        topPanel.setLayout(new GridLayout(11,0));
        bottomPanel.setLayout(new GridLayout(11, 0));
        leftPanel.add(topPanel);
        leftPanel.add(bottomPanel);
    
        firstName = new JTextField();
        surName = new JTextField();
        middleName = new JTextField();
        aptnumber = new JTextField();
        streetnum = new JTextField();
        streetname = new JTextField();
        City = new JTextField(); 
        Province = new JTextField(); 
        postalCode = new JTextField();
        studentID = new JTextField();
        cslLOANAmount = new JTextField();
        oslLOANAmount = new JTextField();

        aramortizationperoid = new JTextField();
    
        JLabel firstLabel = new JLabel("First name: ");
        JLabel middleLabel = new JLabel("middle name: ");
        JLabel surLabel = new JLabel("Last name: ");
             studentIDlabel = new JLabel("StudentID:  ");
        JLabel aptLabel = new JLabel("aptNumber: ");
        JLabel streetnamelable = new JLabel("street Name: ");
        JLabel cityLable = new JLabel("City: ");
        JLabel provinceLable = new JLabel("province: ");
        JLabel postalLable = new JLabel("postal code: ");

        JLabel cslLoanAmountlabel = new JLabel("cslLoanAmount: ");
        JLabel oslLoanAmountlabel = new JLabel("oslLoanAmount: ");

        JLabel namelabel = new JLabel("Name: ");
        JLabel studendid = new JLabel("StudentID: ");
        JLabel csl = new JLabel("cslLoanAmount: ");
        JLabel osl = new JLabel("oslLoanAmount: ");

        JLabel aramortizationperoidlabel = new JLabel("amortization peorid: (in months) ");
        JLabel percentage = new JLabel("annual percentage: ");
        

        rightpanel.add(title);
        rightpanel.add(namelabel);
        rightpanel.add(first);
        rightpanel.add(studendid);
        rightpanel.add(studentidd);
        rightpanel.add(csl);
        rightpanel.add(cslamout);
        rightpanel.add(osl);
        rightpanel.add(oslamout);
        rightpanel.add(button);
      

        topPanel.add(firstLabel);
        topPanel.add(firstName);
        topPanel.add(middleLabel);
        topPanel.add(middleName);
        topPanel.add(surLabel);
        topPanel.add(surName);   
        bottomPanel.add(studentIDlabel);
        bottomPanel.add(studentID);
        //bottomPanel.add(aptLabel);
        //bottomPanel.add(aptnumber); 
        //bottomPanel.add(postalLable);
        //bottomPanel.add(postalCode);

        //bottomPanel.add(streetnamelable);
        //bottomPanel.add(streetname);
        //bottomPanel.add(cityLable);
        //bottomPanel.add(City);
        //bottomPanel.add(provinceLable);
       // bottomPanel.add(Province);
        bottomPanel.add(cslLoanAmountlabel);
        bottomPanel.add(cslLOANAmount);
        bottomPanel.add(oslLoanAmountlabel);
        bottomPanel.add(oslLOANAmount);
        bottomPanel.add(aramortizationperoidlabel);
        //NOTE pls enter in months
        bottomPanel.add(aramortizationperoid);
        bottomPanel.add(percentage);
        bottomPanel.add(petList, BorderLayout.PAGE_START);
        //valudating student it
        studentID.addKeyListener(new KeyAdapter() {
            public void keyPressed(KeyEvent e) {                
               try
               {
                    int i = Integer.parseInt(studentID.getText());
                    studentidd.setText("");
               }
               catch(NumberFormatException e1)
               {
                    studentidd.setText("make sure id is a number");
               }
            }        
         });
        
    }
    public void actionPerformed(ActionEvent e) {
        JComboBox cb = (JComboBox)e.getSource();
        //String intrate = (String)cb.getSelectedItem();
         intrates = Double.parseDouble((String)cb.getSelectedItem());
         System.out.println(intrates);
    }
   

    private class ButtonHandler extends JFrame  implements ActionListener
    {
        
        public void actionPerformed(ActionEvent e)
        {
            if(e.getSource() == button)
            {
                 
                
              // System.out.println(student.toString());

                test();
               
                 

               //System.out.println("Button A was clicked");
                
            }
           
            //double intrates = Double.parseDouble((String)cb.getSelectedItem());
            System.out.println("helo");
            pcsl = 0;
            posl = 0;

            double cslamounts = Double.parseDouble(cslLOANAmount.getText());
           //double cslamounts = 2500.00;
            double oslamounts = Double.parseDouble(oslLOANAmount.getText());
            //double intrates = 0.005625;
            int aramortizationperoids = Integer.parseInt(aramortizationperoid.getText());
            //int aramortizationperoids = 60;
           //   result = Math.pow(2, nan); 
           //p = Math.pow(cslamounts * intrates * (1 + intrates) , aramortizationperoids ) / Math.pow((1 + intrates) - 1, aramortizationperoids) ;
           //p = Math.pow(aramortizationperoids , (cslamounts * intrates * (1 + intrates))) /  (1 + intrates) - 1;
           
           //hard coded the inters rate of 4.25 could not figure out how to get rate from combobox
           double intratecsl;
           double intrateosl;
           double intrestratecsl;
           double intrestratesol;

                intratecsl = 4.25 + 2.5;
                intrateosl = 4.25 + 1.0;
                intrestratecsl = intratecsl * 1 / 1200;
                intrestratesol = intrateosl * 1 / 1200;
                System.out.println(intrestratecsl);
                System.out.println(intrateosl);
         double  s;
         double x;
         double xx;
         double z;
         double ss;
         double sss;
         double ssss;

         double sz;
         double ssz;
         

         x =  (1 + intrestratecsl);
         xx =  (1 + intrestratesol);
         
         z = Math.pow(x, aramortizationperoids);
         
         s =   ((1 + intrestratecsl));
         sss =   ((1 + intrestratesol));
          
         ss = Math.pow(s, aramortizationperoids);
        ssss = Math.pow(sss, aramortizationperoids);

         sz = ss - 1;
         ssz = ssss - 1;

         pcsl = cslamounts * intrestratecsl * z / sz;
         posl = oslamounts * intrestratesol * z / ssz;

        // p = Math.pow(aramortizationperoids, x) / Math.pow(aramortizationperoids, s);
           System.out.println("ummm"+pcsl );
          // System.out.println("ummm"+x );
           
           //System.out.println(z);
           cslamout.setText(Double. toString(pcsl));
           oslamout.setText(Double.toString(posl));
           //System.out.println(s);
           //System.out.println(ss);
           //System.out.println(sz);


          // System.out.println("ummm"+s );

        }

        
        public void test()
        {
            //boilerplate code
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setSize(800, 400);
		this.setLocationRelativeTo(null);
		this.setVisible(true);
		this.setLayout(new FlowLayout());
		
        buildListPanel();
        }
        
        public void buildListPanel()
        {
            JLabel namelabel = new JLabel("Name: ");
            JLabel studendid = new JLabel("StudentID: ");
            JLabel csl = new JLabel("cslLoanAmount: ");
            JLabel osl = new JLabel("oslLoanAmount: ");
    
            JButton button = new JButton("calculate");
            button.addActionListener(this);

            JPanel rightPanel = new JPanel();
            rightPanel.setLayout(new GridLayout(11, 0));
            this.add(rightPanel);
            
            first = new JLabel("fullname");
            studentidd = new JLabel("#######");
            cslamout = new JLabel("0");
            oslamout = new JLabel("0");
    
            rightPanel.add(namelabel);
            rightPanel.add(first);
            rightPanel.add(studendid);
            rightPanel.add(studentidd);
            rightPanel.add(csl);
            rightPanel.add(cslamout);
            rightPanel.add(osl);
            rightPanel.add(oslamout);
            rightPanel.add(button);
    
           
                String name  = firstName.getText();
                String surname = surName.getText();
                String middlename = middleName.getText();
                String aptnum = "aptnumber.getText()";
                String steeet = "streetnum.getText()";
                String streetnam = "streetname.getText()";
                String city =" City.getText()";
                String province = "Province.getText()";
                String postalcode = "postalCode.getText()";

            
                String studentid = studentID.getText();
                double cslamount = Double.parseDouble(cslLOANAmount.getText());
                double oslamount = Double.parseDouble(oslLOANAmount.getText());
                
                
                Student sutdent1 = new Student(studentid, surname, middlename, name, aptnum, steeet, streetnam, city, province, postalcode, cslamount, oslamount);
                student.add(sutdent1);

                 first.setText(sutdent1.getfirstName() +" "+ sutdent1.getmiddleName()+" "+ sutdent1.getsurname());
                 studentidd.setText(sutdent1.getstudentID());
                 cslamout.setText(Double. toString(pcsl));
                 oslamout.setText(Double.toString(posl));
                System.out.println(student.toString());
        }

       
    }
  
    
}