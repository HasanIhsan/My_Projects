
/**
 * Program Name: people.java
 * Purpose:: this is a modified class to create a person object that will be used in the
 *         pandamic simulator application.
 *         
 *  
 */        

import java.awt.*;

public class People
{
	
	
	//REVISION: July 14: set all data members to private so that getters and setters will be
	// used by the Bouncing_BallV4 class
	

	private int xCoord;
	private int yCoord;
	private int diameter;

	private Color color;
	
	private int immunityStatus;
	private boolean isAlive;
	private boolean isInfected;
	//flags for ball direction and their getters and settersREMOVED FOR THIS VERSION
	//private boolean xFlag; //if true, we move to the right by incrementing xCoord
	               //if false, we move left by decrementing xCoord.
	//private boolean yFlag; //if true, we move down by incrementing yCoord
	               //if false, we move up by decrementing yCoord
	
	//NOTE: for version 5 of the Ball class, add two more data members, xIncrement and yIncrement.  
	//These will hold int values in the range of -5 to +4, and will be used in the calcPosition() method
	//to adjust the direction of the ball object after a collision .
	private int xIncrement;
	private int yIncrement;
	
 
	
	//4 arg constructor where ball x and y are generated randomly based on the bounds of the drawing area.
	//random Value = (int)( Math.random() *(highValue � lowValue + 1) + lowValue)
	//
	public People(int diam, Color color, int widthValue, int heightValue, boolean isAlive,boolean isInfected, int immunityStat)
	{
		this.diameter = diam;
		this.color = color;
		this.immunityStatus = immunityStat;
		this.isAlive = isAlive; 
		this.isInfected = isInfected;
		//generate random starting position values bounded by widthValue and heightValue.
		//NOTE: lowest value returned needs to be zero, so we need to generate two separate random values
		// and use the width and length values of the JPanel as the multiplier in Math.random() call.
		//ALSO, we need to make sure that the ball is completely INSIDE the right edge and ABOVE the bottom edge, so 
		// we should SUBTRACT the DIAMETER of the ball object from the randomly generated value.
		// FUrther complication is that the resulting values could go negative if a random value LESS THAN DIAMETER
		// is generated, so we need to account for this possibility. We can do a RANGE TEST on the VALUES to 
		// VALIDATE THEM. IF we get an invalid value we have to generate another one.
		int randomX, randomY;
		boolean loopflag1 = true;
		
	  //loop 
		while(loopflag1)
		{
			//generate a random value using widthValue
			randomX = (int)(Math.random() * widthValue);
			if(randomX >= 0 && randomX <= widthValue - this.diameter)
			{
				//we have a valid x value, assign it to xCoord
				this.xCoord = randomX;
				//System.out.println("STUB:Valid random xCoord value of " + randomX);
				loopflag1 = false;
			}
		}//end while
		
		//reset flag1 to true to start second loop
		loopflag1 = true;
		while(loopflag1)
		{
			//repeat for yCoord
			randomY = (int)(Math.random() * heightValue);
			if(randomY >= 0 && randomY <= heightValue - this.diameter)
			{
				//we have a valid y value, assign it to yCoord
				this.yCoord = randomY;
				//System.out.println("STUB:Valid random yCoord value of " + randomY);
			  loopflag1 = false;
			}
		}//end while
		
		//Added July 15 to get the values for the increments
		if(this.isAlive == false)
		{
			this.xIncrement = 0;
			this.yIncrement = 0;		
		}else
		{
			boolean loopFlag = true;
			while(loopFlag)
			{
				this.xIncrement = (int)(Math.random()*11 - 5);
				this.yIncrement = (int)(Math.random()*11 - 5);		
				if(this.xIncrement ==0 && this.xIncrement ==0)
				{
				  //run it again
					this.xIncrement = (int)(Math.random()*11 - 5);
					this.yIncrement = (int)(Math.random()*11 - 5);
				}
				else
				{
					loopFlag = false;
				}
		}
		
	 
		}//end loop
					
		 
	 
	}//end random constructor
	
	public Color getColor()
	{
		return color;
	}

	public void setColor(Color color)
	{
		this.color = color;
	}

	//getters and setters
	public int people()
	{
		return xCoord;
	}
	//getters and setters
	public int getxCoord()
	{
		return xCoord;
	}
	
	public int getyCoord()
	{
		return yCoord;
	}
	public int getDiameter()
	{
		return diameter;
	}
	public int getImmunityStat()
	{
		return immunityStatus;
	}
	
	public void setImmunityStat(int immunityStat)
	{
		this.immunityStatus = immunityStat;
	}
	public void setIsAlive(boolean isAlive)
	{
		this.isAlive = isAlive;
	}
	public boolean getIsInfected()
	{
		return isInfected;
	}
	
	public void setIsInfected(boolean isInfected)
	{
		this.isInfected = isInfected;
	}
	
	public void setxCoord(int xCoord)
	{
		this.xCoord = xCoord;
	}

	public void setyCoord(int yCoord)
	{
		this.yCoord = yCoord;
	}
  
	public int getxIncrement()
	{
		return xIncrement;
	}

	public void setxIncrement(int xIncrement)
	{
		this.xIncrement = xIncrement;
	}

	public int getyIncrement()
	{
		return yIncrement;
	}

	public void setyIncrement(int yIncrement)
	{
		this.yIncrement = yIncrement;
	}
}
//end class
