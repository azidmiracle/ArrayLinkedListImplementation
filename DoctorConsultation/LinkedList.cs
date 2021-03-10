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
    public class LinkedList//A LINKEDLIST HAS HEAD AND TAIL
    {
        public Node Head;//THE IS THE FIRST IN LINE
        public Node Tail;//LAST IN LINE
        Node current;//to be access in later use

      public void addToNext(LinkedList LinkedList_, string aPatient, string aPatientsConcern)
        {
            if (LinkedList_.Head == null)//if no head, insert the new patient first in line
            {
                Node HeadPatient = new Node(aPatient, aPatientsConcern);//create a node
                LinkedList_.Head = HeadPatient;//this is the head since it is the first patient,
                LinkedList_.Tail = HeadPatient;//this is the tail since it is the first patient,
                MessageBox.Show("PATIENT ADDED SUCCESSFULLY.");
                //set pointer to next

            }
            else//if there is existing patient in the queue
            {
                current = LinkedList_.Tail;// temp name. get the last patient in the queue

                Node NewPatient= new Node(aPatient, aPatientsConcern);//add new patient

                current.Next = NewPatient;//set the NEXT of current tail= address of the newly added patient
                

                LinkedList_.Tail = NewPatient;//set the new patient as the NEW TAIL

                MessageBox.Show("PATIENT ADDED SUCCESSFULLY." + NewPatient.Patient.Name);


            }
        }

        public void CheckNextPatient(LinkedList LinkedList_)//SHOW THE NEXT PATIENT
        {
            if (LinkedList_.Head == null)//IF NO PAIIENT
            {
                MessageBox.Show("NO PATIENT.");
                //set pointer to next
            }
            else//JUST DISPLAY THE NAME
            {
                MessageBox.Show(LinkedList_.Head.Patient.Name+ " ,PLEASE ENTER ROOM.","Enter Room");
            }
        }
        public void ConsultPatient(LinkedList LinkedList_)
        {
            if (LinkedList_.Head == null)//IF NO PAIIENT
            {
                MessageBox.Show("NO PATIENT.");
                
            }
            else//display the name and delete from the queue
            {
                MessageBox.Show("PATIENT " + LinkedList_.Head.Patient.Name + "\n NATURE OF CONCERN:" +LinkedList_.Head.Patient.Concern ,"Begin Consultation" );


                if (LinkedList_.Head.Next != null)// check if there is no next patient in line
                {
                    Node Newhead = LinkedList_.Head.Next;//save temporarily the next patients address

                    LinkedList_.Head = null;//delete the curernt head

                    LinkedList_.Head = Newhead;//set the next patient to be the new head

   
                }
                else//just make the one head =null
                {
                    LinkedList_.Head = null;
                }
 

            }
        }

        public void FreeUpQueue(LinkedList LinkedList_)
        {
            if (LinkedList_.Head == null)//if nothing to free up the queue
            {
                MessageBox.Show("NO PATIENT.");
            }
            else
            {
                DeletePatients(LinkedList_);//call another subroutine to clear the entire list

            }
        }


        public void DeletePatients(LinkedList  LinkedList_)
        {


        //double confirm the user whether he/she wants to delete the queue
        DialogResult DeleteOrNot = MessageBox.Show("Do you want free up the whole queue? ","Time Closing",MessageBoxButtons.YesNo);
        if (DeleteOrNot == DialogResult.Yes)//do this if yes
            {

                Node currentHead = LinkedList_.Head;

                while (currentHead != null)//while the value of head is not null (still have patients data)
                {

                    Node temp = currentHead;//save the current head address to temp variable;

                    LinkedList_.Head = null;//clear the head

                    currentHead = temp.Next;//move to next head

                }

                MessageBox.Show("Deleted Succesfully");
            }

        }

    }
}
