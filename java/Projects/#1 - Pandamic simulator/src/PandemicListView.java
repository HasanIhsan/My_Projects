
/**
 * Program Name: PandamicListView.java
 * Purpose:  show the information gotten from the simulation
 * Coder:
 * 
 
 */

//three wise men
import javax.swing.*;
import javax.swing.event.ListDataListener;

import java.awt.*;
import java.awt.event.*;

public class PandemicListView extends JFrame
{
	private static final long serialVersionUID = 1L;
	
	//for sizing purposes to size the JFrame
	private static final double FRAME_WIDTH_FACTOR = 0.25;
	private static final double FRAME_HEIGHT_FACTOR = 0.5;
	
	//listener related object needs to be here in CLASS SCOPE AREA 
	public JList<String> pandamicInfoList = new JList<String>();
	
	//constructor method..accepts a ListModel object
	public PandemicListView(ListModel<String> mod) throws HeadlessException
	{
		super("Pandamic simulator Information");
		//boilerplate		
			this.setDefaultCloseOperation(JFrame.HIDE_ON_CLOSE);			
			this.setLayout(new BorderLayout() );			
			//Variation: using the current dimensions of your screen resolution
			this.setSize(					
					(int)(this.getToolkit().getScreenSize().width * FRAME_WIDTH_FACTOR), 
					(int)(this.getToolkit().getScreenSize().height * FRAME_HEIGHT_FACTOR)					
					);
			
			this.setLocationRelativeTo(null);
			
			//add the JList component to the frame
			this.add(pandamicInfoList, BorderLayout.CENTER);
			
			//the magic line...assign the MODEL object to the shopping list			
			pandamicInfoList.setModel(mod);//mod is the parameter from the constructor
			
			//the last line
			this.setVisible(true);
	}//end constructor
	
	//temp main to see the controller GUI
	//REVISED: placed this code in the Controller class
	/*
	public static void main(String[] args)
	{
		new ShoppingListView(new DefaultListModel() );
	}
	*/
	
}
