USE [EventDB]
GO
/****** Object:  StoredProcedure [dbo].[LightInsert]    Script Date: 13/6/2023 11:16:23 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[LightInsert]
@LightType nvarchar(50) ,
@LightName nvarchar(50) ,
@LightFilename nvarchar(max),
@LightFilePath nvarchar(max) ,
@Createdby int ,
@Createdate datetime,
@LightCost int
AS
BEGIN
INSERT INTO [dbo].[Light]
           ([LightType]
           ,[LightName]
           ,[LightFilename]
           ,[LightFilePath]
           ,[Createdby]
           ,[Createdate]
           ,[LightCost])
     VALUES
           (@LightType
           ,@LightName
           ,@LightFilename
           ,@LightFilePath
           ,@Createdby
           ,@Createdate
           ,@LightCost)
End


