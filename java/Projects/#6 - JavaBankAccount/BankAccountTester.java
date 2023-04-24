/*
    !ProgramName: BankAccounttester
    *purpose: this is the test file 
    !programmer: hassan ihsan
    !date:

*/

//?class
public class BankAccountTester
{
    //?main method
    public static void main(String[] args)
    {

        PersonalChequingAccount perche = new PersonalChequingAccount("Janice Jopline", "March", 2345);
      
        System.out.println(perche.toString());

        //*doing deposits and withdrawls
        perche.setMonth("March");
        perche.deposit(25.98, 5);
        perche.withdrawl(1300, 6);
        perche.withdrawl(1700, 10);
        perche.deposit(1050, 11);
        perche.withdrawl(1700, 11);
        perche.deposit(25.98, 25);
        perche.withdrawl(400, 26);
        perche.withdrawl(27, 28);
        perche.withdrawl(7.50, 28);

        //*calling monthlyprocess with everything done
        perche.monthlyProcess();
    }
}