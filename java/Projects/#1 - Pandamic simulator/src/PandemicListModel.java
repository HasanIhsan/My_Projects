
/**
 * Program Name: PandamicListModel.java
 * Purpose: here we are breaking out the "model" portion of the application
 *          from the "controller" portion. 
 *          This will be a custom implementation of the ListModel interface
 *          methods that are required for the JList object knows how
 *          to register its listener for the underlying list model.
 *          
 *          This class also includes methods addElement() and removeElement()
 *          so that the controller can manipulate data held in the model.
 
 */
import javax.swing.*;
import javax.swing.event.ListDataEvent;
import javax.swing.event.ListDataListener;

import java.awt.*;
import java.awt.event.*;
import java.util.ArrayList;

public class PandemicListModel implements ListModel<String>
{
	//DATA MEMBERS...implement a private inner class here
	private class Row
	{
		//data members
		public String item;
		public String itemDesc;
		public double number; 
	}//end inner class
	
	//CLASS WIDE SCOPE AREA
	//need an ArrayList to hold the Row objects
	private ArrayList<Row> itemsArrayList = new ArrayList<Row>();
	
	//second arrayList to hold data listeners
	private ArrayList<ListDataListener> dataListenerList = new ArrayList<ListDataListener>();
	
	//FULFILL THE CONTRACT: implement the methods of the ListModel interface so that the JList
	// will be able to display the data that is held in the model
	
	/*
	 * Method Name: getSize()
	 * Purpose: tells JList how many ArrayList items are to be displayed in the GUI
	 * Accepts: nothing
	 * Returns: an int that is the size of the itemsArrayList object.
	 */
	@Override
	public int getSize()
	{
		// this method informs the JList how many ArrayList items are to be displayed		
		return itemsArrayList.size();
	}

	/*
	 * Method Name: getElementAt()
	 * Purpose: retrieves a Row object from the ArrayList and creates 
	 *          a StringBuilder object from the data values of the Row object.
	 *          The StringBuilder object is then converted to a String and returned
	 * Accepts: an int representing the index number of the row desired
	 * Returns: a String object representation of the values in the Row object,
	 *          which can then be displayed in the JList.
	 */
	@Override	
	public String getElementAt(int index)
	{		
		if(index < itemsArrayList.size())
		{
			Row row = itemsArrayList.get(index);
			
			//now append each data member of the row object to a StringBuilder object
			StringBuilder itemsArrayListString = new StringBuilder();
			
			if(row.number >0)//no sense appending a zero
			{
				itemsArrayListString.append(row.number + " x ");
			}
			itemsArrayListString.append(row.itemDesc + " ");
			itemsArrayListString.append(row.item + " ");
			
		 
			
			 
			//now convert the StringBuilder object to a String object so that it can 
			// be stored in the JList, which is set up for just Strings
			return itemsArrayListString.toString(); 
					
		}//end outer if		
		
		return null;//leave this here in case an if statement fails above.
	}
	
	/*
	 * Method Name: addListDataListener()
	 * Purpose: allows the JList view to register its ListDataListener
	 *          with the Model object so that if a change occurs in the
	 *          model, the JList will be able to adjust what is displayed.
	 * Accepts: an object of type ListDataListener
	 * Returns: NOTHING! Void method.
	 */
	@Override
	public void addListDataListener(ListDataListener listener)
	{
		// register it
		dataListenerList.add(listener);		
	}//end method

	@Override
	public void removeListDataListener(ListDataListener listener)
	{
		// if there is a listener,remove it
		if(dataListenerList.contains(listener) )
		{
			dataListenerList.remove(listener);
		}
	}//end method

	/*
	 * Method Name; addElement()
	 * Purpose: creates a Row object from submitted arguments
	 * Accepts: a double and three Strings that are read in from
	 *          the JTextFields in the ShoppingList2Controller class GUI.
	 * Returns: NOTHING! Void method. 
	 */
	public synchronized void addElement(double number, String ItemDesc, String item)
	{
		//CREATE a new Row object
		Row row = new Row();
		row.item = item;
		row.itemDesc = ItemDesc;
		row.number = number;
		 
		//add the Row object to the ArrayList
		itemsArrayList.add(row);
		
		//call the processEvent() method and pass it a new ListDataEvent  
		//object indicating that the contents of the list have been changed.
		processEvent (new ListDataEvent(this, ListDataEvent.CONTENTS_CHANGED,0,0) );
		
	}//end method
	
	/*
	 * Method Name: removeElement()
	 * Purpose: removes a Row object from the arrayList
	 * Accepts: an int that is the index number of the Row object 
	 *          to be removed.
	 * Returns: NOTHING! Void method. 
	 */
	public synchronized void removeElement(int index)
	{
		if(index < itemsArrayList.size() )
		{
			itemsArrayList.remove(index);
		}
		//call the processEvent() method and pass it a ListDataEvent indicating 
		// that the contents of the list have been changed. 
		processEvent (new ListDataEvent(this, ListDataEvent.CONTENTS_CHANGED,0,0) );
		
	}//end method
	
	/*
	 * Method Name: processEvent()
	 * Purpose: this method signals any open view objects that the underlying model
	 *          state has changed, so the view to the user must be updated.
	 * Accepts: a ListDataEvent object generated by the addElement() or removeElement()
	 *          methods.
	 * Returns: NOTHING! Void method 
	 */
	private void processEvent(ListDataEvent ev)
	{
		synchronized(this)//prevents data corruption if multiple threads try to access the arrayList
		{
			//cycle through the list of listeners so that they all get the message
			// and let them know that a list changed event has occured.
			for(int i = 0; i < dataListenerList.size(); i++)
			{
				dataListenerList.get(i).contentsChanged(ev);
			}//end for
		}//end synchronized block
	}//end method
		
}//end class
