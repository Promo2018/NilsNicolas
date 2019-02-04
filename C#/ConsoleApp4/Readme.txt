BoVoyage Intranet est un programme qui permet de créer, d'ajouter et de modifier des voyageurs et des dossiers de voyage. Il permet également de visualiser et modifier les informations nécessaires au suivi des clients et dossiers.

Pour fonctionner BoVoyage Intranet nécessite l'installation au préalable de la BDD SQL serveur "BoVoyageNN". 

Nous recommandons de faire appel à nos services afin d'installer la BDD "BoVoyageNN". Néanmoins le dossier "SQL" comporte les fichiers de requêtes nécessaires pour générer cette BDD dans sa configuration initiale. En exécutant "TablesProjet.sql" pour créer les tables et leurs relations puis "ProcedureProjet.sql » (attention, il faut exécuter chaque procédure individuellement) et finalement "GenerateData.sql" pour ajouter un jeu de données initial.

Pour accéder à BoVoyage Intranet il faut commencer par s'identifier. Pour le moment l'identification implémentée est très simple il suffit de saisir les informations suivantes lorsqu'elles sont demandées : 

Authentification : 
	- Identifiant : admin
	- Mot de passe : password


A partir du menu principal on accède soit à la partie Client/Accompagnant appelée Voyageur Soit à la partie "suivi/création des dossiers" appelée Voyage.

Pour accéder aux différents menus / sous menus, il suffit de rentrer le chiffre correspondant au menu souhaité, ce chiffre est indiqué par les dialogues de la console qui vous guident.

Lors de la saisie des données. Il n'est pas toujours nécessaire de remplir tous les champs à chaque étape. Mais si une information est nécessaire vous ne pourrez pas poursuivre votre démarche sans la saisir.

Pour créer un voyage, vous devez d'abord créer et enregistrer le client et les participants du voyage dans le menu Voyageur s’ils ne sont pas encore présent dans la BDD puis vous pourrez utiliser leur ID pour créer le voyage.

Pour le moment l'affichage des plusieurs informations, tel que les voyages par exemple, n'est pas encore disponible. Vous pouvez consulter ces informations directement dans la BDD BoVoyageNN avec la requête "Select * from Voyages ;" pour retrouver les IDs à rentrer lors de la création de vos voyages notamment dans la colonne "ID_Voyages" de la table Voyages.
De même toutes les tables de la BDD sont consultables via les requêtes exécutables sous "Microsoft SQL Serveur Manager Studio" présentes dans le fichier "Selects.sql" du dossier "SQL".



