USE [MyeQuals]
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_InsertAlumniOrder_OrderDetail]    Script Date: 6/12/2022 12:50:36 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PROC_WebApp_InsertAlumniOrder_OrderDetail]
	@OrderID nvarchar(50) 
    ,@StudentID varchar(50) null
    ,@FirstName varchar(250) null
    ,@LastName varchar(250) null
    ,@DateOfBirth datetime2(7) null
    ,@YearOFStudy nchar(10) null
    ,@USI varchar(50) null
    ,@CHESSN varchar(50) null
	,@CollegeCode varchar(50) null
    ,@CollegeDescription varchar(250) null
    ,@PersonalEmail varchar(50) null
    ,@MobilePhone varchar(50) null
	,@MailingAddressLine1 varchar(250) null
	,@MailingAddressLine2 varchar(250) null
	,@MailingCity varchar(250) null
	,@MailingState varchar(250) null
	,@MailingPostCode varchar(6) null
	,@MailingCountry varchar(250) null
	,@ShippingType varchar(50) null
    ,@Order_omments varchar(max) null
	,@LineNumber nvarchar(50)
	,@OrderType varchar(50) null
    ,@CourseCode varchar(50) null
    ,@CourseDescription varchar(250) null
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


	       INSERT INTO [dbo].tbl_Order
				   ([OrderID]
				   ,[StudentID]
				   ,[FirstName]
				   ,[LastName]
				   ,[DateOfBirth]
				   ,[YearOFStudy]
				   ,[USI]
				   ,[CHESSN]
				   ,CollegeCode
				   ,CollegeDescription
				   ,[PersonalEmail]
				   ,[MobilePhone]
				    ,MailingAddressLine1
				   ,MailingAddressLine2
				   ,MailingCity
				   ,MailingState
				   ,MailingPostCode
				   ,MailingCountry
				   ,ShippingType
				   ,[Comments])
		   VALUES
			   (@OrderID,
			   @StudentID,  
			   @FirstName,  
			   @LastName,  
			   @DateOfBirth,
			   @YearOFStudy,
			   @USI,  
			   @CHESSN, 
			   @CollegeCode,
			   @CollegeDescription,
			   @PersonalEmail,  
			   @MobilePhone,  
			   @MailingAddressLine1,
			   @MailingAddressLine2,
			   @MailingCity,
			   @MailingState,
			   @MailingPostCode,
			   @MailingCountry,
			   @ShippingType,
			   @Order_omments);
			   
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
			   getdate(),
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
END
