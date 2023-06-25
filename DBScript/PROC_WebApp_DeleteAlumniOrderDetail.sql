USE [MyeQuals]
GO
/****** Object:  StoredProcedure [dbo].[PROC_WebApp_DeleteAlumniOrderDetail]    Script Date: 8/12/2022 2:12:57 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		@Author,,Name>
-- Create date: @Create Date,,>
-- Description:	@Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PROC_WebApp_DeleteAlumniOrderDetail]
	@OrderID nvarchar(50) 
	,@LineNumber nvarchar(50)
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

	If @IsExist=1
	Begin
	       Update [dbo].tbl_OrderDetail 
			set
			IsDeleted	='Y',LineNumber=0
			,[Comments] = ISNULL(@Comments,[Comments])
			where [OrderID]=@OrderID
			and LineNumber = @LineNumber
			End
			
END
