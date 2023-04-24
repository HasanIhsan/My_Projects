 
import java.awt.Color;
import java.awt.Container;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.TimerTask;
import java.util.concurrent.TimeUnit;

import javax.swing.GroupLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.LayoutStyle;
import javax.swing.Timer;
 
 
 

public class PandemicSimulatorClient extends JPanel {
 
	//container for popup
	static Container contentPane;
	
	private Timer time;//Timer class object that will fire events every LAG_TIME interval
 
	//static JFrame frame;
	private PandemicListModel theModel = new PandemicListModel();
	
	 
	PandemicListView viewer = null;
	
	private final int WIDTH = 570, HEIGHT = 500;//size of JPanel
	private final int LAG_TIME = 50; // 50 time in milliseconds between re-paints of screen
	 
	private final int IMG_DIM =10; //size of ball to be drawn
	 
	private final int ARRAY_SIZE;
	private People[] peopleArray;
	
	Timer tim;
  
	private boolean isInfected, isAlive = true;
	private int immunityStatus;
	
	
	private int infectedCycle = 150;
	//int second = 0;
	private int numPeopleinfeted;
	private int numPeopleDeath;
	
	int unVacinatednum, oneShotVac, twoShotVac, threeShotVac;
	
	//using arrylist cause its eaiser to keep track and do percentage calculations
	//if there is a better way of doing this implement it...
	private List<Integer> UnvacinatedInfected = new ArrayList<Integer>();
	private List<Integer> OneShotVacInfected = new ArrayList<Integer>();
	private List<Integer> TwoShotVacInfected = new ArrayList<Integer>();
	private List<Integer> ThreeShotVacInfected = new ArrayList<Integer>();
	
	//these arraylist keep track of death 
	private List<Integer> UnvacinatedPeopleDeath = new ArrayList<Integer>();
	private List<Integer> OneShotVacPeopleDeath = new ArrayList<Integer>();
	private List<Integer> TwoShotVacPeopleDeath = new ArrayList<Integer>();
	private List<Integer> ThreeShotVacPeopleDeath = new ArrayList<Integer>();
	
	
	
	public  PandemicSimulatorClient()
	{
		//REVISION July 14 : create an array of Ball objects here in class scope
		ARRAY_SIZE = Integer.parseInt(SetLayout.getNumberOfPopTxtFld().getText());//default to 100 
		//peopleArray = new  People[ARRAY_SIZE];
		
		ButtonListener aboutbtn = new ButtonListener(); 
        ButtonListener startbtn = new ButtonListener(); 
        ButtonListener stopbtn = new ButtonListener(); 
		SetLayout.aboutBtn.addActionListener( aboutbtn);
		SetLayout.startBtn.addActionListener( startbtn);
		SetLayout.stopBtn.addActionListener( stopbtn);
		
		immunityStatus = 0;
		isInfected = false;
		
		this.time = new Timer(LAG_TIME, new BounceListener() );
		
		
		int populationNum = 0;
		int NotVacinatednum = 0;
		int oneShotVac = 0;
		int twoShotVac = 0;
		int threeShotVac = 0;
		
		
		try {
			String population = SetLayout.getNumberOfPopTxtFld().getText();
			String NotVaccinated = SetLayout.getNotVacinatedTxtFld().getText();
			String OneShotVax = SetLayout.getOneShotVacTxtFld().getText();
			String TwoShotVax = SetLayout.getTwoShotVacTxtFld().getText();
			String ThreeShotVax = SetLayout.getThreeShotVacTxtFld().getText();
			
			//pandemic_simulator_client.NumberOfPopTxtFld.setText(pandemic_simulator_client.NumberOfPopTxtFld.getText());
			SetLayout.NumberOfPopTxtFld.setText(population);
			
			populationNum = Integer.parseInt(population);
			NotVacinatednum = Integer.parseInt(NotVaccinated);
			oneShotVac = Integer.parseInt(OneShotVax);
			twoShotVac =  Integer.parseInt(TwoShotVax);
			threeShotVac =  Integer.parseInt(ThreeShotVax);
			
			 
			//ARRAY_SIZE = populationNum;//default to 100 
			peopleArray = new People[ARRAY_SIZE];
				
			
		}
		catch(NumberFormatException e) {
			System.out.println("Input not numeric");
			JOptionPane.showMessageDialog(PandemicSimulatorClient.contentPane,
				    "Invalid input(s)",
				    "Error",
				    JOptionPane.ERROR_MESSAGE);
			System.out.println("Exception handled");
			e.printStackTrace();
			
		}
		
		 
		//REVISION JULY 15
		//use a loop to populate the peopleArray with Peoples with random positions
		//Set the color of the first People to RED
		peopleArray[0] = new People(IMG_DIM, Color.RED,WIDTH, HEIGHT, isAlive,isInfected, immunityStatus);
		//now set color of remaining Peoples to BLUE
		 //color to pass in to People constructor	 
		
		
		//System.out.println(unVacinatednum + " " + oneShotVac + " " + twoShotVac + " " +threeShotVac);
		for(int i = 1; i < peopleArray.length; i++)
		{
			if(i%NotVacinatednum == 0)
			{
				peopleArray[i] = new People(IMG_DIM, Color.BLUE,WIDTH, HEIGHT, isAlive,isInfected , immunityStatus);
			} 
			else
			{
				peopleArray[i] = new People(IMG_DIM, Color.BLUE, WIDTH, HEIGHT, isAlive,isInfected, immunityStatus);	
			}	
			
			if(i%oneShotVac == 0)
			{
				peopleArray[i] = new People(IMG_DIM, Color.CYAN,WIDTH, HEIGHT, isAlive, isInfected, immunityStatus);
			} 
			 
			
			if(i%twoShotVac == 0)
			{
				peopleArray[i] = new People(IMG_DIM, Color.YELLOW,WIDTH, HEIGHT, isAlive, isInfected, immunityStatus);
			} 
			 
			   
			if(i%threeShotVac == 0)
			{
				peopleArray[i] = new People(IMG_DIM, Color.MAGENTA,WIDTH, HEIGHT, isAlive, isInfected, immunityStatus);
			} 
			 
		}//end for
		
		
		
		//set preferred size of panel using an ANONYMOUS Dimension object
		this.setPreferredSize(new Dimension(WIDTH, HEIGHT) );
		this.setBackground(Color.WHITE);
		 
		  
		 
	} //End constructor PandemicSimulatorClient()
	
