using System;
using static System.Console;
using System.IO;
namespace Gomoku
{
    class Gomoku
    {
        static void Main(string[] args)
        {
            WriteLine("##################");
            WriteLine("Welcome to Gomoku!");
            WriteLine("##################\n");
            Write("Press H for Help or S to start a game >> ");

            bool sGame = true;
            string menuAnswer = ReadLine();
            while (sGame)
            {
                if (menuAnswer == "H" || menuAnswer == "h")
                {
                    sGame = false;
                    Menu();

                }

                else if (menuAnswer == "S" || menuAnswer == "s")
                {
                    sGame = false;
                    Gametype();
                }
                else
                {
                    Clear();
                    Write("Press H for Help or S to start a game >> ");
                    menuAnswer = ReadLine();
                }
            }


        }
        public static void Gametype()
        {
            Clear();
            Write("Press H for P1 v P2 or C for P1 v CPU >> ");
            string input = ReadLine();
            GameMode(input);
        }
        public static void GameMode(string input)
        {
            Clear();
            while (!(input == "H" || input == "h" || input == "c" || input == "C"))
            {
                Write("Press H for P1 v P2 or C for P1 v CPU >> ");
                input = ReadLine();
            }
            if (input == "H" || input == "h")
            {
                Mode.HumanVHuman();
            }
            else if (input == "C" || input == "c")
            {
                Mode.HumanVComputer();
            }
        }
        public static void Start(string menuAnswer)
        {

            bool sGame = true;

            while (sGame)
            {
                if (menuAnswer == "H" || menuAnswer == "h")
                {
                    Menu();
                    sGame = false;
                }

                else if (menuAnswer == "S" || menuAnswer == "s")
                {
                    sGame = false;
                }
                else
                {
                    Write("Press H for Help or S to start a game >> ");
                    menuAnswer = ReadLine();
                }
            }
        }

        public static void Menu()
        {
            Clear();
            WriteLine("######## Instructions ######");
            WriteLine();
            WriteLine("When a game has been started, the user will be asked one of two options; To start a Human V Human game or a Human V CPU game.\n" +
                "When the user decided on the game mode choice, they will be re-directed to choose a saved game or start a new game.\n");
            WriteLine();
            createBoard();
            WriteLine();
            WriteLine("\nWhen a new game is started, the board will be initialized with a 10 x 10 board of where labelled from 0 to 99\n"
                + "Saved games will be initialized the move history of the last played game.\n");
            WriteLine("\nWhen playing the game, Player 1 will go first and will chose a spot to place “X” on the board by entering the number on the board." +
                "\nSimilarly, Player 2 will do the same however their move will be an “O” instead. Each move will be placed in the move history and will be updated accordingly\n");
            WriteLine("Each player also can save and/or quit the game in each turn using “S” and “Q” respectively. This also applied to the Human V CPU games as well.\n");
            WriteLine("When playing a Human V CPU game, The CPU will choose a random valid move. Like with Human V Human games, each move will be placed in the move history\n and will be updated accordingly.\n");
            WriteLine();
            string [] moveHistory = Game.Open();
            openBoard(moveHistory);
            WriteLine();
            WriteLine("When a user gets 5 (X’s or O’s) in a row to win the game. When this occurs, the game will display the which player was the winner and end the game.\nIf the board is full and there is no winner, the game will be declared a draw and the game will end. ");
            WriteLine();
            Write("Press and key to start a new game >> ");
            string answer = ReadLine();
            Gametype();
        }

