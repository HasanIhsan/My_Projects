/*
 * Program Name: H_I_WorldLanguageViewer_Viewer
 * Purpose: this is the viewer for the world language 
 * Programmer: Hassan Ihsanr
 * Date: 2022/08/05
 * */

//viewer

//imports
import javax.swing.*;
import javax.swing.table.TableModel;
import java.awt.*;
import java.awt.event.*;

public class H_I_WorldLanguageViewer_Viewer extends JFrame {

	public JTable table = new JTable();
	
	public H_I_WorldLanguageViewer_Viewer(TableModel model)
	{
		//frame name
		super("Lanugages of the World");
		
		//plate
		this.setLayout(new BorderLayout() );
		this.setDefaultCloseOperation(JFrame.HIDE_ON_CLOSE);
		this.setSize(500,300);
		this.setLocationRelativeTo(null);
		
		//set mdoel to frame
		table.setModel(model);
		
		
		//is scrollable
		JScrollPane scrollPane = new JScrollPane(table);		
		this.add(scrollPane);
		 
		//isvisable
		this.setVisible(true);
	}
}
