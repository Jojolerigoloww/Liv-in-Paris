-- Peuplement de la table utilisateur :
INSERT INTO `livin`.`utilisateur` (`ID_User`, `Nom_User`, `Prenom_User`, `Adresse`, `Email`, `Mot_De_Passe`, `Metro`) 
VALUES 
('U654', 'Juniot', 'Gérard', '45 rue des chars', 'Juniot@gmail.com', 'gégé','Chatelet'),
('U626', 'Marchand', 'Leon', '12 rue des piscines', 'Leon.Marchand@gmail.com', 'papillon','Bastille'),
('U656', 'Rinner', 'Teddy', '2 rue des médailles', 'Judo@gmail.com', 'riri','Nation'),
('U526', 'Sy', 'Omar', '6 avenue des blagues', 'Lupin@gmail.com', 'mystere','Réaumur Sébastopol'),
('U536', 'Dupont', 'Alice', '25 rue de la paix', 'alice.dupont@gmail.com', 'tulipe','Opéra'),
('U547', 'Lemoine', 'Claude', '8 rue des roses', 'claude.lemoine@gmail.com', 'jardinier','Gare du Nord');

-- Peuplement de la table client :
INSERT INTO `livin`.`client` (`ID_Client`, `Préférences`, `ID_User`) 
VALUES 
('C654', 'Escalope de poulet', 'U654'),
('C626', 'Paella', 'U626'),
('C656', 'Pizza', 'U536'),
('C666', 'Sushi', 'U547');

-- Peuplement de la table cuisinier :
INSERT INTO `livin`.`cuisinier` (`ID_Cuisinier`, `ID_User`) 
VALUES 
('C656', 'U656'),
('C526', 'U526'),
('C636', 'U536'),
('C646', 'U547');

INSERT INTO `livin`.`particulier` (`ID_Particulier`, `Mot_De_Passe_Particulier`, `ID_Client`) 
VALUES 
('P654', 'mdp123', 'C654'),
('P666', 'passepartout', 'C666');

-- Peuplement de la table entreprise
INSERT INTO `livin`.`entreprise` (`ID_Entreprise`, `Nom_Entreprise`, `Référent`, `Mot_De_Passe_Entreprise`, `ID_Client`) 
VALUES 
('E626', 'Netflix', 'Leon Marchand', 'sisi', 'C626'),
('E636', 'Amazon', 'Alice Dupont', 'admin', 'C656');

-- Peuplement de la table commande
INSERT INTO `livin`.`commande` (`ID_Commande`, `Date_Commande`, `ID_Client`) 
VALUES 
('CMD1', '2024-02-01 10:00:00', 'C654'),
('CMD2', '2024-02-02 15:30:00', 'C626'),
('CMD3', '2024-02-05 12:00:00', 'C656'),
('CMD4', '2024-02-06 16:00:00', 'C666'),
('CMD5', '2024-02-20 10:30:00', 'C654');

-- Peuplement de la table recette
INSERT INTO `livin`.`recette` (`ID_Recette`, `Nom_Recette`, `Ingrédients`, `Type_Plat`, `Nationalité`, `Portions`, `Régime_Alimentaire`, `ID_Cuisinier`) 
VALUES 
('R1', 'Pâtes Carbonara', 'Pâtes, Œufs, Lardons', 'Plat principal', 'Italienne', '2', 'Non végétarien', 'C656'),
('R2', 'Salade César', 'Laitue, Poulet, Parmesan', 'Entrée', 'Américaine', '1', 'Sans gluten', 'C656'),
('R3', 'Couscous Royal', 'Semoule, Viande, Légumes', 'Plat principal', 'Marocaine', '4', 'Halal', 'C526'),
('R4', 'Pizza Margarita', 'Tomates, Mozzarella, Basilic', 'Plat principal', 'Italienne', '2', 'Végétarien', 'C636'),
('R5', 'Sushi', 'Poisson cru, Riz', 'Plat principal', 'Japonaise', '6', 'Sans gluten', 'C646');