        public static void createBoard()
        {
            string[] board = new string[100];
            /* initialize elements of array n */
            for (int j = 0; j < 100; j++)
            {
                board[j] = Convert.ToString(j);
            }

            int i = 0;
            for (int j = 1; j < 10; j++)
            {
                if (i == 0)
                {
                    Console.WriteLine("    {0}   |    {1}   |    {2}   |    {3}   |    {4}   |    {5}   |    {6}   |    {7}   |    {8}   |    {9}   |", board[0 + i], board[1 + i], board[2 + i], board[3 + i], board[4 + i], board[5 + i], board[6 + i], board[7 + i], board[8 + i], board[9 + i]);
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                }
                i = i + 10;
                Console.WriteLine("   {0}   |   {1}   |   {2}   |   {3}   |   {4}   |   {5}   |   {6}   |   {7}   |   {8}   |   {9}   |", board[0 + i], board[1 + i], board[2 + i], board[3 + i], board[4 + i], board[5 + i], board[6 + i], board[7 + i], board[8 + i], board[9 + i]);
                Console.WriteLine("-----------------------------------------------------------------------------------------");

            }

        }
        public static void updateBoard(int number, int turn, string[] moveHistory)
        {
            Clear();
            string[] board = new string[100];

            /* initialize elements of array n */
            for (int j = 0; j < 100; j++)
            {
                board[j] = moveHistory[j];
            }
            int i = 0;
            if (number >= 10 && turn == 1)
            {
                board[number] = " X";
            }
            else if (turn == 1)
            {
                board[number] = "X";
            }

            if (number >= 10 && turn == 2)
            {
                board[number] = " O";
            }
            else if (turn == 2)
            {
                board[number] = "O";
            }

            for (int j = 1; j < 10; j++)
            {
                if (i == 0)
                {
                    Console.WriteLine("    {0}   |    {1}   |    {2}   |    {3}   |    {4}   |    {5}   |    {6}   |    {7}   |    {8}   |    {9}   |", board[0 + i], board[1 + i], board[2 + i], board[3 + i], board[4 + i], board[5 + i], board[6 + i], board[7 + i], board[8 + i], board[9 + i]);
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                }
                i = i + 10;
                Console.WriteLine("   {0}   |   {1}   |   {2}   |   {3}   |   {4}   |   {5}   |   {6}   |   {7}   |   {8}   |   {9}   |", board[0 + i], board[1 + i], board[2 + i], board[3 + i], board[4 + i], board[5 + i], board[6 + i], board[7 + i], board[8 + i], board[9 + i]);
                Console.WriteLine("-----------------------------------------------------------------------------------------");

            }

        }
        public static bool isMoveValid(string input, string[] moveHistory)
        {

            bool range = true;
            while (range)
            {
                int num = 0;
                bool success = Int32.TryParse(input, out num);

                if (success)
                {
                    if (num > 99 || num < 0)
                    {
                        return false;
                    }
                    else
                    {
                        //scuessful 
                        range = false;

                    }

                }
                else
                {
                    return false;
                }
            }

            bool repeat = true;
            while (repeat)
            {
                if ("X" == moveHistory[Convert.ToInt32(input)] || "O" == moveHistory[Convert.ToInt32(input)])
                {
                    return false;
                }
                else
                {
                    repeat = false;
                }

            }

            return true;

        }

        public static bool isRandomMoveValid(string number, string[] moveHistory)
        {
            if ("X" == moveHistory[Convert.ToInt32(number)] || "O" == moveHistory[Convert.ToInt32(number)])
            {
                return false;
            }
            return true;
        }

        public static void openBoard(string[] moveHistory)
        {
            //Updating Board 
            Clear();
            string[] board = new string[100];
            for (int j = 0; j < 100; j++)
            {
                board[j] = moveHistory[j];
            }
            int i = 0;

            for (int j = 1; j < 10; j++)
            {
                if (i == 0)
                {
                    Console.WriteLine("    {0}   |    {1}   |    {2}   |    {3}   |    {4}   |    {5}   |    {6}   |    {7}   |    {8}   |    {9}   |", board[0 + i], board[1 + i], board[2 + i], board[3 + i], board[4 + i], board[5 + i], board[6 + i], board[7 + i], board[8 + i], board[9 + i]);
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                }
                i = i + 10;
                Console.WriteLine("   {0}   |   {1}   |   {2}   |   {3}   |   {4}   |   {5}   |   {6}   |   {7}   |   {8}   |   {9}   |", board[0 + i], board[1 + i], board[2 + i], board[3 + i], board[4 + i], board[5 + i], board[6 + i], board[7 + i], board[8 + i], board[9 + i]);
                Console.WriteLine("-----------------------------------------------------------------------------------------");

            }
        }

        public static string randomise()
        {
            Random random = new Random();
            string rand = Convert.ToString(random.Next(1, 100));
            return rand;
        }

