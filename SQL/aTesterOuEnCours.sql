
--################################## Projet en tester ou en cours ##################################--

--####################################################################
--  Cr�ation table Authentifications :
/*
create table Authentifications
(
identifiant nvarchar(10),
mdp nvarchar(10)
);
*/

--####################################################################
-- Tester l'unicit� des ID Voyage et Client dans la table Dossiers, lors de la cr�ation d'un dossier

/*
if exists (SELECT COUNT(ID_personne) FROM Personnes  where ID_personne = 48 and select COUNT(ID_voyage) from Voyages where ID_voyage = 38)
begin
insert into Dossiers (n_CB, ID_voyage, ID_client) values ('8974564',8 , 35);
end;
else
begin
return PRINT 'L''ID s�lectionn� n''existe pas'
end
go
*/


--####################################################################################################
-- Tester la cr�ation d'une view Dossier nb participant pour l'adapter � une proc�dure stock�e avec param�tre

/*
CREATE VIEW ParticipantVoyage
AS SELECT P.nom, P.prenom, D.ID_dossier
FROM Personnes P, Dossiers D, ParticipDoss Pd
WHERE D.ID_dossier = 3 and P.ID_personne = Pd.ID_participant and Pd.ID_dossier = D.ID_dossier ;
go
-- select * from ParticipantVoyage
-- drop view ParticipantVoyage
*/