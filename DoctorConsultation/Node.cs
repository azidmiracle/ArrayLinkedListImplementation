using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorConsultation
{
    public class Node//create a node
    {
        public Patient Patient;//node has data of patient
        public Node Next;//address of next node

        public Node(string aName, string aPatientsConcern)
        {
            Patient = new Patient(aName, aPatientsConcern);//patient has name and his concers

            Next = null;//if first patient, no data for next

        }

    }
}
