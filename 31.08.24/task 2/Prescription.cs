using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Prescription
    {
        public int PrescriptionId;
        public string PatientName;
        public string MedicationName;
        public float Dosage;

        public Prescription(int _id, string _name, string _mname, float _dosage)
        {
            PrescriptionId = _id;
            PatientName = _name;
            MedicationName = _mname;
            Dosage = _dosage;
        }

        public override string ToString()
        {
            return $"[id={PrescriptionId}, PatientName={PatientName}, MedicationName={MedicationName}, Dosage={Dosage}]";
        }
    }
}
