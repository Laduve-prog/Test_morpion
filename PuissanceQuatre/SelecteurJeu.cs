using MorpionApp.Interface;
using MorpionApp.Joueur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class SelecteurJeu
    {
        ConsoleUtilisateur consoleUtilisateur = new ConsoleUtilisateur();

        protected IJoueur _joueur1;
        protected IJoueur _joueur2;

        public Jeu ChoisirJeu()
        {
            consoleUtilisateur.afficherMessage("Choisissez un jeu : [X] Morpion 2j, [Y] Morpion vs IA , [P] Puissance 4 , [Z] Puissance 4 vs IA");
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.X:
                        _joueur1 = UsineJoueur.CréerJoueur(TypeJoueur.HumainMorpion, "Joueur 1", 'X');
                        _joueur2 = UsineJoueur.CréerJoueur(TypeJoueur.HumainMorpion, "Joueur 2", '0');
                        return new Morpion(consoleUtilisateur , _joueur1 , _joueur2);
                    case ConsoleKey.P:
                        _joueur1 = UsineJoueur.CréerJoueur(TypeJoueur.HumainPuissance4, "Joueur 1", 'X');
                        _joueur2 = UsineJoueur.CréerJoueur(TypeJoueur.HumainPuissance4, "Joueur 2", '0');
                        return new PuissanceQuatre(consoleUtilisateur , _joueur1, _joueur2);
                    case ConsoleKey.Y:
                        _joueur1 = UsineJoueur.CréerJoueur(TypeJoueur.HumainMorpion, "Joueur 1", 'X');
                        _joueur2 = UsineJoueur.CréerJoueur(TypeJoueur.OrdinateurMorpion, "IA", '0');
                        return new Morpion(consoleUtilisateur , _joueur1, _joueur2);
                    case ConsoleKey.Z:
                        _joueur1 = UsineJoueur.CréerJoueur(TypeJoueur.HumainPuissance4, "Joueur 1", 'X');
                        _joueur2 = UsineJoueur.CréerJoueur(TypeJoueur.OrdinateurPuissance4, "IA", '0');
                        return new PuissanceQuatre(consoleUtilisateur , _joueur1, _joueur2);
                    default:
                        consoleUtilisateur.afficherMessage("Choix invalide. Veuillez choisir [X] ,[P] , [Y] , [Z].");
                        continue;
                }
            }
        }
    }
}