        public static string CheckWinner(string[] moveHistory)
        {
            int ffXCount = 0;
            int flXCount = 0;
            int ffXCCount = 0;
            int flXCCount = 0;

            int ffOCount = 0;
            int flOCount = 0;
            int ffOCCount = 0;
            int flOCCount = 0;
            string winner = "";

            int k = 0;
            //Checking first 5 rows
            for (int j = 0; j < 10; j++)
            {

                for (int i = 0; i < 5; i++)
                {

                    if (moveHistory[i + k] == "X")
                    {
                        ffXCount++;
                    }
                    else if (moveHistory[i + k] == "O")
                    {
                        ffOCount++;
                    }
                }
                if (ffXCount == 5)
                {
                    winner = "1";
                }
                else if (ffOCount == 5)
                {
                    winner = "2";
                }
                else
                {
                    ffXCount = 0;
                    ffOCount = 0;
                }
                k = k + 10;

            }

            //Checking last 5 rows
            int w = 0;
            for (int j = 0; j < 10; j++)
            {

                for (int i = 5; i < 10; i++)
                {

                    if (moveHistory[i + w] == "X")
                    {
                        flXCount++;
                    }
                    else if (moveHistory[i + w] == "O")
                    {
                        flOCount++;
                    }
                }
                if (flXCount == 5)
                {
                    winner = "1";
                }
                else if (flOCount == 5)
                {
                    winner = "2";
                }
                else
                {
                    flXCount = 0;
                    flOCount = 0;
                }
                w = w + 10;

            }


            //Checking first 5 colums
            for (int j = 0; j < 5; j++)
            {

                for (int i = 0; i < 100; i += 10)
                {

                    if (moveHistory[i + j] == "X")
                    {
                        ffXCCount++;
                    }

                    else if (moveHistory[i + j] == "O")
                    {
                        ffOCCount++;

                    }
                }
                if (ffXCCount == 5)
                {
                    winner = "1";
                }
                else if (ffOCCount == 5)
                {
                    winner = "2";
                }
                else
                {
                    ffXCCount = 0;
                    ffOCCount = 0;
                }


            }

            //Checking last 5 colums
            for (int j = 5; j < 10; j++)
            {

                for (int i = 0; i < 100; i += 10)
                {

                    if (moveHistory[i + j] == "X")
                    {
                        flXCCount++;
                    }

                    else if (moveHistory[i + j] == "O")
                    {
                        flOCCount++;

                    }
                }
                if (flXCCount == 5)
                {
                    winner = "1";
                }
                else if (flOCCount == 5)
                {
                    winner = "2";
                }
                else
                {
                    flXCCount = 0;
                    flOCCount = 0;
                }

            }
            return winner;
        }


        class Player
        { }// class ends

        class Human : Player
        { }// class ends

        class CPU : Player
        { }// class ends

