
/*
    !programname: automobile
    !purpoe: to have everythig to do with autobile
    *porgrammer: hassan ihsan
    *date: 2/25/2020

*/ 
public class Automobile extends Transport
{

    //variables
    private String maker;
    private String model;
    private int initialSpeed;
    private int maxSafeSpeed;

    public Automobile(String maker, String model, String color, int initialSpeed, int maxSafeSpeed)
    {
        this.maker = maker;
        this.model = model;
        this.setForwardSpeed(initialSpeed); // i could not figure out how to do it without the set s
        this.maxSafeSpeed = maxSafeSpeed;
        color = getColor();

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
    public int getMaxSafeSpeed()
    {
        return maxSafeSpeed;
    }

    //overrider tostring
    public String toString()
    {
        return(super.toString() + "this car is a " + model + " that is made by " + maker);
    }

    //check speed
    public String checkSpeed()
    {
        if(getMovementSpeed() / getMaxSafeSpeed() > 0.95)
        {
            return "warning: vechilce speed is at saftey limits! SLOW DOWN";
        }
        else if(getMovementSpeed() / getMaxSafeSpeed() <= 0.95)
        {
           return "Current car spped is within safe limits";
        }

        return "vechile is not moving";
    }
}