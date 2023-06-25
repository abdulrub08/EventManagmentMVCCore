USE [EventDB]
GO
/****** Object:  StoredProcedure [dbo].[PROC_FlowerInsert]    Script Date: 13/6/2023 11:03:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[FlowerUpdate]
@FlowerID int,
@FlowerName nvarchar(50) ,
@FlowerFilename nvarchar(Max) ,
@FlowerFilePath nvarchar(Max) ,
@Createdby  int,
@Createdate DateTime,
@FlowerCost int
AS
BEGIN
Update [dbo].[Flower]
          set [FlowerName]=@FlowerName
           ,[FlowerFilename]=@FlowerFilename
           ,[FlowerFilePath]=@FlowerFilePath
           ,[Createdby]=@Createdby
           ,[Createdate]=@Createdate
           ,[FlowerCost]=@FlowerCost

where FlowerID=@FlowerID
End


