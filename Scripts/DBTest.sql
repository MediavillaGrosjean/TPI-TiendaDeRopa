CREATE DATABASE [DBTest]

GO

USE [DBTest]

GO

/****** Object:  Table [dbo].[perfiles] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[perfiles](
	[id_perfil] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_perfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[usuarios] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[id_perfil] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[perfiles] ON 
GO
INSERT [dbo].[perfiles] ([id_perfil], [nombre]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[perfiles] ([id_perfil], [nombre]) VALUES (2, N'Vendedor')
GO
INSERT [dbo].[perfiles] ([id_perfil], [nombre]) VALUES (3, N'Gerente')
GO
SET IDENTITY_INSERT [dbo].[perfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 
GO
INSERT [dbo].[usuarios] ([id_usuario], [username], [password], [id_perfil]) VALUES (1, N'user123', N'pass123', 1)
GO
INSERT [dbo].[usuarios] ([id_usuario], [username], [password], [id_perfil]) VALUES (2, N'jdoe', N'p@ssw0rd', 2)
GO
INSERT [dbo].[usuarios] ([id_usuario], [username], [password], [id_perfil]) VALUES (3, N'alice96', N'123abc', 2)
GO
INSERT [dbo].[usuarios] ([id_usuario], [username], [password], [id_perfil]) VALUES (4, N'bobsmith', N'bobby123', 3)
GO
INSERT [dbo].[usuarios] ([id_usuario], [username], [password], [id_perfil]) VALUES (5, N'emma_g', N'securePW', 2)
GO
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Perfiles] FOREIGN KEY([id_perfil])
REFERENCES [dbo].[perfiles] ([id_perfil])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_Usuarios_Perfiles]
GO

/****** Object:  StoredProcedure [dbo].[sp_listar_usuarios] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listar_usuarios]
AS
BEGIN
    SELECT
		u.id_usuario,
		u.username,
		p.id_perfil,
		p.nombre AS 'rol'
    FROM
		usuarios u
    INNER JOIN perfiles p ON u.id_perfil = p.id_perfil
END
GO

/****** Object:  StoredProcedure [dbo].[sp_validar_usuarios] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_validar_usuarios]
    @NombreUsuario VARCHAR(50),
    @Password VARCHAR(50)
AS
BEGIN
    SELECT
		u.id_usuario,
		u.username,
		p.id_perfil,
		p.nombre AS 'rol'
    FROM
		usuarios u
    INNER JOIN perfiles p ON u.id_perfil = p.id_perfil
	WHERE
		upper(username) = upper(@NombreUsuario)
		AND password = @Password
END
GO

USE [master]

GO

ALTER DATABASE [DBTest] SET  READ_WRITE

GO