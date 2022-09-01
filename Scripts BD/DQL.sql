SELECT a.nome 'Animal', t.tipo, a.raca, c.nome 'Dono'
FROM Animais a inner join Clientes c on a.idCliente = c.id
               inner join TipoAnimais t on a.idTipoAnimal = t.id
ORDER BY 1
GO

SELECT c.nome, count(*)
FROM Clientes c inner join Animais a on c.id = a.idCliente
GROUP BY c.Nome
ORDER BY 1
GO

SELECT c.dtConsulta 'Data', a.nome 'Animal', v.nome 'Veterinário', c.valor 'Valor'
FROM Consultas c inner join Veterinarios v on c.idVeterinario = v.id
                 inner join Animais a on c.idAnimal = a.id
ORDER BY 1
GO
