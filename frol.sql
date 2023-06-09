USE [Study]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Access_Rights]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Access_Rights](
	[id_right] [int] IDENTITY(1,1) NOT NULL,
	[Access_right] [nvarchar](max) NULL,
	[user_id_user] [int] NULL,
 CONSTRAINT [PK_dbo.Access_Rights] PRIMARY KEY CLUSTERED 
(
	[id_right] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendance_Student]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance_Student](
	[id_attendance] [int] IDENTITY(1,1) NOT NULL,
	[Student] [int] NOT NULL,
	[date] [nvarchar](max) NULL,
	[quantity_of_hours_GR] [int] NOT NULL,
	[quantity_of_hours_nGR] [int] NOT NULL,
	[General_quantity_of_hours] [int] NOT NULL,
	[_Student_id_student] [int] NULL,
 CONSTRAINT [PK_dbo.Attendance_Student] PRIMARY KEY CLUSTERED 
(
	[id_attendance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disciplines]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disciplines](
	[id_discipline] [int] IDENTITY(1,1) NOT NULL,
	[title_discipline] [nvarchar](max) NULL,
	[teacher] [int] NOT NULL,
	[quantity_of_hours] [int] NOT NULL,
	[Teachers_id_teacher] [int] NULL,
 CONSTRAINT [PK_dbo.Disciplines] PRIMARY KEY CLUSTERED 
(
	[id_discipline] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Educational_Program]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Educational_Program](
	[id_program] [int] IDENTITY(1,1) NOT NULL,
	[title_program] [nvarchar](max) NULL,
	[head_department] [nvarchar](max) NULL,
	[form_education] [int] NOT NULL,
	[specialization] [int] NOT NULL,
	[Form_Of__id_form] [int] NULL,
	[Specialization_id_specializtion] [int] NULL,
 CONSTRAINT [PK_dbo.Educational_Program] PRIMARY KEY CLUSTERED 
(
	[id_program] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Form_Of_Education]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Form_Of_Education](
	[id_form] [int] IDENTITY(1,1) NOT NULL,
	[title_form] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Form_Of_Education] PRIMARY KEY CLUSTERED 
(
	[id_form] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[id_group] [int] IDENTITY(1,1) NOT NULL,
	[Title_group] [nvarchar](max) NULL,
	[Year_of_recruitment] [nvarchar](max) NOT NULL,
	[Elder_of_group] [nvarchar](max) NULL,
	[Director_teacher] [int] NOT NULL,
	[Educational_program] [int] NOT NULL,
	[Teacher_id_teacher] [int] NULL,
	[Educational_Program_id_program] [int] NULL,
 CONSTRAINT [PK_dbo.Groups] PRIMARY KEY CLUSTERED 
(
	[id_group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journal_Enter_Exit]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal_Enter_Exit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](max) NULL,
	[date] [nvarchar](max) NULL,
	[status] [nvarchar](max) NULL,
 CONSTRAINT [PK_Journal_Enter_Exit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journal_Interactions]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal_Interactions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](max) NULL,
	[date] [nvarchar](max) NULL,
	[status] [nvarchar](max) NULL,
 CONSTRAINT [PK_Journal_Interactions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specializations]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specializations](
	[id_specializtion] [int] IDENTITY(1,1) NOT NULL,
	[title_specialization] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Specializations] PRIMARY KEY CLUSTERED 
