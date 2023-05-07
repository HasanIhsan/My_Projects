using System.Text;

public class Infix
{
    //getting the sno and infix expressions form the reader 
    public string Sno { get; set; }
    public string InfixExpr { get; set; }

    //assigning the values gotten
    public Infix(string sno, string infix)
    {
        Sno = sno;
        InfixExpr = infix;
    }

   

}
