CREATE TABLE Companies (
	 Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[Name] [varchar](100) NULL,
	[Email] [varchar](50) NOT NULL UNIQUE,
	[Website] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Logo] [varchar](50) NULL,
	[About] [varchar](100) NULL,
	[Vision] [varchar](100) NULL,
	[Mission] [varchar](100) NULL,
	[Location] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[CreatedDate] date  NULL
) 


CREATE TABLE [dbo].[Users](
	 Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL UNIQUE,
	[Gender] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
	[About] [varchar](50) NULL,
	[Designation] [varchar](50) NULL,
	[CompanyId] [uniqueidentifier] NULL,
	[Status] [varchar](50) NULL,
	[Image] [varchar](50) NULL,
	[CreatedDate] date  NULL
	FOREIGN KEY (CompanyId) REFERENCES Companies (Id)
 )

 CREATE TABLE Jobs (
 Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[Title] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
	[Experience] [varchar](50) NULL,
	[TypeOfWorkPlace] [varchar](50) NULL,
	[Salary] [varchar](50) NULL,
	[Responsibilities] [varchar](50) NULL,
	[JobType] [varchar](50) NULL,
	[VacanciesCount] [int] NULL,
	[AppliedCount] [int] NULL,
	[Status] [varchar](50) NULL,
	[CompanyId] [uniqueidentifier] NULL,
	[CreatedDate] date  NULL,
	[CreatedBy] [uniqueidentifier] NULL,
FOREIGN KEY (CompanyId) REFERENCES Companies (Id),
FOREIGN KEY (CreatedBy) REFERENCES Users (Id)
)

CREATE TABLE Applications (
	 Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[UserId] [uniqueidentifier] NULL,
	[JobId]  [uniqueidentifier] NULL,
	[AppliedDate]  [Date]  NULL,
	[Status] [varchar](50) NULL,
FOREIGN KEY (UserId) REFERENCES Users(Id),
FOREIGN KEY (JobId) REFERENCES Jobs(Id)
)

CREATE TABLE [dbo].[Experiences](
	 Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[UserId] [uniqueidentifier] NULL,
	[JobTitle] [varchar](50) NULL,
	[Company] [varchar](50) NULL,
	[Duration] [varchar](50) NULL,
	[Year] [varchar](50) NULL,
FOREIGN KEY (UserId) REFERENCES Users(Id)
)



CREATE TABLE Interviews (
	Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[JobId] [uniqueidentifier],
	[JobseekerId] [uniqueidentifier],
	[Date] [date],
	[Time] [time](7),
	[Location] [varchar](50),
	[Status] [varchar](50),
	[CreatedBy] [uniqueidentifier],
	CreatedDate date,
FOREIGN KEY (JobId) REFERENCES Jobs(Id),
FOREIGN KEY (JobseekerId) REFERENCES Users(Id),
FOREIGN KEY (CreatedBy) REFERENCES Users(Id)
)

CREATE TABLE Qualifications (
	Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[UserId] [uniqueidentifier] NULL,
	[Title] [varchar](50) NULL,
	[Mark] [varchar](50) NULL,
	[YearOfPassout] [varchar](50) NULL,
	[University] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
FOREIGN KEY (UserId) REFERENCES Users(Id)
)

CREATE TABLE Skills (
	Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[UserId] [uniqueidentifier] NULL,
	[Title] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
FOREIGN KEY (UserId) REFERENCES Users(Id)
)


