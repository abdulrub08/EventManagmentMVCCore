USE [EventDB]
GO
/****** Object:  StoredProcedure [dbo].[FlowerInsert]    Script Date: 13/6/2023 11:52:53 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[FlowerInsert]
@FlowerID int null,
@FlowerName nvarchar(50) ,
@FlowerFilename nvarchar(Max) ,
@FlowerFilePath nvarchar(Max) ,
@Createdby  int,
@Createdate DateTime,
@FlowerCost int
AS
BEGIN
INSERT INTO [dbo].[Flower]
           ([FlowerName]
           ,[FlowerFilename]
           ,[FlowerFilePath]
           ,[Createdby]
           ,[Createdate]
           ,[FlowerCost])
     VALUES
           (@FlowerName
           ,@FlowerFilename
           ,@FlowerFilePath
           ,@Createdby
           ,@Createdate
           ,@FlowerCost)
SELECT CAST(SCOPE_IDENTITY() as int) FlowerID
End


