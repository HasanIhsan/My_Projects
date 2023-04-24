/**
 * Run this class first, then click the button to open up the second class
 */
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class FirstWindow extends JFrame implements ActionListener{

	
	FirstWindow()
	{
		//boilerplate code
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setSize(800, 400);
		this.setLocationRelativeTo(null);
		this.setVisible(true);
		this.setLayout(new FlowLayout());
		
		JButton button = new JButton("Click me!");
		this.add(button);
		
		button.addActionListener(this);
	}
	@Override
	public void actionPerformed(ActionEvent e) {
		
		new JTextAreaExample();
	}
	
	public static void main(String[] args)
	{
		new FirstWindow();
	}

}
