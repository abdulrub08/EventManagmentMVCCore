Declare @StudentID varchar(200) = 'A00016411',@CourseCode varchar(200)  = 'GCIHM'
Declare @CourseType nvarchar(15) = (
select top 1 CourseType
from V_Banner_Students
where Student_ID = @StudentID
and Degree_StatusCode IN ('AW','G')
and CourseCode = @CourseCode)
select @CourseType
OR
(Student_ID = @StudentID
and isnull(CourseCode,'')=isnull(@CourseCode,'')
and Degree_StatusCode IN ('AW','G'))
)
select @CourseType
select * from [dbo].[tbl_MyEquals_AcademicDocuments]
where EligibleCourseTypes = isnull(@CourseType, 'Non VET')


select Degree_StatusCode,* 
from V_Banner_Students
where Student_ID = 'A00016411'
--and Degree_StatusCode IN ('AW','G')
and CourseCode = 'GCIHM'