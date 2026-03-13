using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace trisdombra
{
    internal class Program
    {
        static void scacchiera(string[,] scac)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int z = 0; z < 3; z++)
                {
                    Console.Write($"{scac[i, z].ToString()} ");
                }
                Console.WriteLine();
            }
        }
        static void RiceviGiocata(string player, int riga, int colon, string[,] scac)
        {
            int p = 0;
            do
            {
                Console.WriteLine($"{player} inserisci riga: ");
                riga = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine($"{player} inserisci colonna: ");
                colon = Convert.ToInt16(Console.ReadLine());
                if (riga < 3 && colon < 3 && scac[riga, colon] == "_")
                {
                    scac[riga, colon] = player;
                    p = 1;
                }
                else
                {
                    Console.WriteLine("Errore, giocata non valida");
                }
            } while (p == 0);
        }

        static int Vincente(string[,] scac, string player)
        {
            int q = 0;
            if (player == "X")
                q = 1;
            else
                q = 2;
            if (scac[0,0] != "_" && scac[0, 0] == scac[0, 1] && scac[0, 1] == scac[0, 2])
                return q;
            if (scac[1, 0] != "_" && scac[1, 0] == scac[1, 1] && scac[1, 1] == scac[1, 2])
                return q;
            if (scac[2, 0] != "_" && scac[2, 0] == scac[2, 1] && scac[2, 1] == scac[2, 2])
                return q;
            if (scac[0, 0] != "_" && scac[0, 0] == scac[1, 0] && scac[1, 0] == scac[2, 0])
                return q;
            if (scac[0, 0] != "_" && scac[0, 0] == scac[1, 1] && scac[1, 1] == scac[2, 1])
                return q;
            if (scac[0, 2] != "_" && scac[0, 2] == scac[1, 2] && scac[1, 2] == scac[2, 2])
                return q;
            if (scac[0, 0] != "_" && scac[0, 0] == scac[1, 1] && scac[1, 1] == scac[2, 2])
                return q;
            if (scac[0, 2] != "_" && scac[0, 2] == scac[1, 1] && scac[1, 1] == scac[2, 0])
                return q;
            return 0;
        }

        static void Main(string[] args)
        {
            string[,] tris = {
            { "_", "_", "_" },
            { "_", "_", "_" },
            { "_", "_", "_" }
        };

            scacchiera(tris);
            string player = "X";
            int r = 0, c = 0;
            int winner = 0;
            do
            {
                RiceviGiocata(player, r, c, tris);
                Console.WriteLine();
                scacchiera(tris);
                winner = Vincente(tris, player);
                if (player == "X")
                    player = "O";
                else
                    player = "X";
            } while (winner == 0);
            if (winner == 1)
                player = "X";
            else
                player = "O";
            Console.WriteLine($"{player} e il vincitore!");
            return;
        }
    }
}