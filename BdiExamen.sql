/*
Navicat SQL Server Data Transfer

Source Server         : local
Source Server Version : 150000
Source Host           : localhost:1433
Source Database       : BdiExamen
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 150000
File Encoding         : 65001

Date: 2023-05-06 12:51:54
*/


-- ----------------------------
-- Table structure for tblExamen
-- ----------------------------
DROP TABLE [dbo].[tblExamen]
GO
CREATE TABLE [dbo].[tblExamen] (
[idExamen] int NOT NULL IDENTITY(1,1) ,
[Nombre] nvarchar(255) NOT NULL ,
[Descripcion] nvarchar(255) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[tblExamen]', RESEED, 10)
GO

-- ----------------------------
-- Procedure structure for spActualizar
-- ----------------------------
DROP PROCEDURE [dbo].[spActualizar]
GO
CREATE PROCEDURE [dbo].[spActualizar]
  @Nombre AS varchar ,
  @Descripcion AS varchar 
AS
BEGIN
  -- routine body goes here, e.g.
  -- SELECT 'Navicat for SQL Server'

UPDATE tblExamen
    SET [Nombre] = @Nombre
     ,[Descripcion] = @Descripcion
END
GO

-- ----------------------------
-- Procedure structure for spAgregar
-- ----------------------------
DROP PROCEDURE [dbo].[spAgregar]
GO
CREATE PROCEDURE [dbo].[spAgregar]
  @Nombre AS varchar ,
  @Descripcion AS varchar 
AS
BEGIN
 INSERT INTO tblExamen
           ([Nombre]
           ,[Descripcion])
     VALUES
           (@Nombre
           ,@Descripcion)
END
GO

-- ----------------------------
-- Procedure structure for spConsultar
-- ----------------------------
DROP PROCEDURE [dbo].[spConsultar]
GO
CREATE PROCEDURE [dbo].[spConsultar]
  @Nombre AS varchar ,
  @Descripcion AS varchar 
AS
BEGIN
  -- routine body goes here, e.g.
  -- SELECT 'Navicat for SQL Server'

SELECT idExamen, Nombre, Descripcion  
    FROM tblExamen 
    WHERE Nombre = @Nombre AND Descripcion = @Descripcion  
END
GO

-- ----------------------------
-- Procedure structure for spEliminar
-- ----------------------------
DROP PROCEDURE [dbo].[spEliminar]
GO
CREATE PROCEDURE [dbo].[spEliminar]
  @Id AS int 
AS
BEGIN
  -- routine body goes here, e.g.
  -- SELECT 'Navicat for SQL Server'
DELETE tblExamen  
    WHERE idExamen = @Id 
END
GO

-- ----------------------------
-- Indexes structure for table tblExamen
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table tblExamen
-- ----------------------------
ALTER TABLE [dbo].[tblExamen] ADD PRIMARY KEY ([idExamen])
GO
