using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week4AssessmentApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4AssessmentApp.Tests
{
    [TestClass()]
    public class PrescriptionServiceTests
    {

        [TestMethod()]
        public void SortTest()
        {
            Prescription[] prescriptions = new Prescription[4];
            PrescriptionService.Read(prescriptions);
            Prescription expected = new Prescription
            {
                PrescriptionId = 2,
                PatientName = "Cena",
                MedicationName = "Avilin",
                Dosage = 1
            };
            PrescriptionService.Sort(prescriptions);
            Prescription actual = prescriptions[0];
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod()]
        public void FindMaxTest()
        {
            Prescription[] prescriptions = new Prescription[4];
            PrescriptionService.Read(prescriptions);
            Prescription expected = new Prescription
            {
                PrescriptionId = 3,
                PatientName = "Ortan",
                MedicationName = "Septilin",
                Dosage = 3
            };
            Prescription actual = PrescriptionService.FindMax(prescriptions);
            Assert.AreEqual(expected.ToString(), actual.ToString());
            
        }

        [TestMethod()]
        public void FindThirdMinTest()
        {
            Prescription[] prescriptions = new Prescription[4];
            PrescriptionService.Read(prescriptions);
            Prescription expected = new Prescription
            {
                PrescriptionId = 1,
                PatientName = "John",
                MedicationName = "Paracetamol",
                Dosage = 2.5
            };
            Prescription actual = PrescriptionService.FindThirdMin(prescriptions);
            Assert.AreEqual(expected.ToString(), actual.ToString());
            
        }
    }
}