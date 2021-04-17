using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Software_Engineering_Project
{
    class CreateAccount
    {
        String firstName;
        String lastName;
        String email;
        String passwordPreHash;
        String confirmPasswordPreHash;
        String address;
        String city;
        String state;
        long phoneNumber;
        int age;
        long creditCardNumber;
        int unqiueID;
        MainWindow mainWindow; //MainWindow.xaml is started when project is started. May not need new instance.
        void create_account_onClick()
        {

            //Textbox fname = Application.OpenForms["Form1"].Controls["FirstName"] as TextBox; //might not work, this might be WinForms syntax (not WPF)
                                                                                             //maybe use this in the button click action in the CreateAcctWindow.cs?
            //firstName = CreateAccountWindow.usrBox.Text; //user inputs from textfield

            //lastName = input2;
            //email = input3;
            //address = input4;
            //city = input5;
            //state = input6;
            //phoneNumber = input7;
            //age = input8;
            /*creditCardNumber = input9;
            passwordPreHash = input10;
            confirmPasswordPreHash = input11;

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

                //HASH FOR PASSWORDS - we can probably make this a separate method real easy, and use it for getting hashed strings out easy for both acct gen and pwd compare.

                using (SHA512 sha512hash = SHA512.Create())
                {
                    byte[] sourcePwdBytes = Encoding.UTF8.GetBytes(passwordPreHash); //hash can only be done on string of bytes
                    byte[] hashBytes = sha512hash.ComputeHash(sourcePwdBytes);
                    string hashedPwd = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                }


                //END PASSWORD HASH


                //Initialize UserAccountObj with passed information;
                //Send user object to dictionary;
                //Prompt user with their created 6 digit ID they will use for signing in;
                    //Are we using 6 digit ID? -P
                //remind user to commit their 6 digit ID to memory
                //Return user to login screen;
            */
            
        }
    }
}
