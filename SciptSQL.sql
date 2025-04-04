CREATE DATABASE livin;
USE livin;


CREATE TABLE Utilisateur(
   ID_User VARCHAR(50),
   Nom_User VARCHAR(50),
   Prenom_User VARCHAR(50),
   Adresse VARCHAR(50),
   Email VARCHAR(50),
   Mot_De_Passe VARCHAR(50),
   Metro VARCHAR(50),
   PRIMARY KEY(ID_User)
);

CREATE TABLE Client(
   ID_Client VARCHAR(50),
   Préférences VARCHAR(50),
   ID_User VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Client),
   UNIQUE(ID_User),
   FOREIGN KEY(ID_User) REFERENCES Utilisateur(ID_User)
);

CREATE TABLE Cuisinier(
   ID_Cuisinier VARCHAR(50),
   ID_User VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Cuisinier),
   UNIQUE(ID_User),
   FOREIGN KEY(ID_User) REFERENCES Utilisateur(ID_User)
);

CREATE TABLE Commande(
   ID_Commande VARCHAR(50),
   Date_Commande DATETIME,
   ID_Client VARCHAR(50),
   PRIMARY KEY(ID_Commande),
   FOREIGN KEY(ID_Client) REFERENCES Client(ID_Client)
);

CREATE TABLE Recette(
   ID_Recette VARCHAR(50),
   Nom_Recette VARCHAR(50),
   Ingrédients VARCHAR(50),
   Type_Plat VARCHAR(50),
   Nationalité VARCHAR(50),
   Portions VARCHAR(50),
   Régime_Alimentaire VARCHAR(50),
   ID_Cuisinier VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Recette),
   FOREIGN KEY(ID_Cuisinier) REFERENCES Cuisinier(ID_Cuisinier)
);

CREATE TABLE Particulier(
   ID_Particulier VARCHAR(50),
   Mot_De_Passe_Particulier VARCHAR(50),
   ID_Client VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Particulier),
   UNIQUE(ID_Client),
   FOREIGN KEY(ID_Client) REFERENCES Client(ID_Client)
);

CREATE TABLE Entreprise(
   ID_Entreprise VARCHAR(50),
   Nom_Entreprise VARCHAR(50),
   Référent VARCHAR(50),
   Mot_De_Passe_Entreprise VARCHAR(50),
   ID_Client VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Entreprise),
   UNIQUE(ID_Client),
   FOREIGN KEY(ID_Client) REFERENCES Client(ID_Client)
);

CREATE TABLE Ligne_Commande(
   ID_Ligne VARCHAR(50),
   Adresse_Livraison VARCHAR(50),
   PRIMARY KEY(ID_Ligne)
);

CREATE TABLE Plat(
   ID_Plat VARCHAR(50),
   Nom_Plat VARCHAR(50),
   Date_Création DATE,
   Date_Péremption DATE,
   Prix INT,
   Photo BLOB,
   ID_Ligne VARCHAR(50) NOT NULL,
   ID_Cuisinier VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Plat),
   FOREIGN KEY(ID_Ligne) REFERENCES Ligne_Commande(ID_Ligne),
   FOREIGN KEY(ID_Cuisinier) REFERENCES Cuisinier(ID_Cuisinier)
);

CREATE TABLE Utilise(
   ID_Cuisinier VARCHAR(50),
   ID_Recette VARCHAR(50),
   PRIMARY KEY(ID_Cuisinier, ID_Recette),
   FOREIGN KEY(ID_Cuisinier) REFERENCES Cuisinier(ID_Cuisinier),
   FOREIGN KEY(ID_Recette) REFERENCES Recette(ID_Recette)
);

CREATE TABLE Note(
   ID_Client VARCHAR(50),
   ID_Cuisinier VARCHAR(50),
   Date_Note DATETIME,
   Note DECIMAL(4,2),
   Commentaire VARCHAR(50),
   PRIMARY KEY(ID_Client, ID_Cuisinier,Date_Note),
   FOREIGN KEY(ID_Client) REFERENCES Client(ID_Client),
   FOREIGN KEY(ID_Cuisinier) REFERENCES Cuisinier(ID_Cuisinier)
);

CREATE TABLE Constitue(
   ID_Commande VARCHAR(50),
   ID_Ligne VARCHAR(50),
   PRIMARY KEY(ID_Commande, ID_Ligne),
   FOREIGN KEY(ID_Commande) REFERENCES Commande(ID_Commande),
   FOREIGN KEY(ID_Ligne) REFERENCES Ligne_Commande(ID_Ligne)
);

