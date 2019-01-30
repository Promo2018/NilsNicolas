use BoVoyageNN;

--##################################
-- trigger pour ajouter l'âge à la table Personnes

create trigger age on Personnes after insert as
begin
update Personnes set age = cast(cast(CURRENT_TIMESTAMP as datetime)
- cast(date_naissance as datetime) as int)/ 365;
end
go

--##################################
-- trigger pour ajouter l'âge à la table PArtDoss

create trigger age on ParticipDoss after insert, update as
begin
update Personnes set age = cast(cast(CURRENT_TIMESTAMP as datetime)
- cast(date_naissance as datetime) as int)/ 365
from ParticipDoss, Personnes
where Personnes.ID_personne = ParticipDoss.ID_participant;
end
go

drop trigger age;
delete from Personnes where nom = 'ROUX';

--##################################
select * from Personnes where nom = 'roux' and prenom = 'nicolas';
select * from Personnes


--##################################
-- executable procédure


values ('M', 'roux', 'manu', '08/11/1992',' ' , '7 che', '951101' , 'sannois', 0660572272);

insert into AgenceVoyages(nom) values ('Voyaparadise')

-- insert personnes
insert into Personnes (civ, nom, prenom, date_naissance, age, adresse, tel, email, client, participant, reduction) 
values ('M', 'roux', 'manu', '08/11/1992', 0 ,'7 che', '0660572272' , 'gqergrqeg@egqrg', 1, 1,0);



/*
drop procedure insertVoyageur;
drop procedure insertDestination;
drop procedure insertEmployees ;
drop procedure insertDossier;
*/

