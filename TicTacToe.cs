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

        public int CheckForWin()
        {
            bool GAME_STATUS = HorizontalWin(0) || HorizontalWin(1) || HorizontalWin(2) || VeticalWin(0) || VeticalWin(1) || VeticalWin(2) || DiagonalWin();
            if (GAME_STATUS)
            { 
                return 1;
            }
            else if (IsDraw())
            {
                return 2;
            }
                return -1;
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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.Write("                                        ");
                for (int j = 0; j < 3; j++)
                {
                    
                    Console.Write(TictactoeArr[i, j] + "            ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
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
            if (availablePlaces[place] == -1 || place < 0 || place > 8)
            {
                Console.WriteLine("You entered Invalid Place");
                return false;
            }

            availablePlaces[place] = -1;
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


        private bool HorizontalWin(int row)
        {
            if(TictactoeArr[row,0] == TictactoeArr[row, 1] && TictactoeArr[row, 1] == TictactoeArr[row, 2] && !TictactoeArr[row, 0].Equals("-"))
            {
                return true;
            }
            return false;
        }
        private bool VeticalWin(int column)
        {
            if (TictactoeArr[0, column] == TictactoeArr[1, column] && TictactoeArr[1, column] == TictactoeArr[2, column] && !TictactoeArr[0, column].Equals("-"))
            {
                return true;
            }
            return false;
        }
        private bool DiagonalWin()
        {
            if(TictactoeArr[0,0]== TictactoeArr[1, 1] && TictactoeArr[1, 1]== TictactoeArr[2, 2] && !TictactoeArr[0, 0].Equals("-"))
            {
                return true;
            }
            else if (TictactoeArr[0, 2] == TictactoeArr[1, 1] && TictactoeArr[1, 1] == TictactoeArr[2, 0] && !TictactoeArr[1, 1].Equals("-"))
            {
                return true;
            }
            return false;
        }

        private bool IsDraw()
        {
            return IsAnyPlaceAvailable();
        }
        public bool IsAnyPlaceAvailable()
        {
            int counter = 0;
            foreach (int place in availablePlaces)
            {
                if (place == -1)
                {
                    counter++;
                }
            }
            if (counter == 9)
            {
                return true;
            }
            return false;
        }
    }
}
