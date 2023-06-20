CREATE TABLE Country_Currency  
(  
 ID int NOT NULL IDENTITY(1,1),  
 ISO_Code nvarchar(3),
 Symbol nchar(3),
 OrderBy int,
 PRIMARY KEY (ID)
);

EXEC sp_rename 'Country_Currency.Symbols', 'Symbol';
update Country_Currency set Symbol=N'лв' where OrderBy=5
update Country_Currency set Symbol=N'฿' where OrderBy=25

INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('AUD','$',1)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('USD','$',2)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('INR',N'₹',3)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('CNY','¥',4)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('BGN',N'лв',5)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('BRL','R$',6)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('CAD','$',7)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('CHF','Fr',8)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('CZK','Kč',9)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('DKK','kr.',10)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('EUR','€',11)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('GBP','£',12)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('HKD','$',13)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('HRK','kn',14)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('HUF','Ft',15)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('JPY','¥',16)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('MXN','$',17)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('MYR','RM',18)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('NOK','kr.',19)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('NZD','$',20)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('PLN','zł',21)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('RON','lei',22)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('SEK','kr.',23)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('SGD','$',24)
INSERT Country_Currency(ISO_Code,Symbol,OrderBy) VALUES ('THB',N'฿',25)