	@Override
	public void paintComponent(Graphics g)
	{
		super.paintComponent(g);
		
		//set brush color
		g.setColor(Color.PINK);
		//REIVSISION HERE: need to access the Ball object's state values in the call to
		// fillOval
		//REVISION JULY 15: iterate through the loop to paint the balls onto the panel
		// and set the color using the Ball object's color value
		for(int i = 0; i < peopleArray.length; i++)
		{
			//get the color
			g.setColor(peopleArray[i].getColor());
			g.fillOval(peopleArray[i].getxCoord(), peopleArray[i].getyCoord(),  peopleArray[i].getDiameter(), peopleArray[i].getDiameter());
		}
		//draw a circle shape
		
	}
	
	public int randomChanceOfInfection()
	{
		int max = 10;
		int min = 1;
		
		Random generateRandomchance = new Random();
		int chanceOfInfection = min + generateRandomchance.nextInt(max);
		return chanceOfInfection;
	}
	private class BounceListener implements ActionListener
	{
		
		@Override
		public void actionPerformed(ActionEvent e)
		{
			 int infectedChance = 0;
			 
			// on each Timer event (every 20 milliseconds) re-calculate the co-ordinates
			// of where the ball shape will be drawn next. 
			
			//Simplified code...Now we just call calcPosition() for each ball object, which
			//will update their positions.
			
			//REVISION JULY 14: put this in a loop to call calcPosition() on each ball in the array
			for(int i = 0; i < peopleArray.length; i++)
			{
				Move(peopleArray[i]);
				
			 
			}
			
			//NEXT STEP for version 4: use a nested for loop to check for collisions. Eventually, put this code into its own method. 
			//It could return a boolean true if a collision occurs and xIncrement and yIncrement values
			// will be flipped from positive to negative or negative to positive, depending on their
			//current state.
			
			//Proximity detection: 
			//calculate the difference in the x and y cords ( deltaX and deltaY ) for EACH PAIR OF BALLS IN THE ARRAY.
			//Start with the first ball and compare it against every other ball in the array. Then do the second ball and check it against
			// the remaining balls in the array, and continue until every pair of balls has been checked for proximity.
			//For this we need a NESTED FOR LOOP
			
			int deltaX;//difference in pixels of the x coordinates of the two balls being compared.
			int deltaY;//difference in pixels of the y coordinates of the two balls being compared.
			
			//temp variables to hold the x and y coords of both balls in the pair.
			//The balls will be referred to as firstBall and secondBall
			int firstBallX,  firstBallY, secondBallX, secondBallY;
			
			//outer loop gets the firstBall of the pair and its coordinates.
			for(int i = 0; i < peopleArray.length -1; i++)//LCC to length-1 to avoid out of bounds
			{
				//get the x and y co-ords of  first ball of the pair
				firstBallX = peopleArray[i].getxCoord();
				firstBallY = peopleArray[i].getyCoord();
				
				//Inner loop gets the second ball of the pair
				//start inner loop counter at i+1 so we don't compare the first ball to itself.
				for(int j = i+1; j < peopleArray.length; j++)
				{
					secondBallX = peopleArray[j].getxCoord();
					secondBallY = peopleArray[j].getyCoord();
					
					//now calculate deltaX and deltaY for the pair of balls
					deltaX = firstBallX - secondBallX;
					deltaY = firstBallY - secondBallY;
					//square them to get rid of negative values, then add them and take square root of total
					// and compare it to ball diameter held in IMG_DIM
					if(Math.sqrt(deltaX *deltaX + deltaY * deltaY) <= IMG_DIM)//if true, they have touched
					{
						//REVSION HERE: not using the xFlag and yFlag anymore, so now we  adjust
						// the xIncrement and yIncrement by multiplying by -1
						peopleArray[i].setxIncrement(peopleArray[i].getxIncrement() * -1);
						peopleArray[i].setyIncrement(peopleArray[i].getyIncrement() * -1);
						
						//now do the secondBall
						peopleArray[j].setxIncrement(peopleArray[j].getxIncrement() * -1);
						peopleArray[j].setyIncrement(peopleArray[j].getyIncrement() * -1);
						
						//ALSO, to get a bit of directional change generate a new set of random values for the xIncrement
						//  and yIncrement of each ball involved in the collision and assign them.
			 
						int firstBallnewxIncrement = (int)(Math.random()*11 - 5);
						int firstBallnewyIncrement = (int)(Math.random()*11 - 5);
						int secondBallnewxIncrement = (int)(Math.random()*11 - 5);
						int secondBallnewyIncrement = (int)(Math.random()*11 - 5);
						
						//this will prevent balls from "getting stuck" on the borders.
						peopleArray[i].setxIncrement(firstBallnewxIncrement);
						peopleArray[i].setyIncrement(firstBallnewyIncrement);
						peopleArray[j].setxIncrement(secondBallnewxIncrement);
						peopleArray[j].setyIncrement(secondBallnewyIncrement);
					 
						 
						//no imnumity
						if(peopleArray[i].getColor().equals(Color.RED) && peopleArray[j].getColor().equals(Color.BLUE))
						{
							
							//infected:  
							infectedChance = randomChanceOfInfection();
							
							if(infectedChance <= 8)
							{
								 isInfected = true;
								 numPeopleinfeted++;
								 UnvacinatedInfected.add(numPeopleinfeted);
								// numinfected();
								  
								 
								peopleArray[j].setColor(peopleArray[i].getColor());
								peopleArray[j].setImmunityStat(1);
								peopleArray[j].setIsInfected(isInfected);
							}
							 
							
							 
						}
						
						//one shot of vacsine
						if(peopleArray[i].getColor().equals(Color.RED) && peopleArray[j].getColor().equals(Color.CYAN))
						{
							
							//infected:  
							infectedChance = randomChanceOfInfection();
							
							if(infectedChance <= 6)
							{
								 isInfected = true;
								 numPeopleinfeted++;
								 OneShotVacInfected.add(numPeopleinfeted);
								 
								 
								 
								//System.out.println(OneShotVacInfected.size());
								peopleArray[j].setColor(peopleArray[i].getColor());
								peopleArray[j].setImmunityStat(2);
								peopleArray[j].setIsInfected(isInfected);
							}
							 
							
							 
						}
						//two shot of vacsine
						if(peopleArray[i].getColor().equals(Color.RED) && peopleArray[j].getColor().equals(Color.YELLOW))
						{
							 
							infectedChance = randomChanceOfInfection();
							
							if(infectedChance <= 3)
							{
								 isInfected = true;
								 numPeopleinfeted++;
								 TwoShotVacInfected.add(numPeopleinfeted);
								 
								 
								 //System.out.println(TwoShotVacInfected.size());
								peopleArray[j].setColor(peopleArray[i].getColor());
								peopleArray[j].setImmunityStat(3);
								peopleArray[j].setIsInfected(isInfected);
							}
							 
							
							 
						}
						//three shot of vacsine
						if(peopleArray[i].getColor().equals(Color.RED) && peopleArray[j].getColor().equals(Color.MAGENTA))
						{
							 
							
							infectedChance = randomChanceOfInfection();
							
							if(infectedChance <= 1)
							{
								 isInfected = true;
								 numPeopleinfeted++;
								 ThreeShotVacInfected.add(numPeopleinfeted);
							
								 
								//System.out.println(ThreeShotVacInfected.size());
								peopleArray[j].setColor(peopleArray[i].getColor());
								peopleArray[j].setImmunityStat(4);
								peopleArray[j].setIsInfected(isInfected);
							}
							 
							
							 
						}
						
						 
						if(peopleArray[i].getColor().equals(Color.RED) && peopleArray[i].getIsInfected() == true)
						{
							int chanceOfDeath = randomChanceOfInfection();
							
							 
							//System.out.println(peopleArray[i].getImmunityStat());
							System.out.println("not vac " + UnvacinatedPeopleDeath.size());
							System.out.println("one vac " +OneShotVacPeopleDeath.size());
							System.out.println("two vac " +TwoShotVacPeopleDeath.size());
							System.out.println("three vac " +ThreeShotVacPeopleDeath.size());
								//not vac
								if(peopleArray[i].getImmunityStat() == 1 && chanceOfDeath <= 10) 
								{
									
									isAlive = false;
									peopleArray[j].setColor(Color.black);
									numPeopleDeath++;
									UnvacinatedPeopleDeath.add(numPeopleDeath);
				
									//System.out.println(UnvacinatedPeopleDeath.size());
									//setting is xandy increment to 0 works..... sort of
									peopleArray[j].setxIncrement(0);
									peopleArray[j].setyIncrement(0);
									peopleArray[j].setIsAlive(isAlive);
								}
								 
								//one show vac
								if(peopleArray[i].getImmunityStat() == 2 && chanceOfDeath <= 7) 
								{
									
									isAlive = false;
									peopleArray[j].setColor(Color.black);
									numPeopleDeath++;
									OneShotVacPeopleDeath.add(numPeopleDeath);
				
									//setting is xandy increment to 0 works..... sort of
									peopleArray[j].setxIncrement(0);
									peopleArray[j].setyIncrement(0);
									peopleArray[j].setIsAlive(isAlive);
								}
								 
								//two shot vac
								if(peopleArray[i].getImmunityStat() == 3 && chanceOfDeath <= 3) 
								{
									
									isAlive = false;
									peopleArray[j].setColor(Color.black);
									numPeopleDeath++;
									TwoShotVacPeopleDeath.add(numPeopleDeath);
				
									//setting is xandy increment to 0 works..... sort of
									peopleArray[j].setxIncrement(0);
									peopleArray[j].setyIncrement(0);
									peopleArray[j].setIsAlive(isAlive);
								}
								 
								//three shot vac
								if(peopleArray[i].getImmunityStat() == 4 && chanceOfDeath <= 1) 
								{
									
									isAlive = false;
									peopleArray[j].setColor(Color.black);
									numPeopleDeath++;
									ThreeShotVacPeopleDeath.add(numPeopleDeath);
				
									//setting is xandy increment to 0 works..... sort of
									peopleArray[j].setxIncrement(0);
									peopleArray[j].setyIncrement(0);
									peopleArray[j].setIsAlive(isAlive);
								}
						} //end if(peopleArray[i].getColor()...
					 
					} //end if(Math.sqrt(deltaX *deltaX + deltaY * deltaY) <= IMG_DIM)
				}//end inner for loop j
			 
				
			}//end outer for loop i
			
			//call repaint(), which in turn calls paintComponent() 
			repaint();
			 
		}//end method
		
	}//end BounceListener()
	
	
	
