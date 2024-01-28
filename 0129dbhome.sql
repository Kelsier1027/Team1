USE [dbteam1ch]
GO
/****** Object:  Table [dbo].[AdminRoles]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdminId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AdminRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttractionCategories]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttractionCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AttractionCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttractionContents]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttractionContents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttractionId] [int] NOT NULL,
	[Context] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AttractionContexts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttractionImages]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttractionImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttractionId] [int] NOT NULL,
	[FileName] [varchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_AttractionImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttractionOrders]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttractionOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[OrderDate] [datetime] NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[AttractionOrderStatusId] [int] NOT NULL,
 CONSTRAINT [PK_AttractionOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttractionOrderStatuses]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttractionOrderStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AttractionOrderStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attractions]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attractions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[AttractionCategoryId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[MainImage] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Attractions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttractionTickets]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttractionTickets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttractionId] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Discount] [int] NOT NULL,
	[AttractionTicketTypeId] [int] NOT NULL,
	[TicketStatus] [bit] NOT NULL,
 CONSTRAINT [PK_AttractionTickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttractionTicketStocks]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttractionTicketStocks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttractionTicketId] [int] NOT NULL,
	[stock] [int] NOT NULL,
	[ReserveDate] [datetime] NULL,
 CONSTRAINT [PK_AttractionTicketStocks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttractionTicketTypes]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttractionTicketTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AttractionTicketTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttrationOrderItems]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttrationOrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttractionOrderId] [int] NOT NULL,
	[AttractionTicketId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[UnitPrice] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_AttrationOrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BEAdmins]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BEAdmins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](20) NOT NULL,
	[EncryptedPassword] [varchar](max) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
	[Salt] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarBrands]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarBrands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarEnergyTypes]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarEnergyTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EnergyTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarModelImages]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarModelImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[CarModelId] [int] NOT NULL,
 CONSTRAINT [PK_CarModelImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarModels]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BrandId] [int] NOT NULL,
	[TransmissionId] [int] NOT NULL,
	[EnergyTypeId] [int] NOT NULL,
	[Seats] [int] NOT NULL,
	[FeePerDay] [int] NOT NULL,
	[MainImage] [nvarchar](50) NULL,
	[MaintenanceMileage] [int] NOT NULL,
 CONSTRAINT [PK_CarModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarOrders]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[CarId] [int] NOT NULL,
	[AdminId] [int] NULL,
	[StartDateTime] [datetime2](7) NOT NULL,
	[EndDateTime] [datetime2](7) NOT NULL,
	[Price] [int] NOT NULL,
	[CarOrderStatusId] [int] NOT NULL,
 CONSTRAINT [PK_CarOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarOrderStatuses]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarOrderStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CarOrderStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarModelId] [int] NOT NULL,
	[CarLicenceId] [nvarchar](50) NOT NULL,
	[Mileage] [int] NOT NULL,
	[CarStatusId] [int] NOT NULL,
	[DistrictId] [int] NOT NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarStatuses]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CarStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarTransmissions]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarTransmissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Transmissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentImages]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](50) NOT NULL,
	[CommentId] [int] NOT NULL,
 CONSTRAINT [PK_CommentImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[Text] [nvarchar](50) NULL,
	[CommentDateTime] [datetime] NOT NULL,
	[ServiceCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Districts]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_Districts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelCategories]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JAON] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_HotelCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelImages]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[HotelId] [int] NOT NULL,
 CONSTRAINT [PK_HotelImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelOrderCancelReasons]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelOrderCancelReasons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HotelOrderCancelReasons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelOrderItems]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelOrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelRoomId] [int] NOT NULL,
	[HotelOrderId] [int] NOT NULL,
 CONSTRAINT [PK_HotelRoomOrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelOrders]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderSn] [varchar](50) NOT NULL,
	[NumberOfPeople] [int] NOT NULL,
	[Breakfast] [bit] NOT NULL,
	[HotelOrderStatusId] [int] NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[CreditCard] [nvarchar](50) NOT NULL,
	[MemberId] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Checkin] [datetime] NOT NULL,
	[Checkout] [datetime] NOT NULL,
	[HotelOrderCancelReasonId] [int] NULL,
	[AdminId] [int] NOT NULL,
 CONSTRAINT [PK_HotelOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelOrderStatuses]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelOrderStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HotelOrderStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelRoomImages]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelRoomImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[HotelRoomId] [int] NOT NULL,
 CONSTRAINT [PK_HotelRoomImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelRooms]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelRooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[HotelId] [int] NOT NULL,
	[Size] [nvarchar](50) NOT NULL,
	[RoomFacilities] [nvarchar](max) NOT NULL,
	[Capacity] [int] NOT NULL,
	[BedCapacity] [int] NOT NULL,
	[MainImage] [varchar](max) NOT NULL,
	[WeekdayPrice] [int] NOT NULL,
	[WeekendPrice] [int] NOT NULL,
	[AddTimeFee] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_HotelRooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NOT NULL,
	[DistrictId] [int] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Grade] [decimal](3, 1) NOT NULL,
	[Phone] [nchar](10) NOT NULL,
	[Level] [int] NULL,
	[MainImage] [varchar](max) NOT NULL,
	[CheckinStart] [time](7) NOT NULL,
	[CheckinEnd] [time](7) NULL,
	[CheckoutStart] [time](7) NULL,
	[CheckoutEnd] [time](7) NOT NULL,
	[AddBedFee] [int] NULL,
	[BreakfastPrice] [int] NULL,
	[HotelTypeId] [int] NOT NULL,
	[HotelFacilities] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelTypes]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HotelTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberActivityRecords]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberActivityRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[ActivityTime] [datetime] NOT NULL,
	[ActivityType] [bit] NOT NULL,
	[SessionDuration] [int] NULL,
	[IpAddress] [varchar](50) NULL,
	[Device] [varbinary](50) NULL,
 CONSTRAINT [PK_MemberActivityRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberLevels]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberLevels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[QualifyingAmount] [int] NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_MemberLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberPersonalInfos]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberPersonalInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[IDNumber] [char](10) NULL,
	[BirthDate] [datetime] NULL,
	[PhoneNumber] [char](10) NULL,
	[Address] [nvarchar](100) NULL,
	[EmCName] [nvarchar](40) NULL,
	[EmCPhone] [char](10) NULL,
 CONSTRAINT [PK_MemberPersonalInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberProfiles]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberProfiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[GenderId] [int] NULL,
	[ProfileImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_MemberProfiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nchar](30) NOT NULL,
	[EncryptedPassword] [varchar](max) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
	[Salt] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageAttractionItems]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageAttractionItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttractionId] [int] NOT NULL,
	[PackageId] [int] NOT NULL,
 CONSTRAINT [PK_PackageAttractionItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageHotelRoomItems]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageHotelRoomItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelRoomId] [int] NOT NULL,
	[PackageId] [int] NOT NULL,
 CONSTRAINT [PK_PackageHotelRoomItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageMemos]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageMemos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Days] [int] NOT NULL,
	[DaysMemo] [nvarchar](max) NOT NULL,
	[Breakfast] [nvarchar](200) NOT NULL,
	[Lunch] [nvarchar](200) NOT NULL,
	[Dinner] [nvarchar](200) NOT NULL,
	[PackageId] [int] NOT NULL,
 CONSTRAINT [PK_PackageMemos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageOrderStatuses]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageOrderStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_PackageStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageOrdes]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageOrdes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PackageId] [int] NOT NULL,
	[BeginDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[PackageOrdeStatusId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
 CONSTRAINT [PK_PackageOrdes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Packages]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Packages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[LowestGo] [int] NOT NULL,
	[ApplyEndDate] [datetime] NOT NULL,
	[ApplyBeginDate] [datetime] NOT NULL,
	[CanSold] [int] NOT NULL,
	[TotalNum] [int] NOT NULL,
	[Image] [varchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Alert] [nvarchar](50) NOT NULL,
	[PriceDescription] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Packages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PointTransctions]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PointTransctions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[TransactionType] [varchar](20) NOT NULL,
	[TransactionCategory] [varchar](30) NOT NULL,
	[Amount] [varchar](30) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PointTransctions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QAs]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QAs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceCategoryId] [int] NOT NULL,
	[QName] [nvarchar](50) NOT NULL,
	[AnsText] [nvarchar](500) NULL,
 CONSTRAINT [PK_QAs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissions]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceCategories]    Script Date: 2024/1/29 AM 12:44:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CommentCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AttractionCategories] ON 

INSERT [dbo].[AttractionCategories] ([Id], [Name]) VALUES (5, N'公園')
INSERT [dbo].[AttractionCategories] ([Id], [Name]) VALUES (6, N'水族館')
INSERT [dbo].[AttractionCategories] ([Id], [Name]) VALUES (3, N'主題樂園')
INSERT [dbo].[AttractionCategories] ([Id], [Name]) VALUES (1, N'古蹟')
INSERT [dbo].[AttractionCategories] ([Id], [Name]) VALUES (7, N'動物園')
INSERT [dbo].[AttractionCategories] ([Id], [Name]) VALUES (4, N'博物館')
INSERT [dbo].[AttractionCategories] ([Id], [Name]) VALUES (9, N'溫泉')
INSERT [dbo].[AttractionCategories] ([Id], [Name]) VALUES (8, N'遊樂場')
INSERT [dbo].[AttractionCategories] ([Id], [Name]) VALUES (2, N'觀景台')
SET IDENTITY_INSERT [dbo].[AttractionCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Attractions] ON 

INSERT [dbo].[Attractions] ([Id], [Name], [Address], [AttractionCategoryId], [CityId], [Description], [MainImage]) VALUES (1, N'TAIPEI 101', N'110台北市信義區信義路五段7號', 2, 1, N'台北101是位於臺灣臺北市信義計畫區的超高層摩天大樓，樓高509.2公尺，地上101層、地下5層。於2004年12月1日落成至2010年1月4日是世界第一高樓。目前是台灣第一高樓，以及臺灣唯一高度超過500公尺、樓層超過100層的建築物。', N'test')
SET IDENTITY_INSERT [dbo].[Attractions] OFF
GO
SET IDENTITY_INSERT [dbo].[Cities] ON 

INSERT [dbo].[Cities] ([Id], [Name]) VALUES (1, N'台北')
SET IDENTITY_INSERT [dbo].[Cities] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_AttractionCategories_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[AttractionCategories] ADD  CONSTRAINT [UQ_AttractionCategories_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Brands_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[CarBrands] ADD  CONSTRAINT [UQ_Brands_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_EnergyTypes_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[CarEnergyTypes] ADD  CONSTRAINT [UQ_EnergyTypes_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_CarModels_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[CarModels] ADD  CONSTRAINT [UQ_CarModels_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_CarOrderStatuses_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[CarOrderStatuses] ADD  CONSTRAINT [UQ_CarOrderStatuses_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_CarStatuses_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[CarStatuses] ADD  CONSTRAINT [UQ_CarStatuses_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Transmissions_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[CarTransmissions] ADD  CONSTRAINT [UQ_Transmissions_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Cities_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[Cities] ADD  CONSTRAINT [UQ_Cities_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Districts_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[Districts] ADD  CONSTRAINT [UQ_Districts_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_HotelOrderCancelReasons_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[HotelOrderCancelReasons] ADD  CONSTRAINT [UQ_HotelOrderCancelReasons_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_HotelOrderStatuses_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[HotelOrderStatuses] ADD  CONSTRAINT [UQ_HotelOrderStatuses_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_HotelTypes_Name]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[HotelTypes] ADD  CONSTRAINT [UQ_HotelTypes_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Members_Accont]    Script Date: 2024/1/29 AM 12:45:25 ******/
ALTER TABLE [dbo].[Members] ADD  CONSTRAINT [UQ_Members_Accont] UNIQUE NONCLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdminRoles]  WITH CHECK ADD  CONSTRAINT [FK_AdminRoles_Admins] FOREIGN KEY([AdminId])
REFERENCES [dbo].[BEAdmins] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AdminRoles] CHECK CONSTRAINT [FK_AdminRoles_Admins]
GO
ALTER TABLE [dbo].[AdminRoles]  WITH CHECK ADD  CONSTRAINT [FK_AdminRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[AdminRoles] CHECK CONSTRAINT [FK_AdminRoles_Roles]
GO
ALTER TABLE [dbo].[AttractionContents]  WITH CHECK ADD  CONSTRAINT [FK_AttractionContents_Attractions] FOREIGN KEY([AttractionId])
REFERENCES [dbo].[Attractions] ([Id])
GO
ALTER TABLE [dbo].[AttractionContents] CHECK CONSTRAINT [FK_AttractionContents_Attractions]
GO
ALTER TABLE [dbo].[AttractionImages]  WITH CHECK ADD  CONSTRAINT [FK_AttractionImages_Attractions] FOREIGN KEY([AttractionId])
REFERENCES [dbo].[Attractions] ([Id])
GO
ALTER TABLE [dbo].[AttractionImages] CHECK CONSTRAINT [FK_AttractionImages_Attractions]
GO
ALTER TABLE [dbo].[AttractionOrders]  WITH CHECK ADD  CONSTRAINT [FK_AttractionOrders_AttractionOrderStatuses] FOREIGN KEY([AttractionOrderStatusId])
REFERENCES [dbo].[AttractionOrderStatuses] ([Id])
GO
ALTER TABLE [dbo].[AttractionOrders] CHECK CONSTRAINT [FK_AttractionOrders_AttractionOrderStatuses]
GO
ALTER TABLE [dbo].[AttractionOrders]  WITH CHECK ADD  CONSTRAINT [FK_AttractionOrders_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[AttractionOrders] CHECK CONSTRAINT [FK_AttractionOrders_Members]
GO
ALTER TABLE [dbo].[Attractions]  WITH CHECK ADD  CONSTRAINT [FK_Attractions_AttractionCategories] FOREIGN KEY([AttractionCategoryId])
REFERENCES [dbo].[AttractionCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attractions] CHECK CONSTRAINT [FK_Attractions_AttractionCategories]
GO
ALTER TABLE [dbo].[Attractions]  WITH CHECK ADD  CONSTRAINT [FK_Attractions_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Attractions] CHECK CONSTRAINT [FK_Attractions_Cities]
GO
ALTER TABLE [dbo].[AttractionTickets]  WITH CHECK ADD  CONSTRAINT [FK_AttractionTickets_AttractionTickets] FOREIGN KEY([AttractionId])
REFERENCES [dbo].[Attractions] ([Id])
GO
ALTER TABLE [dbo].[AttractionTickets] CHECK CONSTRAINT [FK_AttractionTickets_AttractionTickets]
GO
ALTER TABLE [dbo].[AttractionTickets]  WITH CHECK ADD  CONSTRAINT [FK_AttractionTickets_AttractionTicketTypes] FOREIGN KEY([AttractionTicketTypeId])
REFERENCES [dbo].[AttractionTicketTypes] ([Id])
GO
ALTER TABLE [dbo].[AttractionTickets] CHECK CONSTRAINT [FK_AttractionTickets_AttractionTicketTypes]
GO
ALTER TABLE [dbo].[AttractionTicketStocks]  WITH CHECK ADD  CONSTRAINT [FK_AttractionTicketStocks_AttractionTickets] FOREIGN KEY([AttractionTicketId])
REFERENCES [dbo].[AttractionTickets] ([Id])
GO
ALTER TABLE [dbo].[AttractionTicketStocks] CHECK CONSTRAINT [FK_AttractionTicketStocks_AttractionTickets]
GO
ALTER TABLE [dbo].[AttrationOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_AttrationOrderItems_AttractionOrders] FOREIGN KEY([AttractionOrderId])
REFERENCES [dbo].[AttractionOrders] ([Id])
GO
ALTER TABLE [dbo].[AttrationOrderItems] CHECK CONSTRAINT [FK_AttrationOrderItems_AttractionOrders]
GO
ALTER TABLE [dbo].[AttrationOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_AttrationOrderItems_AttractionTickets] FOREIGN KEY([AttractionTicketId])
REFERENCES [dbo].[AttractionTickets] ([Id])
GO
ALTER TABLE [dbo].[AttrationOrderItems] CHECK CONSTRAINT [FK_AttrationOrderItems_AttractionTickets]
GO
ALTER TABLE [dbo].[CarModelImages]  WITH CHECK ADD  CONSTRAINT [FK_CarModelImages_CarModels] FOREIGN KEY([CarModelId])
REFERENCES [dbo].[CarModels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarModelImages] CHECK CONSTRAINT [FK_CarModelImages_CarModels]
GO
ALTER TABLE [dbo].[CarModels]  WITH CHECK ADD  CONSTRAINT [FK_CarModels_Brands] FOREIGN KEY([BrandId])
REFERENCES [dbo].[CarBrands] ([Id])
GO
ALTER TABLE [dbo].[CarModels] CHECK CONSTRAINT [FK_CarModels_Brands]
GO
ALTER TABLE [dbo].[CarModels]  WITH CHECK ADD  CONSTRAINT [FK_CarModels_CarEnergyTypes] FOREIGN KEY([EnergyTypeId])
REFERENCES [dbo].[CarEnergyTypes] ([Id])
GO
ALTER TABLE [dbo].[CarModels] CHECK CONSTRAINT [FK_CarModels_CarEnergyTypes]
GO
ALTER TABLE [dbo].[CarModels]  WITH CHECK ADD  CONSTRAINT [FK_CarModels_Transmissions] FOREIGN KEY([TransmissionId])
REFERENCES [dbo].[CarTransmissions] ([Id])
GO
ALTER TABLE [dbo].[CarModels] CHECK CONSTRAINT [FK_CarModels_Transmissions]
GO
ALTER TABLE [dbo].[CarOrders]  WITH CHECK ADD  CONSTRAINT [FK_CarOrders_Admins] FOREIGN KEY([AdminId])
REFERENCES [dbo].[BEAdmins] ([Id])
GO
ALTER TABLE [dbo].[CarOrders] CHECK CONSTRAINT [FK_CarOrders_Admins]
GO
ALTER TABLE [dbo].[CarOrders]  WITH CHECK ADD  CONSTRAINT [FK_CarOrders_CarOrderStatuses] FOREIGN KEY([CarOrderStatusId])
REFERENCES [dbo].[CarOrderStatuses] ([Id])
GO
ALTER TABLE [dbo].[CarOrders] CHECK CONSTRAINT [FK_CarOrders_CarOrderStatuses]
GO
ALTER TABLE [dbo].[CarOrders]  WITH CHECK ADD  CONSTRAINT [FK_CarOrders_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[CarOrders] CHECK CONSTRAINT [FK_CarOrders_Cars]
GO
ALTER TABLE [dbo].[CarOrders]  WITH CHECK ADD  CONSTRAINT [FK_CarOrders_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[CarOrders] CHECK CONSTRAINT [FK_CarOrders_Members]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_CarModels] FOREIGN KEY([CarModelId])
REFERENCES [dbo].[CarModels] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_CarModels]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_CarStatuses] FOREIGN KEY([CarStatusId])
REFERENCES [dbo].[CarStatuses] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_CarStatuses]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Districts] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Districts]
GO
ALTER TABLE [dbo].[CommentImages]  WITH CHECK ADD  CONSTRAINT [FK_CommentImages_Comments] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comments] ([Id])
GO
ALTER TABLE [dbo].[CommentImages] CHECK CONSTRAINT [FK_CommentImages_Comments]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Members1] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Members1]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_ServiceCategories] FOREIGN KEY([ServiceCategoryId])
REFERENCES [dbo].[ServiceCategories] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_ServiceCategories]
GO
ALTER TABLE [dbo].[Districts]  WITH CHECK ADD  CONSTRAINT [FK_Districts_Cities] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Districts] CHECK CONSTRAINT [FK_Districts_Cities]
GO
ALTER TABLE [dbo].[HotelImages]  WITH CHECK ADD  CONSTRAINT [FK_HotelImages_Hotels] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
GO
ALTER TABLE [dbo].[HotelImages] CHECK CONSTRAINT [FK_HotelImages_Hotels]
GO
ALTER TABLE [dbo].[HotelOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_HotelOrderItems_HotelOrders] FOREIGN KEY([HotelOrderId])
REFERENCES [dbo].[HotelOrders] ([Id])
GO
ALTER TABLE [dbo].[HotelOrderItems] CHECK CONSTRAINT [FK_HotelOrderItems_HotelOrders]
GO
ALTER TABLE [dbo].[HotelOrderItems]  WITH CHECK ADD  CONSTRAINT [FK_HotelRoomOrderItems_HotelRooms] FOREIGN KEY([HotelRoomId])
REFERENCES [dbo].[HotelRooms] ([Id])
GO
ALTER TABLE [dbo].[HotelOrderItems] CHECK CONSTRAINT [FK_HotelRoomOrderItems_HotelRooms]
GO
ALTER TABLE [dbo].[HotelOrders]  WITH CHECK ADD  CONSTRAINT [FK_HotelOrders_Admins] FOREIGN KEY([AdminId])
REFERENCES [dbo].[BEAdmins] ([Id])
GO
ALTER TABLE [dbo].[HotelOrders] CHECK CONSTRAINT [FK_HotelOrders_Admins]
GO
ALTER TABLE [dbo].[HotelOrders]  WITH CHECK ADD  CONSTRAINT [FK_HotelOrders_HotelOrderCancelReasons] FOREIGN KEY([HotelOrderCancelReasonId])
REFERENCES [dbo].[HotelOrderCancelReasons] ([Id])
GO
ALTER TABLE [dbo].[HotelOrders] CHECK CONSTRAINT [FK_HotelOrders_HotelOrderCancelReasons]
GO
ALTER TABLE [dbo].[HotelOrders]  WITH CHECK ADD  CONSTRAINT [FK_HotelOrders_HotelOrderStatuses] FOREIGN KEY([HotelOrderStatusId])
REFERENCES [dbo].[HotelOrderStatuses] ([Id])
GO
ALTER TABLE [dbo].[HotelOrders] CHECK CONSTRAINT [FK_HotelOrders_HotelOrderStatuses]
GO
ALTER TABLE [dbo].[HotelOrders]  WITH CHECK ADD  CONSTRAINT [FK_HotelOrders_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[HotelOrders] CHECK CONSTRAINT [FK_HotelOrders_Members]
GO
ALTER TABLE [dbo].[HotelRoomImages]  WITH CHECK ADD  CONSTRAINT [FK_HotelRoomImages_HotelRooms] FOREIGN KEY([HotelRoomId])
REFERENCES [dbo].[HotelRooms] ([Id])
GO
ALTER TABLE [dbo].[HotelRoomImages] CHECK CONSTRAINT [FK_HotelRoomImages_HotelRooms]
GO
ALTER TABLE [dbo].[HotelRooms]  WITH CHECK ADD  CONSTRAINT [FK_HotelRooms_Hotels] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HotelRooms] CHECK CONSTRAINT [FK_HotelRooms_Hotels]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK_Hotels_Districts] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([Id])
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK_Hotels_Districts]
GO
ALTER TABLE [dbo].[Hotels]  WITH CHECK ADD  CONSTRAINT [FK_Hotels_HotelTypes] FOREIGN KEY([HotelTypeId])
REFERENCES [dbo].[HotelTypes] ([Id])
GO
ALTER TABLE [dbo].[Hotels] CHECK CONSTRAINT [FK_Hotels_HotelTypes]
GO
ALTER TABLE [dbo].[MemberActivityRecords]  WITH CHECK ADD  CONSTRAINT [FK_MemberActivityRecords_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[MemberActivityRecords] CHECK CONSTRAINT [FK_MemberActivityRecords_Members]
GO
ALTER TABLE [dbo].[MemberPersonalInfos]  WITH CHECK ADD  CONSTRAINT [FK_MemberPersonalInfos_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MemberPersonalInfos] CHECK CONSTRAINT [FK_MemberPersonalInfos_Members]
GO
ALTER TABLE [dbo].[MemberProfiles]  WITH CHECK ADD  CONSTRAINT [FK_MemberProfiles_Genders] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Genders] ([Id])
GO
ALTER TABLE [dbo].[MemberProfiles] CHECK CONSTRAINT [FK_MemberProfiles_Genders]
GO
ALTER TABLE [dbo].[MemberProfiles]  WITH CHECK ADD  CONSTRAINT [FK_MemberProfiles_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MemberProfiles] CHECK CONSTRAINT [FK_MemberProfiles_Members]
GO
ALTER TABLE [dbo].[PackageAttractionItems]  WITH CHECK ADD  CONSTRAINT [FK_PackageAttractionItems_Attractions] FOREIGN KEY([AttractionId])
REFERENCES [dbo].[Attractions] ([Id])
GO
ALTER TABLE [dbo].[PackageAttractionItems] CHECK CONSTRAINT [FK_PackageAttractionItems_Attractions]
GO
ALTER TABLE [dbo].[PackageAttractionItems]  WITH CHECK ADD  CONSTRAINT [FK_PackageAttractionItems_Packages] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([Id])
GO
ALTER TABLE [dbo].[PackageAttractionItems] CHECK CONSTRAINT [FK_PackageAttractionItems_Packages]
GO
ALTER TABLE [dbo].[PackageHotelRoomItems]  WITH CHECK ADD  CONSTRAINT [FK_PackageHotelRoomItems_HotelRooms] FOREIGN KEY([HotelRoomId])
REFERENCES [dbo].[HotelRooms] ([Id])
GO
ALTER TABLE [dbo].[PackageHotelRoomItems] CHECK CONSTRAINT [FK_PackageHotelRoomItems_HotelRooms]
GO
ALTER TABLE [dbo].[PackageHotelRoomItems]  WITH CHECK ADD  CONSTRAINT [FK_PackageHotelRoomItems_Packages] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([Id])
GO
ALTER TABLE [dbo].[PackageHotelRoomItems] CHECK CONSTRAINT [FK_PackageHotelRoomItems_Packages]
GO
ALTER TABLE [dbo].[PackageMemos]  WITH CHECK ADD  CONSTRAINT [FK_PackageMemos_Packages] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([Id])
GO
ALTER TABLE [dbo].[PackageMemos] CHECK CONSTRAINT [FK_PackageMemos_Packages]
GO
ALTER TABLE [dbo].[PackageOrdes]  WITH CHECK ADD  CONSTRAINT [FK_PackageOrdes_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[PackageOrdes] CHECK CONSTRAINT [FK_PackageOrdes_Members]
GO
ALTER TABLE [dbo].[PackageOrdes]  WITH CHECK ADD  CONSTRAINT [FK_PackageOrdes_PackageOrderStatuses] FOREIGN KEY([PackageOrdeStatusId])
REFERENCES [dbo].[PackageOrderStatuses] ([Id])
GO
ALTER TABLE [dbo].[PackageOrdes] CHECK CONSTRAINT [FK_PackageOrdes_PackageOrderStatuses]
GO
ALTER TABLE [dbo].[PackageOrdes]  WITH CHECK ADD  CONSTRAINT [FK_PackageOrdes_Packages] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Packages] ([Id])
GO
ALTER TABLE [dbo].[PackageOrdes] CHECK CONSTRAINT [FK_PackageOrdes_Packages]
GO
ALTER TABLE [dbo].[PointTransctions]  WITH CHECK ADD  CONSTRAINT [FK_PointTransctions_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[PointTransctions] CHECK CONSTRAINT [FK_PointTransctions_Members]
GO
ALTER TABLE [dbo].[QAs]  WITH CHECK ADD  CONSTRAINT [FK_QAs_ServiceCategories] FOREIGN KEY([ServiceCategoryId])
REFERENCES [dbo].[ServiceCategories] ([Id])
GO
ALTER TABLE [dbo].[QAs] CHECK CONSTRAINT [FK_QAs_ServiceCategories]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Permissions] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([Id])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Permissions]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Roles]
GO
