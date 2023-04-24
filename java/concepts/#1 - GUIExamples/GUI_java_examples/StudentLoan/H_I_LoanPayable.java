
interface H_I_LoanPayable 
{
     double ANNUAL_RATE_TO_MONTHLY_RAT = 8.33;

    public abstract void  calculateLoanPayment(double OSL, double CSL, double annualprimeinterrestrate, int months);

}