CREATE DATABASE IF NOT EXISTS WoowUpChallenge;
USE WoowUpChallenge;

CREATE TABLE IF NOT EXISTS Clientes (
    cli_id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    cli_nombre VARCHAR(50) NOT NULL,
    cli_apellido VARCHAR(50) NOT NULL
);

INSERT INTO Clientes (cli_nombre, cli_apellido) VALUES
('Juan', 'Perez'),
('Maria', 'Gomez'),
('Carlos', 'Rodriguez'),
('Ana', 'Lopez');

CREATE TABLE IF NOT EXISTS Ventas (
	venta_nro_factura INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    venta_fecha DATE NOT NULL,
    venta_sucursal VARCHAR(50) NOT NULL,
    venta_importe DECIMAL(10, 2) NOT NULL,
    cli_id INT NOT NULL,
    FOREIGN KEY (cli_id) REFERENCES Clientes(cli_id)
);

INSERT INTO Ventas (venta_fecha, venta_sucursal,venta_importe, cli_id) VALUES
('2023-01-15', 'Sucursal A',50000.00, 1),
('2023-02-20', 'Sucursal B',75000.00, 2),
('2023-03-10', 'Sucursal A',30000.00, 1),
('2022-05-12', 'Sucursal B',80000.00, 1),
('2023-04-05', 'Sucursal C',120000.00, 3),
('2023-05-12', 'Sucursal B',80000.00, 2);

SELECT c.cli_id, c.cli_nombre, c.cli_apellido, SUM(v.venta_importe) as TotalComprado
FROM clientes c JOIN ventas v ON c.cli_id = v.cli_id
WHERE v.venta_fecha >= CURDATE() - INTERVAL 12 MONTH
GROUP BY c.cli_id
HAVING TotalComprado > 100000

