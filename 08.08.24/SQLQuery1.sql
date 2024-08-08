SELECT * FROM EMP;

--------------STORED PROCEDURE CREATION--------------

CREATE PROCEDURE Employee_name
@EMPNO INT
AS
BEGIN
SELECT ENAME FROM EMP
WHERE EMPNO = @EMPNO
END;

------------------EXECUTION--------------------------

EXEC Employee_name @EMPNO = 7654;

---------------student table creation----------------

CREATE TABLE Students(
stud_id INT PRIMARY KEY NOT NULL,
name VARCHAR(50) NOT NULL,
roll_no INT NOT NULL UNIQUE
);

------stored_procedure to insert data to student table----

CREATE PROCEDURE Stud_data_insert
@id INT,
@name VARCHAR(50),
@rollno INT
AS
BEGIN
INSERT INTO Students (stud_id, name, roll_no)
VALUES (@id,@name,@rollno);
END;

--------execution---------

EXEC Stud_data_insert @id = 1, @name = 'Anugrah', @rollno = 1;

SELECT * FROM Students;