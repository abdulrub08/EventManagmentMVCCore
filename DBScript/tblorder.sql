use MyeQuals
SELECT top(2) * FROM  [dbo].tbl_Order order by RecID desc
 --where OrderId='A221222080313' order by RecID desc
order by RecID desc

SELECT * FROM  [dbo].tbl_OrderDetail order by RecID desc

SELECT * FROM  [dbo].tbl_OrderDetail where OrderId='S230213081421' and IsDeleted='N' order by RecID desc
SELECT * FROM  [dbo].tbl_Order where OrderId='S230213081421' order by RecID desc

Update [dbo].tbl_Order set StudentType='SSO' where ReCID=130
Update [dbo].tbl_Order set MailingAddressLine1='' where ReCID=139
Update [dbo].tbl_OrderDetail set CollegeCode='TE',CourseDescription='SADCF',CourseCode='GCIHM' where OrderId='A230118084233'

delete FROM  [dbo].tbl_OrderDetail where OrderId='A230120121840' 
--delete FROM  [dbo].tbl_Order where StudentID='A00016411'
EXEC PROC_WebApp_GetDocumentPrice 'Testamur'
PROC_WebApp_GetDocumentsAvailableByCourseIDStudentID 'A00016411','GCIHM'
PROC_WebApp_GetStudentByEmail 'abdul.rub@torrens.edu.au'
PROC_WebApp_GetCoursesByStudentID 'A00016411'
PROC_WebApp_GetStudentByEmail '14914.yuru.guo@bluemountains.torrens.edu.au'
PROC_WebApp_SelectAlumniOrder 'A221202014633'
exec PROC_WebApp_GetStudentHoldStatus 'A00016411'
PROC_WebApp_UpsertAlumniOrderDetail 'A221208111904','1',getdate(),'HARD COPY','GCIHM','Graduate Certificate of International Hotel Management','','232910','Hard Copy',
'1','20.33','20.33','Current Student Added Item'


Declare @OrderID varchar(50)='S230213081421'
Declare @LineNumber varchar(50) =null
Declare @FileName varchar(50)
Declare @File varbinary(max)
exec PROC_WebApp_GetTestamurDoc @OrderID,@LineNumber,@FileName output,@File output
select @FileName,@File
SELECT top 1
	@FileName =[FileName]
	,@File = [File]
FROM  
	[MyeQuals].[dbo].[tbl_Testamur_Doc] 
WHERE  
	OrderId= @OrderID
	AND (@LineNumber is null or LineNumber = @LineNumber)
	select @FileName,@File

Update [dbo].tbl_OrderDetail 
			set
			IsDeleted	='Y',LineNumber=0
			where [OrderID]='A221208111904'
			and LineNumber = 1

			Select * from tbl_testamur_doc where OrderId='S230213081421' and LineNumber ='1'
			PROCEDURE [dbo].[PROC_WebApp_AttachTestamurDoc]



DECLARE    @return_value int,
        @FileName varchar(50),
        @File varbinary(max) EXEC    @return_value = [dbo].[PROC_WebApp_GetTestamurDoc]
        @OrderID = N'S230213081421',
        @LineNumber = null,
        @FileName = @FileName OUTPUT,
        @File = @File OUTPUT SELECT    @FileName as N'@FileName',
        @File as N'@File'

Declare @LineNumber varchar(50) =null
Select * from [dbo].[tbl_Testamur_Doc] as d
WHERE OrderId = 'S230213081421' AND (@LineNumber is null or LineNumber = @LineNumber)