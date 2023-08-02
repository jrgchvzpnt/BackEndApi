create database Ventas

use ventas


CREATE TABLE TiposProductos (
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    nombreTipoProducto VARCHAR(50),
    descripcionTipoProducto VARCHAR(200),
    FechaRegistro DATETIME,
    FechaEliminado DATETIME
);

CREATE TABLE Producto (
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    NombreProducto VARCHAR(50),
    DescripcionProducto VARCHAR(200),
    Precio DECIMAL(18,4),
    Existencia DECIMAL(18,4),
    TipoProducto_Id INT,
    FechaRegistro DATETIME,
    FechaEliminado DATETIME,
    FOREIGN KEY (TipoProducto_Id) REFERENCES TiposProductos(Id)
);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Electrónica', 'Productos electrónicos y gadgets', GETDATE(), NULL);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Ropa', 'Ropa para todas las edades y estilos', GETDATE(), NULL);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Hogar', 'Productos para el hogar y decoración', GETDATE(), '2023-07-31');

INSERT INTO TiposProductos (nombreTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Alimentos', GETDATE(), NULL);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Libros', 'Libros de diferentes géneros', GETDATE(), NULL);


INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Smartphone', 'Teléfono inteligente de última generación', 699.99, 50, 1, GETDATE(), NULL);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Camiseta', 'Camiseta de algodón unisex', 19.99, 100, 2, GETDATE(), NULL);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Cojín decorativo', 'Cojín con estampado floral', 24.99, 30, 3, GETDATE(), NULL);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Chocolate', 'Tableta de chocolate negro', 4.49, 200, 4, GETDATE(), NULL);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('El Principito', 'Famosa novela de Antoine de Saint-Exupéry', 12.99, 50, 5, GETDATE(), NULL);



