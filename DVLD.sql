

Use DVLD;

USE DVLD;
GO
ALTER AUTHORIZATION ON DATABASE::DVLD TO sa;
GO

----------------------------------------------------------------------------------------------





select *from LocalDrivingLicenseApplications





select COUNT(Tests.TestID) as Trial from Tests inner join TestAppointments on TestAppointments.TestAppointmentID= Tests.TestAppointmentID
where TestAppointments.LocalDrivingLicenseApplicationID =7033 and Tests.TestResult=0 and TestAppointments.TestTypeID=2



select *from TestTypes

select *from Applications

select *from ApplicationTypes



select *from TestAppointments


select TestID From Tests where TestAppointmentID=@TestAppointmentID;



create  view TestAppointments_View_By_Mustafa
as select TestAppointments.TestAppointmentID, TestAppointments.LocalDrivingLicenseApplicationID, TestTypes.TestTypeTitle, LicenseClasses.ClassName, TestAppointments.AppointmentDate
, TestAppointments.PaidFees,     FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName,
TestAppointments.IsLocked from TestAppointments inner join LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =TestAppointments.LocalDrivingLicenseApplicationID
inner join Applications on Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID
inner join People on People.PersonID =Applications.ApplicantPersonID
inner join LicenseClasses on LicenseClasses.LicenseClassID =LocalDrivingLicenseApplications.LicenseClassID
inner join TestTypes on TestTypes.TestTypeID=TestAppointments.TestTypeID;
order by TestAppointmentID Asc





select* from TestAppointments_View;

select* from TestAppointments_View_By_Mustafa
order by AppointmentDate Desc;



select TestAppointmentID, AppointmentDate,PaidFees,IsLocked from TestAppointments
where (TestTypeID=@TestTypeID) And LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
order by TestAppointmentID Desc;


select* from TestAppointments
order by TestAppointmentID Asc





SELECT 
    LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, 
    LicenseClasses.ClassName,  
    People.NationalNo,   
    FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName,
    Applications.ApplicationDate,  
    Applications.PaidFees, 
    
    -- Õ”«» ⁄œœ «·«Œ »«—«  «·‰«ÃÕ… ›ﬁÿ ﬂ⁄œœ ’ÕÌÕ (INT)
    PassedTests = (
        SELECT COUNT(DISTINCT TestAppointments.TestTypeID)
        FROM Tests 
        INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
        WHERE TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
        AND Tests.TestResult = 1
    ),

    CASE
        WHEN Applications.ApplicationStatus = 1 THEN 'New'
        WHEN Applications.ApplicationStatus = 2 THEN 'Cancelled'
        WHEN Applications.ApplicationStatus = 3 THEN 'Completed' 
    END AS ApplicationStatus

FROM Applications 
INNER JOIN Users ON Applications.CreatedByUserID = Users.UserID 
INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID 
INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID;



select* from LocalDrivingLicenseApplications_View;

SELECT dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, dbo.LicenseClasses.ClassName, dbo.People.NationalNo, dbo.People.FirstName + ' ' + dbo.People.SecondName + ' ' + ISNULL(dbo.People.ThirdName, '') 
                  + ' ' + dbo.People.LastName AS FullName, dbo.Applications.ApplicationDate,
                      (SELECT COUNT(dbo.TestAppointments.TestTypeID) AS PassedTestCount
                       FROM      dbo.Tests INNER JOIN
                                         dbo.TestAppointments ON dbo.Tests.TestAppointmentID = dbo.TestAppointments.TestAppointmentID
                       WHERE   (dbo.TestAppointments.LocalDrivingLicenseApplicationID = dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID) AND (dbo.Tests.TestResult = 1)) AS PassedTestCount, 
                  CASE WHEN Applications.ApplicationStatus = 1 THEN 'New' WHEN Applications.ApplicationStatus = 2 THEN 'Cancelled' WHEN Applications.ApplicationStatus = 3 THEN 'Completed' END AS Status
