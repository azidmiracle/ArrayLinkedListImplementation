/* -----------EXECERCISE 1B: DOCTOR'S CONSULTATION--------------
 * STUDENT NAME: EMELY DIAZ
 * STUDENT NUMBER: 2018-30326
 * DATE: MARCH 3, 2019
 * 
 * DESCRIPTON
 * In this program, I used windows form to create a program for doctor's consultation.
 * 5 options (SIGN-UP, ENTERROOM, CONSULATION, TIME OUT and exit).
 * Implement QUEUES using LinkedList
 

 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace DoctorConsultation
{
    public partial class Form1 : Form
    {
        string inputNumber;

        LinkedList ListofUser;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)

        {
            //display menu

            ListofUser = new LinkedList();//create linkedlist

            DisPlayMenu();// DISPLAY THE MENU
        }

        public void DisPlayMenu()//THIS WILL BE CALLED MANY TIMES UNTIL THE USER WILL SELECT EXIT
        {
            //POP UP INPUT BOX FOR THE OPTIONS 1 - 5
            //THEN STORE THE INPUT VALUE IN THE inputNumber VARIABLE
            inputNumber = Interaction.InputBox("Please Input Number: \n[1] Sign up for doctor’s consultation \n[2] Enter room \n[3] Begin consultation \n[4] Closing time \n[5] Exit", "Menu");
            //DELCARE THE OWNER
            string name;
            string concern;


            // USE SWITCH CASE STATEMENT FOR THE 5 OPTIONS
            switch (inputNumber)
            {

                //IF USER INPUT "1"
                case "1":
                    //ASK USER TO INPUT THE PATIENTS  NAME AND HIS CONCERN
                    name = Interaction.InputBox("Please type the name of consulting person:", "Patient's Sign-up");                  
                    concern = Interaction.InputBox("Please type the nature of the concern.:", "Patient's Sign-up");
                    
                    //CALL THIS PROCEDURE TO INSERT THE NEW PATIENTS NEXT IN LINE.
                    ListofUser.addToNext(ListofUser, name, concern);

                    DisPlayMenu();//DISPLAY THE MENU

                    break;

                case "2":
                    //JUST DISPLAY THE NEXT PATIENT
                    ListofUser.CheckNextPatient(ListofUser);
                    DisPlayMenu();
                    break;

                case "3":
                    ListofUser.ConsultPatient(ListofUser);//PATIENT IN CONSULATION
                    DisPlayMenu();
                    break;

                case "4":
                    ListofUser.FreeUpQueue(ListofUser);//CLEAR THE LIST OF PATIENTS
                    DisPlayMenu();
                    break;


                case "5"://EXIT THE MENU           
                    break;

                default:
                    MessageBox.Show("Please type a valid number.");
                    DisPlayMenu();
                    break;

            }

        }

    }
}
