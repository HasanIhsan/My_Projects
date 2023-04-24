import javax.swing.*;
import javax.swing.event.ListSelectionEvent;

import java.awt.*;
import java.awt.event.*;

public class H_I_WaffleHouse extends JFrame 
{
  
    
    JPanel listPanel;
    JList title;
    JPanel checkBoxPanel;
    JPanel checkBoxPanel2;
    JPanel radioPanel;
    JButton button;
    JCheckBox box1, box2, box3, box4;

    H_I_WaffleHouse()
    {

        super("hassan Ihsan waffle hosue");
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setSize(400, 150);
        this.setLocationRelativeTo(null);
        this.setLayout(new GridLayout(1,1));
        this.setVisible(true);

        buildRadioPanel();
		buildListPanel();
        buildCheckBoxPanel();
       
		
		add(radioPanel);
		add(listPanel);
        add(checkBoxPanel);
        
    }
    public void buildListPanel()
	{
		listPanel = new JPanel();
        String [] data = {"Welcome to Hassans waffle House!"};
        //String [] waffles = {"waffles"};
        //String [] toppings = {"toppings"};
        //String [] coffechoice = {"coffie choice"};
		button = new JButton("Submit");	
        title = new JList(data);
    
		
		title.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
		
        listPanel.add(title);
        listPanel.add(button);
		
		
 
        }

        public void buildCheckBoxPanel()
	{
		checkBoxPanel = new JPanel();
		checkBoxPanel.setLayout(new GridLayout(4,1));
		
		box1 = new JCheckBox("Butter");
		box2 = new JCheckBox("Maple Syrup");
        box3 = new JCheckBox("Cherry");
        box4 = new JCheckBox("StrawBerries");
		
		
		
		checkBoxPanel.add(box1);
		checkBoxPanel.add(box2);
        checkBoxPanel.add(box3);
        checkBoxPanel.add(box4);
	}
        
        public void buildRadioPanel()
	{
		radioPanel = new JPanel();
		radioPanel.setLayout(new GridLayout(4,1));
		JRadioButton btn1, btn2, btn3, btn4;
		
		btn1 = new JRadioButton("belgian");
		btn2 = new JRadioButton("whole wheat");
		btn3 = new JRadioButton("Banana");
        btn4 = new JRadioButton("Straberry");
        
		ButtonGroup group1 = new ButtonGroup();
		group1.add(btn1);
		group1.add(btn2);
        group1.add(btn3);
        group1.add(btn4);
		
		 
        
        
		radioPanel.add(btn1);
		radioPanel.add(btn2);
        radioPanel.add(btn3);
        radioPanel.add(btn4);
       
    }
    
	
        public static void main(String[] args)
	{
		new H_I_WaffleHouse();
	}
   
}