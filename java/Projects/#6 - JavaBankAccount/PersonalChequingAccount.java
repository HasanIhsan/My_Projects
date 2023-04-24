/*
    !ProgramName: PersonalChequingAccount
    *purpose: this is the personal chequing account file which extends the bankaccout and implements intrestpayble
    !programmer: hassan ihsan
    !date:

    ! NOTE so you will notice that the clacintrest/monthly process methods only go up to the month of march 
    !      that is becuase in your example it did not show if it would be all the month so i did it that way.
*/

//?imports
import java.util.ArrayList;
import java.text.DecimalFormat;

//?personalchecquing class extends bankaccount implements intrestpayable
public class PersonalChequingAccount extends BankAccount implements InterestPayable
{
    //*Variables
    private String accountNumber;
    private int numberWithdrawls;
    private int numberDeposits;
    private double balance;
    private boolean accountActive;
    private double INT_RATE = 0.025;
    private double SERVICE_FEE = 0.85;

    //arary
    private ArrayList<Transaction> record = new ArrayList<Transaction>();
   // private static DecimalFormat df2 = new DecimalFormat("#.##");

   //?methods no arguments
    PersonalChequingAccount()
    {
        //*setting customer name and accounttype and account number to null
        //*setting account active to false and everything else to 0
        this.setCustomerName(null);
        this.setAccountType(null);
        this.accountNumber = null;
        this.accountActive = false;
        this.numberDeposits = 0;
        this.numberWithdrawls = 0;
        this.balance = 0.0;
    }

    //?method with 3 argumetns
    PersonalChequingAccount(String CustomerName, String month, double balance)
    {
        //*setting things to where they need to be set.
        this.setCustomerName(CustomerName);
        this.setMonth(month);
        this.balance = balance;
        this.setAccountType("Chequing");
        this.accountNumber = generateAccountNumber();
        this.accountActive = isAccountActive();

    }


    /*
    ? getter methods 
    ?       - accoutnumber
    ?       - number of with drawls
    ?       - number of deposits
    ?       - balance
    ?       - account active
    ?       - intrest
    ?       - service
    */
    
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
            return accountActive =  false;
        }


        return accountActive = true;
    }

    public double getIntresetRate()
    {
        return INT_RATE;
    }

    public double getServiceFee()
    {
        return SERVICE_FEE;
    }



    //?generting account number method
    public String generateAccountNumber()
    {
        int randomNumber = 0;
        String bankNumber = "002-623490";
        //*random;y generates 5random number (10000 to 90000)
        //i was not sure if we had to generate 5 serprate random numbers so i did it this way
        randomNumber = (int) (Math.random()*((90000)+10000));  
        
        String enddigit = "550";
        return bankNumber + "-" +  randomNumber  +  "-" + enddigit;
    }

    //?deposit method
    public void deposit(double depositAmount, int day)
    {
        this.balance += depositAmount;
        //*increments the number of deposits
        numberDeposits++;
        //this.numberDeposits = day;
        isAccountActive();
        recordTransaction(day, "Deposits" ,depositAmount, balance);
    }

    //?withdrawl method
    public void withdrawl(double withdrawlAmount, int day)
    {
        String transactionMessages = " ";
        double balancelef = balance - withdrawlAmount;


        
        
            if(balancelef > 0.0 && isAccountActive() == true)
            {
                balance -= withdrawlAmount;
                transactionMessages = "withdrawl";
            }
            else if (balancelef < 0.0)
            {
                transactionMessages = "Transaction cancelled. insufficiend funds";
            }
            else if (isAccountActive() == false)  
            {
                transactionMessages = "Transacion cancelled. Account is inactive";
            }
    
            
        
        //*incremetns the number of withdrawls
        numberWithdrawls++;
        accountActive =  isAccountActive();
        recordTransaction(day, transactionMessages, withdrawlAmount, balance);
         
        
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
        String month = getMonth();
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
                        if(record.get(i).getBalance() >= 1000)
                        {
                            intrst = (INT_RATE / 12) * balance;
                            transaction = "intrest is";
                            amount = intrst;
                            
                        }
                        
                    }
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
                        if(record.get(i).getBalance() >= 1000)
                        {
                            intrst = (INT_RATE / 12) * balance;
                            transaction = "intrest is";
                            amount = intrst;
                        }
                         
                    }
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
                        if(record.get(i).getBalance() >= 1000)
                        {
                            intrst = (INT_RATE / 12) * balance;
                            transaction = "intrest is: ";
                            amount = intrst;
                        }
                       
                    }
                }
            
                //?update the intrest
                balance += intrst;
                //?record transaction
                recordTransaction(day, transaction, amount, balance);
            }break;
          
        }
        
       
    }

    //?record transaction method
    public void recordTransaction(int day, String transaction, double amount, double balance)
    {
        Transaction tran1 = new Transaction();
        tran1.set(getMonth(), day, transaction, amount, balance);
        record.add(tran1);
            
    }
    
    //?print transaction method
    public void printTransations()
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
       
    /*
        !Method name:calcinterst 
        *purpose: calculates the intrest
          NOTE only did switch case to march did not know if it needed to be all the months
    
    */
    public void monthlyProcess()
    {
        //determine the last day of the current month
        String month = getMonth();
        int day = 0;
        String transaction = " ";
        double Service = 0.0;
        double amount = 0.0;

                /* 
           ? NOTE aging i was not sure how many month you wanted so i only went up to march (since example shown goes to march)
           ?      sry if that was not where you wanted it to go to.
        
            *using a switch case for each month (again only goes to march) 
        
        */
        switch(month)
        {
            case "January":
            {
                day = 31;

               if(getNumberWithdrawls() >= 4)
               {
                  amount =  (numberWithdrawls * (double)SERVICE_FEE);
                  balance -= amount;
                   transaction = "service fee";
               }

               amount += Service;
               calcInterest();
               printTransations();
               isAccountActive();
            } break;
            case "Febuary":
            {
                day = 29;

                if(getNumberWithdrawls() >= 4)
                {
                    amount =  (numberWithdrawls * (double)SERVICE_FEE);
                    balance -= amount;
                    transaction = "service fee";
                }
                amount += Service;
                calcInterest();
                printTransations();
                isAccountActive();
            }break;
            case "March":
            {
                
                day = 31;
                if(getNumberWithdrawls() >= 4)
                {
                    amount =  (numberWithdrawls * (double)SERVICE_FEE);
                    balance -= amount;
                    transaction = "service fee";
                } else
                {
                   amount = 0.0;
                }
                amount += Service;
                calcInterest();
                printTransations();
                isAccountActive();
            }break;
        }
        


   
    }

    //?tostring method (overrides normal tostring)
    public String toString()
    {
        return (super.toString() +
        "\n***************************************" +
        "\nCustomerNAme " + getCustomerName() +
        "\nAccount Type " + getAccountType() +
        "\nCurrent month " + getMonth() + 
        "\n***************************************" +
        "\nAccount Number: " + accountNumber + 
        "\nNumber of Withdrawls: "  + numberWithdrawls + 
        "\nNumber of Deposits: " + numberDeposits + 
        "\nBalance: " + balance + 
        "\nAccount Acive: " + accountActive + 
        "\nAnnual interest Rate: " + INT_RATE + 
        "\nMonthly Service Fee Rate: " + SERVICE_FEE);

    }
}