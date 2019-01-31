use BoVoyageNN;

--####################################################################################################
-- Trigger pour ajouter l'âge à la table Personnes en se basant sur la date de naissance

create trigger age on Personnes after insert as
begin
update Personnes set age = cast(cast(CURRENT_TIMESTAMP as datetime)
- cast(date_naissance as datetime) as int)/ 365;
end
go

-- drop trigger age


--####################################################################################################
-- trigger pour ajouter la réduction au personne de moins de 12 ans

create trigger reduction on Personnes after insert, update as
IF exists ( select * from Personnes)
begin
update Personnes set reduction = 0.6 where participant = 1 and age < 12;
end
go

-- drop trigger reduction


--####################################################################################################
-- procedure permettant d'afficher la table personne entière

CREATE PROCEDURE Voir
AS
begin
SELECT *  FROM  Personnes;
end
go

-- exec Voir
-- drop procedure voir

--####################################################################################################
-- création de view Voyage Dossier Agence

CREATE VIEW VoyageDossierAgence
 AS SELECT Do.ID_dossier, Do.etatDossier, Do.prixTotal, Do.raisonAnnulation, P.civ, P.nom, P.prenom, P.tel, P.email, V.dateAller, V.dateRetour, D.continent, D.pays, D.region, A.nomAgence, Ass.type_assurance 
 FROM Voyages V, Agences A, Destinations D, Dossiers Do, Personnes P, Assurances Ass
 WHERE D.ID_destination = V.ID_destination and A.ID_agence = V.ID_agence and V.ID_voyage = Do.ID_voyage and P.ID_personne = Do.ID_client;
  go
-- select * from VoyageDossierAgence
-- drop view VoyageDossierAgence


 --####################################################################################################
 -- création de view Dossier nb participant

 CREATE VIEW ParticipantVoyage
 AS SELECT P.nom, P.prenom, D.ID_dossier
 FROM Personnes P, Dossiers D, ParticipDoss Pd
 WHERE P.participant = 1 and P.ID_personne = Pd.ID_participant and Pd.ID_dossier = D.ID_dossier ;
 go
 -- select * from ParticipantVoyage
 -- drop view ParticipantVoyage







