USE [MyeQuals]
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_GetTestamurDoc]    Script Date: 13/2/2023 9:42:44 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[PROC_WebApp_GetTestamurDoc]
           @OrderID varchar(50),
           @LineNumber varchar(50) = null,
		   @FileName varchar(50) OUTPUT,
		   @File varbinary(max) OUTPUT
           
AS
BEGIN

	SET NOCOUNT ON;


SELECT top 1
	@FileName =[FileName]
	,@File = [File]
FROM  
	[MyeQuals].[dbo].[tbl_Testamur_Doc] 
WHERE  
	OrderId= @OrderID
	AND (@LineNumber is null or LineNumber = @LineNumber)
--RAISERROR (@Output_Error,16,1)

END