FROM     dbo.LocalDrivingLicenseApplications INNER JOIN
                  dbo.Applications ON dbo.LocalDrivingLicenseApplications.ApplicationID = dbo.Applications.ApplicationID INNER JOIN
                  dbo.LicenseClasses ON dbo.LocalDrivingLicenseApplications.LicenseClassID = dbo.LicenseClasses.LicenseClassID INNER JOIN
                  dbo.People ON dbo.Applications.ApplicantPersonID = dbo.People.PersonID


select  Applications.ApplicationID , Applications.ApplicationDate, LicenseClasses.ClassName, Applications.PaidFees, Users.UserName,
case
when Applications.ApplicationStatus =1 then 'New'
when Applications.ApplicationStatus =2 then 'Cancelled'
when Applications.ApplicationStatus =3 then 'Completed' end as ApplicationStatus
from Applications inner join Users on Applications.CreatedByUserID =Users.UserID inner join LocalDrivingLicenseApplications on Applications.ApplicationID =LocalDrivingLicenseApplications.ApplicationID
inner join LicenseClasses on LocalDrivingLicenseApplications.LicenseClassID =LicenseClasses.LicenseClassID


SELECT ActiveApplicationID=ApplicationID FROM Applications WHERE ApplicantPersonID = 1 and ApplicationTypeID=1 and ApplicationStatus=1;


select* from Applications;


SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = 9029
                            and ApplicationTypeID=1 
							and LocalDrivingLicenseApplications.LicenseClassID = 1
                            and ApplicationStatus=1;


select* from LocalDrivingLicenseApplications;


select* from LicenseClasses;

select* from People;



select* from Users;



select* from DetainedLicenses;


select *from DetainedLicenses ˆ;

select *from Users;


select *from Applications;

select *from InternationalLicenses;

select *from LicenseClasses;
select *from ApplicationTypes;


select *from Licenses;

select *from People;


select Found =1 from InternationalLicenses 
where DriverID =@DriverID;

select* from DetainedLicenses;


select DetainedLicenses.DetainID as 'D ID', DetainedLicenses.LicenseID as 'L ID', DetainedLicenses.DetainDate as 'D Date', DetainedLicenses.IsReleased, DetainedLicenses.FineFees, DetainedLicenses.ReleaseDate
, People.NationalNo as 'N No', 'Full Name' =People.FirstName+' '+ People.SecondName+' '+ISNULL(People.ThirdName, '')+' '+People.LastName, DetainedLicenses.ReleaseApplicationID as 'Release App ID'
from DetainedLicenses inner join Licenses on Licenses.LicenseID =DetainedLicenses.LicenseID 
inner join Drivers on Drivers.DriverID =Licenses.DriverID
inner join People on People.PersonID =Drivers.PersonID
order by DetainedLicenses.DetainID desc

select Drivers.DriverID, Drivers.PersonID, FullName =People.FirstName+' '+ People.SecondName+' '+ISNULL(People.ThirdName, '')+' '+People.LastName,
Drivers.CreatedDate, Licenses.IsActive as ActiveLicense from Drivers
inner join Licenses on Drivers.DriverID =Licenses.DriverID 
inner join People on Drivers.PersonID =People.PersonID 


select Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
from Licenses inner join LicenseClasses on Licenses.LicenseClass =LicenseClasses.LicenseClassID
inner join Drivers on Drivers.DriverID =Licenses.DriverID 
inner join People on People.PersonID =Drivers.PersonID 
where People.PersonID=@PersonID;



select *from Licenses;

select *from DetainedLicenses;

select *from DetainedLicenses;



select Found=1 from DetainedLicenses 
where IsReleased=0 and LicenseID =@LicenseID






select *from Drivers;
select *from LicenseClasses;

select *from Applications;




select *from TestAppointments
select *from Tests
select *from LocalDrivingLicenseApplications



select top 1 Tests.TestResult from Tests inner join TestAppointments on Tests.TestAppointmentID= TestAppointments.TestAppointmentID
where
TestAppointments.TestTypeID =1
 and TestResult =1;


 SELECT TOP 1 Found=1 FROM Tests 
INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
  AND TestAppointments.TestTypeID = @TestTypeID
  AND Tests.TestResult = 1;


select Tests.TestResult from Tests inner join TestAppointments on Tests.TestAppointmentID= TestAppointments.TestAppointmentID
inner join LocalDrivingLicenseApplications on  TestAppointments.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID
inner join TestTypes on TestAppointments.TestTypeID =@TestTypeID
where TestResult =1;




select Tests.TestResult from Tests inner join TestAppointments on Tests.TestAppointmentID= TestAppointments.TestAppointmentID
inner join LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
inner join TestTypes on TestTypes.TestTypeID= TestAppointments.TestTypeID
where TestResult =1;




--«Ã—« „Œ“‰ 

CREATE PROCEDURE [dbo].[SP_AddNewTest]
    @TestAppointmentID INT,
    @TestResult BIT,
    @Notes NVARCHAR(500),
    @CreatedByUserID INT,
    @TestID INT OUTPUT
AS
BEGIN
    -- 1. Õ›Ÿ ‰ ÌÃ… «·«Œ »«— ›Ì ÃœÊ· Tests
    INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
    VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);

    SET @TestID = SCOPE_IDENTITY();

    -- 2. ﬁ›· «·„Ê⁄œ  ·ﬁ«∆Ì« ›Ì ÃœÊ· TestAppointments
    UPDATE TestAppointments
    SET IsLocked = 1
    WHERE TestAppointmentID = @TestAppointmentID;
END


select *from TestAppointments








select *from TestTypes







select *from Tests

select *from TestAppointments;

select TestAppointments.TestAppointmentID, TestAppointments.AppointmentDate, TestAppointments.PaidFees, TestAppointments.IsLocked
from TestAppointments where TestAppointments.LocalDrivingLicenseApplicationID=30



select TestAppointments.TestAppointmentID, TestAppointments.AppointmentDate, TestAppointments.PaidFees, TestAppointments.IsLocked
from TestAppointments where TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID









select *from Applications

select *from ApplicationTypes








select *from LicenseClasses

select *from Applications
select *from Drivers



select IsFound=1 from Applications where ApplicationStatus in (1,3);

select* from TestTypes
select* from TestAppointments
select* from LocalDrivingLicenseApplications
select* from Applications
select* from ApplicationTypes


select* from Tests


select COUNT(Tests.TestID) as PassedTest from Tests
where TestResult =1  and TestAppointmentID =65;

select COUNT(DISTINCT TestAppointments.TestTypeID) as PassedTest	 from TestAppointments
inner join Tests on TestAppointments.TestAppointmentID =Tests.TestAppointmentID 
where TestAppointments.LocalDrivingLicenseApplicationID=30 and TestResult =1;


select COUNT(Tests.TestID) as Trial from Tests inner join TestAppointments on TestAppointments.TestAppointmentID= Tests.TestAppointmentID
where TestAppointments.LocalDrivingLicenseApplicationID =30 and Tests.TestResult=0 and TestAppointments.TestTypeID=1;


select COUNT(Tests.TestID) as Trial from Tests inner join TestAppointments on TestAppointments.TestAppointmentID= Tests.TestAppointmentID
where TestAppointments.LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and Tests.TestResult=0 and TestAppointments.TestTypeID=@TestTypeID;



-------------------------------


select users.UserID, users.PersonID, FullName = People.FirstName +' '+  People.SecondName+ ' '+ ISNULL(People.ThirdName, '') +' '+ People.LastName, 
 users.UserName, users.IsActive from Users   inner join People on Users.PersonID =People.PersonID;



select* from People;

select* from ApplicationTypes;

select* from Applications;



select* from TestAppointments;




alter table TestAppointments
Add constraint RetakeTestApplicationID foreign key(RetakeTestApplicationID) references Applications(ApplicationID);

select* from People;





----IN C# Find

select* from Users Where UserID=1;

----IN C# Add

