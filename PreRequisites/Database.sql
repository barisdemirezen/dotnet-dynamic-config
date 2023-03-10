
CREATE DATABASE DynamicConfig
GO

USE [DynamicConfig]
GO
/****** Object:  Table [dbo].[Parameter]    Script Date: 1/11/2023 6:00:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parameter](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [varchar](max) NULL,
	[Value] [varchar](max) NULL,
	[Environment] [varchar](max) NULL,
	[ApplicationName] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Parameter] ON 

INSERT [dbo].[Parameter] ([Id], [Key], [Value], [Environment], [ApplicationName]) VALUES (1, N'Key1', N'Value', N'Development', N'Subscriber')
INSERT [dbo].[Parameter] ([Id], [Key], [Value], [Environment], [ApplicationName]) VALUES (2, N'Key2', N'Value2', N'Development', N'Subscriber')
INSERT [dbo].[Parameter] ([Id], [Key], [Value], [Environment], [ApplicationName]) VALUES (3, N'Key3', N'Value3', N'Development', N'Subscriber')
INSERT [dbo].[Parameter] ([Id], [Key], [Value], [Environment], [ApplicationName]) VALUES (4, N'Key1', N'Value1', N'Production', N'Subscriber')
INSERT [dbo].[Parameter] ([Id], [Key], [Value], [Environment], [ApplicationName]) VALUES (5, N'Key1', N'Value1', N'Development', N'Product')
SET IDENTITY_INSERT [dbo].[Parameter] OFF
GO