        class Mode
        {
            public static void HumanVHuman()
            {
          
                Clear();

                //Init Board
                string[] moveHistory = new string[100];
                int gameMovesLeft = 0;

                //Gametype 
                bool gameTypeAnswer = false;
                //1st moves 
                bool p1firstMove = true;
                bool p2firstMove = true;
                Write("Press 'O' to open a saved game or 'N' to start a new game >> ");
                string gameType = ReadLine();
                Clear();
                while (!gameTypeAnswer)
                {
                    if (gameType == "o" || gameType == "O")
                    {
                        gameTypeAnswer = true;

                        moveHistory = Game.Open();
                        openBoard(moveHistory);
                        for (int i = 0; i < moveHistory.Length; i++)
                        {
                            if (!(moveHistory[i] == "O" || moveHistory[i] == "X"))
                            {
                                ++gameMovesLeft;
                            }
                        }

                    }
                    else if (gameType == "n" || gameType == "N")
                    {
                        gameTypeAnswer = true;
                        gameMovesLeft = 100;
                        //Initializing New Board
                        for (int i = 0; i < 100; i++)
                        {
                            moveHistory[i] = Convert.ToString(i);
                        }
                        createBoard();

                    }
                    else
                    {
                        Write("Press 'O' to open a saved game or 'N' to start a new game >> ");
                        gameType = ReadLine();
                    }
                }


                //Creating Player objects
                Human player1 = new Human();
                Human player2 = new Human();

                //Setting default player
                int turn = 1;
                bool gameWon = false;
                string check = "";
                string lastp1move = "";
                string lastp2move = "";
                bool candoRedo2 = false;

             
                bool canRedo = false;


                while (!gameWon)
                {
                    if (turn == 1)
                    {

                        WriteLine("Player 1's Turn.");
                        Write("Enter a valid number between 0 and 99 or 'S' to Save, 'U' to undo, 'R' to Redo or 'Q' to Quit >>: ");
                        string p1Move = ReadLine();
                        //Undo Move
                        if (p1Move == "S" || p1Move == "s")
                        {
                            Game.Save(moveHistory);
                        }
                        else if (p1Move == "Q" || p1Move == "q")
                        {
                            gameWon = true;
                        }
                        else if ((p1Move == "U" && p1firstMove == false) || (p1Move == "u" && p1firstMove == false))
                        {

                            Move.Undo(lastp1move, moveHistory);
                            canRedo = true;
                            turn = 2;
                        }
                        else if (p1Move == "R" || p1Move == "r")
                        {
                            bool validRedo = Move.Redo(lastp1move, moveHistory, canRedo);
                            while (validRedo)
                            {
                                //Update Move History
                                moveHistory[Convert.ToInt32(lastp1move)] = "X";

                                //Update Board
                                updateBoard(Convert.ToInt32(lastp1move), 1, moveHistory);

                                //Check Winner
                                check = CheckWinner(moveHistory);

                                //Check Winner
                                if (check == "1")
                                {
                                    gameWon = true;

                                    WriteLine("Player 1 Won!");
                                }
                                else if (check == "2")
                                {
                                    gameWon = true;
                                    WriteLine("Player 2 Won!");
                                }
                                //Change Player
                                else
                                {
                                    canRedo = false;
                                    turn = 2;
                                    gameMovesLeft--;
                                    //Check if game is draw
                                    if (gameMovesLeft == 0)
                                    {
                                        gameWon = true;

                                        WriteLine("Game is a Draw!");
                                    }
                                }
                                validRedo = false;
                            }
                        }
                        else
                        {
                            bool p1valid = isMoveValid(p1Move, moveHistory);
                            while (!p1valid)
                            {
                                Write("Enter a valid number between 0 and 99 >> ");
                                p1Move = ReadLine();
                                p1valid = isMoveValid(p1Move, moveHistory);
                            }
                            //
                            if (p1valid)
                            {
                                // Saving last move 
                                lastp1move = Convert.ToString(Array.IndexOf(moveHistory, p1Move));
                                WriteLine(lastp1move);
                                //Update Move History
                                moveHistory[Convert.ToInt32(p1Move)] = "X";

                                //Update Board
                                updateBoard(Convert.ToInt32(p1Move), 1, moveHistory);

                                //Check Winner
                                check = CheckWinner(moveHistory);

                                //Removing Moves
                                gameMovesLeft--;

                                //Check if game is draw
                                if (gameMovesLeft == 0)
                                {
                                    gameWon = true;

                                    WriteLine("Game is a Draw!");
                                }

                                //Check Winner
                                if (check == "1")
                                {
                                    gameWon = true;

                                    WriteLine("Player 1 Won!");
                                }
                                else if (check == "2")
                                {
                                    gameWon = true;
                                    WriteLine("Player 2 Won!");
                                }

                                //Change Player
                                else
                                {
                                    turn = 2;
                                    p1firstMove = false;
                                }
                            }
                        }
                    }
                    if (turn == 2)
                    {
                        WriteLine("Player 2's Turn.");
                        Write("Enter a valid number between 0 and 99 or 'S' to Save, 'U' to undo, 'R' to Redo or 'Q' to Quit >>: ");
                        string p2Move = ReadLine();
                        //Undo Move
                        if (p2Move == "S" || p2Move == "s")
                        {
                            Game.Save(moveHistory);
                        }
                        else if (p2Move == "Q" || p2Move == "q")
                        {
                            gameWon = true;
                        }
                        else if ((p2Move == "U" && p2firstMove == false) || (p2Move == "u" && p2firstMove == false))
                        {

                            Move.Undo(lastp2move, moveHistory);
                            candoRedo2 = true;
                            turn = 1;
                        }
                        else if (p2Move == "R" || p2Move == "r")
                        {
                            bool validRedo = Move.Redo(lastp2move, moveHistory, candoRedo2);
                            while (validRedo)
                            {
                                //Update Move History
                                moveHistory[Convert.ToInt32(lastp2move)] = "O";

                                //Update Board
                                updateBoard(Convert.ToInt32(lastp2move), 2, moveHistory);

                                //Check Winner
                                check = CheckWinner(moveHistory);

                                //Check Winner
                                if (check == "1")
                                {
                                    gameWon = true;

                                    WriteLine("Player 1 Won!");
                                }
                                else if (check == "2")
                                {
                                    gameWon = true;
                                    WriteLine("Player 2 Won!");
                                }
                                //Change Player
                                else
                                {
                                    candoRedo2 = false;
                                    turn = 1;
                                    gameMovesLeft--;
                                    //Check if game is draw
                                    if (gameMovesLeft == 0)
                                    {
                                        gameWon = true;

                                        WriteLine("Game is a Draw!");
                                    }
                                }
                                validRedo = false;
                            }
                        }
                        else
                        {
                            bool p2valid = isMoveValid(p2Move, moveHistory);
                            while (!p2valid)
                            {
                                Write("Enter a valid number between 0 and 99 >> ");
                                p2Move = ReadLine();
                                p2valid = isMoveValid(p2Move, moveHistory);
                            }
                            //
                            if (p2valid)
                            {
                                // Saving last move 
                                lastp2move = Convert.ToString(Array.IndexOf(moveHistory, p2Move));
                                WriteLine(lastp2move);
                                //Update Move History
                                moveHistory[Convert.ToInt32(p2Move)] = "O";

                                //Update Board
                                updateBoard(Convert.ToInt32(p2Move), 2, moveHistory);

                                //Check Winner
                                check = CheckWinner(moveHistory);

                                //Removing Moves
                                gameMovesLeft--;

                                //Check if game is draw
                                if (gameMovesLeft == 0)
                                {
                                    gameWon = true;

                                    WriteLine("Game is a Draw!");
                                }

                                //Check Winner
                                if (check == "1")
                                {
                                    gameWon = true;

                                    WriteLine("Player 1 Won!");
                                }
                                else if (check == "2")
                                {
                                    gameWon = true;
                                    WriteLine("Player 2 Won!");
                                }

                                //Change Player
                                else
                                {
                                    turn = 1;
                                    p2firstMove = false;
                                }
                            }
                        }
                    }
                }
            }


