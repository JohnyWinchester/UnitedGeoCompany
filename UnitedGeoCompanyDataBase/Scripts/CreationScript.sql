-- Создание таблицы для заявок
CREATE TABLE Applications (
    ID BIGINT PRIMARY KEY IDENTITY(1,1),
    ClientName NVARCHAR(255) NOT NULL,
    ContactInfo NVARCHAR(255) NOT NULL,
    RequestDate DATE NOT NULL,
    ApplicationStatus INT NOT NULL
);

-- Создание таблицы для бригад
CREATE TABLE Brigades (
    ID BIGINT PRIMARY KEY IDENTITY(1,1),
    BrigadeName NVARCHAR(255) NOT NULL,
    BrigadeLeader NVARCHAR(255) NOT NULL,
);

-- Создание таблицы для заданий
CREATE TABLE Objectives (
    ID BIGINT PRIMARY KEY IDENTITY(1,1),
    ApplicationId BIGINT,
    BrigadeId BIGINT,
    AssignmentDate DATE NOT NULL,
    CompletionDate DATE,
    Notes TEXT,
    FOREIGN KEY (ApplicationId) REFERENCES Applications(ID),
    FOREIGN KEY (BrigadeId) REFERENCES Brigades(ID)
);
