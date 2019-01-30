
/*
select * from Personnes;
select * from Dossiers;
select * from Voyages;
select * from Destinations;
select * from Agences;
select * from AssurDoss;
select * from ParticipDoss;
select * from Assurances;

*/

-- drop tables
/*
drop table AssurDoss;
drop table ParticipDoss;
drop table Dossiers;
drop table Assurances;
drop table Personnes;
drop table Voyages;
drop table Destinations;
drop table Agences;
*/

--select * from Personnes where prenom = 'nico';
--##################################
--  Cr�ation de la data base BoVoyageNN

--create database BoVoyageNN;
use BoVoyageNN;


--##################################
--  Cr�ation table Destinations
create table Destinations
(
ID_destination int not null identity,
continent nvarchar(20),
pays nvarchar(32),
region nvarchar(32),
descriptif nvarchar(max),
primary key(ID_destination)
);


--##################################
--  Cr�ation table Agences

create table Agences
(
ID_agence int not null identity,
nomAgence nvarchar(32) not null,
primary key(ID_agence)
);

--##################################
--  Cr�ation table Voyages

create table Voyages
(
ID_voyage int not null identity,
dateAller date not null,
dateRetour date not null,
placeDispo int not null,
tarifToutCompris money not null,
ID_destination int not null,
ID_agence int not null
primary key (ID_voyage)
);


--##################################
--  Cr�ation table Personnes

create table Personnes
(
ID_personne int not null identity,
civ nvarchar(5),
nom nvarchar(32) not null,
prenom nvarchar(32) not null, 
date_naissance Date not null,
age int not null,
adresse nvarchar (230),  
tel nvarchar(20) not null,
email nvarchar(320),
client bit DEFAULT (0),
participant bit DEFAULT (0), 
reduction float DEFAULT (0),
primary key (ID_personne)
);

--##################################
--  Cr�ation table Dossiers

create table Dossiers
(
ID_dossier int not null identity,
n_CB nvarchar(20) not null,
prixTotal money,
etatDossier tinyint not null,
raisonAnnulation tinyint, 
ID_voyage int not null,
ID_client int not null,
primary key (ID_dossier)
);

--##################################
--  Cr�ation table Assurances
create table Assurances
(
ID_assurance int not null identity,
type_assurance nvarchar(32)null,
prix float,
primary key (ID_assurance)
);

--##################################
--  Cr�ation table AssurDoss
create table AssurDoss
(
ID_assurance int not null,
ID_dossier int not null
);

--##################################
--  Cr�ation table ParticipDoss

create table ParticipDoss
(
ID_participant int not null,
ID_dossier int not null
);

----------------------------------------------------------------------------------------------------

--##################################
--  Attribution FK Voyages
alter table Voyages 
add constraint fkV1 foreign key (ID_destination) references Destinations(ID_destination);

alter table Voyages
add constraint fkV2 foreign key (ID_agence) references Agences (ID_agence);


--  Attribution FK Dossiers
alter table Dossiers
add constraint fkD1 foreign key (ID_client) references Personnes (ID_personne);

alter table Dossiers
add constraint fkD2 foreign key (ID_voyage) references Voyages (ID_voyage);

--  Attribution FK AssurDoss
alter table AssurDoss
add constraint fkAD1 foreign key (ID_assurance) references Assurances (ID_assurance);

alter table AssurDoss
add constraint fkAD2 foreign key (ID_dossier) references Dossiers (ID_dossier);

--  Attribution FK ParticipDoss
alter table ParticipDoss
add constraint fkPD1 foreign key (ID_participant) references Personnes (ID_personne);

alter table ParticipDoss
add constraint fkPD2 foreign key (ID_dossier) references Dossiers (ID_dossier);

----------------------------------------------------------------------------------------------------
ALTER TABLE Personnes ADD CONSTRAINT age_def DEFAULT (-1) FOR age; 
ALTER TABLE Dossiers ADD CONSTRAINT etatDoss_def DEFAULT (0) FOR etatDossier; 
 

--ALTER TABLE Participants ADD CONSTRAINT reduc_def DEFAULT 0 FOR reduction; 

-- select tables

select * from Personnes;
select * from Dossiers;
select * from Voyages;
select * from destinations;
select * from Agences;
select * from AssurDoss;
select * from ParticipDoss;
select * from Assurances;



-- drop tables
/*
drop table Voyages;
drop table Destinations;
drop table Agences;
drop table AssurDoss;
drop table ParticipDoss;
drop table Dossiers;
drop table Assurances;
drop table Participants;
drop table Clients;
drop table Personnes;
drop table AssurAnnul;
*/




--##################################
--  Proc�dure liste des noms et pr�noms des voyageurs avec leurs ID correspondant

/*
create procedure ListeIDVoyageur 
as
select ID_voyageur, nom, prenom
from dbo.Voyageurs
;
go

drop procedure ListeIDVoyageur;
execute ListeIDVoyageur;
*/


