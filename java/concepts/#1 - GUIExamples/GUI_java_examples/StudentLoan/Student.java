/*
!program name: Student
*purpose: this is the background of the program
*programmer: hassan 


*/
import java.util.ArrayList;

import java.awt.*;
import javax.swing.*;
import javax.swing.BorderFactory;
import java.awt.event.*;

public class Student 
{

    private String studentID;
    private String surname;
    private String middleName;
    private String firstName;
    private String aptNumber;
    private String streetNumber;
    private String streetName;
    private String city;
    private String province;
    private String postalCode;
    private double cslLoanAmount;
    private double oslLoanAmount;


    public Student(String studentID, String surname, String middleName, String firstName, String aptNumber, String streetnumber, String streetName,
                   String city, String province, String postalCode, double cslLoanAmount, double oslLoanAmount)
    {
          this.studentID = studentID;
          this.surname = surname;
          this.middleName = middleName;
          this.firstName = firstName;
          this.aptNumber = aptNumber;
          this.streetNumber = streetnumber;
          this.streetName = streetName;
          this.city = city;
          this.province = province;
          this.postalCode = postalCode;
          this.cslLoanAmount = cslLoanAmount;
          this.oslLoanAmount = oslLoanAmount;          
    }
    

    //getters
    public String getstudentID()
    {
        return studentID;
    }
    public String getsurname()
    {
        return surname;
    }


    public String getmiddleName()
    {
        return middleName;
    }

    public String getfirstName()
    {
        return firstName;
    }

    public String getaptNumber()
    {
        return aptNumber;
    }

    public String getstreetNumber()
    {
        return streetNumber;
    }

    public String getstreetName()
    {
        return streetName;
    }

    public String getcity()
    {
        return city;
    }

    public String getprovince()
    {
        return province;
    }
    
    public String getpostalCode()
    {
        return postalCode;
    }

    public double getcslLoanAmount()
    {
        return cslLoanAmount;
    }

    public double getoslLoanAmount()
    {
        return oslLoanAmount;
    }

    //setters
    public void setsurname(String surname)
    {
        this.surname = surname;
    }


    public void  setmiddleName(String middlename)
    {
        this.middleName = middlename;
    }

    public void setfirstName(String firstname)
    {
        this.firstName = firstname;
    }

    public void settaptNumber(String aptnumber)
    {
        this.aptNumber = aptnumber;
    }

    public void setstreetNumber(String streetnumber)
    {
        this.streetNumber = streetnumber;
    }

    public void setstreetName(String streetname)
    {
        this.streetName = streetname;
    }

    public void setcity(String City)
    {
        this.city = City;
    }

    public void setprovince(String Province)
    {
        this.province = Province;
    }
    
    public void setpostalCode(String postalcode)
    {
        this.postalCode = postalcode;
    }

    public void setcslLoanAmount(double cslloanamount)
    {
        this.cslLoanAmount = cslloanamount;
    }

    public void setoslLoanAmount(double oslloanamoubt)
    {
        this.oslLoanAmount = oslloanamoubt;
    }


    public String toString()
    {
        return "Student Name: " + firstName + " " + middleName + " " + surname + 
                "\nStudent Number: " + " " + studentID + 
                "\nCSL Amount: " + " " + cslLoanAmount + 
                "\nOSL Amount: " + " " + oslLoanAmount;
    }


 
    


}