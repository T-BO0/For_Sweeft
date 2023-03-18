﻿use skola;

Create Table Teacher (
   teacher_id Int Primary Key,
   first_name VARCHAR(50),
   last_name VARCHAR(50),
   gender VARCHAR(10),
   subject VARCHAR(50)
);

Create Table Pupil (
   pupil_id int Primary Key,
   first_name VARCHAR(50),
   last_name VARCHAR(50),
   gender VARCHAR(10),
   class VARCHAR(50)
);

Create Table Teacher_Pupil (
   teacher_id int,
   pupil_id int,
   Constraint PK_Teacher_Pupil Primary Key (teacher_id, pupil_id),
   Constraint FK_Teacher Foreign Key (teacher_id) REFERENCES Teacher (teacher_id),
   Constraint FK_Pupil Foreign Key (pupil_id) REFERENCES Pupil (pupil_id)
);

Select * From Teacher
Inner Join Teacher_Pupil on Teacher.teacher_id = Teacher_Pupil.teacher_id
Inner Join Pupil ON Pupil.pupil_id = Teacher_Pupil.pupil_id
Where Pupil.first_name = 'გიორგი';