/*
    !programname: vechiletester
    !purpoe: to have everying where we can test it
    *porgrammer: hassan ihsan
    *date: 2/25/2020

*/ 

public class vehicleTester
{

    public static void main(String[] args)
    {
        //creating the objects
         Aeroplane plane1 = new Aeroplane("boeing", "787 Dreamliner ", "blue", 125);
         Automobile car1 = new Automobile("toyota", "corolla", "red", 65, 130);

         Aeroplane plane2 = new Aeroplane("diamond", "katana", "white", 50);

         System.out.println("plane1 object " + plane1.toString());
         System.out.println("car1 object " + car1.toString());

         //for space
         System.out.println("\n");

         System.out.println("plane1 check speed " + plane1.checkSpeed());
         System.out.println("Car1 check speed " + car1.checkSpeed());

         //for space
         System.out.println("\n");

        System.out.println("plane2 object " + plane2.toString());

        plane2.setAirborne(true);
        plane2.setForwardSpeed(65);

        System.out.println("plane2 forward speed is: " + plane2.getMovementSpeed());
        System.out.println("plane2 spped check: " + plane2.checkSpeed());

        plane2.setForwardSpeed(40);
        System.out.println("plane2 forward speed is: " +  plane2.getMovementSpeed());
        System.out.println("plane speed check " + plane2.checkSpeed());



    }

}