	//caulculates the percentages
	//adds the caculations to the model
	public void displayCalculations()
	{ 
		//percentage calculation may be wrong!
		 double number = 0;
		 
		 //total infected
		 double TotalInfected = UnvacinatedInfected.size() + OneShotVacInfected.size() + TwoShotVacInfected.size() + ThreeShotVacInfected.size();
		 double TotalNumOfPopInfected = TotalInfected / ARRAY_SIZE * 100;  
		 
		 //unvacinated infected
		 double TotalNumUnVacInfected = (double)UnvacinatedInfected.size() / unVacinatednum * 100;
		 
		 //one shot infected 
		 double TotalNumOneShotInfected = (double) OneShotVacInfected.size() / oneShotVac * 100;
		 //two shot infected
		 double TotalNumTwoShotInfected = (double)TwoShotVacInfected.size() / twoShotVac * 100;
		 //three shot infected
		 double TotalNumThreeShotInfected = (double)ThreeShotVacInfected.size() / threeShotVac * 100;
		
		 //add calculations to model
		 theModel.addElement(number, "Total population that contracted the disease: ",Double.toString(TotalNumOfPopInfected));
		 theModel.addElement(number, "unvaccinated persons who contracted the disease: ",Double.toString(TotalNumUnVacInfected ));
		 theModel.addElement(number, "One-shot-vaccinated persons who contracted the disease: ",Double.toString(TotalNumOneShotInfected));
		 theModel.addElement(number, "Two-shot-vaccinated persons who contracted the disease: ",Double.toString(TotalNumTwoShotInfected));
		 theModel.addElement(number, "Three-shot-vaccinated persons who contracted the disease: ",Double.toString(TotalNumThreeShotInfected));
		 
		 //death percentage
		 //take death divide by total number 
		 //ex: if there were 100 unvaccinated persons and 50 got infected, and 5 died, 
		 //the percentage death rate for unvaccinated persons would be 5/100 or 5%.
		 
		 //death percentage of unvaccinated people
		 double unvacDeathPercentage = (double)UnvacinatedPeopleDeath.size() / unVacinatednum;
		 
		 //Debugging purposes
		// System.out.println(UnvacinatedPeopleDeath.size());
		// System.out.println(unVacinatednum);
		// System.out.println( unvacDeathPercentage);
		 //death percentage of one shot vac
		 double oneShotDeathPercentage = (double)OneShotVacPeopleDeath.size() / oneShotVac * 100;
		 //death percentage of two shot vac
		 double twoShotDeathPercentage = (double)TwoShotVacPeopleDeath.size() / twoShotVac * 100;
		 //death percentage of three shot vac
		 double threeShotDeathPercentage = (double)ThreeShotVacPeopleDeath.size() / threeShotVac * 100;
		 
		 //add calculation to model
		 theModel.addElement(number, "Death Percentage of unvaccinated People: ", Double.toString(unvacDeathPercentage ));
		 theModel.addElement(number, "Death Percentage of One-shot-vaccinated people: ",Double.toString(oneShotDeathPercentage));
		 theModel.addElement(number, "Death Percentage of Two-shot-vaccinated people: ",Double.toString(twoShotDeathPercentage));
		 theModel.addElement(number, "Death Percentage of Three-shot-vaccinated people: ",Double.toString(threeShotDeathPercentage));
	}//end DisplayCalculation
	
