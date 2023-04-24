/**
	 * Class Name:	JTextAreaExample	
	 * Purpose:		This demonstrates how to write data to a JTextArea and JLabel. This program takes a first and last name as input from the user (from two textfields) and outputs the names to a jtextarea and jlabel.
	 * 				It also demonstrates how to use helper methods to create the GUI, instead of writing everything in the constructor
 
*/
import java.awt.*;
import javax.swing.*;
import java.awt.event.*;

public class JTextAreaExample extends JFrame{
	
	//I have to declare these outside of the constructor, since I use them in methods outside of the constructor. Anything that's declared in the constructor is only visible in the scope of the constructor.
	private JTextArea outputArea;
	private JTextField firstName, lastName;
	private JButton submit;
	private JPanel inputPanel, outputPanel;
	private JLabel outputLabel;
	
	JTextAreaExample()
	{
		super("Demo of text areas and labels");
		
		//buildInputPanel instantiates the inputPanel and all of its associated objects. buildOutputPanel does the same with the outputPanel and its associated objects.
		buildInputPanel();
		buildOutputPanel();
		
		//this is equivalent to this.add(inputPanel) and this.add(outputPanel)
		add(inputPanel);
		add(outputPanel);
		
		//boilerplate code
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setSize(800, 400);
		this.setLocationRelativeTo(null);
		this.setVisible(true);
		this.setLayout(new GridLayout(2,1));
	}
	
	public void buildInputPanel()
	{
		inputPanel = new JPanel();
		inputPanel.setLayout(new GridLayout(2,1));
		firstName = new JTextField();
		lastName = new JTextField();
		inputPanel.add(firstName);
		inputPanel.add(lastName);
	}
	
	public void buildOutputPanel()
	{
		outputPanel = new JPanel();
		outputPanel.setLayout(new GridLayout(1,3));
		submit = new JButton("submit");
		
		submit.addActionListener(new buttonListener());
		outputLabel = new JLabel();
		
		//Note that setBorder lets you set a border. in this case it's dark grey with a width of 2
		outputArea = new JTextArea(3,10);
		outputArea.setBorder(BorderFactory.createLineBorder(Color.DARK_GRAY,2));
		outputArea.setBackground(Color.WHITE);
		
		//You can use font objects, along with the setFont method, to change the font of a textArea or textField
		Font font = new Font("SansSerif", Font.PLAIN, 16);
		outputArea.setFont(font);
		
		outputPanel.add(outputArea);
		outputPanel.add(outputLabel);
		outputPanel.add(submit);
		
		
	}
	
	private class buttonListener implements ActionListener
	{

		@Override
		public void actionPerformed(ActionEvent e) {
			//Although textareas are typically used as output, you can also call getText on them to use them as input if you wanted. in this case I'm using only the textfields as input
			String output = firstName.getText() + " " + lastName.getText();
			
			//You can use the setText method to write output to a label or a textarea
			outputArea.setText(output);
			outputLabel.setText(output);
		}
		
	}
	public static void main(String[] args)
	{
		new JTextAreaExample();
	}
	
}
