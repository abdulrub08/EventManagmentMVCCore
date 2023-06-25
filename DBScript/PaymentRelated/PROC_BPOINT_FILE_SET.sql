USE [ODS]
GO
/****** Object:  StoredProcedure [bpoint].[PROC_BPOINT_FILE_SET]    Script Date: 16/12/2022 10:55:36 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/* =============================================
	Author:			Iftekhar Imran
	Created:		01/05/2019
	Active Version: V5
	Description:	Populate data in [bpoint].[T_BKT_BPOINT] table

   =============================================*/
ALTER PROCEDURE  [bpoint].[PROC_BPOINT_FILE_SET]
@BT_REF varchar(250),
@BT_DT varchar(50),
@BT_RESPONSE_CODE varchar(5)='',
@BT_RESPONSE_TEXT varchar(100)='',
@BT_RECEIPT_NUMBER varchar(250)='',
@BT_CRN1 varchar(250)='',
@BT_CRN2 varchar(250)='',
@BT_CRN3 varchar(250)='',
@BT_MERCHANT_NUMBER varchar(20)='',
@BT_ACTION varchar(20)='',
@BT_BILLER_CODE varchar(10)='',
@BT_AMOUNT varchar(15)=null,
@BT_CARD_TYPE varchar(20)='',
@BT_RESPONSE_FILE varchar(max)='',
@BT_Email varchar(250)='',
@Error_Code int = 0 OUTPUT,
@Error_Message nvarchar(max) = '' OUTPUT
as
Begin	
  ----SET ANSI_NULLS ON;
  ---- SET  ANSI_WARNINGS ON;

	--SET NOCOUNT ON;
	Declare @term as varchar(10)
	Declare @PIDM as varchar(10)
	Declare @found as varchar(10) ='0'
	Declare @AC_detail_code as varchar(10)
	Declare @Declined_count as int=0
   declare @BannerUpdateStatus varchar(25)=''
   declare @custom_parameter_store_ids varchar(25)=''
	
	  select @custom_parameter_store_ids=custom_parameter_store_id  from openjson(@BT_RESPONSE_FILE,'$.metadata')    
      with (custom_parameter_store_id nvarchar(150) '$.custom_parameter_store_id') 

	  If len(@BT_MERCHANT_NUMBER)>16 and isnull(@custom_parameter_store_ids,'')<>''
	  Begin
			set @BT_MERCHANT_NUMBER=@custom_parameter_store_ids
	  End

	select @found=1 from [bpoint].[T_BKT_BPOINT]
	where [BT_RECEIPT_NUMBER]=@BT_RECEIPT_NUMBER

	if @found=0 
	begin

	   BEGIN TRY
	   	     
			INSERT INTO [bpoint].[T_BKT_BPOINT]
			   ([BT_REF]
			   ,[BT_DT]
			   ,[BT_RESPONSE_CODE]
			   ,[BT_RESPONSE_TEXT]
			   ,[BT_RECEIPT_NUMBER]
			   ,[BT_CRN1]
			   ,[BT_CRN2]
			   ,[BT_CRN3]
			   ,[BT_MERCHANT_NUMBER]
			   ,[BT_ACTION]
			   ,[BT_BILLER_CODE]
			   ,[BT_AMOUNT]
			   ,[BT_CARD_TYPE]
			   ,[BT_RESPONSE_FILE]
			   ,BT_Email
			   ,Banner_Upload_Status)
			   VALUES(@BT_REF ,
				@BT_DT ,
				@BT_RESPONSE_CODE ,
				@BT_RESPONSE_TEXT ,
				@BT_RECEIPT_NUMBER ,
				@BT_CRN1 ,
				@BT_CRN2 ,
				@BT_CRN3 ,
				@BT_MERCHANT_NUMBER ,
				@BT_ACTION ,
				@BT_BILLER_CODE ,
				@BT_AMOUNT ,
				@BT_CARD_TYPE ,
				@BT_RESPONSE_FILE ,
				@BT_Email,
				@BannerUpdateStatus)

	----TUA 5353109596120544
	----Think 5353109296120234

	---Test -"TorrensStoreID": "3600002211","ThinkStoreID": "3600002212",
	  if @BT_CRN1 not like '%T'
			  Begin

				   Select @term=[STVTERM_CODE]  FROM [shared].[T_Banner_SATURN_STVTERM]  where [STVTERM_CODE]=	cast(datepart(yyyy,getdate()) as varchar)+'99';
				  Select @PIDM=spriden_pidm
				  from  BannerProto..SATURN.SPRIDEN
				 where spriden_change_ind is null
				   and spriden_id=@BT_CRN1;

				Set @BT_RESPONSE_TEXT=iif(@BT_RESPONSE_TEXT<>'Approved','Declined',@BT_RESPONSE_TEXT)---- Set response status 'Declined' if Bank response is not 'Aprroved' 
				Set @AC_detail_code=iif(@BT_MERCHANT_NUMBER in('5353109596120544','3600002211'),'P003','P001')

				IF @BT_RESPONSE_TEXT not like 'Approved%'
				begin
	
					set @BT_AMOUNT=0;
					select @Declined_count=count(*) from (select top 3 * from  [bpoint].[T_BKT_BPOINT]
						where  BT_CRN1=@BT_CRN1
						and TRN_Date>=DATEADD(dd,-1,getdate())
						order by TRN_Date desc) t
						where BT_RESPONSE_TEXT not like 'Approved%'
				end
	
			  if @Declined_count<3 and  @Declined_count>0
					  select @Declined_count=isnull(Total_Declined,0)+1 
						  FROM [bpoint].[T_BKT_BPOINT_ON_HOLD]
						  Where [STUDENT_ID]=@BT_CRN1
						  and Total_Declined>0

				If @PIDM is null
				begin
					set @Error_Code=50001;
				   set @Error_Message='The Student '+@BT_CRN1+'does not exist in Banner.';
				   THROW @Error_Code, @Error_Message, 1;
				end
				else IF @term is null
				begin
					set @Error_Code=50002;
				   set @Error_Message='The Term '+@term+'  does not exist in Banner.';
				   THROW @Error_Code,@Error_Message, 1;
				end
				else
				begin 
				if  @Declined_count<=3
				 begin
				
							exec [bpoint].[PROC_Make_Payment] @PIDM,@AC_detail_code,@BT_AMOUNT,@term,@BT_Email,@BT_CRN2,@BT_RECEIPT_NUMBER,@BT_MERCHANT_NUMBER	
						   if @BT_CRN2 like '%Transcript%'
							begin	
								Set @AC_detail_code='M002'
								exec [bpoint].[PROC_Make_Payment] @PIDM,@AC_detail_code,@BT_AMOUNT,@term,@BT_Email,@BT_CRN2,@BT_RECEIPT_NUMBER,@BT_MERCHANT_NUMBER	
								exec [bpoint].[PROC_BPOINT_Process_Email] @BT_CRN1,@BT_RECEIPT_NUMBER
							end
							if @Declined_count>=3
							Begin
									exec [Shared].[PROC_Put_On_Hold] @PIDM,'CC','N',' Credit card declined'
									INSERT INTO [bpoint].[T_BKT_BPOINT_ON_HOLD]
									([STUDENT_ID],STUDENT_PIDM,Total_Declined)
									VALUES
									(@BT_CRN1,@PIDM,@Declined_count)
							end
							else
							begin 		
									delete 
									FROM [bpoint].[T_BKT_BPOINT_ON_HOLD]
									Where [STUDENT_ID]=@BT_CRN1;

									Select '1 record inserted' as Return_Value
							end
			  
				 end
				end;
		end
		else
			begin
				 Select '1 record inserted' as Return_Value
			 end;

		END TRY

		BEGIN CATCH
			SET @Error_Code = ERROR_NUMBER()  
			SET @Error_Message = ERROR_MESSAGE()  
				INSERT INTO [control].[Error_log]
			   ([Error_Code]
			   ,[Error_Massage]
			   ,[Schema_name]
			   ,[Proc_Name]
			   ,Proc_Parameters
			   )
		 VALUES
			   (@Error_Code
			   ,@Error_Message
			   ,'bpoint'
			   ,'PROC_BPOINT_FILE_SET'
			   ,@BT_REF+','+@BT_DT+','+@BT_CRN1+','+@BT_CRN2+','+@BT_CRN3)  
		END CATCH
	end
end
