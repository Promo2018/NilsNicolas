use BoVoyageNN;

--#################################################################################################################
-- Insert Authentifications

insert into Authentifications (identifiant, mdp) values ('admin', 'password');
insert into Authentifications (identifiant, mdp) values ('client', 'voyage89');
insert into Authentifications (identifiant, mdp) values ('marketing', 'conseil42');


--#################################################################################################################
-- Insert Personnes

INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Beck','While''mina','17/02/2009','Ap #245-2016 Duis St.','0378588069','sodales.elit@elitdictum.com',0, 0);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Chang','Meredith','09/12/1967','Ap #878-9210 Pharetra Av.','0692930681','bibendum@elitEtiam.ca',1, 0);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Morrison','Joy','15/05/1946','P.O. Box 472, 8823 Etiam Avenue','0604220689','pellentesque@sitametrisus.ca',1, 0);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Page','Jeanette','14/05/2018','P.O. Box 164, 5582 Nec Road','0725412213','nisl.sem.consequat@necurna.org',1, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Petty','Farrah','07/08/1949','P.O. Box 379, 2932 Tristique Avenue','0124015711','molestie.pharetra@quam.net',0, 0);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Sherman','Tobias','01/11/1960','Ap #994-8387 Faucibus Rd.','0510185988','nunc.interdum@vel.org',0, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('Mme','William','Erich','05/12/1996','Ap #845-917 Sapien. Rd.','0164087186','Praesent.luctus.Curabitur@adipiscingnon.co.uk',1, 0);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('Mme','Maldonado','Zenaida','28/12/1959','Ap #493-2903 Quisque Ave','0910628512','primis.in@in.org',1, 0);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Ramsey','Gemma','23/03/2012','Ap #136-6267 Consectetuer Ave','0102402642','velit.Pellentesque@velitSed.org',0, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Stevens','Alexander','16/06/1989','Ap #777-6856 Gravida. Ave','0262244343','Maecenas@Maurisut.net',0, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('Mme','Strickland','Regan','12/01/1974','7699 Vitae, Rd.','0335254733','venenatis.lacus.Etiam@aliquetlobortis.edu',0, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('Mme','Donovan','Aurora','26/09/1952','Ap #266-9530 Hendrerit Avenue','0173584296','pulvinar@Suspendisse.edu',0, 0);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Santiago','Lisandra','07/09/1973','Ap #210-6933 Sapien. Rd.','0923133496','dis.parturient@Pellentesquehabitant.org',1, 0);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('Mme','Miles','Michael','30/08/1983','P.O. Box 610, 1919 Velit Ave','0745717348','Maecenas.iaculis.aliquet@Nullamsuscipitest.ca',1, 0);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Olson','Abdul','17/03/1960','Ap #888-8252 Suspendisse St.','0879208516','vel.est@euismodac.org',0, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Juarez','Keefe','12/05/1953','Ap #702-5396 Ligula Rd.','0909601006','Sed.molestie@amet.net',1, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Macias','Sophia','20/08/1999','4114 Ut, Rd.','0394784549','at.libero@tinciduntcongueturpis.com',1, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('Mme','Bridges','Lyle','05/02/1959','P.O. Box 214, 7804 Sagittis St.','0973187896','metus@arcuVestibulumante.edu',1, 0);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Russell','Ashton','18/03/1973','Ap #129-2302 Tincidunt Rd.','0855406423','rutrum@risusInmi.net',1, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('Mme','Colon','Cullen','09/09/1958','Ap #420-6459 Nunc Avenue','0734005710','diam@eleifendCrassed.net',0, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('Mme','Cazal','Marine','05/09/1962','36 rue Nunc Avenue','0768004710','jira@eleclodCrassed.fr',0, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('Mme','Rihdo','Claire','19/02/1984','48 chemin de la rivière','0668486210','minet@chiris.fr',0, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Marc','George','23/05/1998','67 avenue de la marne','0684696210','jagra@novice.fr',0, 1);
INSERT INTO Personnes(civ,nom,prenom,date_naissance,adresse,tel,email,client,participant) VALUES('M','Julien','Leaps','28/11/1966','95 boulevard de la rep','0868699210','GLM@basic.fr',0, 1);


--#################################################################################################################
-- Insert Destinations
INSERT INTO Destinations(continent,pays,region,descriptif) VALUES('South Sudan','PR','Grasse','magnis dis parturient montes, nascetur ridiculus mus. Proin vel');
INSERT INTO Destinations(continent,pays,region,descriptif) VALUES('Korea, North','Cornwall','Truro','nisi. Cum sociis natoque penatibus');
INSERT INTO Destinations(continent,pays,region,descriptif) VALUES('Tajikistan','Heredia','Ulloa (Barrial)','cursus non, egestas a, dui. Cras pellentesque. Sed dictum. Proin');
INSERT INTO Destinations(continent,pays,region,descriptif) VALUES('Cook Islands','Friesland','Leeuwarden','luctus');
INSERT INTO Destinations(continent,pays,region,descriptif) VALUES('Andorra','PO','Poitiers','nec, imperdiet nec, leo. Morbi neque');
INSERT INTO Destinations(continent,pays,region,descriptif) VALUES('Syria','Banffshire','Keith','augue id ante dictum');
INSERT INTO Destinations(continent,pays,region,descriptif) VALUES('Argentina','VEN','Castelbaldo','lobortis tellus justo sit amet nulla. Donec non justo.');
INSERT INTO Destinations(continent,pays,region,descriptif) VALUES('Czech Republic','Lombardia','Casnate con Bernate','metus urna convallis erat, eget tincidunt');
INSERT INTO Destinations(continent,pays,region,descriptif) VALUES('Burundi','Jönköpings län','Värnamo','enim. Curabitur massa. Vestibulum accumsan neque');
INSERT INTO Destinations(continent,pays,region,descriptif) VALUES('New Caledonia','CH','Châlons-en-Champagne','placerat');



