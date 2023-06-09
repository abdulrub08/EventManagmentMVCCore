USE [EventDB]
GO
/****** Object:  StoredProcedure [dbo].[LightInsert]    Script Date: 13/6/2023 11:38:40 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[LightInsert]
@LightID int null,
@LightType nvarchar(1) ,
@LightName nvarchar(50) ,
@LightFilename nvarchar(200),
@LightFilePath nvarchar(200) ,
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
 SELECT CAST(SCOPE_IDENTITY() as int) LightID
End


