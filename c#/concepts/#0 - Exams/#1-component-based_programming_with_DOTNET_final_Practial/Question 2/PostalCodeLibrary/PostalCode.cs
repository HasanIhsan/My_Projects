/*
 * Program:         PostalCodeLibrary.dll
 * Module:          PostalCode.cs
 * Author:          T. Haworth
 * Date:            Feb 16, 2023
 * Description:     Defines a PostalCode class that provides some basic services 
 *                  related to Canadian postal codes.
 */

using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;
namespace PostalCodeLibrary
{
    [Serializable]
    public class PostalCode
    {
        public Application AppWord = new();
        // ---------------- Private Member variables -----------------

        private string originalCode = "", formattedCode = "";
        private bool valid = false;

        // --------------------- Public Methods ----------------------

        public string GetOriginalCode()
        {
            return originalCode;
        } // end GetOriginalCode()

        public string GetFormattedCode()
        {
            return formattedCode;
        } // end GetFormattedCode()


        public void SetCode(string value)
        {
            // Initialize pcode
            originalCode = value;
            formattedCode = "ERROR";

            // Process the number
            Validate();
        } // end SetCode()

        public bool IsValid()
        {
            return valid;
        } // end IsValid()


        // ---------------------- Helper Methods ----------------------

        // Validates and formats the postal code 
        private void Validate()
        {
            // Remove irrelevant characters
            Regex illegalChars = new ("[^a-zA-Z0-9]");
            string code = illegalChars.Replace(originalCode, "");

            // Vaidate remaining characters
            Regex patternCheck = new (@"^[A-Za-z]\d[A-Za-z]\d[A-Za-z]\d$");
            if (valid = patternCheck.IsMatch(code))
            {
                // Format the postal code
                var codeItems = code.ToList<char>();
                codeItems = codeItems.Select(c => Char.ToUpper(c)).ToList();
                codeItems.Insert(3, ' ');
                formattedCode = string.Join("", codeItems);
            }

            
        } // end validate()


        public void Dispose()
        {
            AppWord.Quit();
        }
    }
}