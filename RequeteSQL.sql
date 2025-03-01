SELECT *
FROM utilisateur
ORDER BY Nom_User,Prenom_User;

SELECT * 
FROM client;

SELECT * 
FROM plat
ORDER BY Date_Péremption;

SELECT * 
FROM recette
ORDER BY Portions;

SELECT * 
FROM ligne_commande;

SELECT Nom_Plat, Date_Péremption
FROM Plat
WHERE Date_Péremption >= CURDATE();

SELECT Client.ID_Client, Cuisinier.ID_Cuisinier, Note.Note, Note.Commentaire
FROM Note
JOIN Client ON Note.ID_Client = Client.ID_Client
JOIN Cuisinier ON Note.ID_Cuisinier = Cuisinier.ID_Cuisinier
ORDER BY note DESC;

SELECT Utilisateur.Nom_User AS Nom_Cuisinier,
Utilisateur.Prenom_User AS Prenom_Cuisinier,
COALESCE(AVG(Note.Note), 0) AS Note_Moyenne
FROM Cuisinier
JOIN Utilisateur ON Cuisinier.ID_User = Utilisateur.ID_User
LEFT JOIN Note ON Cuisinier.ID_Cuisinier = Note.ID_Cuisinier
GROUP BY Cuisinier.ID_Cuisinier, Utilisateur.Nom_User, Utilisateur.Prenom_User
ORDER BY Note_Moyenne DESC;

SELECT Commande.ID_Commande, Plat.Nom_Plat, Plat.Prix, Plat.Date_Péremption, Ligne_Commande.Adresse_Livraison
FROM Commande
JOIN Constitue ON Commande.ID_Commande = Constitue.ID_Commande
JOIN Ligne_Commande ON Constitue.ID_Ligne = Ligne_Commande.ID_Ligne
JOIN Plat ON Ligne_Commande.ID_Ligne = Plat.ID_Ligne
ORDER BY Commande.ID_Commande,Plat.Prix;

SELECT c.ID_Commande, SUM(p.Prix) AS Prix_Total
FROM commande c
JOIN constitue co ON c.ID_Commande = co.ID_Commande
JOIN ligne_commande lc ON co.ID_Ligne = lc.ID_Ligne
JOIN plat p ON lc.ID_Ligne = p.ID_Ligne
GROUP BY c.ID_Commande
ORDER BY Prix_Total ASC;

SELECT c.Nom_User AS Cuisinier_Nom,
c.Prenom_User AS Cuisinier_Prenom,
COUNT(p.ID_Plat) AS Nombre_De_Plats
FROM cuisinier cu
JOIN utilisateur c ON cu.ID_User = c.ID_User
JOIN plat p ON cu.ID_Cuisinier = p.ID_Cuisinier
GROUP BY c.ID_User;

