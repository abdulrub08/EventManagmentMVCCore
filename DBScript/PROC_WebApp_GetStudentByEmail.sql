USE [MyeQuals]
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_GetStudentByEmail]    Script Date: 7/12/2022 5:24:58 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: moh
-- Create date: 25/10/22
-- exec [PROC_WebApp_GetStudentByEmail] '4473.naomi.quick@ssnt.think.edu.au'
-- =============================================
ALTER PROCEDURE [dbo].[PROC_WebApp_GetStudentByEmail]
	@Email varchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [Student_ID] as StudentID
      ,[Student_FirstName] as FirstName
      ,[Student_LastName] as LastName
      ,[Email]
   --   ,[CourseCode]
	  --,CourseDesc
	  --,CollegeCode
	  ,(select distinct iif(count(SPRHOLD_pidm)>0,'Yes','No') Has_hold  from ods.[shared].[T_Banner_SATURN_SPRHOLD]
		    where SPRHOLD_pidm=[Student_PIDM]
			and SPRHOLD_TO_DATE>=getdate()) Has_hold
      from V_Banner_Students
	  where Email=@Email
	  AND Degree_StatusCode in ('PD', 'EC', 'AW', 'G')
END
