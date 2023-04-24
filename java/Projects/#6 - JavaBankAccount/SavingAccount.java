/*
    !ProgramName: SavingAccount
    *purpose: this is the savingsaccount file which again extends bankaccount and implement interrestpayable 
    !programmer: hassan ihsan
    !date:

*/

//?imports
import java.util.ArrayList;
import java.text.DecimalFormat;

//?savingsaccount class extends bankaccount implements intrestpayable
public class SavingAccount extends BankAccount implements InterestPayable
{
    //*variables
    private String accountNumber;
    private int numberWithdrawls;
    private int numberDeposits;
    private double balance;
    private boolean accountActive;
    private double INT_RATE = 0.03;

    //*arraylist
    private ArrayList<Transaction> record = new ArrayList<Transaction>();

    //?method no args
    SavingAccount()
    {
        this.setCustomerName(null);
        this.setAccountType(null);
        this.accountNumber = null;
        this.accountActive = false;
        this.numberWithdrawls = 0;
        this.numberDeposits = 0;
        this.balance = 0.0;

    }

    //?method 3 args
    SavingAccount(String CUstomerName, String month, double balance)
    {
        this.setCustomerName(CUstomerName);
        this.setMonth(month);
        this.balance = balance;
        this.setAccountType("Saving");
        this.accountNumber = generateAccountNumber();
        this.accountActive = isAccountActive();

    }

    //?getters
    public String getAccountNumber()
    {
        return accountNumber;
    }

    public int getNumberWithdrawls()
    {
        return numberWithdrawls;
    }

    public int getNumberDeposits()
    {
        return numberDeposits;
    }

    public double getBalance()
    {
        return balance;
    }

    public boolean isAccountActive()
    {
        if(balance < 25)
        {
            accountActive = false;
        }

        return true;
    }

    public double getInterestRate()
    {
        return INT_RATE;
    }

    //?generate account number
    public String generateAccountNumber()
    {
        int randomNumber = 0;
        String bankNumber = "002-623490";
        //*did not know if you wanted the numbers done serpataly so i did it this way
        randomNumber = (int) (Math.random()*((90000)+10000));  
        String enddigit = "550";
        return bankNumber + "-" +  randomNumber  +  "-" + enddigit;
    }

    //?deposti method
    public void deposit(double depositAmount, int day)
    {
        numberDeposits++;
        this.balance += depositAmount;
        
        isAccountActive();
        recordTransaction(day, "depost:", depositAmount, balance);
        //recordTransaction(day, ,depositAmount, balance);
    }

    //?widthdrawl method
    public void withdrawl(double withdrawlAmount, int day)
    {
        String transactionMessage  = " hello ";

      

        //*runs trought the array checking the balance
        for(int i = 0; i < record.size(); i++)
        {
            if(record.get(i).getBalance() > 0.0)
            {
                transactionMessage = "withdrawl";
            }
            else if (record.get(i).getBalance() < 0.0)
            {
                transactionMessage = "Transaction cancelled. insufficiend funds";
            }
            else if (isAccountActive() == false)  
            {
                transactionMessage = "Transacion cancelled. Account is inactive";
            }
    
        }
        //*update number of withdrawls
        numberWithdrawls++;
        isAccountActive();
        recordTransaction(day, transactionMessage, withdrawlAmount, balance);
        
    }

