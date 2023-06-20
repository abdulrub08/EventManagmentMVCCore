USE [MyeQuals]
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_UpdateMailingAddress]    Script Date: 8/12/2022 8:34:03 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		@Author,,Name>
-- Create date: @Create Date,,>
-- Description:	@Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PROC_WebApp_UpdateMailingAddress]
	@OrderID nvarchar(50) 
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

	If @IsExist!=0
			Begin
			Update [dbo].tbl_Order
			set
		/*	StudentID=ISNULL(@StudentID,StudentID)
			,[FirstName] = ISNULL(@FirstName,[FirstName])
			,[LastName] = ISNULL(@LastName,[LastName])
			,[DateOfBirth] = ISNULL(@DateOfBirth,[DateOfBirth])
			,[YearOFStudy] = ISNULL(@YearOFStudy,[YearOFStudy])
			,[USI] = ISNULL(@USI,[USI]) 
			,[CHESSN] = ISNULL(@CHESSN,[CHESSN])
			,[CollegeCode] = ISNULL(@CollegeCode,[CollegeCode])
			,[CollegeDescription] = ISNULL(@CollegeDescription,[CollegeDescription])*/
			[PersonalEmail] = ISNULL(@PersonalEmail,[PersonalEmail])
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
