USE [EventDB]
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_InsertAlumniOrder_OrderDetail]    Script Date: 6/12/2022 12:50:36 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[PROC_RegisterUser]
	@Name nvarchar(50) ,
	@Address nvarchar(50) ,
	@City varchar(50) null,
	@State varchar(50) null,
	@Country varchar(50) null,
	@Mobileno varchar(10) null,
	@EmailID varchar(50) null,
	@Username varchar(50) null,
	@Password varchar(Max),
	@ConfirmPassword varchar(Max),
	@Gender varchar(50) null,
	@Birthdate varchar(50) null,
	@RoleID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.


	       INSERT INTO  [dbo].[Registration]
           ([Name]
           ,[Address]
           ,[City]
           ,[State]
           ,[Country]
           ,[Mobileno]
           ,[EmailID]
           ,[Username]
           ,[Password]
           ,[ConfirmPassword]
           ,[Gender]
           ,[Birthdate]
           ,[RoleID])
		   VALUES
			   (@Name
           ,@Address
           ,@City
           ,@State
           ,@Country
           ,@Mobileno
           ,@EmailID
           ,@Username
           ,@Password
           ,@ConfirmPassword
           ,@Gender
           ,@Birthdate
           ,@RoleID)
END