insert into Users (PersonID, UserName,Password,IsActive) values (@PersonID, @UserName, @Password,@IsActive); select SCOPE_IDENTITY();

----IN C# Update

update Users set PersonID=@PersonID, UserName=@UserName, Password=@Password,IsActive=@IsActive where UserID=@UsersID; 

----IN C# Delete

delete from Users where UserID=@UserID;

----IN C# Show All List Table

select* from Users;

----IN C# Is Exit

select Found=1 from Users where UserID =@UserID;





------

select* from Users Where UserID=1;

insert into Users (PersonID, UserName,Password,IsActive) values (@PersonID, @UserName, @Password,@IsActive); select SCOPE_IDENTITY();


update Users set PersonID=@PersonID, UserName=@UserName, Password=@Password,IsActive=@IsActive where UserID=@UsersID; 


delete from Users where UserID=@UserID;

select* from Users;

select Found=1 from Users where UserID =@UserID;




---------

select* from People;

select* from Users;


select* from Countries;

select* from ApplicationTypes;


select* from LicenseClasses;


select* from TestTypes;




--
select* from Applications;

select* from LocalDrivingLicenseApplications;


select* from TestAppointments;


select* from Tests;

--


select* from Drivers;
select* from Licenses;
select* from DetainedLicenses;
select* from InternationalLicenses;




----

select* from People;



select  People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, 
Case 
when Gendor =0 then 'Male'
else 'Famale' end as GenderCaption,
People.Address, People.Phone, People.Email, People.NationalityCountryID,Countries.CountryName, People.ImagePath
from People inner join Countries on People.NationalityCountryID =Countries.CountryID
order by People.FirstName





select  Applications.ApplicationID , People.NationalNo,  LicenseClasses.ClassName, 
FullName = People.FirstName +' '+  People.SecondName+ ' '+ ISNULL(People.ThirdName, '') +' '+ People.LastName,
Applications.ApplicationDate,  Applications.PaidFees, PassedTests= Tests.TestResult,
case
when Applications.ApplicationStatus =1 then 'New'
when Applications.ApplicationStatus =2 then 'Cansled'
when Applications.ApplicationStatus =3 then 'Completed' end as ApplicationStatus
from Applications inner join Users on Applications.CreatedByUserID =Users.UserID inner join LocalDrivingLicenseApplications on Applications.ApplicationID =LocalDrivingLicenseApplications.ApplicationID
inner join LicenseClasses on LocalDrivingLicenseApplications.LicenseClassID =LicenseClasses.LicenseClassID 
inner join People on Applications.ApplicantPersonID =People.PersonID
inner join TestAppointments on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID =TestAppointments.LocalDrivingLicenseApplicationID
inner join Tests on TestAppointments.TestAppointmentID =Tests.TestAppointmentID






select  Applications.ApplicationID , Applications.ApplicationDate, LicenseClasses.ClassName, Applications.PaidFees, Users.UserName,
case
when Applications.ApplicationStatus =1 then 'New'
when Applications.ApplicationStatus =2 then 'Cansled'
when Applications.ApplicationStatus =3 then 'Completed' end as ApplicationStatus
from Applications inner join Users on Applications.CreatedByUserID =Users.UserID inner join LocalDrivingLicenseApplications on Applications.ApplicationID =LocalDrivingLicenseApplications.ApplicationID
inner join LicenseClasses on LocalDrivingLicenseApplications.LicenseClassID =LicenseClasses.LicenseClassID


select* from Applications
Go
select* from  LocalDrivingLicenseApplications
Go
select* from  LicenseClasses;
Go
select* from  TestAppointments;
Go
select* from  Tests;


begin TRANSACTION T1

Delete  from Tests where TestAppointmentID in (select TestAppointmentID from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID);

delete from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;
delete from LocalDrivingLicenseApplications  where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;
delete from Applications where ApplicationID =@ApplicationID;


commit TRANSACTION T1





select* from TestAppointments

select* from Tests







select* from Countries;


select* from People;


select* from Users;













































