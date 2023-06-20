USE [MyeQuals]
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_GetDocumentPrice]    Script Date: 21/12/2022 12:10:26 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: moh
-- Create date: 25/10/22
-- exec [PROC_WebApp_GetStudentByEmail] '4473.naomi.quick@ssnt.think.edu.au'
-- =============================================
ALTER PROCEDURE [dbo].[PROC_WebApp_GetDocumentPrice]
	@DocumentName varchar(200),
	@DocumentType varchar(200) = Null
AS
BEGIN

select *
from [dbo].[tbl_MyEquals_AcademicDocuments] 
where DocumentName = @DocumentName 
OR
(EligibleCourseTypes = @DocumentType
and isnull(EligibleCourseTypes,'')=isnull(@DocumentType,'')
)

END

select PriceSoftCopy,
PriceHardCopy_Domestic,
PriceHardCopy_International,DocumentName,EligibleCourseTypes
from [dbo].[tbl_MyEquals_AcademicDocuments] 
where DocumentName = 'Academic Transcript' and  EligibleCourseTypes = null
exec PROC_WebApp_GetDocumentPrice 'Academic Transcript'
