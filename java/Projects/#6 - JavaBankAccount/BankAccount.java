/*
    !ProgramName: Bankaccount
    *purpose: this is the bank account file (also is an abstract class)
    !programmer: hassan ihsan
    !date:

*/

//?bankaccount abstract method
public abstract class BankAccount
{
    //*variables
    private String CustomerName;
    private String AccountType;
    private String Month;

    //?method no arg
    BankAccount()
    {
        this.CustomerName = null;
        this.AccountType = null;
        this.Month = null;
    }

    //?method 3 args
    BankAccount(String CustomerName, String AccountType, String month)
    {
        this.CustomerName = CustomerName;
        this.AccountType = AccountType;
        this.Month = month;
        //System.out.println("helo");
    }


    //?getters
    public String getCustomerName()
    {
        return CustomerName;
    }

    public void setCustomerName(String CustomerName)
    {
        this.CustomerName = CustomerName;
    }

    public String getAccountType()
    {
        return AccountType;
    }

    //?setter accouttype
    public void setAccountType(String AccountType)
    {
        this.AccountType = AccountType;
    }

    public String getMonth()
    {
        return Month;
    }

    public void setMonth(String month)
    {
        this.Month = month;
    }


    //?other abstract methods
    public abstract String generateAccountNumber();
    public abstract void deposit(double depositAmount, int day);
    public abstract void withdrawl(double withdrawlAmount, int day);
    public abstract void recordTransaction(int day, String tracsaction, double amount, double balance);
    public abstract void monthlyProcess();

    //?tostrings
    public String toString()
    {
        return 
        "Customer: " + CustomerName + 
        "\nAccountType: " + AccountType + 
        "\nCurrent Month: " + Month;
    }
    
}