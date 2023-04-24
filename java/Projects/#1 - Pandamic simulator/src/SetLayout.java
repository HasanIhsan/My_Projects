import java.awt.Color;
import java.awt.FlowLayout;

import javax.swing.GroupLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.LayoutStyle;
import javax.swing.Timer;

public class SetLayout extends JFrame {
	
	public static JPanel SimulatorPanel, menuPanel;
	public static JButton aboutBtn, startBtn, stopBtn;
	public static JLabel LevelOfImuLbl, OneShotVacLbl, PopLbl, ThreeShotVacLbl, TwoShotVacLbl, notVacLbl;
	public static JTextField NotVacinatedTxtFld, NumberOfPopTxtFld,OneShotVacTxtFld, TwoShotVacTxtFld, ThreeShotVacTxtFld;
	
	static JFrame frame;
	
	//container for popup
	 
	
	public SetLayout() {
		
		
		
		frame = new JFrame("Just Follow the Bouncing Ball");
		frame.setLocationRelativeTo(null);
		 
		frame.setLayout(new FlowLayout() );//ANONYMOUS object
		frame.setSize(1200,1000);
		
		 	menuPanel = new javax.swing.JPanel();
	        startBtn = new javax.swing.JButton();
	        stopBtn = new javax.swing.JButton();
	        aboutBtn = new javax.swing.JButton();
	        PopLbl = new javax.swing.JLabel();
	        NumberOfPopTxtFld = new javax.swing.JTextField();
	        LevelOfImuLbl = new javax.swing.JLabel();
	        NotVacinatedTxtFld = new javax.swing.JTextField();
	        OneShotVacTxtFld = new javax.swing.JTextField();
	        TwoShotVacTxtFld = new javax.swing.JTextField();
	        ThreeShotVacTxtFld = new javax.swing.JTextField();
	        notVacLbl = new javax.swing.JLabel();
	        OneShotVacLbl = new javax.swing.JLabel();
	        TwoShotVacLbl = new javax.swing.JLabel();
	        ThreeShotVacLbl = new javax.swing.JLabel();
	       

	        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	        frame.setTitle("pandamic simulator");
	       
	        
	        menuPanel.setBackground(new Color(204, 255, 255));

	        startBtn.setText("Start"); 
	        stopBtn.setText("Stop"); 
	        aboutBtn.setText("About");
	        


	        //setting text for lables
	        PopLbl.setText("Population:");
	        NumberOfPopTxtFld.setText("100");
	        LevelOfImuLbl.setText("Level of Immunity");
	        NotVacinatedTxtFld.setText("10");
	        OneShotVacTxtFld.setText("10");
	        TwoShotVacTxtFld.setText("10");
	        ThreeShotVacTxtFld.setText("10");
	        notVacLbl.setText("Not Vacinated:");
	        notVacLbl.setToolTipText(notVacLbl.getText());
	        OneShotVacLbl.setText("One Shot Vac: ");
	        OneShotVacLbl.setToolTipText(OneShotVacLbl.getText());
	        TwoShotVacLbl.setText("Two Shot Vac:");
	        TwoShotVacLbl.setToolTipText(TwoShotVacLbl.getText());
	        ThreeShotVacLbl.setText("Three Shot Vac: ");
	        ThreeShotVacLbl.setToolTipText(ThreeShotVacLbl.getText());
	         
			
	        GroupLayout menuPanelLayout = new GroupLayout(menuPanel);
	        menuPanel.setLayout(menuPanelLayout);
	        
			/*
			 * JPanel buttons = new JPanel(new FlowLayout()); buttons.add(startBtn);
			 * buttons.add(stopBtn); buttons.add(aboutBtn);
			 * 
			 * 
			 * menuPanelLayout.setVerticalGroup(null);
			 */
	        //PROB BYE BYE
	        menuPanelLayout.setHorizontalGroup(
		            menuPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING)
		            .addGroup(GroupLayout.Alignment.TRAILING, menuPanelLayout.createSequentialGroup()
		                .addContainerGap(21, Short.MAX_VALUE)
		                .addComponent(PopLbl, GroupLayout.PREFERRED_SIZE, 68, GroupLayout.PREFERRED_SIZE)
		                .addPreferredGap(LayoutStyle.ComponentPlacement.UNRELATED)
		                .addComponent(NumberOfPopTxtFld, 50, 50, 50)
		                .addGap(58, 58, 58))
		            .addGroup(menuPanelLayout.createSequentialGroup()
		                .addContainerGap()
		                .addGroup(menuPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING)
		                    .addComponent(startBtn, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
		                    .addComponent(stopBtn, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
		                    .addComponent(aboutBtn, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
		                    .addComponent(LevelOfImuLbl, GroupLayout.Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
		                    .addGroup(menuPanelLayout.createSequentialGroup()
		                        .addGroup(menuPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING)
		                            .addGroup(menuPanelLayout.createSequentialGroup()
		                                .addComponent(ThreeShotVacLbl)
		                                .addPreferredGap(LayoutStyle.ComponentPlacement.RELATED)
		                                .addComponent(ThreeShotVacTxtFld, 50, 50, 50))
		                            .addGroup(menuPanelLayout.createSequentialGroup()
		                                .addComponent(notVacLbl)
		                                .addPreferredGap(LayoutStyle.ComponentPlacement.UNRELATED)
		                                .addComponent(NotVacinatedTxtFld, 50, 50, 50))
		                            .addGroup(menuPanelLayout.createParallelGroup(GroupLayout.Alignment.TRAILING, false)
		                                .addGroup(GroupLayout.Alignment.LEADING, menuPanelLayout.createSequentialGroup()
		                                    .addComponent(TwoShotVacLbl)
		                                    .addGap(18, 18, 18)
		                                    .addComponent(TwoShotVacTxtFld, GroupLayout.PREFERRED_SIZE, 1, Short.MAX_VALUE))
		                                .addGroup(GroupLayout.Alignment.LEADING, menuPanelLayout.createSequentialGroup()
		                                    .addComponent(OneShotVacLbl, GroupLayout.PREFERRED_SIZE, 78, GroupLayout.PREFERRED_SIZE)
		                                    .addPreferredGap(LayoutStyle.ComponentPlacement.UNRELATED)
		                                    .addComponent(OneShotVacTxtFld, 50, 50, 50))))
		                        .addGap(0, 0, Short.MAX_VALUE)))
		                .addContainerGap())
		        );
		        menuPanelLayout.setVerticalGroup(
		            menuPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING)
		            .addGroup(menuPanelLayout.createSequentialGroup()
		                .addContainerGap()
		                .addComponent(startBtn, GroupLayout.PREFERRED_SIZE, 56, GroupLayout.PREFERRED_SIZE)
		                .addPreferredGap(LayoutStyle.ComponentPlacement.RELATED)
		                .addComponent(stopBtn, GroupLayout.PREFERRED_SIZE, 52, GroupLayout.PREFERRED_SIZE)
		                .addPreferredGap(LayoutStyle.ComponentPlacement.RELATED)
		                .addComponent(aboutBtn, GroupLayout.PREFERRED_SIZE, 54, GroupLayout.PREFERRED_SIZE)
		                .addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 23, Short.MAX_VALUE)
		                .addGroup(menuPanelLayout.createParallelGroup(GroupLayout.Alignment.BASELINE)
		                    .addComponent(NumberOfPopTxtFld, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
		                    .addComponent(PopLbl, GroupLayout.PREFERRED_SIZE, 16, GroupLayout.PREFERRED_SIZE))
		                .addGap(141, 141, 141)
		                .addComponent(LevelOfImuLbl)
		                .addPreferredGap(LayoutStyle.ComponentPlacement.RELATED)
		                .addGroup(menuPanelLayout.createParallelGroup(GroupLayout.Alignment.BASELINE)
		                    .addComponent(notVacLbl)
		                    .addComponent(NotVacinatedTxtFld, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
		                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
		                .addGroup(menuPanelLayout.createParallelGroup(GroupLayout.Alignment.BASELINE)
		                    .addComponent(OneShotVacTxtFld, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)
		                    .addComponent(OneShotVacLbl))
		                .addGap(12, 12, 12)
		                .addGroup(menuPanelLayout.createParallelGroup(GroupLayout.Alignment.BASELINE)
		                    .addComponent(TwoShotVacLbl)
		                    .addComponent(TwoShotVacTxtFld, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
		                .addGap(9, 9, 9)
		                .addGroup(menuPanelLayout.createParallelGroup(GroupLayout.Alignment.BASELINE)
		                    .addComponent(ThreeShotVacLbl)
		                    .addComponent(ThreeShotVacTxtFld, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE))
		                .addGap(17, 17, 17))
		        );
	        
	   
	         
	        SimulatorPanel = new JPanel();
			 SimulatorPanel.setBackground(new java.awt.Color(255, 255, 255));

			//SimulatorPanel.setLayout(null);
			 GroupLayout SimulatorPanelLayout = new GroupLayout(SimulatorPanel);
		        SimulatorPanel.setLayout(SimulatorPanelLayout);
		        SimulatorPanelLayout.setHorizontalGroup(
		            SimulatorPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING)
		            .addGap(0, 565, Short.MAX_VALUE)
		        );
		        SimulatorPanelLayout.setVerticalGroup(
		            SimulatorPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING)
		            .addGap(0, 0, Short.MAX_VALUE)
		        );
		       
		  frame.add(menuPanel);
		  frame.add(new PandemicSimulatorClient());
		 
		 // frame.add(SimulatorPanel);
	        frame.pack();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true);
	}

	public static JPanel getSimulatorPanel() {
		return SimulatorPanel;
	}

	public static JPanel getMenuPanel() {
		return menuPanel;
	}

	public static JButton getAboutBtn() {
		return aboutBtn;
	}

	public static JButton getStartBtn() {
		return startBtn;
	}

	public static JButton getStopBtn() {
		return stopBtn;
	}

	public static JLabel getLevelOfImuLbl() {
		return LevelOfImuLbl;
	}

	public static JLabel getOneShotVacLbl() {
		return OneShotVacLbl;
	}

	public static JLabel getPopLbl() {
		return PopLbl;
	}

	public static JLabel getThreeShotVacLbl() {
		return ThreeShotVacLbl;
	}

	public static JLabel getTwoShotVacLbl() {
		return TwoShotVacLbl;
	}

	public static JLabel getNotVacLbl() {
		return notVacLbl;
	}

	public static JTextField getNotVacinatedTxtFld() {
		return NotVacinatedTxtFld;
	}

	public static JTextField getNumberOfPopTxtFld() {
		return NumberOfPopTxtFld;
	}

	public static JTextField getOneShotVacTxtFld() {
		return OneShotVacTxtFld;
	}

	public static JTextField getTwoShotVacTxtFld() {
		return TwoShotVacTxtFld;
	}

	public static JTextField getThreeShotVacTxtFld() {
		return ThreeShotVacTxtFld;
	}

	public static JFrame getFrame() {
		return frame;
	}
	
	
}