            public static void HumanVComputer()
            {

                Clear();

                //Init Board
                string[] moveHistory = new string[100];
                int gameMovesLeft = 0;

                //Gametype 
                bool gameTypeAnswer = false;
                Write("Press 'O' to open a saved game or 'N' to start a new game >> ");
                string gameType = ReadLine();
                Clear();
                while (!gameTypeAnswer)
                {
                    if (gameType == "o" || gameType == "O")
                    {
                        gameTypeAnswer = true;
                        
                        moveHistory = Game.Open();
                        openBoard(moveHistory);
                        for (int i = 0; i < moveHistory.Length; i++)
                        {
                            if (!(moveHistory[i] == "O" || moveHistory[i] == "X"))
                            {
                                ++gameMovesLeft;
                            }
                        }

                    }
                    else if (gameType == "n" || gameType == "N")
                    {
                        gameTypeAnswer = true;
                        gameMovesLeft = 100;
                        //Initializing New Board
                        for (int i = 0; i < 100; i++)
                        {
                            moveHistory[i] = Convert.ToString(i);
                        }
                        createBoard();

                    }
                    else
                    {
                        Write("Press 'O' to open a saved game or 'N' to start a new game >> ");
                        gameType = ReadLine();
                    }
                }

                //Creating Player objects
                Player player1 = new Player();
                CPU player2 = new CPU();


                //Setting default player
                int turn = 1;
                bool gameWon = false;
                string check = "";
                string lastp1move = "";

                bool canRedo = false;

                //1st Move 
                bool p1firstMove = true;

                //Total Game Moves
               


                while (!gameWon)
                {

                    if (turn == 1)
                    {
                        WriteLine("Player 1's Turn.");
                        Write("Enter a valid number between 0 and 99 or 'S' to Save, 'U' to undo, 'R' to Redo or 'Q' to Quit >>: ");
                        string p1Move = ReadLine();
                        //Undo Move
                        if (p1Move == "S" || p1Move == "s")
                        {
                            Game.Save(moveHistory);
                        }
                        else if (p1Move == "Q" || p1Move == "q")
                        {
                            gameWon = true;
                        }
                        else if ((p1Move == "U" && p1firstMove == false) || (p1Move == "u" && p1firstMove == false))
                        {

                            Move.Undo(lastp1move, moveHistory);
                            canRedo = true;
                            turn = 2;
                        }
                        else if (p1Move == "R" || p1Move == "r")
                        {
                            bool validRedo = Move.Redo(lastp1move, moveHistory, canRedo);
                            while (validRedo)
                            {
                                //Update Move History
                                moveHistory[Convert.ToInt32(lastp1move)] = "X";

                                //Update Board
                                updateBoard(Convert.ToInt32(lastp1move), 1, moveHistory);

                                //Check Winner
                                check = CheckWinner(moveHistory);

                                //Check Winner
                                if (check == "1")
                                {
                                    gameWon = true;

                                    WriteLine("Player 1 Won!");
                                }
                                else if (check == "2")
                                {
                                    gameWon = true;
                                    WriteLine("Player 2 Won!");
                                }
                                //Change Player
                                else
                                {
                                    canRedo = false;
                                    turn = 2;
                                    p1firstMove = false;
                                    gameMovesLeft--;
                                    //Check if game is draw
                                    if (gameMovesLeft == 0)
                                    {
                                        gameWon = true;

                                        WriteLine("Game is a Draw!");
                                    }
                                }
                                validRedo = false;
                            }

                        }
                        else
                        {
                            bool p1valid = isMoveValid(p1Move, moveHistory);
                            while (!p1valid)
                            {
                                Write("Enter a valid number between 0 and 99 >> ");
                                p1Move = ReadLine();
                                p1valid = isMoveValid(p1Move, moveHistory);
                            }
                            //
                            if (p1valid)
                            {
                                // Saving last move 
                                lastp1move = Convert.ToString(Array.IndexOf(moveHistory, p1Move));
                                WriteLine(lastp1move);
                                //Update Move History
                                moveHistory[Convert.ToInt32(p1Move)] = "X";

                                //Update Board
                                updateBoard(Convert.ToInt32(p1Move), 1, moveHistory);

                                //Check Winner
                                check = CheckWinner(moveHistory);

                                //Removing Moves
                                gameMovesLeft--;

                                //Check if game is draw
                                if (gameMovesLeft == 0)
                                {
                                    gameWon = true;

                                    WriteLine("Game is a Draw!");
                                }

                                //Check Winner
                                if (check == "1")
                                {
                                    gameWon = true;

                                    WriteLine("Player 1 Won!");
                                }
                                else if (check == "2")
                                {
                                    gameWon = true;
                                    WriteLine("Player 2 Won!");
                                }

                                //Change Player
                                else
                                {
                                    turn = 2;
                                }
                            }
                        }
                    }

                    if (turn == 2)
                    {
                        string p2Move = randomise();
                        bool valid = isRandomMoveValid(p2Move, moveHistory);

                        while (!valid)
                        {
                            WriteLine("Enter a valid number between 0 and 99 >> ");
                            p2Move = randomise();
                            valid = isRandomMoveValid(p2Move, moveHistory);
                        }

                        //Update Move History
                        moveHistory[Convert.ToInt32(p2Move)] = "O";
                        //Update Board
                        updateBoard(Convert.ToInt32(p2Move), 2, moveHistory);

                        //Check Winner
                        check = CheckWinner(moveHistory);
                        if (check == "1")
                        {
                            gameWon = true;
                            WriteLine("Player 1 Won!");
                        }
                        else if (check == "2")
                        {
                            gameWon = true;
                            WriteLine("Player 2 Won!");
                        }
                        gameMovesLeft--;
                        //Check if game is draw
                        if (gameMovesLeft == 0)
                        {
                            gameWon = true;
                            WriteLine("Game is a Draw!");
                        }
                        //Change Player
                        else
                        {
                            turn = 1;
                        }
                    }
                }
            }
        }  // class ends