--#################################################################################################################
-- Insert Agences
INSERT INTO Agences(nomAgence) VALUES('Sodales Inc.');
INSERT INTO Agences(nomAgence) VALUES('Tempus Ltd');
INSERT INTO Agences(nomAgence) VALUES('Erat PC');
INSERT INTO Agences(nomAgence) VALUES('Vulputate Eu Odio LLC');
INSERT INTO Agences(nomAgence) VALUES('Ut Quam Ltd');
INSERT INTO Agences(nomAgence) VALUES('Laoreet Lectus Quis Inc.');
INSERT INTO Agences(nomAgence) VALUES('Elementum Dui Corporation');
INSERT INTO Agences(nomAgence) VALUES('Elit Institute');
INSERT INTO Agences(nomAgence) VALUES('Auctor Non Feugiat Corp.');
INSERT INTO Agences(nomAgence) VALUES('Volutpat Nulla LLC');


--#################################################################################################################
-- Insert Voyages
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('17/01/2019', '20/03/2019', 3, 1724.22, 7, 6);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('23/01/2019', '03/03/2019', 9, 1495.63, 9, 1);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('01/02/2019', '04/03/2019', 1, 1777.18, 4, 7);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('28/01/2019', '27/03/2019', 1, 1181.17, 10, 9);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('17/01/2019', '16/03/2019', 8, 1398.41, 5, 2);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('09/02/2019', '21/02/2019', 4, 2015.67, 7, 2);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('21/01/2019', '08/04/2019', 4, 1060.67, 7, 5);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('14/02/2019', '04/03/2019', 2, 1111.91, 1, 3);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('24/01/2019', '25/02/2019', 6, 2637.32, 1, 1);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('03/02/2019', '25/03/2019', 9, 1397.25, 4, 3);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('18/01/2019', '15/03/2019', 7, 2751.25, 3, 8);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('25/01/2019', '14/03/2019', 1, 2934.74, 2, 3);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('18/02/2019', '11/04/2019', 7, 1505.09, 8, 5);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('20/01/2019', '16/03/2019', 6, 1769.15, 5, 6);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('07/02/2019', '03/04/2019', 9, 1266.93, 9, 9);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('01/02/2019', '07/04/2019', 1, 1365.56, 6, 4);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('21/01/2019', '16/04/2019', 9, 2116.15, 9, 1);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('04/02/2019', '13/03/2019', 7, 2027.01, 4, 5);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('24/01/2019', '11/04/2019', 4, 2894.7, 4, 10);
insert into Voyages (dateAller, dateRetour, placeDispo, tarifToutCompris, ID_destination, ID_agence) values ('15/01/2019', '04/03/2019', 3, 632.56, 2, 4);



--#################################################################################################################
-- Insert Assurances

insert into Assurances (type_assurance, prix) values ('annulation', 14.99);


--#################################################################################################################
-- Insert Dossiers

insert into Dossiers (n_CB, ID_voyage, ID_client) values ('6378867045927111',9 , 2);
insert into Dossiers (n_CB, ID_voyage, ID_client) values ('201925610849213',7 , 3);
insert into Dossiers (n_CB, ID_voyage, ID_client) values ('3557430574455168',12 , 7);
insert into Dossiers (n_CB, ID_voyage, ID_client) values ('6391593844827178',9 , 8);
insert into Dossiers (n_CB, ID_voyage, ID_client) values ('3536982894949714',12 , 13);
insert into Dossiers (n_CB, ID_voyage, ID_client) values ('201636351549595',18 , 14);
insert into Dossiers (n_CB, ID_voyage, ID_client) values ('5602228496546951',5 , 18);
insert into Dossiers (n_CB, ID_voyage, ID_client) values ('4844445318384111',15 , 16);
insert into Dossiers (n_CB, ID_voyage, ID_client) values ('6334453298860110',3 , 17);
insert into Dossiers (n_CB, ID_voyage, ID_client) values ('6759097504074150',6 , 4);
insert into Dossiers (n_CB, ID_voyage, ID_client) values ('4453197504944150',6 , 19);


--#################################################################################################################
-- Insert AssurDoss

insert into AssurDoss (ID_assurance, ID_dossier) values (1, 1);
insert into AssurDoss (ID_assurance, ID_dossier) values ( 1, 7);
insert into AssurDoss (ID_assurance, ID_dossier) values ( 1, 10);
insert into AssurDoss (ID_assurance, ID_dossier) values ( 1, 9);
insert into AssurDoss (ID_assurance, ID_dossier) values (1 , 5);
insert into AssurDoss (ID_assurance, ID_dossier) values ( 1, 3);
insert into AssurDoss (ID_assurance, ID_dossier) values ( 1, 8);

--#################################################################################################################
-- Insert ParticipDoss

insert into ParticipDoss (ID_participant, ID_dossier) values (4, 1);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 6, 7);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 16, 10);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 9, 9);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 17, 5);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 10, 3);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 19, 8);
insert into ParticipDoss (ID_participant, ID_dossier) values (11, 8);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 15, 7);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 20, 10);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 21, 7);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 22, 8);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 23, 3);
insert into ParticipDoss (ID_participant, ID_dossier) values ( 24, 8);