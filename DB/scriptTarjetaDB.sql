USE [master]
GO
/****** Object:  Database [TarjetaCreditoDB]    Script Date: 9/4/2024 15:55:37 ******/
CREATE DATABASE [TarjetaCreditoDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TarjetaCreditoDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TarjetaCreditoDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TarjetaCreditoDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\TarjetaCreditoDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TarjetaCreditoDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TarjetaCreditoDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TarjetaCreditoDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TarjetaCreditoDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TarjetaCreditoDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TarjetaCreditoDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TarjetaCreditoDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TarjetaCreditoDB] SET  MULTI_USER 
GO
ALTER DATABASE [TarjetaCreditoDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TarjetaCreditoDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TarjetaCreditoDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TarjetaCreditoDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TarjetaCreditoDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TarjetaCreditoDB]
GO
/****** Object:  Table [dbo].[MovimientosTarjeta]    Script Date: 9/4/2024 15:55:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MovimientosTarjeta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[IdTarjeta] [int] NOT NULL,
	[Descripcion] [text] NULL,
	[FechaMovimiento] [datetime] NULL,
	[Monto] [money] NULL,
	[TipoMovimiento] [char](1) NULL,
	[fechaCreacion] [datetime] NULL,
	[creadoPor] [varchar](50) NULL,
	[fechaModificacion] [datetime] NULL,
	[modificadoPor] [varchar](50) NULL,
	[status] [char](1) NULL,
 CONSTRAINT [PK_MovimientosTarjeta] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TarjetasCredito]    Script Date: 9/4/2024 15:55:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TarjetasCredito](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NombreTitular] [varchar](50) NULL,
	[NumeroTarjeta] [varchar](50) NULL,
	[MontoOtorgado] [money] NULL,
	[PorceInteres] [decimal](12, 2) NULL,
	[PorceInteresMinimo] [decimal](12, 2) NULL,
	[fechaCreacion] [datetime] NULL,
	[creadoPor] [varchar](50) NULL,
	[fechaModificacion] [datetime] NULL,
	[modificadoPor] [varchar](50) NULL,
	[status] [char](1) NULL,
 CONSTRAINT [PK_TarjetasCredito] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[MovimientosTarjeta] ON 

INSERT [dbo].[MovimientosTarjeta] ([id], [IdTarjeta], [Descripcion], [FechaMovimiento], [Monto], [TipoMovimiento], [fechaCreacion], [creadoPor], [fechaModificacion], [modificadoPor], [status]) VALUES (1, 1, N'COMPRA EN BERSHKA', CAST(N'2024-04-09 14:52:45.190' AS DateTime), 114.4700, N'1', CAST(N'2024-04-09 14:52:45.597' AS DateTime), N'cguerrero', NULL, NULL, N'1')
INSERT [dbo].[MovimientosTarjeta] ([id], [IdTarjeta], [Descripcion], [FechaMovimiento], [Monto], [TipoMovimiento], [fechaCreacion], [creadoPor], [fechaModificacion], [modificadoPor], [status]) VALUES (2, 1, N'PAGO APP PROPIA', CAST(N'2024-04-09 14:53:04.773' AS DateTime), -10.0000, N'2', CAST(N'2024-04-09 14:53:04.827' AS DateTime), N'cguerrero', NULL, NULL, N'1')
INSERT [dbo].[MovimientosTarjeta] ([id], [IdTarjeta], [Descripcion], [FechaMovimiento], [Monto], [TipoMovimiento], [fechaCreacion], [creadoPor], [fechaModificacion], [modificadoPor], [status]) VALUES (3, 1, N'COMPRA FOREVER21', CAST(N'2024-04-09 14:53:13.883' AS DateTime), 10.0000, N'1', CAST(N'2024-04-09 14:53:13.910' AS DateTime), N'cguerrero', NULL, NULL, N'1')
SET IDENTITY_INSERT [dbo].[MovimientosTarjeta] OFF
SET IDENTITY_INSERT [dbo].[TarjetasCredito] ON 

INSERT [dbo].[TarjetasCredito] ([id], [NombreTitular], [NumeroTarjeta], [MontoOtorgado], [PorceInteres], [PorceInteresMinimo], [fechaCreacion], [creadoPor], [fechaModificacion], [modificadoPor], [status]) VALUES (1, N'CESAR GUERRERO', N'4550-0606-1509-0099', 2200.0000, CAST(25.00 AS Decimal(12, 2)), CAST(5.00 AS Decimal(12, 2)), CAST(N'2024-04-05 00:00:00.000' AS DateTime), N'cguerrero', NULL, NULL, N'1')
SET IDENTITY_INSERT [dbo].[TarjetasCredito] OFF
ALTER TABLE [dbo].[MovimientosTarjeta]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosTarjeta_TarjetasCredito] FOREIGN KEY([IdTarjeta])
REFERENCES [dbo].[TarjetasCredito] ([id])
GO
ALTER TABLE [dbo].[MovimientosTarjeta] CHECK CONSTRAINT [FK_MovimientosTarjeta_TarjetasCredito]
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerMovimientosTarjeta]    Script Date: 9/4/2024 15:55:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		César Guerrero
-- Create date: 05-04-2024
-- Description:	Obtener los movimientos de una tarjeta de credito
-- =============================================
CREATE PROCEDURE [dbo].[sp_ObtenerMovimientosTarjeta] 
	@IdTarjeta as int,
	@NumeroTarjeta varchar(50),
	@Tipo as int,
	@mes as int,
	@anio as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF @Tipo = 1
	BEGIN 
	select id, idTarjeta, Descripcion, FechaMovimiento, Monto,
		CASE TipoMovimiento
		WHEN 1 THEN 'Compra'
		WHEN 2 THEN 'Pago'
		ELSE 'Otro'
	END AS 'TipoMovimiento'
	from MovimientosTarjeta where IdTarjeta = @IdTarjeta and
	MONTH(FechaMovimiento) = @mes and YEAR(FechaMovimiento) = @anio and TipoMovimiento = 1
	ORDER BY FechaMovimiento desc
	END
	ELSE IF @Tipo = 2
	BEGIN
		select id, idTarjeta, Descripcion, FechaMovimiento, Monto, 
		CASE TipoMovimiento
		WHEN 1 THEN 'Compra'
		WHEN 2 THEN 'Pago'
		ELSE 'Otro'
	END AS 'TipoMovimiento'
	from MovimientosTarjeta where IdTarjeta = @IdTarjeta and
	MONTH(FechaMovimiento) = @mes and YEAR(FechaMovimiento) = @anio  and TipoMovimiento = 2
	ORDER BY FechaMovimiento desc
	END 
	ELSE
	BEGIN
		select id, idTarjeta, Descripcion, FechaMovimiento, Monto,
		CASE TipoMovimiento
		WHEN 1 THEN 'Compra'
		WHEN 2 THEN 'Pago'
		ELSE 'Otro'
	END AS 'TipoMovimientoNombre'
	from MovimientosTarjeta where IdTarjeta = @IdTarjeta and
	MONTH(FechaMovimiento) = @mes
	and YEAR(FechaMovimiento) = @anio 
	ORDER BY FechaMovimiento desc
	END
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerValoresTarjeta]    Script Date: 9/4/2024 15:55:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		César Guerrero
-- Create date: 05-04-2024
-- Description:	Procedimiento que trae todos los valores correspondientes a la tarjeta
-- =============================================
CREATE PROCEDURE [dbo].[sp_ObtenerValoresTarjeta]
	@IdTarjeta int,
	@NumeroTarjeta varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
--- Variables a utilizar
	DECLARE @SaldoTotal as money
	DECLARE @InteresBonificable as money
	DECLARE @CuotaMinima as money
	DECLARE @TotalContadoConInteres as money
	DECLARE @SaldoDisponible as money
	DECLARE @MontoOtorgado as money

--- Porcentajes de interes
	DECLARE @PorceInteres as decimal(12,2)
	DECLARE @PorcentajeSaldoMinimo as decimal(12,2)

--- Obtendremos el saldo actual
	select 
	@SaldoTotal = sum(Monto) 
	from MovimientosTarjeta where IdTarjeta = @IdTarjeta

	if @SaldoTotal = 0
	BEGIN
		SET @SaldoTotal = 0
		SET @CuotaMinima = 0
		SET @InteresBonificable = 0
		SET @TotalContadoConInteres = 0
	END

--- Una vez obtenido el saldo de las compras y pagos realizados en la tarjeta
--- Procederemos a calcular los demas valores
--- Antes llenaremos variables de la tarjeta como los porcentajes

	select @PorceInteres = PorceInteres, @PorcentajeSaldoMinimo = PorceInteresMinimo, @MontoOtorgado = MontoOtorgado
	from TarjetasCredito where Id = @IdTarjeta and NumeroTarjeta = @NumeroTarjeta

--- Obtenemos los demas valores
	SET @CuotaMinima = (@SaldoTotal * @PorcentajeSaldoMinimo) / 100
	SET @InteresBonificable = (@SaldoTotal * @PorceInteres) / 100
	SET @TotalContadoConInteres = @SaldoTotal + @InteresBonificable
	SET @SaldoDisponible = @MontoOtorgado - @SaldoTotal

--- Imprimimos los resultados
	select *,FORMAT(@SaldoTotal, '0.00') as SaldoTotal, 
	FORMAT(@CuotaMinima, '0.00') as CuotaMinima, FORMAT(@InteresBonificable, '0.00') as InteresBonificable,
	FORMAT(@TotalContadoConInteres, '0.00') as TotalContadoConInteres, FORMAT(@SaldoDisponible, '0.00') as Disponible
	from TarjetasCredito where Id = @IdTarjeta and NumeroTarjeta = @NumeroTarjeta

END

GO
USE [master]
GO
ALTER DATABASE [TarjetaCreditoDB] SET  READ_WRITE 
GO
