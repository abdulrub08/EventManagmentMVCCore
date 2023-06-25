Alter PROCEDURE [dbo].[PROC_WebApp_INSERT_Transaction_Details]
@Receipt_Number nvarchar(50) null,
 @email nvarchar(50) null,
 @Reference nvarchar(50) null,
 @stnumber nvarchar(50) null,
 @PaymentMethodID nvarchar(100) null,
 @baseamount nvarchar(50) null,
 @localamount nvarchar(50) null,
 @surchargepercent nvarchar(50) null,
 @surchargeamount nvarchar(50) null,
 @localsurchargeamount nvarchar(50) null,
 @localcurrencytype nvarchar(50) null,
 @basecurrencytype nvarchar(50) null,
 @paymentmethod nvarchar(50) null,
 @basetotalamount nvarchar(50) null,
 @localtotalamount nvarchar(50) null,
 @customerid nvarchar(100) null,
 @SourceType nvarchar(50) null,
 @Timespan nvarchar(50) null,
 @T_DT datetime null,
 @resCode nvarchar(50) null
AS
BEGIN
Insert into Transaction_Details(Receipt_Number,email,Reference,stnumber,
PaymentMethodID,baseamount,localamount,surchargeamount,localsurchargeamount,
localcurrencytype,basecurrencytype,paymentmethod,basetotalamount,
localtotalamount,customerid,SourceType,resCode,Transaction_DT,surchargepercent,Created) Values 
(@Receipt_Number,@email,@Reference,@stnumber,@PaymentMethodID,@baseamount,@localamount,
@surchargeamount,@localsurchargeamount,@localcurrencytype,@basecurrencytype,
@paymentmethod,@basetotalamount,@localtotalamount,@customerid,@SourceType,
@resCode,@Timespan,@surchargepercent,@T_DT)
END
CREATE TABLE Transaction_Details  
(  
 ID int NOT NULL IDENTITY(1,1),
 Receipt_Number nvarchar(50),
 email nvarchar(50),
 Reference nvarchar(50),
 stnumber nvarchar(50),
 PaymentMethodID nvarchar(100),
 baseamount nvarchar(50),
 localamount nvarchar(50),
 surchargepercent nvarchar(50),
 surchargeamount nvarchar(50),
 localsurchargeamount nvarchar(50),
 localcurrencytype nvarchar(50),
 basecurrencytype nvarchar(50),
 paymentmethod nvarchar(50),
 basetotalamount nvarchar(50),
 localtotalamount nvarchar(50),
 customerid nvarchar(100),
 SourceType nvarchar(50),
 resCode nvarchar(50),
 Transaction_DT nvarchar(30),
 Created Datetime,
 PRIMARY KEY (ID)
);

Alter Table Transaction_Details
Add Transaction_DT nvarchar(30)

Select * from Transaction_Details
