/*  
    Program Name: Roman
    Purpose: this program converts roman to arabic and vise versa
    Programmer: Hassan Ihsan
        
        REMINDER!: The program is not properly working... once the project is done, try to see 
                    if you can complete it.
        
*/


#include <stdio.h>
#include <conio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

//varibles
char userinput[100], ch[100];
int  length, i, j, Number, num1, num2, num3, num4, mul = 1000;
float k;
double a[100];

int main()
{



    //while loop
    while (strcmp(userinput, "quit") != 0)
    {
        //userinput
        printf("\n Enter a roman or arabic value: ");
        scanf_s("%s", userinput, 100);//scanner

        /*if statement see if is a digit or not*/
        if (isdigit(userinput[0])) {
            sscanf_s(userinput, "%d", &Number);


            num1 = Number / 1000 % 10;

            num2 = Number / 100 % 10;

            num3 = Number / 10 % 10;

            num4 = Number / 1 % 10;

            
            printf("%d is ",  Number);

           
            //for the 1000s goes up to 9000
            switch (num1) {
                case 1: printf("M");
                    break;
                case 2: printf("MM");
                    break;
                case 3: printf("MMM");
                    break;
                case 4: printf("IV_");
                    break;
                case 5: printf("V_");
                    break;
                case 6: printf("VI_");
                    break;
                case 7: printf("VII_");
                    break;
                case 8: printf("VIII_");
                    break;
                case 9: printf("IX_");
                    break;
            }
            //for the 100s goes up to 900
            switch (num2) {
                case 1: printf("C");
                    break;
                case 2: printf("CC");
                    break;
                case 3: printf("CCC");
                    break;
                case 4: printf("CD");
                    break;
                case 5: printf("D");
                    break;
                case 6:printf("DC");
                    break;
                case 7:printf("DCC");
                    break;
                case 8:printf("DCC");
                    break;
                case 9:printf("CM");
                    break;
            }
            //for the 10s goes up to 90
            switch (num3) {
                case 1: printf("X");
                    break;
                case 2: printf("XX");
                    break;
                case 3: printf("XXX");
                    break;
                case 4: printf("XL");
                    break;
                case 5: printf("L");
                    break;
                case 6:printf("LX");
                    break;
                case 7:printf("LXX");
                    break;
                case 8:printf("LXX");
                    break;
                case 9:printf("XC");
                    break;
            }
            //for the 1s goes up to 9
            switch (num4) {
            
                case 1: printf("I");
                    break;
                case 2: printf("II");
                    break;
                case 3: printf("III");
                    break;
                case 4: printf("IV");
                    break;
                case 5: printf("V");
                    break;
                case 6:printf("VI");
                    break;
                case 7:printf("VII");
                    break;
                case 8:printf("VIII");
                    break;
                case 9:printf("IX");
                    break;
            }
        }
        //if the number is not a digit aka a char
        else {
        /* strlen function counts the number of characters in a given 
        string and returns the integer value.*/
            length = strlen(userinput);
            //for loop
            for (i = 0; i < length; i++)
            {
                //get whatever the user enter to uppcase 
                ch[i] = toupper(userinput[i]);

                //not properly working
                if (ch[i] == 'I')
                {
                    a[i] = 1;
                }

                else if (ch[i] == 'V')
                {
                    a[i] = 5;
                }

                else if (ch[i] == 'X')
                {
                    a[i] = 10;
                }
                
                else if (ch[i] == 'L')
                {
                    a[i] = 50;
                }
                
                else if (ch[i] == 'C')
                {
                    a[i] = 100;
                }
                
                else if (ch[i] == 'D')
                {
                    a[i] = 500;
                }
                
                else if (ch[i] == 'M')
                {
                    a[i] = 1000;
                }
                
                else if (ch[i] == '_')
                {
                    a[i] = 1000;
                }
                
                else if (ch[i] == 'S')
                {
                    a[i] = 0.5;
                }

                else if (ch[i] == '-')
                {
                    a[i] * mul;
                }
                
                else if (ch[i] == '.')
                {
                    a[i] = 0.8;
                }

            }
            //calculates the decimal value
            k = a[length - 1];
            for (i = length - 1; i > 0; i--)
            {
                if (a[i] > a[i - 1])
                {
                    k = k - a[i - 1];
                }
                else if (a[i] == a[i - 1] || a[i] < a[i - 1])
                {
                    k = k - a[i - 1];
                }

            }
            printf("%s is %g\t", userinput, k);
        }

    }




    return 0;
}



