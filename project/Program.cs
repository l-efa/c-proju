using System;

namespace project
{
    class Program
    {
        static int i = 0;

        // Rakenne pelikentälle
        static string[,] gameBoard =
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
        static void Main(string[] args)
        {
            int playerValue = 0;
            bool isInputValid = false;

            //Console.WriteLine(gameBoard);

            draw();

            // pää looppi, kysyy rivinumeroa jolle pelaaja haluaa pelata vuoronsa. todo: while loopilla mielummin?
            for (i = 0; i < 100; i++)
            {
                // katsotaan onko input täydellinen (input virheen esto)
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
                        i = 0;
                        continue;
                    }

                    if (!int.TryParse(userInput, out playerValue))
                    {
                        Console.WriteLine("Not a number between 1-8!");
                        isInputValid = false;
                    }
                    else if (int.TryParse(userInput, out playerValue))
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


                // laitetaan pelaajan merkki oikeaan kohtaan

                for (int j = 0; j < 7; j++)
                {
                    if (gameBoard[j, playerValue] == "-")
                    {
                        if (i % 2 == 0)
                        {
                            dropPiece(playerValue, i, j, "o");
                        }
                        else
                        {
                            dropPiece(playerValue, i, j, "x");
                        }
                    }
                }
            }

            if (i == 55)
            {
                Console.WriteLine("It's a tie!");
                Environment.Exit(1);
            }
        }


        // funktio joka piirtää pelikentän
        static void draw()
        {
            Console.WriteLine(" 12345678 ");
            for (int l = 0; l < 8; l++)
            {
                for (int m = 0; m < 10; m++)
                {
                    Console.Write(gameBoard[l, m]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(" 12345678 ");
            Console.WriteLine("-------------------");
        }


        // katsotaan onko ylimmän rivin columnissa tilaa
        static bool isRowValid(int column)
        {
            bool isValid = false;

            if (gameBoard[0, column] == "-")
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
        static void clearBoard()
        {
            for (int row = 0; row < 7; row++)
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

        // laitetaan pelinappula oikeeseen paikkaan
        static void dropPiece(int playerValue, int i, int j, string player)
        {
            gameBoard[j, playerValue] = player;
            draw();
            if (gameBoard[j + 1, playerValue] == "-")
            {
                gameBoard[j, playerValue] = "-";
                System.Threading.Thread.Sleep(300);
            }
            checkWin(player);
        }

        // katsotaan onko voittajaa
        static void checkWin(string player)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (gameBoard[i, j] == player)
                    {
                        // tarkistaa onko vaakasuunnassa voittoa
                        if (gameBoard[i, j + 1] == player && gameBoard[i, j + 2] == player && gameBoard[i, j + 3] == player)
                        {
                            draw();
                            Console.WriteLine($"{player} wins!");
                            Environment.Exit(1);
                        }

                        // tarkistaa onko pystysuunnassa voittoa
                        if (gameBoard[i + 1, j] == player && gameBoard[i + 2, j] == player && gameBoard[i + 3, j] == player)
                        {
                            draw();
                            Console.WriteLine($"{player} wins!");
                            Environment.Exit(1);
                        }

                        // tarkistaa onko viistosuunnassa oikealle voittoa
                        if (gameBoard[i + 1, j + 1] == player && gameBoard[i + 2, j + 2] == player && gameBoard[i + 3, j + 3] == player)
                        {
                            draw();
                            Console.WriteLine($"{player} wins!");
                            Environment.Exit(1);
                        }

                        // tarkistaa onko viistosuunnassa vasemmalle voittoa
                        if (gameBoard[i + 1, j - 1] == player && gameBoard[i + 2, j - 2] == player && gameBoard[i + 3, j - 3] == player)
                        {
                            draw();
                            Console.WriteLine($"{player} wins!");
                            Environment.Exit(1);
                        }
                    }
                }
            }
        }
    }
}