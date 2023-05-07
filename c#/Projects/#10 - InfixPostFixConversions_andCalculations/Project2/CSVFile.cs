using Project2;
using System;
using System.Collections.Generic;
using System.IO;

class CSVFile
{
    // list to hold csv data
    private List<Infix> _csvData; 
    //list to hold prefix data
    private List<string> _preFixData;

    //list to hold postfix data
    private List<string> _postFixData;

    //list for infix objects
    public List<Infix> InFix  
    {
        // Returns the private field _csvData
        get 
        { 
            return _csvData; 
        }
        // Sets the private field _csvData to the value passed in
        set 
        { 
            _csvData = value;
        }   
    }

    //;list for prefix string
    public List<string> PreFix
    {
        // Returns the private field _preFixData
        get 
        { 
            return _preFixData; 
        }
        // Sets the private field _preFixData to the value passed in
        set 
        { 
            _preFixData = value; 
        }   
    }

    //list for postfix data
    public List<string> PostFix
    {
        //return the private field _postFixData
        get
        {
            return _postFixData;
        }
        //sets the field _postFixData to a value passed in
        set
        {
            _postFixData = value;
        }
    }


    public CSVFile(string filePath)  
    {
       
        //calls the private CSVDEsearialize method to deserialize the data
        CSVDeserialize(filePath);  
    }

    //method to deserialize the data
    private void CSVDeserialize(string filePath) 
    {
        // Initializes the _csvData list
        _csvData = new List<Infix>();
        // Initializes the _preFixData list
        _preFixData = new ();

        //initialize the _postFixData list
        _postFixData = new();

        // Opens a file stream to read the CSV file
        StreamReader readData = new(filePath);

        
        string line;
        // Reads each line of the CSV file
        while ((line = readData.ReadLine()) != null)   
        {
            // Splits the line into values using ',' as the delimiter
            string[] values = line.Split(',');
            // Retrieves the first value as sno
            string sno = values[0];
            // Retrieves the second value as infix
            string infix = values[1];
            // Creates a new infix object with sno and infix values
            Infix infixObj = new Infix(sno, infix);

            //instancitate a toprefix object to call on 
            ToPreFix toPre = new();

            //instancitate a topostfix object to call on
            ToPostFix toPost = new();

            // Adds the infix object to _csvData list
            _csvData.Add(new Infix(sno, infix));

            // Adds the prefix expression to _preFixData list
            _preFixData.Add(toPre.ToPreFixConverter(infixObj.InfixExpr));

            //adds the postfix expreesion to the _postFixData list
            _postFixData.Add(toPost.ToPostFixConverter(infixObj.InfixExpr));
        }
         
    }
}

 
