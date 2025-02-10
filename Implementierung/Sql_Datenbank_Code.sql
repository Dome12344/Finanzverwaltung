USE master;
GO 
if DB_ID(N'Finanzverwaltung') is not null
Begin
alter Database Finanzverwaltung set single_user WITH ROLLBACK IMMEDIATE;
drop database Finanzverwaltung;
end

if DB_ID ('Finanzverwaltung') is null
Begin
CREATE DATABASE Finanzverwaltung;
end
go

USE Finanzverwaltung;
if OBJECT_ID('Mitarbeiterprofile','U') is not null
Begin
DROP TABLE Mitarbeiterprofile;
end
Go
if OBJECT_ID('Firma','F') is not null
Begin
Drop Table Firma;
End
if OBJECT_ID('Finanzverwaltung','V') is not null
Begin
Drop Table Finanzverwaltung
end
if OBJECT_ID('Verwaltung','V') is not null
Begin
Drop Table Verwaltung
end
if OBJECT_ID('Einnahmen','E') is not null
Begin
Drop Table Einnahmen
end
if OBJECT_ID('Ausgaben','A') is not null
Begin
Drop Table Ausgaben
end
if OBJECT_ID('Budgetwert','B') is not null
Begin
Drop Table Budgetwert
end
if OBJECT_ID('Kennzahlen','K') is not null
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
EinnahmenID int primary Key Identity(1,1),
Einnahmen decimal
);
Create Table Ausgaben(
AuagebenID int primary Key Identity(1,1),
Ausgaben decimal
);
Create Table Budgetwert(
BudgetwertID int primary Key Identity(1,1),
Budget decimal,
Budgetnummer int
);
Create Table Kennzahlen(
KennzahlenID int primary Key Identity(1,1),
Gesamteinnahmen decimal,
Gesamtausgaben decimal,
Budget decimal
Constraint EH_Einnahmen Foreign Key(KennzahlenID)References Einnahmen(EinnahmenID),
Constraint AH_Ausgaben Foreign Key(KennzahlenID)References Ausgaben(AuagebenID)
);
Create Table Finanzverwaltung(
FinanzverwaltungID int primary Key Identity(1,1),
Constraint EH_Einnahmen_VW Foreign Key(FinanzverwaltungID)References Einnahmen(EinnahmenID),
Constraint AH_Ausgaben_VW Foreign Key(FinanzverwaltungID)References Ausgaben(AuagebenID),
Constraint KZ_Kennzahken_VW Foreign Key(FinanzverwaltungID)References Kennzahlen(KennzahlenID),
);
Create Table Firma(
FirmaID int Primary Key Identity(1,1),
Constraint FW_Finanzverwaltung Foreign Key(FirmaID)References Finanzverwaltung(FinanzverwaltungID)
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
Insert into Ausgaben(Ausgaben)Values
(150000),
(256347),
(359841)
;
Insert Into Budgetwert(Budget,Budgetnummer) Values
(3000000,1),
(3957854,2),
(5000000,3)
;
Insert into  Kennzahlen(Gesamteinnahmen,Gesamtausgaben,Budget) Values
(4569722,3698412,3000000),
(4586318,4235489,3957854),
(6879521,5987413,5000000)
;