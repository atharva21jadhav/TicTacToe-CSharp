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
                            string currentGameStatus = "PLAYING";
                            while (currentGameStatus.Equals("PLAYING") )
                            {
                                ticTacToe.ShowCurrentGame();
                                Console.WriteLine("====================================");
                                Console.WriteLine("Player 1 - Enter where you want to place the character. ");
                                Console.Write("Avaiable Places =>  ");
                                ticTacToe.ShowAvaiblePlaces();

                                int place;
                                if (int.TryParse( Console.ReadLine(),out place))
                                {
                                    if (ticTacToe.SetCharInPlace(place))
                                    {
                                        Console.WriteLine("Player 2 - Enter where you want to place the character. ");
                                        Console.Write("Avaiable Places =>  ");
                                        ticTacToe.ShowAvaiblePlaces();
                                        if (int.TryParse(Console.ReadLine(), out place))
                                        {
                                            if (ticTacToe.SetCharInPlace(place))
                                            {
                                                continue;
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
