/*
 * Program Name: H_I_WorldLanguageViwer_Controller
 * Purpose: this is the controller for the world language 
 * Programmer: Hassan Ihsan
 * Date: 2022/08/05
 * */
//imports
import javax.swing.*;
import javax.swing.table.TableModel;
 

import java.awt.*;
import java.awt.event.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class H_I_WorldLanguageViwer_Controller extends JFrame {

	//variables
	private JTextField languageName = new JTextField(30);
	private JTextField precentOfPopulation = new JTextField(20);
	private JButton executeBtn = new JButton("Execute Query");
	
	//jdcb entry code to sql database
	Connection myConn = null;
	Statement myStmt = null;
	ResultSet myRslt = null;
	
	//object and string for connection
	PreparedStatement myPrepStmt = null;
	String URL = "jdbc:mysql://localhost:3306/world?useSSL=false&allowPublicKeyRetrieval=true";
	String user = "root";
	String password = "password";
	
	
	//viewer referece
	H_I_WorldLanguageViewer_Viewer viewer;
	
	public H_I_WorldLanguageViwer_Controller() throws HeadlessException
	{
		
		//frame name
		super("Hassan Ihsans World Lanuage Controller");
		
		//plate
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLayout(new BorderLayout());
		this.setSize(800, 250);
		this.setLocationRelativeTo(null);
		
		//panels and compoenents
		//main panel
		JPanel mainPanel = new JPanel();
		mainPanel.setLayout(new GridLayout(2,2));
		
		 //lanugage panel
		JPanel LanguagePanel = new JPanel(new GridLayout(1,2));
		LanguagePanel.add(new JLabel("Enter name of Language here>"));
		LanguagePanel.add(languageName ); 
		
		//percentage of popualtion panel
		JPanel percentageOfPopPanel = new JPanel(new GridLayout(1,2));
		percentageOfPopPanel.add(new JLabel("Enter percentage of population speaking it here>"));
		percentageOfPopPanel.add(precentOfPopulation); 
		
		//button panel
		JPanel ButtonPanel = new JPanel(new FlowLayout());
		ButtonPanel.add(executeBtn);
		
		mainPanel.add(LanguagePanel);
		mainPanel.add(percentageOfPopPanel);
		
		//listner
		Listener listener = new Listener();
		executeBtn.addActionListener(listener);
		
		this.add(mainPanel, BorderLayout.CENTER);
		this.add(ButtonPanel, BorderLayout.SOUTH);
		this.pack();
		//last line
		this.setVisible(true);
	}
	
	//listner class
	private class Listener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent ev)
		{
			//if user hits execute 
			if(ev.getActionCommand().equals("Execute Query")) 
			{
				//both language name and percentage of population is enterd
				if(languageName.getText().length() > 0 && precentOfPopulation.getText().length() > 0)
				{
					try {
						//connection
						myConn = DriverManager.getConnection(URL, user, password);
						
						
						//object query
						myPrepStmt = myConn.prepareStatement("SELECT country.name, country.population, countrylanguage.language, countrylanguage.percentage"
								+ " FROM country INNER JOIN countrylanguage ON country.code = countrylanguage.countrycode"
								+ " WHERE countrylanguage.language = ? AND countrylanguage.percentage >= ?");
			
						
						//assigne paratermer to '?' in query
						myPrepStmt.setString(1, languageName.getText());
						myPrepStmt.setDouble(2, Double.parseDouble(precentOfPopulation.getText()));
						
						//run query
						myRslt = myPrepStmt.executeQuery();
						
						//call dbuil method 
						TableModel model = DbUtils.resultSetToTableModel(myRslt);
						
						//pass model object to jtable
						if(viewer == null)
						{
							viewer = new H_I_WorldLanguageViewer_Viewer(model);
						} 
						else 
						{
							//just update the model used by the viewer
							viewer.table.setModel(model);
						}
							 
						
					}
					//exections
					catch(SQLException ex)
					{
						System.out.println("SQLException caught, message is: " + ex.getMessage());
						ex.printStackTrace();
					}
					catch(NumberFormatException ex)
					{
						//not a number aka double
						System.out.println("Number format exception, message is " + ex.getMessage());
						ex.printStackTrace();
						JOptionPane.showMessageDialog(null, "Enter numeric values for precentage of population");
					}
					catch(Exception ex)
					{
						System.out.println("Exception message is " + ex.getMessage());
						ex.printStackTrace();
					}
					finally
					{
						try
							{
								// closings
								if(myRslt != null)
									myRslt.close();
								if(myStmt != null)
									myStmt.close();
								if(myConn != null)
									myConn.close();
							}//end try
						catch(SQLException ex)
						{
							ex.printStackTrace();
						}
					}//end finally
				}
				else
				{
					// If lang  not typed
					if(languageName.getText().length() <= 0)
					{
						JOptionPane.showMessageDialog(null, "Please input Langauge.");
						languageName.requestFocus();
					}
					// If  percentage pop not typed
					else if(precentOfPopulation.getText().length() <= 0)
					{
						JOptionPane.showMessageDialog(null, "Please input Percentage of population.");
						precentOfPopulation.requestFocus();
					}
				}
			}
			 
		}//end action performed
	}//end listner
	
	//main method
	public static void main(String[] args)
	{
		new H_I_WorldLanguageViwer_Controller();
	}

}
