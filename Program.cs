using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose Option :\n1. New Game\n2. Quit");
                
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Clear();
                    if (choice == 1)
                    {
                        TicTacToe ticTacToe = new TicTacToe();
                        Console.WriteLine("Player 1 choose your character. Press x / o ::");
                        string playerOneCharacter = Console.ReadLine();
                        bool isGameSet = ticTacToe.SetPlayerCharacters(playerOneCharacter);
                        if (isGameSet)
                        {
                            bool IsADraw = true;
                            int currentGameStatus = -1;
                            while (currentGameStatus == -1)
                            {
                                Console.Clear();
                                ticTacToe.ShowCurrentGame();
                                Console.WriteLine("==========================================================================================");
                                Console.WriteLine("Player 1 - Enter where you want to place the character. ");
                                Console.Write("Avaiable Places =>  ");
                                ticTacToe.ShowAvaiblePlaces();

                                int place;
                                if (int.TryParse( Console.ReadLine(),out place))
                                {
                                    if (ticTacToe.SetCharInPlace(place-1, ticTacToe.PlayerOneCharacter))
                                    {
                                        Console.Clear();
                                        if (ticTacToe.CheckForWin() == 1)
                                        {
                                            Console.WriteLine("Player 1 Wins. Press Enter to continue.");
                                            Console.ReadLine();
                                            IsADraw = false;
                                            break;

                                        }
                                        ticTacToe.ShowCurrentGame();
                                        while (true && !ticTacToe.IsAnyPlaceAvailable())
                                        {
                                            Console.WriteLine("==========================================================================================");
                                            Console.WriteLine("Player 2 - Enter where you want to place the character. ");
                                            Console.Write("Avaiable Places =>  ");
                                            ticTacToe.ShowAvaiblePlaces();
                                            if (int.TryParse(Console.ReadLine(), out place))
                                            {
                                                if (ticTacToe.SetCharInPlace(place - 1, ticTacToe.PlayerTwoCharacter))
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Place was entered. Try again");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid Place was entered");
                                            }
                                        }
                                        if (ticTacToe.CheckForWin()== 1)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Player 2 Wins. Press Enter to continue.");
                                            Console.ReadLine();
                                            IsADraw = false;
                                            break;
                                        }


                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Place was entered");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Place was entered");
                                }
                                //Last Line
                                currentGameStatus = ticTacToe.CheckForWin();
                            }
                            if (IsADraw)
                            {
                                Console.WriteLine("Game Drawn. Press Enter to continue..");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Character choosen x_x");
                        }

                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Thank you for playing.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Press Enter to continue..");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Press Enter to continue..");
                    Console.ReadKey();
                    

                }
            }
        }
    }
}
