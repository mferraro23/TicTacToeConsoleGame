using System;

namespace TicTacToeConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            beginGame();            
        }
        public static void beginGame()
        {
            string[,] gameBoard =
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };
            int turn = 1;
            generateBoard(gameBoard, turn);
        }        
        public static void generateBoard(string[,] gameBoard, int turn)
        {
            // Create the board
            Console.Clear();
            Console.WriteLine("|        |        |        |");
            Console.WriteLine($"|    {gameBoard[0, 0]}   |    {gameBoard[0, 1]}   |    {gameBoard[0,2]}   |");
            Console.WriteLine("|        |        |        |");
            Console.WriteLine("----------------------------");
            Console.WriteLine("|        |        |        |");
            Console.WriteLine($"|    {gameBoard[1, 0]}   |    {gameBoard[1, 1]}   |    {gameBoard[1, 2]}   |");
            Console.WriteLine("|        |        |        |");
            Console.WriteLine("----------------------------");
            Console.WriteLine("|        |        |        |");
            Console.WriteLine($"|    {gameBoard[2, 0]}   |    {gameBoard[2, 1]}   |    {gameBoard[2, 2]}   |");
            Console.WriteLine("|        |        |        |");

            // Decide which player is up using the current turn
            int playerNum = (turn%2==0)?2:1;
            Console.WriteLine($"\nTurn {turn}!\nPlayer {playerNum} go!");
            Console.WriteLine("Enter an number from the available spaces!");

            // Decide if a valid choice was made
            bool validChoice = false;
            int choice = 0;
            while (!validChoice)
            {                
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    for (int i = 0; i < gameBoard.GetLength(0); i++)
                    {
                        for (int j = 0; j < gameBoard.GetLength(1); j++)
                        {
                            if (gameBoard[i, j] == choice.ToString())
                            {
                                validChoice = true;
                            }                            
                        }
                    }                    
                }
                catch (Exception) { Console.WriteLine("Invalid Choice!\nEnter an number from the available spaces!"); }                
            }
            runGame(gameBoard, choice, turn);
        }

        // Correctly place X or O into the input matrix 
        public static void runGame(string[,] gameBoard, int choice, int turn)
        {
            string playerVal = (turn % 2 == 0) ? "O" : "X";
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == choice.ToString())
                    {
                        gameBoard[i, j] = playerVal;
                    }
                }
            }
            bool isGameOver = checkWinner(gameBoard, turn);
            if (isGameOver)
            {
                Console.WriteLine("Do you want to play again?\nEnter yes or no...");

                bool isValidAnswer = false;
                string answer = "";
                while (!isValidAnswer)
                {
                    answer = Console.ReadLine().ToLower();
                    if (answer == "yes" || answer == "no")
                    {
                        isValidAnswer = true;
                    }
                }
                if (answer == "yes")
                {
                    beginGame();
                }
                else { Console.WriteLine("Thanks for playing!"); }
            }
            else
            {
                turn++;
                generateBoard(gameBoard, turn);
            }
        }

        // Check if game is over
        public static bool checkWinner(string[,] gameBoard, int turn)
        {
            int playerNum = (turn%2==0)?2:1;
            // Horizontal checks
            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2])
                {
                    Console.WriteLine($"Player {playerNum} wins!");
                    return true;
                }
            }
            // Vertical checks
            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[0, i] == gameBoard[1, i] && gameBoard[1, i] == gameBoard[2, i])
                {
                    Console.WriteLine($"Player {playerNum} wins!");
                    return true;
                }
            }
            // Diagonal checks
            if (gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2])
            {
                Console.WriteLine($"Player {playerNum} wins!");
                return true;
            }
            else { return false; }            
        }
    }
}