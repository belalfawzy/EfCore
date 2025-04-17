# EfCore
schema in SQL 
CREATE TABLE Department (
    ID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE School (
    ID INT PRIMARY KEY,
    DepartmentID INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Type NVARCHAR(50),
    FOREIGN KEY (DepartmentID) REFERENCES Department(ID)
);

CREATE TABLE Teacher (
    ID INT PRIMARY KEY,
    SchoolID INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    BirthDate DATE,
    NationalID NVARCHAR(50),
    Code NVARCHAR(50),
    Job NVARCHAR(100),
    Phone NVARCHAR(20),
    Qualification NVARCHAR(100),
    QualificationDate DATE,
    HiringDate DATE,
    Address NVARCHAR(255),
    Notes NVARCHAR(MAX),
    FOREIGN KEY (SchoolID) REFERENCES School(ID)
);

CREATE TABLE TeacherTransfere (
    ID INT PRIMARY KEY,
    TeacherID INT NOT NULL,
    FromSchoolID INT NOT NULL,
    ToSchoolID INT NOT NULL,
    Date DATE NOT NULL,
    FOREIGN KEY (TeacherID) REFERENCES Teacher(ID),
    FOREIGN KEY (FromSchoolID) REFERENCES School(ID),
    FOREIGN KEY (ToSchoolID) REFERENCES School(ID)
);
