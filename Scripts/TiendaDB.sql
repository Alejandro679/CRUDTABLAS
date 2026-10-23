-- Script de creación de TiendaDB (Unidad V - CRUD con BD MDF y EF Core)
-- Úselo en el Explorador de servidores si prefiere crear las tablas manualmente.

-- Tabla: Categorias
CREATE TABLE [dbo].[Categorias] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Nombre] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- Tabla: Productos
CREATE TABLE [dbo].[Productos] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]      NVARCHAR (100)  NOT NULL,
    [Precio]      DECIMAL (18, 2) NOT NULL,
    [CategoriaId] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY ([CategoriaId]) REFERENCES [dbo].[Categorias] ([Id]) ON DELETE CASCADE
);
GO

-- Datos de prueba (opcionales)
INSERT INTO [dbo].[Categorias] ([Nombre]) VALUES (N'Electrónica'), (N'Ropa'), (N'Hogar');
INSERT INTO [dbo].[Productos] ([Nombre], [Precio], [CategoriaId]) VALUES
    (N'Audífonos Bluetooth', 45.00, 1),
    (N'Cargador USB-C', 15.50, 1),
    (N'Camisa de algodón', 22.00, 2),
    (N'Jeans clásicos', 35.00, 2),
    (N'Licuadora', 60.00, 3);
GO