	public void Move(People people)
	{
		
		//check if near boundary. If so, then apply negative operator to the relevant increment
		//Changed the operators to >= and <= from == to fix the "disappearing people" problem
		if(people.getxCoord() >= WIDTH - people.getDiameter() )
		{
			//we are at right side, so change xIncrement to a negative
			people.setxIncrement(people.getxIncrement() * -1);
		}
		if(people.getxCoord() <= 0)//changed operator to <=
		{
			//if true, we're at left edge, flip the flag
			people.setxIncrement(people.getxIncrement() * -1);;
		}
		if(people.getyCoord() >= HEIGHT - people.getDiameter() )
		{
			people.setyIncrement(people.getyIncrement() * -1);
		}
		if(people.getyCoord() <= 0)
		{
			//if true, we're at left edge, flip the flag
			people.setyIncrement(people.getyIncrement() * -1);;
		}
		//adjust the people positions using the getters and setters
		people.setxCoord(people.getxCoord() + people.getxIncrement());
		people.setyCoord(people.getyCoord() + people.getyIncrement());
 
		
	}//end Move()
	
	private class ButtonListener implements ActionListener
	{
		  
		  
	    	@Override
			public void actionPerformed(ActionEvent e)
			{
	    		 	
	    			if(e.getSource().equals(SetLayout.startBtn))
	    				time.start();
	    			if(e.getSource().equals(SetLayout.stopBtn))
					{
		    			 //getContentPane().remove(SimulatorPanel); 
		    			time.stop();
		    			displayCalculations();
		    			if (viewer == null)
		    				viewer = new PandemicListView(theModel);
		    			else
		    				viewer.pandamicInfoList.setModel(theModel);
					}
	  	        
			 
		    		if(e.getSource().equals(SetLayout.aboutBtn))
					{
		    			JOptionPane.showMessageDialog(contentPane, "Group Members: Hassan Ihsan, Garen Ikezian");
					}
	    		 
			} //end actionPerformed
	  } //end ButtonListener
}
