-- Вставка начальных данных в таблицу Applications
INSERT INTO Applications (ClientName, ContactInfo, RequestDate, ApplicationStatus)
VALUES
('Client A', 'contactA@example.com', '2023-01-01', 0), -- Pending
('Client B', 'contactB@example.com', '2023-02-01', 1), -- InProgress
('Client C', 'contactC@example.com', '2023-03-01', 2), -- Completed
('Client D', 'contactD@example.com', '2023-04-01', 3), -- Cancelled
('Client E', 'contactE@example.com', '2023-05-01', 0), -- Pending
('Client F', 'contactF@example.com', '2023-06-01', 1), -- InProgress
('Client G', 'contactG@example.com', '2023-07-01', 2), -- Completed
('Client H', 'contactH@example.com', '2023-08-01', 0), -- Pending
('Client I', 'contactI@example.com', '2023-09-01', 1), -- InProgress
('Client J', 'contactJ@example.com', '2023-10-01', 2); -- Completed

-- Вставка начальных данных в таблицу Brigades
INSERT INTO Brigades (BrigadeName, BrigadeLeader)
VALUES
('Brigade Alpha', 'Leader Alpha'),
('Brigade Beta', 'Leader Beta'),
('Brigade Gamma', 'Leader Gamma'),
('Brigade Delta', 'Leader Delta');

-- Вставка начальных данных в таблицу Objectives
INSERT INTO Objectives (ApplicationId, BrigadeId, AssignmentDate, CompletionDate, Notes)
VALUES
(1, 1, '2023-01-02', NULL, 'Initial assignment for Client A'),
(2, 2, '2023-02-02', '2023-02-10', 'Completed assignment for Client B'),
(3, 3, '2023-03-02', NULL, 'Assignment for Client C'),
(4, 4, '2023-04-02', '2023-04-10', 'Completed assignment for Client D'),
(5, 1, '2023-05-02', NULL, 'Assignment for Client E'),
(6, 2, '2023-06-02', '2023-06-10', 'Completed assignment for Client F'),
(7, 3, '2023-07-02', NULL, 'Assignment for Client G'),
(8, 4, '2023-08-02', NULL, 'Assignment for Client H'),
(9, 1, '2023-09-02', '2023-09-10', 'Completed assignment for Client I'),
(10, 2, '2023-10-02', NULL, 'Assignment for Client J');

