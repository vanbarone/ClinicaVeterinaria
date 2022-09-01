USE ClinicaVeterinaria
GO

DELETE Consultas
DELETE Veterinarios
DELETE Animais
DELETE Clientes
DELETE TipoAnimais
GO


INSERT INTO TipoAnimais (tipo) VALUES ('Cachorro'), ('Gato'), ('Rato'), ('Cobra')
GO

select * from clientes


INSERT INTO Clientes (nome, cpf, email, celular)
VALUES ('Vanessa', '21365478965', 'vanessa@gmail.com', '1191234-5678'),
       ('Lilian', '14785236900', 'lilian@gmail.com', '1191234-5678'),
	   ('Caio', '13261598400', 'caio@gmail.com', '1191234-1122'),
	   ('Maria', '14785296500', 'maria@gmail.com', '1191234-3344'),
	   ('Paula', '16235148523', 'paula@gmail.com', '1191234-5566')
GO


INSERT INTO Animais(nome, raca, dtNasc, idTipoAnimal, idCliente)
VALUES ('Kinder', 'Yorkshire', '2020-09-01T13:54:04.279Z', (Select id From TipoAnimais Where tipo = 'Cachorro'), (Select id From Clientes Where nome = 'Vanessa')),
       ('Fred', 'Yorkshire', '2021-09-01T13:54:04.279Z', (Select id From TipoAnimais Where tipo = 'Cachorro'), (Select id From Clientes Where nome = 'Lilian')),
	   ('Bruce', 'Labrador', '2020-05-01T13:54:04.279Z', (Select id From TipoAnimais Where tipo = 'Cachorro'), (Select id From Clientes Where nome = 'Lilian')),
	   ('Tom', 'Persa', '2018-09-01T13:54:04.279Z', (Select id From TipoAnimais Where tipo = 'Gato'), (Select id From Clientes Where nome = 'Caio')),
	   ('Bob', 'Sem raça definida', '2019-09-01T13:54:04.279Z', (Select id From TipoAnimais Where tipo = 'Cachorro'), (Select id From Clientes Where nome = 'Maria')),
	   ('Brad', 'Siamês', '2020-01-01T13:54:04.279Z', (Select id From TipoAnimais Where tipo = 'Gato'), (Select id From Clientes Where nome = 'Maria')),
	   ('Leo', 'Ramster', '2022-02-01T13:54:04.279Z', (Select id From TipoAnimais Where tipo = 'Rato'), (Select id From Clientes Where nome = 'Paula'))
GO


INSERT INTO Veterinarios(nome, crv, cpf, email, celular)
VALUES ('Roberto', '1234', '11253698500', 'roberto@gmail.com', '1198815-5678'),
       ('Patricia', '5678', '28456315200', 'patricia@gmail.com', '1198836-5678'),
	   ('Caroline', '1593', '23158423500', 'caroline@gmail.com', '1198814-1122')
GO


INSERT INTO Consultas(dtConsulta, peso, idAnimal, idVeterinario, valor)
VALUES ('2022-08-08T10:00:00', 4.2, (Select id From Animais Where nome = 'Kinder'), (Select id From Veterinarios Where nome = 'Roberto'), 150)
GO
INSERT INTO Consultas(dtConsulta, peso, idAnimal, idVeterinario, valor)
VALUES ('2022-08-08T13:00:00', 35, (Select id From Animais Where nome = 'Bruce'), (Select id From Veterinarios Where nome = 'Patricia'), 300)
GO
INSERT INTO Consultas(dtConsulta, peso, idAnimal, idVeterinario, valor)
VALUES ('2022-08-08T15:00:00', 7.5, (Select id From Animais Where nome = 'Tom'), (Select id From Veterinarios Where nome = 'Caroline'), 120)
GO
INSERT INTO Consultas(dtConsulta, peso, idAnimal, idVeterinario, valor)
VALUES ('2022-08-08T16:00:00', 0.5, (Select id From Animais Where nome = 'Leo'), (Select id From Veterinarios Where nome = 'Patricia'), 500)
GO