    //?calcintrest method
    /*
        !Method name:calcinterst 
        *purpose: calculates the intrest
        NOTE only did switch case to march did not know if it needed to be all the months
    
    */
    public void calcInterest()
    {
        int day;
        String month = " ";
        String transaction = " ";
        double intrst = 0.0;
        double amount = 0.0;

          /* 
           ? NOTE now i was not sure how many month you wanted so i only went up to march (since example shown goes to march)
           ?      sry if that was not where you wanted it to go to.
        
            *using a switch case for each month (again only goes to march) and using a for loop checks the values given
        
        */
        switch(month)
        {
            case "January":
            {
                day = 31;
                

                if(balance >= 25)
                {
                    for(int i = 0; i < record.size(); i++)
                    {
                        if(record.get(i).getBalance() >= 2000)
                        {
                            intrst = (INT_RATE + 0.0075) / 12 * balance;
                            transaction = "rate has gone up by 0.0075";
                            amount = intrst;
                        }
                        else
                        {
                            intrst = (INT_RATE / 12) * balance;
                            transaction = "rate is normal";
                            intrst = amount;
                            break;
                        }
                    }
                }
                else
                {
                    intrst = 0.0;
                }
                //?update the intrest
                balance += intrst;
                //?record transaction
                recordTransaction(day, transaction, amount, balance);
            }break;
            case "February":
            {
                day = 29;
                

                if(balance >= 25)
                {
                    for(int i = 0; i < record.size(); i++)
                    {
                        if(record.get(i).getBalance() >= 2000)
                        {
                            intrst = (INT_RATE + 0.0075) / 12 * balance;
                            transaction = "rate has gone up by 0.0075";
                            amount = intrst;
                        }
                        else
                        {
                            intrst = (INT_RATE / 12) * balance;
                            transaction = "rate is normal";
                            intrst = amount;
                            break;
                        }
                    }
                }
                else
                {
                    intrst = 0.0;
                }
                //?update the intrest
                balance += intrst;
                //?record transaction
                recordTransaction(day, transaction, amount, balance);
            }break;
            case "March":
            {
                day = 31;
                

                if(balance >= 25)
                {
                    for(int i = 0; i < record.size(); i++)
                    {
                        if(record.get(i).getBalance() >= 2000)
                        {
                            intrst = (INT_RATE + 0.0075) / 12 * balance;
                            transaction = "rate has gone up by 0.0075";
                            amount = intrst;
                        }
                        else
                        {
                            intrst = (INT_RATE / 12) * balance;
                            transaction = "rate is normal";
                            intrst = amount;
                            break;
                        }
                    }
                }
                else
                {
                    intrst = 0.0;
                }
                //?update the intrest
                balance += intrst;
                //?record transaction
                recordTransaction(day, transaction, amount, balance);
            }break;
          
        }
        
       
    }

    //?record tranction method
    public void recordTransaction(int day, String transaction, double amount, double balancce)
    {

        Transaction tran2 = new Transaction();
        tran2.set(getMonth(), day, transaction, amount, balance);
        record.add(tran2);
    }

    //?print traction method
    public void printTransaction()
    {
        DecimalFormat df2 = new DecimalFormat("#.##");
        System.out.println("************************************************");
        System.out.println("Transaction record for the month of " + getMonth());
        System.out.println("************************************************");
        //System.out.println(record + "\n");
        
         //   System.out.println( record.toString());

            for(int i = 0; i < record.size(); i++)
            {
                //*using printf like in c
                System.out.printf("%-5s %-5d %-5s: $%-20s Balance:$%-5s\n", record.get(i).getMonth(), record.get(i).getDay(), record.get(i).getTransation(), df2.format(record.get(i).getAmount()),df2.format(record.get(i).getBalance()));
            }
         
    }

    //?monthly process method
    public void monthlyProcess()
    {
        calcInterest();
        printTransaction();
        isAccountActive();
    }

    //?tostring method
    public String toString()
    {
         return(super.toString() +
         "\n***************************************" +
        "\nCustomerNAme " + getCustomerName() +
        "\nAccount Type " + getAccountType() +
        "\nCurrent month " + getMonth() + 
        "\n***************************************" +
         "\nAccount Number: " + accountNumber + 
         "\n Number of Withdrawls" + numberWithdrawls + 
         "\nNumber of Deposits: " + numberDeposits + 
         "\n Balance: " + balance + 
         "\n Account Acive: " + accountActive + 
         "\n Annual interest Rate:" + INT_RATE);
    }
}