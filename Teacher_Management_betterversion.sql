CREATE DATABASE [ManagementTeacherWorks]
USE [ManagementTeacherWorks]
DROP DATABASE ManagementTeacherWorks
GO
/****** Object:  Table [dbo].[CalendarWorking]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarWorking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name_CalendarWorking] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[Address] [nvarchar](255) NULL,
	[TeacherID] [int] NOT NULL,
	[WorkID] [int] NOT NULL,
	[TypeCalendarID] [int] NOT NULL,
	[WorkState] [nvarchar](255) NULL,
	[Status] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Files] [nvarchar](max) NULL,
 CONSTRAINT [PK_CalendarWorking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[TeacherID] [int] NOT NULL,
	[MajorID] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NULL,
	[ThemeColor] [nvarchar](10) NULL,
	[IsFullDay] [bit] NOT NULL,
	[UserID] [int] NOT NULL
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[File](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[FileForm] [nvarchar](max) NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupUser]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupUser](
	[ID] [varchar](50) NOT NULL,
	[Name_GroupUser] [nvarchar](255) NULL,
	[CodeRole] [nchar](10) NULL,
 CONSTRAINT [PK_GroupUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ReportMonth]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonthReport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[ClassName] [nvarchar](255) NULL,
	[Date] [datetime] NOT NULL,
	[Files] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_MonthReport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Major]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Major](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Founding] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Major] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name_Student] [nvarchar](255) NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[ClassID] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name_Teacher] [nvarchar](255) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Avatar] [nvarchar](255) NULL,
	[Gender] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [nvarchar](255) NULL,
	[MajorID] [int] NOT NULL,
	[UserID] [int] NULL
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeCalendar]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeCalendar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](255) NULL,
	[TypeDescription] [nvarchar](255) NULL,
	[Status] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_TypeCalendar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[UserName] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[GroupID] [varchar](50) NULL,
	[Status] [bit] NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](255) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name_Work] [nvarchar](255) NULL,
	[Description_Work] [nvarchar](255) NULL,
	[Details_Work] [nvarchar](255) NULL,
	[Note] [nvarchar](255) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Work] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TeachCalendar]    Script Date: 11/29/2021 11:14:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeachCalendar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Subject_Name] [nvarchar](255) NOT NULL,
	[TeacherID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[Room] [nvarchar](50) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Note] [nvarchar](225) NULL,
	[Status] [nvarchar](50) NOT NULL
 CONSTRAINT [PK_TeachCalendar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
 
/*****Object: TeacherWork******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[TeacherWork](
--	[ID] [int] IDENTITY(1,1) NOT NULL,
--	[TeacherID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Teacher] ([ID]),
--	[WorkID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Work] ([ID]),
--	CONSTRAINT [PK_TeacherWork] PRIMARY KEY CLUSTERED
--(
--	[ID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO

--ALTER TABLE [dbo].[Teacher] WITH CHECK ADD CONSTRAINT [FK_Teacher_User] FOREIGN KEY([UserID]) 
--REFERENCES [dbo].[User] ([ID])
--GO
--ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_User]
--GO

ALTER TABLE [dbo].[TeachCalendar] WITH CHECK ADD CONSTRAINT [FK_TeachCal_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher]([ID])
GO
ALTER TABLE [dbo].[TeachCalendar] CHECK CONSTRAINT [FK_TeachCal_Teacher] 
GO

ALTER TABLE [dbo].[TeachCalendar] WITH CHECK ADD CONSTRAINT [FK_TeachCal_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class]([ID])
GO
ALTER TABLE [dbo].[TeachCalendar] CHECK CONSTRAINT [FK_TeachCal_Class]
GO

ALTER TABLE [dbo].[Event] WITH CHECK ADD CONSTRAINT [FK_Event_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_User]
GO

ALTER TABLE [dbo].[CalendarWorking]  WITH CHECK ADD  CONSTRAINT [FK_CalendarWorking_TypeCalendar] FOREIGN KEY([TypeCalendarID])
REFERENCES [dbo].[TypeCalendar] ([ID])
GO
ALTER TABLE [dbo].[CalendarWorking] CHECK CONSTRAINT [FK_CalendarWorking_TypeCalendar]
GO
ALTER TABLE [dbo].[CalendarWorking]  WITH CHECK ADD  CONSTRAINT [FK_CalendarWorking_Work] FOREIGN KEY([WorkID])
REFERENCES [dbo].[Work] ([ID])
GO
ALTER TABLE [dbo].[CalendarWorking] CHECK CONSTRAINT [FK_CalendarWorking_Work]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Major] FOREIGN KEY([MajorID])
REFERENCES [dbo].[Major] ([ID])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Major]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Teacher]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Class]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Major] FOREIGN KEY([MajorID])
REFERENCES [dbo].[Major] ([ID])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Major]
GO
ALTER TABLE [dbo].[User] WITH CHECK ADD CONSTRAINT FK_User_Role FOREIGN KEY ([GroupID]) 
REFERENCES [dbo].[GroupUser] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [User] 
ALTER COLUMN GroupID VARCHAR(50) NOT NULL;
GO

