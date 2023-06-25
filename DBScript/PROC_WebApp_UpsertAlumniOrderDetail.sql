USE [MyeQuals]
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_UpsertAlumniOrderDetail]    Script Date: 6/12/2022 12:46:04 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		@Author,,Name>
-- Create date: @Create Date,,>
-- Description:	@Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PROC_WebApp_UpsertAlumniOrderDetail]
	@OrderID nvarchar(50) 
	,@LineNumber nvarchar(50)
	,@OrderDate datetime
	,@OrderType varchar(50) null
    ,@CourseCode varchar(50) null
    ,@CourseDescription varchar(250) null
	,@CollegeCode varchar(50) null
    ,@RequestedDocument varchar(50) null
	,@DocFormat varchar(50) null
    ,@NumberOfCopies int null
    ,@Price int null
    ,@TotalPrice numeric(18,2) null
    ,@Comments varchar(max) null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Declare @IsExist int=0 
	select @IsExist=COUNT(*) from tbl_OrderDetail
	where [OrderID]=@OrderID
	and LineNumber = @LineNumber
	
	set  @IsExist=ISNULL(@IsExist,0)

	If @IsExist=0
	Begin
	       INSERT INTO [dbo].tbl_OrderDetail
				   ([OrderID]
				   ,LineNumber
				   ,OrderDate
				   ,[OrderType]
				   ,[CourseCode]
				   ,[CourseDescription]
				   ,CollegeCode				   
				   ,[RequestedDocument]
				   ,DocFormat
				   ,[NumberOfCopies]
				   ,[Price]
				   ,[TotalPrice]
				   ,[Comments])
		   VALUES
			   (@OrderID,
			   @LineNumber,
			   @OrderDate,  
			   @OrderType,  
			   @CourseCode,  
			   @CourseDescription,  
			   @CollegeCode,
			   @RequestedDocument,
			   @DocFormat,		   
			   @NumberOfCopies,
			   @Price,
			   @TotalPrice,
			   @Comments)
			End
			Else
			Begin
			Update [dbo].tbl_OrderDetail 
			set
			OrderDate	=ISNULL(@OrderDate,OrderDate)
			,[OrderType] = ISNULL(@OrderType,[OrderType])
			,[CourseCode] = ISNULL(@CourseCode,[CourseCode])
			,[CourseDescription] = ISNULL(@CourseDescription,[CourseDescription])
			,[CollegeCode] = ISNULL(@CollegeCode,[CollegeCode])
			,[RequestedDocument] = ISNULL(@RequestedDocument,[RequestedDocument])
			,[DocFormat] = ISNULL(@DocFormat,[DocFormat])
			,[NumberOfCopies] = ISNULL(@NumberOfCopies,[NumberOfCopies])
			,[Price] = ISNULL(@Price,[Price])
			,[TotalPrice] = ISNULL(@TotalPrice,[TotalPrice])
			,[Comments] = ISNULL(@Comments,[Comments])
			where [OrderID]=@OrderID
			and LineNumber = @LineNumber
			End
END
