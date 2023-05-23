CREATE USER baby with password 'baby'
CREATE DATABASE baby;

CREATE TABLE Equipe (
    idEquipe    INT IDENTITY(1,1) PRIMARY KEY,
    nomEquipe   VARCHAR(15)
);

CREATE table Joueur (
    idJoueur    INT IDENTITY(1,1) PRIMARY KEY,
    positionX   int,
    positionY int,
    idBaton    int,
    FOREIGN KEY(idBaton) REFERENCES  Baton (idBaton)
);

CREATE table personne (
    idPersonne INT IDENTITY(1,1) PRIMARY KEY,
    nomPersonne     VARCHAR(15),
    intitule        int
);

CREATE table Matchs(
    idMatch INT IDENTITY(1,1) PRIMARY KEY,
    pointGagnant        INT
);
CREATE table misePersonne(
    idMise INT IDENTITY(1,1) PRIMARY KEY,
    idPersonne    int,
    Montant       DECIMAL(8,2),
    idMatch     int,
    FOREIGN KEY (idPersonne) REFERENCES personne  (idPersonne),
    FOREIGN KEY (idMatch) REFERENCES  Matchs (idMatch)
);

CREATE TABLE CAISSE (
    idCaisse  INT IDENTITY(1,1) PRIMARY KEY,
    idPersonne      INT,
    idMatch         INT,
    montant        DECIMAL(8,2),
    FOREIGN KEY (idPersonne) REFERENCES personne (idPersonne),
    FOREIGN KEY (idMatch) REFERENCES Matchs (idMatch)
);

CREATE table jeton (
    idJeton INT IDENTITY(1,1) PRIMARY KEY,
    idMatch int,
    montantJeton DECIMAL(8,2),
    FOREIGN KEY (idMatch) REFERENCES Matchs (idMatch)
);

CREATE table score(
    idscore int IDENTITY(1,1) PRIMARY key,
    idMatch int,
    idPersonne int ,
    score int,
    FOREIGN KEY (idPersonne) REFERENCES personne (idPersonne),
    FOREIGN KEY (idMatch) REFERENCES Matchs (idMatch)
);