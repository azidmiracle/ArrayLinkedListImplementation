/* -----------EXECERCISE 1A: Checking Notebook--------------
 * STUDENT NAME: EMELY DIAZ
 * STUDENT NUMBER: 2018-30326
 * DATE: MARCH 3, 209
 * 
 * DESCRIPTON
 * In this program, I used windows form to create a program wherein a checker will choose
 * 5 options (add notebook, check notebook, peek notebook, clear notebook and exit).
 * Implement STACK using Arrays
 The top most notebook will be checked first

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

namespace NoteBookApp
{

    public partial class Form1 : Form
    {

        //THESE ARE GLOBAL CONSTANT AND VARIABLES
        static int Array_size;//SET THE SIZE OF THE STACK

        String[] NoteBookArray; //= new String[Array_size];//THIS IS THE ARRAY OF NOTEBOOK

        string inputValue;
        int TopNotebook = 0;//THIS IS MY STACKPOINTER. INITIALLY THE STACK IS EMPTY. SET TopNotebook TO 0

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CreateNotebookStack();//ASK USER TO INPUT THE SIZE OF THE ARRAY.
        }

        public void CreateNotebookStack()
        {
            //CHECK IF THE INPUT IS NUMBER OR NOT
            bool isNumber = int.TryParse(Interaction.InputBox("Please enter the size of the stack."), out Array_size);

            if (isNumber == false)//IF NOT NUMBER
            {
                MessageBox.Show("Not a valid number.");
                CreateNotebookStack();//RECURSION. CALL AGAIN THE SUBROUTINE UNTIL BECOMES TRUE
            }

            else//IF TRUE THEN CREATE THE NOTEBOOK ARRAY
            {
                NoteBookArray = new String[Array_size];//THIS IS THE ARRAY OF NOTEBOOK
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //ask the user the size of stack;
            DisPlayMenu();// DISPLAY THE MENU

        }

        public void DisPlayMenu()//THIS WILL BE CALLED MANY TIMES UNTIL THE USER WILL SELECT EXIT
        {
            //POP UP INPUT BOX FOR THE OPTIONS 1 - 5
            //THEN STORE THE INPUT VALUE IN THE inputValue VARIABLE
            inputValue = Interaction.InputBox("Please Input Number: \n[1] Add Notebook \n[2] Check Notebook \n[3] Peek at Notebook \n[4] Check All \n[5] Exit", "Menu");
            //DELCARE THE OWNER
            string owner;

            // USE SWITCH CASE STATEMENT FOR THE 5 OPTIONS
            switch (inputValue)
            {

                //IF USER INPUT "1"
                case "1":
                    //ASK USER TO INPUT THE NOTEBOOKS OWNER NAME TO BE ADDED
                    owner = Interaction.InputBox("Please type the notebook's owner name:", "Add Note Book");
                    //CALL THIS PROCEDURE PUSH TO INSERT THE OWNER ON TOP OF THE STACK
                    PushNotebook(owner);
                    break;

                case "2":
                    //CALL THIS PROCEDURE POP TO DELETE THE OWNER FROM THE STACK
                    PopNotebook();
                    break;

                case "3":

                    PeekNotebook();//check the top owner in the stack

                    break;

                case "4":
                    CheckAll(NoteBookArray);//check all the notebook in array

                    break;


                case "5"://just exit the menu.
                    MessageBox.Show("You will exit from Notebook.");// I DONOT WANT TO CLEAR THE STACK. 
                    //SO THE OWNERS NAME STILL IN THE STACK. 

                    break;


                default://if input other than number, this will be displayed.
                    MessageBox.Show("Please type a valid number.");
                    DisPlayMenu();
                    break;
            }

        }


        public void PushNotebook( string owner_a)//ADD NOTEBOOK OWNER ON TOP OF THE STACK
        {

            if (TopNotebook >=0 && TopNotebook < Array_size)//IF THE STACK IS NULL, 
            {
                NoteBookArray[TopNotebook] = owner_a.ToUpper();//THEN ADD OWNER TO THE STACK

                MessageBox.Show("You have added successfully.");

                TopNotebook++; // INCREASE THE STACK BY ADD. MEANING THIS IS THE NEXT AVAILABLE STACK
            }

            else//IF STACK IS MORE THAN THE STACK SIZE. 
            {
                MessageBox.Show("Stack overflow. Maximum stack size is " + (Array_size.ToString()));

            }

            DisPlayMenu();//display again the menu
        }

        public void PopNotebook()//REMOVE NOTEBOOK OWNER ON TOP OF THE STACK
        {    

            if (TopNotebook == 0)//IF NOTHING TO REMOVE
            {
                MessageBox.Show("Stack Underflow. Nothing to check from the stack.");
            }

            else//check the notebook from the top
            {    
                TopNotebook = TopNotebook - 1;
                string owner_a = NoteBookArray[TopNotebook];//put it in variable

                //ask user to confirm whether h/she wants to check it
                DialogResult CheckOrNot = MessageBox.Show("You are going to check : \n" + owner_a + "'s notebook. Do you want to check?", "Delete All", MessageBoxButtons.YesNo);

                if (CheckOrNot == DialogResult.Yes)//if yes, then remove the notebook
                {
                   
                    NoteBookArray[TopNotebook] = null;
                    MessageBox.Show(owner_a + "’s notebook is being checked.");
                }
                else//if he will not continue to check, point back the pointer to top by adding 1.
                {
                    TopNotebook = TopNotebook + 1;
                }

            }

            DisPlayMenu();//display again the menu
        }

        public void PeekNotebook()//REMOVE NOTEBOOK OWNER ON TOP OF THE STACK
        {

            if (TopNotebook == 0)//IF NOTHING TO REMOVE
            {
                MessageBox.Show("Stack Underflow.");
            }

            else//check the top owner and display it.
            {

                string owner_a = NoteBookArray[TopNotebook - 1];
                MessageBox.Show("Top notebook's owner: " + owner_a);
            }

            DisPlayMenu();//display again the menu
        }
        public void CheckAll(string[] Notebook)//check from the top
        {

            int i = TopNotebook - 1;//set the starting loop from the top
            string allnotebook = "";
            while (i > -1 && i< TopNotebook)//print out all the names in the stack
            {
                allnotebook = allnotebook + Notebook[i] + "\n";

                i--;
            }

            if (TopNotebook > 0)//ask user if want to delete from stack
            {
                DialogResult CheckOrNot = MessageBox.Show("Do you want to check all notebooks? \n" + allnotebook, "Check All", MessageBoxButtons.YesNo);
                if (CheckOrNot == DialogResult.Yes)
                {
                    NoteBookArray = new String[Array_size];//THIS IS THE ARRAY OF NOTEBOOK
                    TopNotebook = 0;
                    MessageBox.Show("All notebooks have been checked successfully.");
                }

            }

            else
            {
                MessageBox.Show("Stack Underflow.");
            }

            DisPlayMenu();
        }


    }
}
