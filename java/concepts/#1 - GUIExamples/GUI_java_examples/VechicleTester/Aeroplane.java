/*
    !programname: aeroplane
    !purpoe: to have everythig to do with areplane
    *porgrammer: hassan ihsan
    *date: 2/25/2020

*/ 


public class Aeroplane extends Transport
{
    //variables
    private String maker;
    private String model;
    private boolean isAirborne;
    private int stallSpeed;

    public Aeroplane(String maker, String model, String color, int stallSpeed)
	{
        this.maker = maker;
        this.model = model;
        this.stallSpeed = stallSpeed;
        color = this.getColor();
        this.setForwardSpeed(0);
        this.isAirborne = false;

		
    }
    
    //getters
    public String getMaker()
    {
        return maker;
    }

    public String getModel()
    {
        return model;
    }

    public boolean getAirborne()
    {
        return isAirborne;
    }

    public int getStallSpeed()
    {
        return stallSpeed;
    }

    //setters
    public void setAirborne(boolean airborne)
    {
        this.isAirborne = airborne;
    }

    //override toString
    public String toString()
    {
        return (super.toString() + "This aeroplane is a " + model + " that is made by " + maker);
    }

    //check spped
    public String checkSpeed()
    {
         if(isAirborne == true &&  getMovementSpeed() <= getStallSpeed())
        {
            return "warmimg: airspeed is at or below stall seed! increase speed NOW";
        }
        else if(isAirborne == true && getMovementSpeed() >= getStallSpeed())
        {
            return "Current spped is wihtin safe limits";
        }

        return "Aeroplae is not airborne at this time";
    }


}