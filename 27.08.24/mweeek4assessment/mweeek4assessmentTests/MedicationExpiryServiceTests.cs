using Microsoft.VisualStudio.TestTools.UnitTesting;
using mWeek4AssessmentApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mWeek4AssessmentApp.Tests
{
    [TestClass()]
    public class MedicationExpiryServiceTests
    {
        [TestMethod()]
        public void FindMin_Test()
        {
            MedicationExpiry[] medicationExpiries = new MedicationExpiry[3];
            MedicationExpiryService.Read(medicationExpiries);
            MedicationExpiry expected = new MedicationExpiry
            {
                BatchID = 3,
                Medication = "Halls",
                ExpiryDate = DateTime.Parse("2025-05-31")
            };
            MedicationExpiry actual = MedicationExpiryService.FindMin(medicationExpiries);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod()]
        public void FindSecondMax_Test()
        {
            MedicationExpiry[] medicationExpiries = new MedicationExpiry[3];
            MedicationExpiryService.Read(medicationExpiries);
            MedicationExpiry expected = new MedicationExpiry
            {
                BatchID = 2,
                Medication = "Vicks",
                ExpiryDate = DateTime.Parse("2025-11-20")
            };
            MedicationExpiry actual = MedicationExpiryService.FindSecondMax(medicationExpiries);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod()]
        public void Sort_Test()
        {
            MedicationExpiry[] medicationExpiries = new MedicationExpiry[3];
            MedicationExpiryService.Read(medicationExpiries);
            MedicationExpiry expected = new MedicationExpiry
            {
                BatchID = 3,
                Medication = "Halls",
                ExpiryDate = DateTime.Parse("2025-05-31")
            };
            MedicationExpiryService.Sort(medicationExpiries);
            MedicationExpiry actual = medicationExpiries[0];
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}