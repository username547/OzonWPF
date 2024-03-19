--общая статистика всех пвз
SELECT 
    pp.PickupPointId AS 'Id Пункта выдачи заказов',
    pp.PickupPointAddress AS 'Адрес',
    pp.PickupPointDescription AS 'Описание',
    COUNT(DISTINCT e.EmployeeId) AS 'Количество сотрудников',
    COUNT(DISTINCT i.IssuanceId) AS 'Количество выданных заказов',
    AVG(i.IssuanceRating) AS 'Средний рейтинг'
FROM PickupPoints pp
LEFT JOIN Employees e ON pp.PickupPointId = e.PickupPointId
LEFT JOIN Issuances i ON e.EmployeeId = i.EmployeeId
GROUP BY pp.PickupPointId, pp.PickupPointAddress, pp.PickupPointDescription;

--статистика по конкретному пвз
SELECT 
    e.EmployeeId,
    u.UserName AS 'Имя',
    u.UserSurname AS 'Фамилия',
    COUNT(i.IssuanceId) AS 'Количество выданных заказов',
    AVG(i.IssuanceRating) AS 'Средний рейтинг отзывов'
FROM Employees e
JOIN Users u ON e.UserId = u.UserId
LEFT JOIN Issuances i ON e.EmployeeId = i.EmployeeId
WHERE e.PickupPointId = 1
GROUP BY e.EmployeeId, u.UserName, u.UserSurname;


select * from Roles
select * from Users

select * from PickupPoints
select * from Orders
select * from Employees

--исправляю заказы
--update Orders
--set PickupPointId = 2
--where OrderId > 4 and OrderId < 8


insert into Users (UserName, UserSurname, UserEmail, UserPassword, RoleId)
values
('Employee', 'Three', 'employee3@example.com', 'employeepassword', 2),
('Employee', 'Four', 'employee4@example.com', 'employeepassword', 2),
('Employee', 'Five', 'employee5@example.com', 'employeepassword', 2)

insert into Employees (UserId, EmployeePassport, EmployeePhone, EmployeeSalary, PickupPointId)
values
(1002, 'EMP003', '0987654322', 3000, 1),
(1003, 'EMP004', '0987654323', 3500, 1),
(1004, 'EMP005', '0987654324', 4000, 2)

--для пвз 1
insert into Issuances (IssuanceDate, IssuanceRating, OrderId, EmployeeId)
values
('2024-03-22 17:41:53', 3, 1, 1),
('2024-01-17 17:41:53', 4, 2, 1002),
('2024-03-27 17:41:53', 4, 3, 1003),
('2024-02-01 17:41:53', 5, 4, 1003)

--для пвз 2
insert into Issuances (IssuanceDate, IssuanceRating, OrderId, EmployeeId)
values
('2024-04-06 17:41:53', 1, 5, 2),
('2024-02-11 17:41:53', 2, 6, 1004),
('2024-04-16 17:41:53', 5, 7, 1004)

--осталось адекватно заполнить выдачи заказов и написать запрос чтобы в ПВЗ устанавливался средний рейтинг
