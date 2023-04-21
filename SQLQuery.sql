CREATE DATABASE login;
USE login;

CREATE TABLE usuarios (
id INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
nombre VARCHAR(50),
correo VARCHAR(50),
contraseña VARCHAR(50)
)

SELECT * FROM usuarios;

INSERT INTO usuarios (nombre, correo, contraseña) VALUES ('Roberto Morales', 'roberto@gmail.com', '1999');
INSERT INTO usuarios (nombre, correo, contraseña) VALUES ('Alexander Morales', 'alex@gmail.com', '2023');

SELECT COUNT(*) FROM usuarios WHERE correo='roberto@gmail.com' AND contraseña='1999'


