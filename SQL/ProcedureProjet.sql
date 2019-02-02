use BoVoyageNN;

--####################################################################################################
-- trigger pour ajouter la réduction au personne de moins de 12 ans

create trigger reduction on Personnes after insert, update as
declare @age int;
set @age = cast(cast(CURRENT_TIMESTAMP as datetime) - cast(date_naissance as datetime) as int)/ 365
IF exists ( select * from Personnes)
begin
update Personnes set reduction = 0.6 where participant = 1 and @age < 12;
end
go

-- drop trigger reduction

--####################################################################################################
-- création de view Voyage Dossier Agence

CREATE VIEW VoyageDossierAgence
AS SELECT Do.ID_dossier, Do.etatDossier, Do.raisonAnnulation, P.civ, P.nom, P.prenom, P.tel, P.email, V.dateAller, V.dateRetour, D.continent, D.pays, D.region, A.nomAgence, Ass.type_assurance 
FROM Voyages V, Agences A, Destinations D, Dossiers Do, Personnes P, Assurances Ass
WHERE D.ID_destination = V.ID_destination and A.ID_agence = V.ID_agence and V.ID_voyage = Do.ID_voyage and P.ID_personne = Do.ID_client;
go
-- select * from VoyageDossierAgence
-- drop view VoyageDossierAgence