-- Peuplement de la table ligne_commande
INSERT INTO `livin`.`ligne_commande` (`ID_Ligne`, `Adresse_Livraison`) 
VALUES 
('L1', '10 rue des Oliviers, Paris'),
('L2', '22 avenue de Lyon, Marseille'),
('L3', '5 boulevard Haussmann, Paris'),
('L4', '15 avenue de la République, Lyon'),
('L5', '23 rue de la Liberté, Paris'),
('L6', '15 avenue des Champs-Élysées, Paris'),
('L7', '7 rue du Faubourg Saint-Antoine, Paris');

-- Peuplement de la table plat
INSERT INTO `livin`.`plat` (`ID_Plat`, `Nom_Plat`, `Date_Création`, `Date_Péremption`, `Prix`, `Photo`, `ID_Ligne`, `ID_Cuisinier`) 
VALUES 
('P1', 'Pizza Margherita', '2024-02-01', '2024-02-05', 12.50, NULL, 'L1', 'C656'),
('P2', 'Bœuf Bourguignon', '2024-02-02', '2024-02-06', 18.00, NULL, 'L2', 'C526'),
('P3', 'Tajine de Poulet', '2025-02-03', '2025-03-07', 20.00, NULL, 'L3', 'C526'),
('P4', 'Pizza 4 Fromages', '2024-02-05', '2024-02-10', 14.00, NULL, 'L4', 'C636'),
('P5', 'Maki', '2024-02-06', '2024-02-13', 22.00, NULL, 'L1', 'C646'),
('P6', 'Salade de Fruits', '2024-02-20', '2024-02-25', 8.00, NULL, 'L5', 'C656'),
('P7', 'Soupe de Légumes', '2024-02-20', '2024-02-22', 10.00, NULL, 'L6', 'C526'),
('P8', 'Steak Frites', '2024-02-20', '2024-02-23', 15.00, NULL, 'L7', 'C526');

-- Peuplement des Notes (Évaluations des cuisiniers)
INSERT INTO `livin`.`note` (`ID_Client`, `ID_Cuisinier`, `Date_Note`, `Note`, `Commentaire`) 
VALUES 
('C654', 'C656', '2024-02-03 14:00:00', 4.50, 'Très bon repas'),
('C626', 'C526', '2024-02-05 20:00:00', 5.00, 'Excellente qualité et service !'),
('C626', 'C526', '2024-02-10 12:15:00', 4.80, 'Délicieux et bien présenté'),
('C654', 'C656', '2024-02-11 19:45:00', 4.20, 'Bon mais un peu trop salé'),
('C654', 'C526', '2024-02-12 21:30:00', 5.00, 'Parfait ! Rien à dire.'),
('C626', 'C656', '2024-02-13 15:00:00', 3.80, 'C’était correct, mais peut mieux faire.'),
('C654', 'C656', '2024-02-14 17:20:00', 4.50, 'Belle découverte, je recommanderai.'),
('C626', 'C526', '2024-02-15 13:10:00', 4.00, 'Sympa mais un peu trop épicé pour moi.'),
('C656', 'C636', '2024-02-17 14:30:00', 5.00, 'Excellente pizza !'),
('C666', 'C646', '2024-02-18 16:00:00', 4.75, 'Sushi de qualité, bien préparé.');

-- Peuplement des Utilisations de Recettes par les Cuisiniers
INSERT INTO `livin`.`utilise` (`ID_Cuisinier`, `ID_Recette`) 
VALUES 
('C656', 'R1'),
('C526', 'R2'),
('C526', 'R3'),
('C636', 'R4'),
('C646', 'R5');

-- Peuplement des Relations Commande - Ligne de Commande
INSERT INTO `livin`.`constitue` (`ID_Commande`, `ID_Ligne`) 
VALUES 
('CMD1', 'L1'),
('CMD2', 'L2'),
('CMD3', 'L3'),
('CMD4', 'L4'),
('CMD5', 'L5'),
('CMD5', 'L6'),
('CMD5', 'L7');
