using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_Project
{
    class CreateAccount
    {
        String firstName;
        String lastName;
        String email;
        String passwordHash;
        String confirmPasswordHash;
        String address;
        String city;
        String state;
        long phoneNumber;
        int age;
        long creditCardNumber;
        int unqiueID;
        MainWindow mainWindow;
        void create_account_onClick()
        {
            firstName = mainWindow.usrBox.Text; //user inputs from textfield
            lastName = input2;
            email = input3;
            address = input4;
            city = input5;
            state = input6;
            phoneNumber = input7;
            age = input8;
            creditCardNumber = input9;
            passwordHash = input10;
            confirmPasswordHash = input11;

            if(passwordHash != confirmPasswordHash)
                {
                //Prompt user to go back and retry creating a password;
            
            }else if (firstName == null || lastName == null || email == null || address == null || city == null ||
                state == null || phoneNumber == 0 || age == 0 || 
                creditCardNumber == 0 || passwordHash == null || confirmPasswordHash == null)
            {
                //Prompt user to go back and fill in required fields;
            }
            else
            {
                //Initialize UserAccountObj with passed information;
                //Send user object to database;
                //Prompt user with their created 6 digit ID they will use for signing in;
                //remind user to commit their 6 digit ID to memory
                //Return user to login screen;
            }
        }
    }
}
