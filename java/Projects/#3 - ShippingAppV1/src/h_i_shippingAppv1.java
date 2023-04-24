//program Name: H_I_ShippingAppv1
//Purpose: simple shipping cost calculator
//Programmer: Hassan Ihsan
//Date: 2022/07/15


import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.text.DecimalFormat;

import javax.swing.event.*;





public class h_i_shippingAppv1 extends JFrame{
	
	private JButton calulatebtn, clearbtn;
	private JTextField widthvaluefld, heightvaluefld, lenhthvaluefld, volumevaluefld, weightvaluefld,costotshipvaluefld  ;
	Container contentPane;
 
	public h_i_shippingAppv1()
	{
		super("Hassan's Shipping Calculator");
		
		 
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setLayout(new FlowLayout() );
		this.setSize(500,300);
		this.setLocationRelativeTo(null);
		 
		JPanel topPanel = new JPanel(); 
		 
		JLabel topLbl = new JLabel("Enter dimension and weight values in fileds below:");
		topPanel.add(topLbl);
	 
		this.add(topPanel, BorderLayout.NORTH);
		
		JPanel centerPanel = new JPanel(); 
		centerPanel.setLayout(new GridLayout(5,3, 10, 15) );
		centerPanel.setBackground(new Color(0,0,255));
		  
		JLabel widthLbl = new JLabel("width(cm)");
		widthLbl.setHorizontalAlignment(SwingConstants.LEFT);
		
		JLabel heightlbl = new JLabel("Height(cm)");
		heightlbl.setHorizontalAlignment(SwingConstants.LEFT);
		
		JLabel lengthlbl = new JLabel("Length(cm)");
		lengthlbl.setHorizontalAlignment(SwingConstants.LEFT);
		
		JLabel valuemlbl = new JLabel("Total Volume(cm)");
		valuemlbl.setHorizontalAlignment(SwingConstants.LEFT);
		
		widthvaluefld = new JTextField();
		heightvaluefld = new JTextField();
		lenhthvaluefld = new JTextField();
		volumevaluefld = new JTextField();
		 
		centerPanel.add(widthLbl);
		centerPanel.add(widthvaluefld);
		centerPanel.add(heightlbl);
		centerPanel.add(heightvaluefld);
		centerPanel.add(lengthlbl);
		centerPanel.add(lenhthvaluefld);
		centerPanel.add(valuemlbl);
		centerPanel.add(volumevaluefld );
		 
		this.add(centerPanel, BorderLayout.WEST);
		
		JPanel rightpanel = new JPanel();
		rightpanel.setLayout(new GridLayout(5,3, 10, 10) );
		rightpanel.setBackground(new Color(255,0,0));
		//add it to the frame
		 
		
		JLabel weightkglb = new JLabel("weight(kg)");
		 weightkglb.setHorizontalAlignment(SwingConstants.LEFT);
		
		JLabel costtoshoplbl = new JLabel("cost to ship: $");
		costtoshoplbl.setHorizontalAlignment(SwingConstants.LEFT);
		
		weightvaluefld = new JTextField();
		costotshipvaluefld = new JTextField();
		
		rightpanel.add(weightkglb);
		rightpanel.add(weightvaluefld);
		rightpanel.add(costtoshoplbl);
		rightpanel.add(costotshipvaluefld);
		
		calulatebtn = new JButton("Calculate Cost"); 
		clearbtn = new JButton("Clear");
		
		rightpanel.add(calulatebtn);
		rightpanel.add(clearbtn);
		
		ButtonListener calculate = new ButtonListener(); 
		calulatebtn.addActionListener( calculate);
		
		this.add(rightpanel, BorderLayout.EAST);
		 
		 
		
		this.pack();
		//last line
		this.setVisible(true);
	}
	
	private class ButtonListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent ev)
		{
			double widthvaluint = Double.parseDouble(widthvaluefld.getText());
			double heightvalusint =  Double.parseDouble(heightvaluefld.getText());
			double lenghtvalueint = Double.parseDouble(lenhthvaluefld.getText());
			double weightvalueint = Double.parseDouble(weightvaluefld.getText());
			
			double cubicvalue = 0;
			double cubicshipcost = 0;
			
			double weightcost = 0;
			
			double finlcosttosip = 0;
			if(ev.getSource().equals(calulatebtn))
			{
				cubicvalue = widthvaluint * lenghtvalueint * heightvalusint;
				String cubicstr = String.valueOf(cubicvalue);
				volumevaluefld.setText(cubicstr + " cubic cms");
				
				 cubicshipcost = cubicvalue * 0.012;
				
				weightcost =   weightvalueint * 1.35;
				
				finlcosttosip = cubicshipcost + weightcost;
				
				if(weightvalueint > 25)
				{
					JOptionPane.showInternalMessageDialog(contentPane, "weight over 25 kg");
				}
				
				if(cubicvalue > 30000)
				{
					JOptionPane.showInternalMessageDialog(contentPane, "cubic limit exeed");
				}
				{
					JOptionPane.showInternalMessageDialog(contentPane, "weight over 25 kg");
				}
				
				DecimalFormat currencyFormatter = new DecimalFormat("$0.00");
				
				 
				costotshipvaluefld.setText(currencyFormatter.format(finlcosttosip));
				
				
			}
		}
	}
	public static void main(String [] args)
	{
		new h_i_shippingAppv1();
	}
}
