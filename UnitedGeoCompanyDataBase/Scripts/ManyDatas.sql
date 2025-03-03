-- Вставка дополнительных данных в таблицу Objectives
-- Вставка дополнительных данных в таблицу Applications
INSERT INTO Applications (ClientName, ContactInfo, RequestDate, ApplicationStatus)
VALUES
('Client K', 'contactK@example.com', '2023-11-01', 0), -- Pending
('Client L', 'contactL@example.com', '2023-11-02', 1), -- InProgress
('Client M', 'contactM@example.com', '2023-11-03', 2), -- Completed
('Client N', 'contactN@example.com', '2023-11-04', 0), -- Pending
('Client O', 'contactO@example.com', '2023-11-05', 1), -- InProgress
('Client P', 'contactP@example.com', '2023-12-01', 2), -- Completed
('Client Q', 'contactQ@example.com', '2023-12-02', 0), -- Pending
('Client R', 'contactR@example.com', '2023-12-03', 1), -- InProgress
('Client S', 'contactS@example.com', '2023-12-04', 2), -- Completed
('Client T', 'contactT@example.com', '2023-12-05', 0), -- Pending
('Client U', 'contactU@example.com', '2024-01-01', 1), -- InProgress
('Client V', 'contactV@example.com', '2024-01-02', 2), -- Completed
('Client W', 'contactW@example.com', '2024-01-03', 0), -- Pending
('Client X', 'contactX@example.com', '2024-01-04', 1), -- InProgress
('Client Y', 'contactY@example.com', '2024-01-05', 2), -- Completed
('Client Z', 'contactZ@example.com', '2024-02-01', 0), -- Pending
('Client AA', 'contactAA@example.com', '2024-02-02', 1), -- InProgress
('Client AB', 'contactAB@example.com', '2024-02-03', 2), -- Completed
('Client AC', 'contactAC@example.com', '2024-02-04', 0), -- Pending
('Client AD', 'contactAD@example.com', '2024-02-05', 1), -- InProgress
('Client AE', 'contactAE@example.com', '2024-02-06', 2); -- Completed


INSERT INTO Objectives (ApplicationId, BrigadeId, AssignmentDate, CompletionDate, Notes)
VALUES
(11, 1, '2023-11-05', '2023-11-20', 'Assignment for Client K'),
(12, 2, '2023-11-06', '2023-11-21', 'Assignment for Client L'),
(13, 3, '2023-11-07', '2023-11-22', 'Assignment for Client M'),
(14, 4, '2023-11-08', '2023-11-23', 'Assignment for Client N'),
(15, 1, '2023-11-09', '2023-11-24', 'Assignment for Client O'),
(16, 2, '2023-12-05', '2023-12-20', 'Assignment for Client P'),
(17, 3, '2023-12-06', '2023-12-21', 'Assignment for Client Q'),
(18, 4, '2023-12-07', '2023-12-22', 'Assignment for Client R'),
(19, 1, '2023-12-08', '2023-12-23', 'Assignment for Client S'),
(20, 2, '2023-12-09', '2023-12-24', 'Assignment for Client T'),
(21, 3, '2024-01-05', '2024-01-20', 'Assignment for Client U'),
(22, 4, '2024-01-06', '2024-01-21', 'Assignment for Client V'),
(23, 1, '2024-01-07', '2024-01-22', 'Assignment for Client W'),
(24, 2, '2024-01-08', '2024-01-23', 'Assignment for Client X'),
(25, 3, '2024-01-09', '2024-01-24', 'Assignment for Client Y'),
(26, 4, '2024-02-05', '2024-02-20', 'Assignment for Client Z'),
(27, 1, '2024-02-06', '2024-02-21', 'Assignment for Client AA'),
(28, 2, '2024-02-07', '2024-02-22', 'Assignment for Client AB'),
(29, 3, '2024-02-08', '2024-02-23', 'Assignment for Client AC'),
(30, 4, '2024-02-09', '2024-02-24', 'Assignment for Client AD');
