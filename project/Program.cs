using System;

namespace project 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            int playerValue = 0;
            bool isInputValid = false;

            // Rakenne pelikentälle
            string [,] gameBoard = 
            {
                {"|","-","-","-","-","-","-","-","-","|"},
                {"|","-","-","-","-","-","-","-","-","|"},
                {"|","-","-","-","-","-","-","-","-","|"},
                {"|","-","-","-","-","-","-","-","-","|"},
                {"|","-","-","-","-","-","-","-","-","|"},
                {"|","-","-","-","-","-","-","-","-","|"},
                {"|","-","-","-","-","-","-","-","-","|"},
                {"+","~","~","~","~","~","~","~","~","+"}
            };

            draw();

            // pää looppi, kysyy rivinumeroa jolle pelaaja haluaa pelata vuoronsa. todo: while loopilla mielummin?
            for(int i = 0; i < 100; i++)
            {
                // katsotaan onko input täydellinen
                do 
                {
                    isInputValid = false;

                    if (i % 2 == 0) 
                    {
                        Console.Write("player o: ");
                    }
                    else 
                    {
                        Console.Write("player x: ");
                    }

                    string userInput = Console.ReadLine();
                    if (userInput == "reset") 
                    {
                        clearBoard();
                        continue;
                    }

                    if (!int.TryParse(userInput, out playerValue))
                    {
                        Console.WriteLine("Not a number between 1-8!");
                        isInputValid = false;
                    }
                    else if(int.TryParse(userInput, out playerValue)) 
                    {
                        if (playerValue < 1 || playerValue > 8)
                        {
                            Console.WriteLine("Please enter a number between 1-8!");
                        }
                        else if (playerValue > 0 && playerValue < 9 && isRowValid(playerValue))
                        {
                            isInputValid = true;
                        }
                        else 
                        {
                            Console.WriteLine("This row is already full, select another one!");
                        }

                    }
                }
                while (isInputValid == false);


                // laitetaan pelaajan merkki oikeaan kohtaan, katsotaan alin rivi ekana
                for (int j = 6; j >= 0; j--) 
                {
                    if (gameBoard[j, playerValue] == "-") 
                    {
                        if (i % 2 == 0)
                        {
                            gameBoard[j, playerValue] = "o";
                            draw();
                            checkWin("o");
                            break;
                        }
                        else 
                        {   
                            gameBoard[j, playerValue] = "x";
                            draw();
                            checkWin("x");
                            break;
                        }
                    }
                }

                if(i == 55) 
                {
                    Console.WriteLine("It's a tie!");
                    Environment.Exit(1);
                }
            }


            // funktio joka piirtää pelikentän
            void draw() 
            {
                Console.WriteLine(" 12345678 ");
                for(int l = 0; l < 8; l++)
                {
                    for(int m = 0; m < 10; m++) 
                    {
                        Console.Write(gameBoard[l, m]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(" 12345678 ");
                Console.WriteLine("-------------------");
            }

            // funktio joka tarkastaa onko voittajaa
            void checkWin(string turn) 
            {
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 1; j < 9; j++) 
                    {
                        if(turn == "o")
                        {
                            if (gameBoard[i, j] == "o") 
                            {
                                // tarkistaa onko vaakasuunnassa voittoa
                                if (gameBoard[i, j + 1] == "o" && gameBoard[i, j + 2] == "o" && gameBoard[i, j + 3] == "o") 
                                {
                                    draw();
                                    Console.WriteLine("o wins!");
                                    Environment.Exit(1);
                                }

                                // tarkistaa onko pystysuunnassa voittoa
                                if(gameBoard [i + 1, j] == "o" && gameBoard[i + 2, j] == "o" && gameBoard[i + 3, j] == "o")
                                {
                                    draw();
                                    Console.WriteLine("o wins!");
                                    Environment.Exit(1);
                                }

                                // tarkistaa onko viistosuunnassa oikealle voittoa
                                if(gameBoard [i + 1, j + 1] == "o" && gameBoard[i + 2, j + 2] == "o" && gameBoard[i + 3, j + 3] == "o") 
                                {
                                    draw();
                                    Console.WriteLine("o wins!");
                                    Environment.Exit(1);
                                }

                                // tarkistaa onko viistosuunnassa vasemmalle voittoa
                                if (gameBoard [i + 1, j - 1] == "o" && gameBoard[i + 2, j - 2] == "o" && gameBoard[i + 3, j - 3] == "o")
                                {
                                    draw();
                                    Console.WriteLine("o wins!");
                                    Environment.Exit(1);
                                }
                            }
                        }
                        else if(turn == "x")
                        {
                            if (gameBoard[i, j] == "x") 
                            {
                                // tarkistaa onko vaakasuunnassa voittoa
                                if (gameBoard[i, j + 1] == "x" && gameBoard[i, j + 2] == "x" && gameBoard[i, j + 3] == "x") 
                                {
                                    draw();
                                    Console.WriteLine("x wins!");
                                    Environment.Exit(1);
                                }

                                // tarkistaa onko pystysuunnassa voittoa
                                if(gameBoard [i + 1, j] == "x" && gameBoard[i + 2, j] == "x" && gameBoard[i + 3, j] == "x")
                                {
                                    draw();
                                    Console.WriteLine("x wins!");
                                    Environment.Exit(1);
                                }

                                // tarkistaa onko viistosuunnassa oikealle voittoa
                                if(gameBoard [i + 1, j + 1] == "x" && gameBoard[i + 2, j + 2] == "x" && gameBoard[i + 3, j + 3] == "x") 
                                {
                                    draw();
                                    Console.WriteLine("x wins!");
                                    Environment.Exit(1);
                                }

                                // tarkistaa onko viistosuunnassa vasemmalle voittoa
                                if (gameBoard [i + 1, j - 1] == "x" && gameBoard[i + 2, j - 2] == "x" && gameBoard[i + 3, j - 3] == "x")
                                {
                                    draw();
                                    Console.WriteLine("x wins!");
                                    Environment.Exit(1);
                                }
                            }

                        }
                    }
                }
            }

            // katsotaan onko ylimmän rivin columnissa tilaa
            bool isRowValid(int column)
            {
                bool isValid = false;
                
                if(gameBoard[0, column] == "-") 
                {
                    isValid = true;
                }
                else if (gameBoard[0, column] == "o" || gameBoard[0, column] == "x") 
                {
                    isValid = false;
                }

                return isValid;
            }

            // tyhjentää pelialustan
            void clearBoard() 
            {
                for(int row = 0; row < 7; row++) 
                {
                    for (int col = 0; col < 9; col++) 
                    {
                        if (gameBoard[row, col] == "x" || gameBoard[row, col] == "o") 
                        {
                            gameBoard[row, col] = "-";
                            draw();
                        }
                    }
                }
            }
            
        }
    }
}
