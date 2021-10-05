using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        private string[,] TictactoeArr;
        private int[] availablePlaces;           

        public string PlayerOneCharacter { get; set; }
        public string PlayerTwoCharacter { get; set; }

        public TicTacToe()
        {
            this.TictactoeArr = new string[3, 3] {
                { "-", "-", "-" },
                { "-", "-", "-" },
                { "-", "-", "-" }
            };
            availablePlaces = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        public string CheckForWin()
        {
            if (false)
            {
                // TODO: Implement the logic here
                return "PLA";
            }
                return "PLAYING";
        }

        internal bool SetPlayerCharacters(string playerOneCharacter)
        {
            playerOneCharacter = playerOneCharacter.ToLower();
            if (playerOneCharacter.Equals("x"))
            {
                PlayerOneCharacter = "x";
                PlayerTwoCharacter = "o";
                return true;

            }
            else if (playerOneCharacter.Equals("o"))
            {
                PlayerOneCharacter = "o";
                PlayerTwoCharacter = "x";
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void ShowCurrentGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(TictactoeArr[i, j] + "    ");
                }
                Console.WriteLine();
            }
        }

        private int[] GetAvaiablePlaces()
        {
            return availablePlaces;
        }

        public void ShowAvaiblePlaces()
        {
            Console.Write("[  ");
            foreach (int avlPlace in GetAvaiablePlaces())
            {
                if (avlPlace != -1)
                {
                    Console.Write( avlPlace + "  ");
                }
            }
            Console.Write("]");
            Console.WriteLine();
        }

        public bool SetCharInPlace(int place, string PlayerCharacter)
        {
            if (place == -1 || place < 0 || place > 8)
            {
                Console.WriteLine("You entered Invalid Place");
                return false;
            }
            availablePlaces[place] = -1;
            // TODO :IMPLEMENT LOGIC FOR setting char
            if(place >=0 && place <=2)
            {
                TictactoeArr[0, place] = PlayerCharacter;
            }
            else if (place >= 3 && place <= 5)
            {
                TictactoeArr[1, place-3] = PlayerCharacter;
            }
            else
            {
                TictactoeArr[2, place-6] = PlayerCharacter;
            }
                return true;
        }

    }
}
