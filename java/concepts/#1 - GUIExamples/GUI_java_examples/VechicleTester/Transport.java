/*
    !programname: transport
    !purpoe: to have everythig to do with transport
    *porgrammer: hassan ihsan
    *date: 2/25/2020

*/ 

public abstract class Transport
{
    private String vechicleType;
    private String color;
    private boolean isMoving;
    private int forwardSpeed;


    public Transport()
    {
      this.vechicleType = "unkown";
      this.color = "black";

    }

    public Transport(String vehicleType, String color, int forwardSpeed)
    {
        this.vechicleType = vehicleType;
        this.color = color;
        this.forwardSpeed = forwardSpeed;

        if(forwardSpeed == 0){
            isMoving = false;
        }
        else if(forwardSpeed > 0)
        {
            isMoving = true;
        }
    }

    //getters
    public String getVechicleType()
    {
        return vechicleType;
    }

    public String getColor()
    {
        return color;
    }

    public boolean getisMoving()
    {
        return isMoving;
    }

    public int getMovementSpeed()
    {
        return forwardSpeed;
    }

    //setters
    public void setForwardSpeed(int newSpeed)
    {
        this.forwardSpeed = newSpeed;

        if(newSpeed > 0)
        {
            isMoving = true;
        }
        
    }


    //overrider

    public String toString()
    {
        return "This vechicle is a(n)" + vechicleType + " its color is  " + color + " \nCurrent speed is " + forwardSpeed + " so the in-motion stat is " + isMoving + ".\n";
    }

    public abstract String checkSpeed();
    
}