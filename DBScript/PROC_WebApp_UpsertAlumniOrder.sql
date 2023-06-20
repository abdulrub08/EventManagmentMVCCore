USE [MyeQuals]
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_UpsertAlumniOrder]    Script Date: 7/12/2022 6:37:21 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		@Author,,Name>
-- Create date: @Create Date,,>
-- Description:	@Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PROC_WebApp_UpsertAlumniOrder]
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
    ,@Comments varchar(max) null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Declare @IsExist int=0 
	select @IsExist=COUNT(*) from tbl_Order
	where [OrderID]=@OrderID
	
	set  @IsExist=ISNULL(@IsExist,0)

	If @IsExist=0
	Begin
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
			   @Comments)
			End
			Else
			Begin
			Update [dbo].tbl_Order
			set
			StudentID=ISNULL(@StudentID,StudentID)
			,[FirstName] = ISNULL(@FirstName,[FirstName])
			,[LastName] = ISNULL(@LastName,[LastName])
			,[DateOfBirth] = ISNULL(@DateOfBirth,[DateOfBirth])
			,[YearOFStudy] = ISNULL(@YearOFStudy,[YearOFStudy])
			,[USI] = ISNULL(@USI,[USI]) 
			,[CHESSN] = ISNULL(@CHESSN,[CHESSN])
			,[CollegeCode] = ISNULL(@CollegeCode,[CollegeCode])
			,[CollegeDescription] = ISNULL(@CollegeDescription,[CollegeDescription])
			,[PersonalEmail] = ISNULL(@PersonalEmail,[PersonalEmail])
			,[MobilePhone] = ISNULL(@MobilePhone,[MobilePhone]) 
			,[MailingAddressLine1] = ISNULL(@MailingAddressLine1,[MailingAddressLine1])
			,[MailingAddressLine2] = ISNULL(@MailingAddressLine2,[MailingAddressLine2])
			,[MailingCity] = ISNULL(@MailingCity,[MailingCity])
			,[MailingState] = ISNULL(@MailingState,[MailingState])
			,[MailingPostCode] = ISNULL(@MailingPostCode,[MailingPostCode])
			,[MailingCountry] = ISNULL(@MailingCountry,[MailingCountry])
			,[ShippingType] = ISNULL(@ShippingType,[ShippingType])
			,[Comments] = ISNULL(@Comments,[Comments])
			where [OrderID]=@OrderID
			End
END