        class Move
        {
            public static void Undo(string lastmove, string[] moveHistory)
            {
                if (moveHistory[Convert.ToInt32(lastmove)] == "X")
                {
                    moveHistory[Convert.ToInt32(lastmove)] = lastmove;

                    //Updating Board 
                    Clear();
                    string[] board = new string[100];
                    for (int j = 0; j < 100; j++)
                    {
                        board[j] = moveHistory[j];
                    }
                    int i = 0;

                    for (int j = 1; j < 10; j++)
                    {
                        if (i == 0)
                        {
                            Console.WriteLine("    {0}   |    {1}   |    {2}   |    {3}   |    {4}   |    {5}   |    {6}   |    {7}   |    {8}   |    {9}   |", board[0 + i], board[1 + i], board[2 + i], board[3 + i], board[4 + i], board[5 + i], board[6 + i], board[7 + i], board[8 + i], board[9 + i]);
                            Console.WriteLine("-----------------------------------------------------------------------------------------");
                        }
                        i = i + 10;
                        Console.WriteLine("   {0}   |   {1}   |   {2}   |   {3}   |   {4}   |   {5}   |   {6}   |   {7}   |   {8}   |   {9}   |", board[0 + i], board[1 + i], board[2 + i], board[3 + i], board[4 + i], board[5 + i], board[6 + i], board[7 + i], board[8 + i], board[9 + i]);
                        Console.WriteLine("-----------------------------------------------------------------------------------------");

                    }
                }
                else if (moveHistory[Convert.ToInt32(lastmove)] == "O")
                {
                    moveHistory[Convert.ToInt32(lastmove)] = lastmove;

                    //Updating Board 
                    Clear();
                    string[] board = new string[100];
                    for (int j = 0; j < 100; j++)
                    {
                        board[j] = moveHistory[j];
                    }
                    int i = 0;

                    for (int j = 1; j < 10; j++)
                    {
                        if (i == 0)
                        {
                            Console.WriteLine("    {0}   |    {1}   |    {2}   |    {3}   |    {4}   |    {5}   |    {6}   |    {7}   |    {8}   |    {9}   |", board[0 + i], board[1 + i], board[2 + i], board[3 + i], board[4 + i], board[5 + i], board[6 + i], board[7 + i], board[8 + i], board[9 + i]);
                            Console.WriteLine("-----------------------------------------------------------------------------------------");
                        }
                        i = i + 10;
                        Console.WriteLine("   {0}   |   {1}   |   {2}   |   {3}   |   {4}   |   {5}   |   {6}   |   {7}   |   {8}   |   {9}   |", board[0 + i], board[1 + i], board[2 + i], board[3 + i], board[4 + i], board[5 + i], board[6 + i], board[7 + i], board[8 + i], board[9 + i]);
                        Console.WriteLine("-----------------------------------------------------------------------------------------");

                    }
                }
                else
                {
                    WriteLine("Cannot undo move.");
                }

            }
            public static bool Redo(string input, string[] moveHistory, bool canRedo)
            {
                if (!canRedo)
                {
                    return false;
                }
                else
                {
                    bool repeat = true;
                    while (repeat)
                    {
                        if (moveHistory[Convert.ToInt32(input)] == "X" || moveHistory[Convert.ToInt32(input)] == "O")
                        {
                            return false;
                        }
                        else
                        {
                            repeat = false;
                        }

                    }
                }
                return true;

            }

        }// class ends
        class Game
        {
            public static void Save(string[] moveHistory)
            {

                const string FILENAME = "Gomoku.txt";
                FileStream outFile = new FileStream(FILENAME, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);
                for (int i = 0; i < moveHistory.Length; i++)
                {
                    writer.Write(moveHistory[i] + " ");
                }
                WriteLine("Game Saved");
                writer.Close();
                outFile.Close();
            }
            public static string[] Open()
            {
                //Init Board
                string[] moveHistory = new string[100];
                // Get File
                const string FILENAME = "Gomoku.txt";
                FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                string recordIn;
                recordIn = reader.ReadLine();
                string[] words = recordIn.Split(' ');

                for (int i = 0; i < moveHistory.Length; i++)
                {
                    moveHistory[i] = words[i];
                    Write(moveHistory[i]);
                }
                reader.Close();
                inFile.Close();
                return moveHistory;
            }
        }// class ends
    }
}