(
	[id_specializtion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Progress]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Progress](
	[id_progress] [int] IDENTITY(1,1) NOT NULL,
	[student] [int] NOT NULL,
	[descipline] [int] NOT NULL,
	[estimation] [int] NOT NULL,
	[Discipline_id_discipline] [int] NULL,
	[Student_id_student] [int] NULL,
 CONSTRAINT [PK_dbo.Student_Progress] PRIMARY KEY CLUSTERED 
(
	[id_progress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[id_student] [int] IDENTITY(1,1) NOT NULL,
	[FCs] [nvarchar](max) NULL,
	[numb_of_gradebook] [int] NOT NULL,
	[date_of_born] [nvarchar](max) NOT NULL,
	[address] [nvarchar](max) NULL,
	[telephone] [nvarchar](max) NULL,
	[group] [int] NOT NULL,
	[fluorography] [nvarchar](max) NULL,
	[Groups_id_group] [int] NULL,
 CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED 
(
	[id_student] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[id_teacher] [int] IDENTITY(1,1) NOT NULL,
	[FCs] [nvarchar](max) NULL,
	[E_Mail] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Teachers] PRIMARY KEY CLUSTERED 
(
	[id_teacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20.05.2022 9:59:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[FCs] [nvarchar](max) NULL,
	[Access_rights] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Access_Rights] ON 

INSERT [dbo].[Access_Rights] ([id_right], [Access_right], [user_id_user]) VALUES (1, N'Администратор', NULL)
INSERT [dbo].[Access_Rights] ([id_right], [Access_right], [user_id_user]) VALUES (2, N'Преподаватель', NULL)
INSERT [dbo].[Access_Rights] ([id_right], [Access_right], [user_id_user]) VALUES (3, N'Редактор', NULL)
SET IDENTITY_INSERT [dbo].[Access_Rights] OFF
GO
SET IDENTITY_INSERT [dbo].[Attendance_Student] ON 

INSERT [dbo].[Attendance_Student] ([id_attendance], [Student], [date], [quantity_of_hours_GR], [quantity_of_hours_nGR], [General_quantity_of_hours], [_Student_id_student]) VALUES (5, 1, N'24.11.2021', 2, 0, 2, 1)
INSERT [dbo].[Attendance_Student] ([id_attendance], [Student], [date], [quantity_of_hours_GR], [quantity_of_hours_nGR], [General_quantity_of_hours], [_Student_id_student]) VALUES (6, 1, N'23.09.2021', 1, 2, 3, 1)
INSERT [dbo].[Attendance_Student] ([id_attendance], [Student], [date], [quantity_of_hours_GR], [quantity_of_hours_nGR], [General_quantity_of_hours], [_Student_id_student]) VALUES (7, 2, N'25.02.2022', 0, 4, 4, 2)
INSERT [dbo].[Attendance_Student] ([id_attendance], [Student], [date], [quantity_of_hours_GR], [quantity_of_hours_nGR], [General_quantity_of_hours], [_Student_id_student]) VALUES (1005, 5, N'23.05.2022', 2, 2, 4, 5)
SET IDENTITY_INSERT [dbo].[Attendance_Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Disciplines] ON 

INSERT [dbo].[Disciplines] ([id_discipline], [title_discipline], [teacher], [quantity_of_hours], [Teachers_id_teacher]) VALUES (1, N'ТРПО', 1, 54, 1)
INSERT [dbo].[Disciplines] ([id_discipline], [title_discipline], [teacher], [quantity_of_hours], [Teachers_id_teacher]) VALUES (2, N'Биохимия', 4, 34, 4)
INSERT [dbo].[Disciplines] ([id_discipline], [title_discipline], [teacher], [quantity_of_hours], [Teachers_id_teacher]) VALUES (3, N'Системное программирование', 9, 56, 9)
INSERT [dbo].[Disciplines] ([id_discipline], [title_discipline], [teacher], [quantity_of_hours], [Teachers_id_teacher]) VALUES (4, N'ИСРПО', 15, 46, 15)
INSERT [dbo].[Disciplines] ([id_discipline], [title_discipline], [teacher], [quantity_of_hours], [Teachers_id_teacher]) VALUES (5, N'Метрология', 14, 26, 14)
INSERT [dbo].[Disciplines] ([id_discipline], [title_discipline], [teacher], [quantity_of_hours], [Teachers_id_teacher]) VALUES (6, N'Информационные технолгии', 3, 36, 3)
INSERT [dbo].[Disciplines] ([id_discipline], [title_discipline], [teacher], [quantity_of_hours], [Teachers_id_teacher]) VALUES (7, N'Разработка и защита баз данных', 11, 64, 11)
INSERT [dbo].[Disciplines] ([id_discipline], [title_discipline], [teacher], [quantity_of_hours], [Teachers_id_teacher]) VALUES (8, N'Английский язык', 6, 54, 6)
INSERT [dbo].[Disciplines] ([id_discipline], [title_discipline], [teacher], [quantity_of_hours], [Teachers_id_teacher]) VALUES (9, N'Философия', 5, 36, 5)
INSERT [dbo].[Disciplines] ([id_discipline], [title_discipline], [teacher], [quantity_of_hours], [Teachers_id_teacher]) VALUES (10, N'Численные методы', 10, 34, 10)
INSERT [dbo].[Disciplines] ([id_discipline], [title_discipline], [teacher], [quantity_of_hours], [Teachers_id_teacher]) VALUES (1002, N'asdsd', 0, 2, 1)
SET IDENTITY_INSERT [dbo].[Disciplines] OFF
GO
SET IDENTITY_INSERT [dbo].[Educational_Program] ON 

INSERT [dbo].[Educational_Program] ([id_program], [title_program], [head_department], [form_education], [specialization], [Form_Of__id_form], [Specialization_id_specializtion]) VALUES (1, N'Информационные системы и программирование (квалификация - программист)', N'Борисова Н.Г.', 1, 1, 1, 1)
INSERT [dbo].[Educational_Program] ([id_program], [title_program], [head_department], [form_education], [specialization], [Form_Of__id_form], [Specialization_id_specializtion]) VALUES (2, N'Оператор станков с программным управлением', N'Агрикова Е.В.', 1, 12, 1, 9)
INSERT [dbo].[Educational_Program] ([id_program], [title_program], [head_department], [form_education], [specialization], [Form_Of__id_form], [Specialization_id_specializtion]) VALUES (3, N'Технология машиностроения', N'Кожевникова Г.Н.', 2, 4, 1, 4)
INSERT [dbo].[Educational_Program] ([id_program], [title_program], [head_department], [form_education], [specialization], [Form_Of__id_form], [Specialization_id_specializtion]) VALUES (4, N'Экономика и бухгалтерский учет', N'Борисова Н.Г.', 2, 7, 2, 7)
INSERT [dbo].[Educational_Program] ([id_program], [title_program], [head_department], [form_education], [specialization], [Form_Of__id_form], [Specialization_id_specializtion]) VALUES (5, N'Операционная деятельность и логистика', N'Борисова Н.Г.', 1, 8, 2, 8)
INSERT [dbo].[Educational_Program] ([id_program], [title_program], [head_department], [form_education], [specialization], [Form_Of__id_form], [Specialization_id_specializtion]) VALUES (6, N'Товароведение и экспертиза качества потребительских товаров ', N'Рябушко А.В.', 1, 3, 2, 3)
INSERT [dbo].[Educational_Program] ([id_program], [title_program], [head_department], [form_education], [specialization], [Form_Of__id_form], [Specialization_id_specializtion]) VALUES (7, N'Сварщик (Ручной и частично механизированной сварки (наплавки))', N'Агрикова Е.В.', 1, 6, 1, 6)
INSERT [dbo].[Educational_Program] ([id_program], [title_program], [head_department], [form_education], [specialization], [Form_Of__id_form], [Specialization_id_specializtion]) VALUES (8, N'Станочник (металлообработка)', N'Агрикова Е.В.', 1, 9, 1, 9)
INSERT [dbo].[Educational_Program] ([id_program], [title_program], [head_department], [form_education], [specialization], [Form_Of__id_form], [Specialization_id_specializtion]) VALUES (10, N'Техническое обслуживание и ремонт двигателей, систем и агрегатов автомобилей', N'Кожевникова Г.Н.', 1, 4, 1, 4)
INSERT [dbo].[Educational_Program] ([id_program], [title_program], [head_department], [form_education], [specialization], [Form_Of__id_form], [Specialization_id_specializtion]) VALUES (11, N'Повар-Кондитер', N'Матюшина Н.М.', 1, 2, 1, 2)
INSERT [dbo].[Educational_Program] ([id_program], [title_program], [head_department], [form_education], [specialization], [Form_Of__id_form], [Specialization_id_specializtion]) VALUES (12, N'Оператор беспилотных авиационных систем', N'Кожевникова Г.Н.', 1, 5, 1, 5)
SET IDENTITY_INSERT [dbo].[Educational_Program] OFF
GO
SET IDENTITY_INSERT [dbo].[Form_Of_Education] ON 

INSERT [dbo].[Form_Of_Education] ([id_form], [title_form]) VALUES (1, N'Очная')
INSERT [dbo].[Form_Of_Education] ([id_form], [title_form]) VALUES (2, N'Заочная')
SET IDENTITY_INSERT [dbo].[Form_Of_Education] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([id_group], [Title_group], [Year_of_recruitment], [Elder_of_group], [Director_teacher], [Educational_program], [Teacher_id_teacher], [Educational_Program_id_program]) VALUES (1, N'19ИС-1', N'2019', N'Белова А.А', 1, 1, 1, 1)
INSERT [dbo].[Groups] ([id_group], [Title_group], [Year_of_recruitment], [Elder_of_group], [Director_teacher], [Educational_program], [Teacher_id_teacher], [Educational_Program_id_program]) VALUES (2, N'18ИС-1', N'2018', N'Иванов И.А.', 1, 1, 1, 1)
INSERT [dbo].[Groups] ([id_group], [Title_group], [Year_of_recruitment], [Elder_of_group], [Director_teacher], [Educational_program], [Teacher_id_teacher], [Educational_Program_id_program]) VALUES (3, N'20Л-1', N'2020', N'Лисина А.А.', 5, 5, 5, 5)
INSERT [dbo].[Groups] ([id_group], [Title_group], [Year_of_recruitment], [Elder_of_group], [Director_teacher], [Educational_program], [Teacher_id_teacher], [Educational_Program_id_program]) VALUES (4, N'20БСП-1', N'2020', N'Зикрин С.Э.', 10, 12, 10, 12)
INSERT [dbo].[Groups] ([id_group], [Title_group], [Year_of_recruitment], [Elder_of_group], [Director_teacher], [Educational_program], [Teacher_id_teacher], [Educational_Program_id_program]) VALUES (5, N'18ТЭП-1', N'2018', N'Зайцева А.С.', 8, 6, 8, 6)
INSERT [dbo].[Groups] ([id_group], [Title_group], [Year_of_recruitment], [Elder_of_group], [Director_teacher], [Educational_program], [Teacher_id_teacher], [Educational_Program_id_program]) VALUES (7, N'20АДС-1', N'2020', N'Мизонов Е.А.', 12, 10, 12, 10)
INSERT [dbo].[Groups] ([id_group], [Title_group], [Year_of_recruitment], [Elder_of_group], [Director_teacher], [Educational_program], [Teacher_id_teacher], [Educational_Program_id_program]) VALUES (8, N'19Э-1', N'2019', N'Шангина А.Н.', 3, 4, 3, 4)
INSERT [dbo].[Groups] ([id_group], [Title_group], [Year_of_recruitment], [Elder_of_group], [Director_teacher], [Educational_program], [Teacher_id_teacher], [Educational_Program_id_program]) VALUES (9, N'18П-2', N'2018', N'Ковалева К.А.', 12, 11, 12, 11)
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Journal_Enter_Exit] ON 

INSERT [dbo].[Journal_Enter_Exit] ([id], [username], [date], [status]) VALUES (6, N'admin', N'18.05.2022 0:00:00', N'Пользователь вошел в систему')
INSERT [dbo].[Journal_Enter_Exit] ([id], [username], [date], [status]) VALUES (7, N'admin', N'18.05.2022 0:00:00', N'Пользователь вошел в систему')
INSERT [dbo].[Journal_Enter_Exit] ([id], [username], [date], [status]) VALUES (11, N'admin', N'20.05.2022 0:00:00', N'Пользователь вошел в систему')
INSERT [dbo].[Journal_Enter_Exit] ([id], [username], [date], [status]) VALUES (12, N'admin', N'20.05.2022 0:00:00', N'Пользователь вышел из системы')
SET IDENTITY_INSERT [dbo].[Journal_Enter_Exit] OFF
GO
SET IDENTITY_INSERT [dbo].[Journal_Interactions] ON 

INSERT [dbo].[Journal_Interactions] ([id], [username], [date], [status]) VALUES (1, N'admin', N'20.05.2022 0:00:00', N'Добавление данных в таблицу Students')
SET IDENTITY_INSERT [dbo].[Journal_Interactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Specializations] ON 

INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (1, N'Программист')
INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (2, N'Повар')
INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (3, N'Товаровед')
INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (4, N'Автомеханик')
INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (5, N'Оператор беспилотных систем')
INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (6, N'Сварщик')
INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (7, N'Экономист')
INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (8, N'Логист')
INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (9, N'Станочник')
INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (10, N'Слесарь-сборщик')
INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (11, N'Техник')
INSERT [dbo].[Specializations] ([id_specializtion], [title_specialization]) VALUES (12, N'Оператор станков')
SET IDENTITY_INSERT [dbo].[Specializations] OFF
GO
SET IDENTITY_INSERT [dbo].[Student_Progress] ON 

INSERT [dbo].[Student_Progress] ([id_progress], [student], [descipline], [estimation], [Discipline_id_discipline], [Student_id_student]) VALUES (1, 1, 1, 5, 1, 1)
INSERT [dbo].[Student_Progress] ([id_progress], [student], [descipline], [estimation], [Discipline_id_discipline], [Student_id_student]) VALUES (2, 1, 10, 4, 10, 1)
INSERT [dbo].[Student_Progress] ([id_progress], [student], [descipline], [estimation], [Discipline_id_discipline], [Student_id_student]) VALUES (3, 3, 4, 5, 4, 3)
INSERT [dbo].[Student_Progress] ([id_progress], [student], [descipline], [estimation], [Discipline_id_discipline], [Student_id_student]) VALUES (4, 2, 9, 4, 9, 2)
INSERT [dbo].[Student_Progress] ([id_progress], [student], [descipline], [estimation], [Discipline_id_discipline], [Student_id_student]) VALUES (5, 6, 9, 4, 9, 6)
INSERT [dbo].[Student_Progress] ([id_progress], [student], [descipline], [estimation], [Discipline_id_discipline], [Student_id_student]) VALUES (6, 6, 10, 4, 10, 6)
INSERT [dbo].[Student_Progress] ([id_progress], [student], [descipline], [estimation], [Discipline_id_discipline], [Student_id_student]) VALUES (7, 5, 6, 5, 6, 5)
INSERT [dbo].[Student_Progress] ([id_progress], [student], [descipline], [estimation], [Discipline_id_discipline], [Student_id_student]) VALUES (8, 5, 9, 5, 9, 5)
SET IDENTITY_INSERT [dbo].[Student_Progress] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([id_student], [FCs], [numb_of_gradebook], [date_of_born], [address], [telephone], [group], [fluorography], [Groups_id_group]) VALUES (1, N'Фролов Д.А.', 234523, N'24.11.2003', N'Димитрова, 18', N'8(902)-152-93-87', 1, N'Присутствует', 1)
INSERT [dbo].[Students] ([id_student], [FCs], [numb_of_gradebook], [date_of_born], [address], [telephone], [group], [fluorography], [Groups_id_group]) VALUES (2, N'Дронин Д.А.', 234234, N'16.03.2001', N'Созидателей, 13', N'8(232)-232-23-23', 1, N'Отсутствует', 1)
INSERT [dbo].[Students] ([id_student], [FCs], [numb_of_gradebook], [date_of_born], [address], [telephone], [group], [fluorography], [Groups_id_group]) VALUES (4, N'Мизонов Е.В', 246456, N'11.09.2004', N'Ленком, 25', N'8(232)-25-64-53', 7, N'Присутствует', 7)
INSERT [dbo].[Students] ([id_student], [FCs], [numb_of_gradebook], [date_of_born], [address], [telephone], [group], [fluorography], [Groups_id_group]) VALUES (5, N'Казаков М.О.', 254771, N'29.03.2003', N'Ульяновский, 5', N'8(243)-46-65-21', 4, N'Присутствует', 4)
INSERT [dbo].[Students] ([id_student], [FCs], [numb_of_gradebook], [date_of_born], [address], [telephone], [group], [fluorography], [Groups_id_group]) VALUES (1012, N'Кеков К.К.', 228788, N'01.01.1900', N'Ул.Пушкина, д.12', N'+7(800)-555-35-35', 0, N'Отсутствует', 8)
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (1, N'Кякшта М.А.', N'kyakshta@mail.ru')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (2, N'Борисова Н.Г.', N'borisova@mail.ru')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (3, N'Кирилина М.А.', N'kirilina@mail.ru')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (4, N'Ершова Н.А.', N'ershova@gmail.com')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (5, N'Брайцара А.А.', N'braicara@gmail.com')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (6, N'Левченкова Н.В.', N'levchenkova@mail.ru')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (7, N'Брындина И.С.', N'bryndina@gmail.com')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (8, N'Абрамова Л.Б.', N'abramova@mail.ru')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (9, N'Мардамшина А.А.', N'mardamshina@inbox.ru')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (10, N'Чубыкина М.М.', N'chybikina@gmai.com')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (11, N'Сквалецая Н.В.', N'skvaleckaya@mail.ru')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (12, N'Суздалева Е.А.', N'suzdaleva@mail.ru')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (13, N'Симонова Е.А.', N'simonova@gmail.com')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (14, N'Солуянова Л.П.', N'soluyanova@mail.ru')
INSERT [dbo].[Teachers] ([id_teacher], [FCs], [E_Mail]) VALUES (15, N'Березин Б.А.', N'berezin@inbox.ru')
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (1, N'Логин', N'Пароль', N'Фрол', 1)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (2, N'AdminStray ', N'Stray778', N'Дронин Д.А.', 1)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (3, N'kyakshtaMA', N'KYakShta73', N'Кякшта М.А.', 2)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (4, N'BoriSova223', N'BorISova773', N'Борисова Н.Г.', 2)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (5, N'ErshovaNina', N'Nina12321', N'Ершова Н.А.', 2)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (6, N'Bryndina12', N'BryndinaIrina123', N'Брындина И.С.', 2)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (7, N'Mardamshik', N'MaRdamshina45', N'Мардамшина А.А.', 2)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (8, N'Chybikina', N'TeorVer776', N'Чубыкина М.М.', 2)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (9, N'Bebrezin', N'cmdrus', N'Березин Б.А.', 2)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (10, N'Levchenkova', N'LevchekovaNadezhda', N'Левченкова Н.В.', 2)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (11, N'Braycara', N'Phylosophy', N'Брайцара А.А.', 2)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (12, N'admin', N'admin', N'asdsad', 1)
INSERT [dbo].[Users] ([id_user], [Login], [Password], [FCs], [Access_rights]) VALUES (1002, N'lox', N'haha', N'lox', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_user_id_user]    Script Date: 20.05.2022 9:59:59 ******/
CREATE NONCLUSTERED INDEX [IX_user_id_user] ON [dbo].[Access_Rights]
(
	[user_id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX__Student_id_student]    Script Date: 20.05.2022 9:59:59 ******/
CREATE NONCLUSTERED INDEX [IX__Student_id_student] ON [dbo].[Attendance_Student]
(
	[_Student_id_student] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teachers_id_teacher]    Script Date: 20.05.2022 9:59:59 ******/
CREATE NONCLUSTERED INDEX [IX_Teachers_id_teacher] ON [dbo].[Disciplines]
(
	[Teachers_id_teacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Form_Of__id_form]    Script Date: 20.05.2022 9:59:59 ******/
CREATE NONCLUSTERED INDEX [IX_Form_Of__id_form] ON [dbo].[Educational_Program]
(
	[Form_Of__id_form] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Specialization_id_specializtion]    Script Date: 20.05.2022 9:59:59 ******/
CREATE NONCLUSTERED INDEX [IX_Specialization_id_specializtion] ON [dbo].[Educational_Program]
(
	[Specialization_id_specializtion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Educational_Program_id_program]    Script Date: 20.05.2022 9:59:59 ******/
CREATE NONCLUSTERED INDEX [IX_Educational_Program_id_program] ON [dbo].[Groups]
(
	[Educational_Program_id_program] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teacher_id_teacher]    Script Date: 20.05.2022 9:59:59 ******/
CREATE NONCLUSTERED INDEX [IX_Teacher_id_teacher] ON [dbo].[Groups]
(
	[Teacher_id_teacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Discipline_id_discipline]    Script Date: 20.05.2022 9:59:59 ******/
CREATE NONCLUSTERED INDEX [IX_Discipline_id_discipline] ON [dbo].[Student_Progress]
(
	[Discipline_id_discipline] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Student_id_student]    Script Date: 20.05.2022 9:59:59 ******/
CREATE NONCLUSTERED INDEX [IX_Student_id_student] ON [dbo].[Student_Progress]
(
	[Student_id_student] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Groups_id_group]    Script Date: 20.05.2022 9:59:59 ******/
CREATE NONCLUSTERED INDEX [IX_Groups_id_group] ON [dbo].[Students]
(
	[Groups_id_group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Access_Rights]  WITH NOCHECK ADD  CONSTRAINT [FK_dbo.Access_Rights_dbo.Users_user_id_user] FOREIGN KEY([user_id_user])
REFERENCES [dbo].[Users] ([id_user])
GO
ALTER TABLE [dbo].[Access_Rights] NOCHECK CONSTRAINT [FK_dbo.Access_Rights_dbo.Users_user_id_user]
GO
ALTER TABLE [dbo].[Attendance_Student]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Attendance_Student_dbo.Students__Student_id_student] FOREIGN KEY([_Student_id_student])
REFERENCES [dbo].[Students] ([id_student])
GO
ALTER TABLE [dbo].[Attendance_Student] CHECK CONSTRAINT [FK_dbo.Attendance_Student_dbo.Students__Student_id_student]
GO
ALTER TABLE [dbo].[Disciplines]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Disciplines_dbo.Teachers_Teachers_id_teacher] FOREIGN KEY([Teachers_id_teacher])
REFERENCES [dbo].[Teachers] ([id_teacher])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Disciplines] CHECK CONSTRAINT [FK_dbo.Disciplines_dbo.Teachers_Teachers_id_teacher]
GO
ALTER TABLE [dbo].[Educational_Program]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Educational_Program_dbo.Form_Of_Education_Form_Of__id_form] FOREIGN KEY([Form_Of__id_form])
REFERENCES [dbo].[Form_Of_Education] ([id_form])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Educational_Program] CHECK CONSTRAINT [FK_dbo.Educational_Program_dbo.Form_Of_Education_Form_Of__id_form]
GO
ALTER TABLE [dbo].[Educational_Program]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Educational_Program_dbo.Specializations_Specialization_id_specializtion] FOREIGN KEY([Specialization_id_specializtion])
REFERENCES [dbo].[Specializations] ([id_specializtion])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Educational_Program] CHECK CONSTRAINT [FK_dbo.Educational_Program_dbo.Specializations_Specialization_id_specializtion]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Groups_dbo.Educational_Program_Educational_Program_id_program] FOREIGN KEY([Educational_Program_id_program])
REFERENCES [dbo].[Educational_Program] ([id_program])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_dbo.Groups_dbo.Educational_Program_Educational_Program_id_program]
GO
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Groups_dbo.Teachers_Teacher_id_teacher] FOREIGN KEY([Teacher_id_teacher])
REFERENCES [dbo].[Teachers] ([id_teacher])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_dbo.Groups_dbo.Teachers_Teacher_id_teacher]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Students_dbo.Groups_Groups_id_group] FOREIGN KEY([Groups_id_group])
REFERENCES [dbo].[Groups] ([id_group])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.Groups_Groups_id_group]
GO
