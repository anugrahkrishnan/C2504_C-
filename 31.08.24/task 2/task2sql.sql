create database task2

use task2

CREATE TABLE Prescription 
(
PrescriptionId INT PRIMARY KEY IDENTITY(1,1),
PatientName VARCHAR(50) NOT NULL,
MedicationName VARCHAR(50) NOT NULL,
Dosage FLOAT(2) NOT NULL
)


INSERT INTO Prescription 
(PatientName, MedicationName, Dosage) 
VALUES
('John', 'Paracetamol', 2.50),
('Cena', 'Avilin', 1.00),
('Ortan', 'Septilin', 3.00)



SELECT * FROM Prescription