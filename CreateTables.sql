Use Budget

--create schema logging

Begin Tran

Create Table UserRole
(
	UserRole_Pk int identity primary key not null,
	Name varchar(20) not null, -- Admin, General Users, etc.
	Description varchar(50) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into UserRole
Values ('Admin', 'Site Administrator', getdate(), null, SYSTEM_USER, getdate(), null, null),
       ('RegisteredUser', 'Registerd User', getdate(), null, SYSTEM_USER, getdate(), null, null)

Select *
From UserRole

Create Table [User]
(
	User_Pk int identity primary key not null,
	UserRole_Fk int foreign key references UserRole(UserRole_Pk) not null,
	UserName varchar(20) unique not null,
	PasswordHash binary(64) not null,
	Salt uniqueidentifier not null,
	ResetPasswordGuid uniqueidentifier null,
	ResetPasswordExpirationDate datetime null,
	LogInAttempts int null default 0,
	FirstName varchar(50) not null,
	LastName varchar(100) not null,
	EmailAddress varchar(50) unique not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

declare @salt1 as uniqueidentifier = newid()
declare @salt2 as uniqueidentifier = newid()

Insert Into [User]
Values (1, 'siteAdmin', HASHBYTES('SHA2_512', 'test123'+CAST(@salt1 AS NVARCHAR(36))), @salt1, null, null, null, 'Ben', 'Angelo', 'ben.t.angelo@gmail.com', getdate(), null, SYSTEM_USER, getdate(), null, null),
       (2, 'bangelo', HASHBYTES('SHA2_512', 'test1234'+CAST(@salt2 AS NVARCHAR(36))), @salt2, null, null, null, 'Ben', 'Angelo', 'testEmail@example.com', getdate(), null, SYSTEM_USER, getdate(), null, null)

Select *
From [User]

Create Table AccountRole
(
	AccountRole_Pk int identity primary key not null,
	Name varchar(20) not null,
	Description varchar(50) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into AccountRole
Values ('AccountPrimary', 'Read/Write', getdate(), null, SYSTEM_USER, getdate(), null, null),
	   ('AccountSecondary', 'Read', getdate(), null, SYSTEM_USER, getdate(), null, null)

Select *
From AccountRole

Create Table Account
(
	Account_Pk int identity primary key not null,
	Name varchar(50) not null,
	Description varchar(50) null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into Account
Values ('Test Account', null, getdate(), null, SYSTEM_USER, getdate(), null, null)

Select *
From Account

Create Table UserAccount
(
	UserAccount_Pk int identity primary key not null,
	Account_Fk int foreign key references Account(Account_Pk) not null,
	AccountRole_Fk int foreign key references AccountRole(AccountRole_Pk) not null,
	User_Fk int foreign key references [User](User_Pk) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into UserAccount
Values (1, 1, 2, getdate(), null, SYSTEM_USER, getdate(), null, null)

Select *
From UserAccount

Create Table AccountBalance
(
	AccountBalance_Pk int identity primary key not null,
	Account_Fk int foreign key references Account(Account_Pk) not null,
	Balance decimal(9,2) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into AccountBalance
Values (1, 100.45, getdate(), null, SYSTEM_USER, getdate(), null, null)

Select *
From AccountBalance

Create Table AccountBalanceHistory
(
	AccountBalanceHistory_Pk int identity primary key not null,
	Account_Fk int foreign key references Account(Account_Pk) not null,
	Balance decimal(9,2) not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into AccountBalanceHistory
Values (1, 60, getdate(), null, SYSTEM_USER, getdate(), null, null)

Select *
From AccountBalanceHistory

Create Table IncomeSchedule
(
	IncomeSchedule_Pk int identity primary key not null,
	Name varchar(50) unique not null, -- e.g. Monthly, Bi-Weekly
	Description varchar(100) null,
	DaysUntilNextPayDay int null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into IncomeSchedule
Values ('One Time', null, 0, getdate(), null, SYSTEM_USER, getdate(), null, null),
	   ('Weekly', 7, null, getdate(), null, SYSTEM_USER, getdate(), null, null),
	   ('Bi-Weekly', null, 14, getdate(), null, SYSTEM_USER, getdate(), null, null),
	   ('1st and 15th', null, null, getdate(), null, SYSTEM_USER, getdate(), null, null),
	   ('Monthly', 30, null, getdate(), null, SYSTEM_USER, getdate(), null, null),
	   ('Yearly', 365, null, getdate(), null, SYSTEM_USER, getdate(), null, null)

Select *
From IncomeSchedule

Create Table Payor
(
	Payor_Pk int identity primary key not null,
	Account_Fk int foreign key references Account(Account_Pk) not null,
	IncomeSchedule_Fk int foreign key references IncomeSchedule(IncomeSchedule_Pk) not null,
	Name varchar(100) not null,
	Description varchar(100) null,
	GrossAmount decimal(9,2) not null,
	NetAmount decimal(9,2) not null,
	TaxRate decimal(2,2) null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into Payor
Values (1, 1, 'Ben''s Paycheck', null, 4000, 3000, .25, getdate(), null, SYSTEM_USER, getdate(), null, null)

Select *
From Payor

Create Table ExpenseSchedule
(
	ExpenseSchedule_Pk int identity primary key not null,
	Name varchar(50) not null, -- e.g. Monthly, Bi-Weekly, One-Time
	Description varchar(100) null,
	DaysUntilNextDueDate int null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into ExpenseSchedule
Values ('One Time', null, 0, getdate(), null, SYSTEM_USER, getdate(), null, null),
	   ('Weekly', null, 7, getdate(), null, SYSTEM_USER, getdate(), null, null),
	   ('Bi-Weekly', null, 14, getdate(), null, SYSTEM_USER, getdate(), null, null),
	   ('Monthly', null, 30, getdate(), null, SYSTEM_USER, getdate(), null, null),
	   ('Yearly', null, 365, getdate(), null, SYSTEM_USER, getdate(), null, null)

Select *
From ExpenseSchedule

Create Table Payee
(
	Payee_Pk int identity primary key not null,
	Account_Fk int foreign key references Account(Account_Pk) not null,
	ExpenseSchedule_Fk int foreign key references ExpenseSchedule(ExpenseSchedule_Pk) not null,
	Name varchar(100) not null,
	Description varchar(100) null,
	MinimumDue decimal(9,2) default 0.00,
	DueDate datetime not null, -- Change value after a payment is added to the AccountExpensePayment table, increments based on Schedule_Fk value
	AutoPay bit default 0 not null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,	
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into Payee
Values (1, 3, 'Mortgage', null, 1800.23, dateadd(day, 5, cast(getdate() as date)), 1, getdate(), null, SYSTEM_USER, getdate(), null, null),
       (1, 3, 'Phone Bill', null, 1800.23, dateadd(day, 5, cast(getdate() as date)), 1, getdate(), null, SYSTEM_USER, getdate(), null, null)

Select *
From Payee

Create Table Payment
(
	Payment_PK int identity primary key not null,
	Payee_Fk int foreign key references Payee(Payee_Pk) not null,
	AmountPaid decimal(9,2) null,
	DatePaid datetime null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Insert Into Payment
Values (1, 1800.23,  dateadd(day, 5, cast(getdate() as date)), SYSTEM_USER, getdate(), null, null)

Select *
From Payment

Create Table logging.ErrorLog
(
	ErrorLog_Pk int identity primary key not null,	
	ErrorCode int not null,
	ErrorDescription varchar(500) not null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Select *
From logging.ErrorLog

Create Table logging.AccessLog
(
	Access_Pk int identity primary key not null,	
	User_Fk int foreign key references [User](User_Pk) null,
	IPAddress varchar(50) null,
	Device varchar(50) null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Select *
From logging.AccessLog

Create Table logging.ChangeLog
(
	Change_Pk int identity primary key not null,	
	TableName varchar(50) not null,	
	ColumnName varchar(50) not null,
	RecordPk int not null,
	OldValue varchar(1000) not null,
	NewValue varchar(1000) not null,
	CreatedBy varchar(50) not null,
	CreateDate datetime not null,
	ModifiedBy varchar(50) null,
	ModifiedDate datetime null
)

Select *
From logging.ChangeLog

Commit Tran

--select HASHBYTES('SHA2_512', 'test123'+CAST('22DD6C31-855B-4AF1-8D74-F1187F88C303' AS NVARCHAR(36)))
--select HASHBYTES('SHA2_512', 'test123')
--select HASHBYTES('SHA2_512', CAST('22DD6C31-855B-4AF1-8D74-F1187F88C303' AS NVARCHAR(36)))

