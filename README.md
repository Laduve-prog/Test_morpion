# Reprise ( Test et Refacto ) d'un jeu de morpion en C

## I. Analyse de la solution de base :

##### **Présence de code mort**

Le code commenté dans la méthode `tourJoueur` n'est jamais exécuté et peut être supprimé.

```csharp
                    //case ConsoleKey.UpArrow:
                    //    if (row <= 0)
                    //    {
                    //        row = 3;
                    //    }
                    //    else
                    //    {
                    //        row = row - 1;
                    //    }
                    //    break;
```



##### **Duplication de code** :tri:

Certaine méthode exécutent le meme code a une variable pret il est donc possible de créer une méthode utilisable pour le joueur1 et le joueur2 afin de rendre le code plus maintenable

- Les méthodes `tourJoueur` et `tourJoueur2` sont presque identiques et pourraient être regroupées en une seule méthode paramétrée.

```csharp
public void tourJoueur() {...}
public void tourJoueur2() {...}
```



##### **Violation du principe de responsabilité unique**

 La classe `MainProgram` gère plusieurs aspects distincts (sélection du jeu, boucle de jeu, interface utilisateur) et devrait être refactorisée en classes distinctes.



##### **Violation du principe OCP (Open-Close-Principle)**

Il stipule que les classes et modules logiciels doivent être ouverts à l'extension mais fermés à la modification.

En d'autres termes, il devrait être possible d'ajouter de nouvelles fonctionnalités à un logiciel sans avoir à modifier le code existant.

- Ici l'ajout de nouveaux jeux nécessite de modifier la classe `MainProgram`.

- **Violation du principe d'inversion des dépendances**
  
  Il stipule que les dépendances entre les modules logiciels doivent être définies par des abstractions et non par des implémentations concrètes.

          La classe `MainProgram` dépend directement des classes `Morpion` et             `PuissanceQuatre`. `MainProgram`  dépend également de la Console ce qui rend         difficile le test et la maintenance du code. L'injection de dépendances est une              meilleure approche.



##### **Présence de "Magic Number"**

Les valeurs "4" et "7" dans la déclaration de la grille (`grille = new char[4, 7];`) ne sont pas explicites et pourraient être remplacées par des constantes nommées pour une meilleure compréhension.



##### **Nom des variables peu intuitifs**

La variable `c` dans la méthode `verifVictoire` n'est pas claire et pourrait être remplacée par un nom plus précis indiquant son rôle.

```csharp
public bool verifVictoire(char c)
```

## 2. Proposition d'amélioration :

##### **Présence de code mort**

- Supprimer le code commenté dans la méthode `tourJoueur`.

##### **Duplication de code**

- Implémenter une méthode unique `tourJoueur(int joueur)` paramétrée par le numéro du joueur pour éviter la duplication de code entre `tourJoueur` et `tourJoueur2`.

##### **Violation des principes SOLID**

Division du programme en plusieurs classe distinctes :

- **Classe Abstraite Jeu** : 
  
  Décrit les fonctionnalités communes à tous les jeux (gestion du plateau, tours, vérification des victoires/égalités). 

- **Classe Morpion** :
  
   Implémente les règles spécifiques du jeu de Morpion

- **Classe PuissanceQuatre** :
  
  Implémente les règles spécifiques du jeu de Puissance 4

- **Classe SelectionJeu** :
  
  Gère la sélection du jeu par l'utilisateur.
  
  Affiche la liste des jeux disponibles et permet à l'utilisateur de choisir son jeu.

- **Classe InterfaceUtilisateur** :
  
  Gère l'interaction avec l'utilisateur (affichage des messages, saisie des informations).
  
  Implémente des méthodes pour afficher le plateau, les messages d'information et demander des actions à l'utilisateur.

- **Classe Main** :
  
  Point d'entrée principal du programme.
  
  Crée les instances des classes nécessaires et lance la boucle de jeu.
  
  

##### **Présence de "Magic Number"**

- Remplacer les valeurs "4" et "7" par des constantes nommées explicites pour une meilleure compréhension.

Exemple:  `const int NB_LIGNES = 4;` et `const int NB_COLONNES = 7;`.



##### **Nom des variables peu intuitifs**

- Donner des noms plus précis aux variables pour une meilleure lisibilité.

Exemple: Remplacer `c` par `symboleJoueur` dans la méthode `verifVictoire`.



##### **Gestion des erreurs:**

 Implémenter une gestion des erreurs robuste pour garantir la fiabilité du programme.



##### **Implémentation de test unitaire**