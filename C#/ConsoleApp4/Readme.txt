BoVoyage Intranet est un programme qui permet de cr�er, d'ajouter et de modifier des voyageurs et des dossiers de voyage. Il permet �galement de visualiser et modifier les informations n�cessaires au suivi des clients et dossiers.

Pour fonctionner BoVoyage Intranet n�cessite l'installation au pr�alable de la BDD SQL serveur "BoVoyageNN". 

Nous recommandons de faire appel � nos services afin d'installer la BDD "BoVoyageNN". N�anmoins le dossier "SQL" comporte les fichiers de requ�tes n�cessaires pour g�n�rer cette BDD dans sa configuration initiale. En ex�cutant "TablesProjet.sql" pour cr�er les tables et leurs relations puis "ProcedureProjet.sql � (attention, il faut ex�cuter chaque proc�dure individuellement) et finalement "GenerateData.sql" pour ajouter un jeu de donn�es initial.

Pour acc�der � BoVoyage Intranet il faut commencer par s'identifier. Pour le moment l'identification impl�ment�e est tr�s simple il suffit de saisir les informations suivantes lorsqu'elles sont demand�es : 

Authentification : 
	- Identifiant : admin
	- Mot de passe : password


A partir du menu principal on acc�de soit � la partie Client/Accompagnant appel�e Voyageur Soit � la partie "suivi/cr�ation des dossiers" appel�e Voyage.

Pour acc�der aux diff�rents menus / sous menus, il suffit de rentrer le chiffre correspondant au menu souhait�, ce chiffre est indiqu� par les dialogues de la console qui vous guident.

Lors de la saisie des donn�es. Il n'est pas toujours n�cessaire de remplir tous les champs � chaque �tape. Mais si une information est n�cessaire vous ne pourrez pas poursuivre votre d�marche sans la saisir.

Pour cr�er un voyage, vous devez d'abord cr�er et enregistrer le client et les participants du voyage dans le menu Voyageur s�ils ne sont pas encore pr�sent dans la BDD puis vous pourrez utiliser leur ID pour cr�er le voyage.

Pour le moment l'affichage des plusieurs informations, tel que les voyages par exemple, n'est pas encore disponible. Vous pouvez consulter ces informations directement dans la BDD BoVoyageNN avec la requ�te "Select * from Voyages ;" pour retrouver les IDs � rentrer lors de la cr�ation de vos voyages notamment dans la colonne "ID_Voyages" de la table Voyages.
De m�me toutes les tables de la BDD sont consultables via les requ�tes ex�cutables sous "Microsoft SQL Serveur Manager Studio" pr�sentes dans le fichier "Selects.sql" du dossier "SQL".



