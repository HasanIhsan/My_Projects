/*
    !ProgramName: Transaction
    *purpose: this is the transcation file
    !programmer: hassan ihsan
    !date:

*/

//?traction class
public  class Transaction
{
    //*varables
    private String month;
    private int day;
    private String tracsaction;
    private double amount;
    private double balance;

    //?method no args
    Transaction()
    {
        this.month = null;
        this.day = 0;
        this.tracsaction = null;
        this.amount = 0;
        this.balance = 0;
    }

    //?getters
    public String getMonth()
    {
        return month;
    }

    public int getDay()
    {
        return day;
    }

    public String getTransation()
    {
        return tracsaction;
    }

    public  double getAmount()
    {   
        return amount;
    }

    public double getBalance()
    {
        return balance;
    }

    //?set method
    public void set(String month, int day, String transation, double amount, double balance)
    {
        this.month = month;
        this.day = day;
        this.tracsaction = transation;
        this.amount = amount;
        this.balance = balance;
    }

    //?tostring method
    public String toString()
    {
        return "\n" +  month  + " \t" 
        + day + "\t"
        +tracsaction + ":\t" 
        + amount +"\t" 
        +"Balance" +"\t" 
        + balance;
    }

}