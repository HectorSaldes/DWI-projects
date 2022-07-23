CREATE DATABASE test;

USE test;
CREATE TABLE Contacto
(
    Id                INT IDENTITY PRIMARY KEY,
    Nombre            NVARCHAR(50) NOT NULL,
    CorreoElectronico NVARCHAR(50) NOT NULL,
    Telefono          NVARCHAR(10) NOT NULL,
    Edad              INT
);
GO
