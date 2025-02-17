USE master;
GO 
if DB_ID(N'Finanzverwaltung') is not null
Begin
drop database Finanzverwaltung;
end

if DB_ID ('Finanzverwaltung') is null
Begin
CREATE DATABASE Finanzverwaltung;
end
go

USE Finanzverwaltung;
if OBJECT_ID('Mitarbeiterprofile') is not null
Begin
DROP TABLE Mitarbeiterprofile;
end
Go
if OBJECT_ID('Firma') is not null
Begin
Drop Table Firma;
End
if OBJECT_ID('Finanzverwaltung') is not null
Begin
Drop Table Finanzverwaltung
end
if OBJECT_ID('Verwaltung') is not null
Begin
Drop Table Verwaltung
end
if OBJECT_ID('Einnahmen') is not null
Begin
Drop Table Einnahmen
end
if OBJECT_ID('Ausgaben') is not null
Begin
Drop Table Ausgaben
end
if OBJECT_ID('Budgetwert') is not null
Begin
Drop Table Budgetwert
end
if OBJECT_ID('Kennzahlen') is not null
Begin
Drop Table Kennzahlen
end
CREATE TABLE Mitarbeiterprofile (
  MitarbeiterId INT PRIMARY KEY,
  Mitarbeiternummer NVARCHAR(100),
  Vorname NVARCHAR(50),
  Nachname NVARCHAR(50),
  Benutzername NVARCHAR(50),
  Passwort NVARCHAR(50),
  Email NVARCHAR(50),
  Telefonnummer int,
  Diensthandynummer int
);

Create Table Einnahmen(
ID_Einnahmen int Identity not Null primary Key,
Einnahmen decimal(18,2),
);
Create Table Ausgaben(
ID_Ausgaben int Identity not Null primary Key,
Ausgaben decimal(18,2),
Ausgabennummer int
  --CONSTRAINT fk_Ausgabennummer 
  --FOREIGN KEY (Ausgabennummer)
	--REFERENCES Einnahmen(ID_Einnahmen)
);
Create Table Budgetwert(
ID_Budgetwert int Identity not Null primary Key,
Budget decimal(18,2),
Budgetnummer int,
  --CONSTRAINT fk_Budgetnummer 
  --FOREIGN KEY (Budgetnummer)
	--REFERENCES Ausgaben(ID_Ausgaben)
);

Create Table Verbleibendesbudget(
ID_verbleibendesbudget int Identity not Null primary Key ,
Einnahmen decimal(18,2),
Ausgaben decimal(18,2),
Budget decimal(18,2),
verbleibendesbudget decimal(18,2),
Verbleibudgetnummer int


);
Create Table Finanzverwaltung(
  ID_Ausgaben int, 
  ID_Einnahmen int,
  CONSTRAINT pk_PersonID PRIMARY KEY (ID_Ausgaben, ID_Einnahmen), 
  CONSTRAINT fk_Ausgaben 
	FOREIGN KEY (ID_Ausgaben)
	REFERENCES Ausgaben(ID_Ausgaben),
  CONSTRAINT fk_Einnahmen 
	FOREIGN KEY (ID_Einnahmen)
	REFERENCES Einnahmen(ID_Einnahmen)
	

);
Create Table Firma(
FirmaID int Primary Key Identity,
FinanzverwaltungID int,

);
INSERT INTO Mitarbeiterprofile(MitarbeiterId,Mitarbeiternummer, Vorname, Nachname, Benutzername, Passwort, Email,Telefonnummer,Diensthandynummer) VALUES
  ('1','25645891','Dom','MUstermann','Admin','admin12345','dom.mustermann@hotmail.de','21845328','125462876'),
  ('2','25641821','Bob','MUstermann','Verwalterhans','D@t_lef','bob.mustermann@hotmail.de','86545755','85456463'),
  ('3','25678641','Lukas','MUstermann','Verwaltermann','D@t_beb','Lukas.mustermann@hotmail.de','86548523','85496314'),
  ('4','25696245','Dirk','MUstermann','Verwalterlord','D@t_hzh','Dirk.mustermann@hotmail.de','865396974','85450375')
;
Insert Into Einnahmen(Einnahmen) Values
(255000.25),
(350000.35),
(482000.55)
;
Insert into Ausgaben(Ausgaben,Ausgabennummer)Values
(150000,1),
(256347,2),
(359841,3)
;
Insert Into Budgetwert(Budget,Budgetnummer) Values
(30000,1),
(39578,2),
(50000,3)
;
Insert into  Verbleibendesbudget(Einnahmen,Ausgaben,Budget,verbleibendesbudget, Verbleibudgetnummer) Values
(255000.25,150000,30000,135000.25,1),
(350000.35,359841,39578,29697.35,2),
(482000.55,359841,50000,172159.55,3)

Insert Into Finanzverwaltung(ID_Ausgaben,ID_Einnahmen)Values
(1,1),
(2,2),
(3,3);
;