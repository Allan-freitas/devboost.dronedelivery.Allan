IF NOT EXISTS(
    SELECT name
    FROM sys.databases
    WHERE name = 'DroneDelivery'
)
    CREATE DATABASE [DroneDelivery]
GO

USE [DroneDelivery]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Drone](
	[Id] [int] NOT NULL,
	[Capacidade] [int] NOT NULL,
	[Velocidade] [int] NOT NULL,
	[Autonomia] [int] NOT NULL,
	[Carga] [int] NOT NULL,
    [Status] [int] NOT NULL
 CONSTRAINT [PK_Drone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Pedido]    Script Date: 22/08/2020 00:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[Id] [uniqueidentifier] NOT NULL,
	[Peso] [int] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[DataHora] [datetime] NOT NULL,
	[StatusPedido] [int] NULL
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Pedido_Drone]    Script Date: 22/08/2020 00:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido_Drone](
	[Pedido_Id] [uniqueidentifier] NOT NULL,
	[Drone_Id] [int] NOT NULL
 CONSTRAINT [PK_Pedido_Drone] PRIMARY KEY CLUSTERED 
(
	[Pedido_Id], [Drone_Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pedido_Drone]  WITH CHECK ADD CONSTRAINT [FK_Pedido_Drone_Pedido] FOREIGN KEY([Pedido_Id])
REFERENCES [dbo].[Pedido] ([Id])
GO
ALTER TABLE [dbo].[Pedido_Drone] CHECK CONSTRAINT [FK_Pedido_Drone_Pedido]
GO
ALTER TABLE [dbo].[Pedido_Drone]  WITH CHECK ADD CONSTRAINT [FK_Pedido_Drone_Drone] FOREIGN KEY([Drone_Id])
REFERENCES [dbo].[Drone] ([Id])
GO
ALTER TABLE [dbo].[Pedido_Drone] CHECK CONSTRAINT [FK_Pedido_Drone_Drone]
GO

INSERT INTO [Drone] ([Id], [Capacidade], [Velocidade], [Autonomia],	[Carga], [Status])
VALUES
  -- ID, Capacidade KG, Velocidade KM/H, Autonomia min, Carga em %, Status
    (1,  12,            35,              15,            100,        1),
    (2,  7,             25,              35,            50,         1),
    (3,  5,             25,              35,            25,         1),
    (4,  10,            40,              20,            100,        1),
    (5,  8,             60,              25,            100,        1),
    (6,  7,             50,              30,            20,         1)
GO
