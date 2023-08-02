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
VALUES ('Electr�nica', 'Productos electr�nicos y gadgets', GETDATE(), NULL);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Ropa', 'Ropa para todas las edades y estilos', GETDATE(), NULL);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Hogar', 'Productos para el hogar y decoraci�n', GETDATE(), '2023-07-31');

INSERT INTO TiposProductos (nombreTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Alimentos', GETDATE(), NULL);

INSERT INTO TiposProductos (nombreTipoProducto, descripcionTipoProducto, FechaRegistro, FechaEliminado)
VALUES ('Libros', 'Libros de diferentes g�neros', GETDATE(), NULL);


INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Smartphone', 'Tel�fono inteligente de �ltima generaci�n', 699.99, 50, 1, GETDATE(), NULL);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Camiseta', 'Camiseta de algod�n unisex', 19.99, 100, 2, GETDATE(), NULL);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Coj�n decorativo', 'Coj�n con estampado floral', 24.99, 30, 3, GETDATE(), NULL);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('Chocolate', 'Tableta de chocolate negro', 4.49, 200, 4, GETDATE(), NULL);

INSERT INTO Producto (NombreProducto, DescripcionProducto, Precio, Existencia, TipoProducto_Id, FechaRegistro, FechaEliminado)
VALUES ('El Principito', 'Famosa novela de Antoine de Saint-Exup�ry', 12.99, 50, 5, GETDATE(), NULL);



