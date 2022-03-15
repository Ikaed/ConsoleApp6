using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class Program
{
    //1. tic tac toe x 8
    public static char playerSignature = ' ';

    static int turns = 0; //Will count each turn.  Once == 10 then the game is a draw.

    //Skapa upp alla bräden här
    static string[] ArrBoard =
    {
        "NW", "NC", "NE", "CW", "CC", "CE", "SW", "SC", "SE"
    }; //Global char array variable to store the players input.



    public static void BoardReset() //If this method is called then the game resets.  
    {
        string[] ArrBoardInitialize =
        {
            "NW", "NC", "NE", "CW", "CC", "CE", "SW", "SC", "SE"
        };

        ArrBoard = ArrBoardInitialize;
        DrawBoard();

    }

    public static void DrawBoard()
    {
        Console.Clear();
        Console.WriteLine("  -------------------------");
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", ArrBoard[0], ArrBoard[1], ArrBoard[2]);
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  -------------------------");
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", ArrBoard[3], ArrBoard[4], ArrBoard[5]);
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  -------------------------");
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", ArrBoard[6], ArrBoard[7], ArrBoard[8]);
        Console.WriteLine("  |       |       |       |");
        Console.WriteLine("  -------------------------");
    } //Draws the player board to terminal.  



    static void Main(string[] args)
    {

        //string userInput = args[0];
        string userInput = "NW, CC, SE, SE, SW, NC, NC, SC, NE, CW, CW, CW, CW, CE";
        //string userInput = "NW,NC, NE, CC, CE, CW, SW, SE, SC";
        //string userInput = " NW.CC, NC.CC, NW.NW, NE.CC, NW.SE, CE.CC, CW.CC, SE.CC, CW.NW, CC.CC, CW.SE, CC.NW, CC.SE, CE.NW, SW.CC, CE.SE, SW.NW, SE.SE, SW.SE";
        userInput = string.Concat(userInput.Where(c => !char.IsWhiteSpace(c)));
        string[] moves = userInput.Split(',');
       



        //int player = 2; // Player 1 Starts


        do //Alternates player turns.
        {

            eligebleTile(moves);
            DrawBoard();
            HorizontalWin();
            VerticalWin();
            DiagonalWin();
            if (turns == 9)
            {
                Draw();
            }


        } while (turns <= 9);
    }

    //Gameplay loop.  Controls player turns & overrides the array with players input.


    public static void eligebleTile(string[] moves)
    {
        bool playerOTurn = true;
        int countO = 0;
        int countX = 0;
        int player;
        List<string> movesX = new List<string>();
        List<string> movesO = new List<string>();
        string input = "";
        //delar upp strängen som matas in för vardera spelare
        //problemet är att den sätter allt i stringen till en egen index



        // Kollar så att ingen av spelarna har spelat det draget som läggs till nu och om ingen har spelat det så lägger den till i antingen playero eller playerx
        for (var index = 0; index < moves.Length; index++)
        {
            if (!movesO.Contains(moves[index]) && !movesX.Contains(moves[index])) //Metod från eligebleTile
            {
                if (playerOTurn)
                {
                    player = 1;
                    movesO.Add(moves[index]);
                    input = movesO[countO];
                    countO++;

                    Console.WriteLine(input + countO + "Player1");
                    turns++;
                    OorX(player, input);
                }
                else
                {
                    player = 2;
                    movesX.Add(moves[index]);
                    input = movesX[countX];
                    countX++;
                    Console.WriteLine(input + countX + "Player2");
                    turns++;
                    OorX(player, input);
                }

                playerOTurn = !playerOTurn;
            }
        }
    }

    //code smell?
    public static void OorX(int player, string input)
    {

        if (player == 1) playerSignature = 'X';
        else if (player == 2) playerSignature = 'O';

        switch (input)
        {
            
            case var _ when input.Contains("NW"):
                ArrBoard[0] = playerSignature.ToString();
                break;
            case var _ when input.Contains("NC"):
                ArrBoard[1] = playerSignature.ToString();
                break;
            case var _ when input.Contains("NE"):
                ArrBoard[2] = playerSignature.ToString();
                break;
            case var _ when input.Contains("CW"):
                ArrBoard[3] = playerSignature.ToString();
                break;
            case var _ when input.Contains("CC"):
                ArrBoard[4] = playerSignature.ToString();
                break;
            case var _ when input.Contains("CE"):
                ArrBoard[5] = playerSignature.ToString();
                break;
            case var _ when input.Contains("SW"):
                ArrBoard[6] = playerSignature.ToString();
                break;
            case var _ when input.Contains("SC"):
                ArrBoard[7] = playerSignature.ToString();
                break;
            case var _ when input.Contains("SE"):
                ArrBoard[8] = playerSignature.ToString();
                break;
        }

    } //Controls if the player is X or O.

    public static void HorizontalWin()
    {
        char[] playerSignatures = {'X', 'O'};
        foreach (var playerSignature in playerSignatures)
        {
            if (((ArrBoard[0].Contains(playerSignature)) && (ArrBoard[1].Contains(playerSignature)) && (ArrBoard[2].Contains(playerSignature)))
                || ((ArrBoard[3].Contains(playerSignature)) && (ArrBoard[4].Contains(playerSignature)) &&
                    (ArrBoard[5].Contains(playerSignature)))
                || ((ArrBoard[6].Contains(playerSignature)) && (ArrBoard[7].Contains(playerSignature)) &&
                    (ArrBoard[8].Contains(playerSignature))))
            {
                Console.Clear();
                if (playerSignature == 'X')
                {
                    Console.WriteLine("Congratulations Player 1.\nYou have a achieved a horizontal win! " +
                                      "\nYou're the Tic Tac Toe Master!\n" +
                                      "\nTurns taken{0}", turns);

                }
                else if (playerSignature == 'O')
                {
                    Console.WriteLine("Congratulations Player 2.\nYou have a achieved a horizontal win! " +
                                      "\nYou're the Tic Tac Toe Master!\n" +
                                      "\nTurns taken{0}", turns);
                }


                //WinArt();
                Console.WriteLine("Please press any key to reset the game");
                Console.ReadKey();
                BoardReset();

                break;
            }
        }
    } //Method is called to check for a horizontal win.  

    public static void VerticalWin()
    {
        char[] playerSignatures = {'X', 'O'};

        foreach (char playerSignature in playerSignatures)
        {
            if (((ArrBoard[0].Contains(playerSignature)) && (ArrBoard[3].Contains(playerSignature)) && (ArrBoard[6].Contains(playerSignature)))
                || ((ArrBoard[1].Contains(playerSignature)) && (ArrBoard[4].Contains(playerSignature)) &&
                    (ArrBoard[7].Contains(playerSignature)))
                || ((ArrBoard[2].Contains(playerSignature)) && (ArrBoard[5].Contains(playerSignature)) &&
                    (ArrBoard[8].Contains(playerSignature))))
            {
                Console.Clear();
                if (playerSignature == 'X')
                {
                    Console.WriteLine(
                        "Player 1, that was Fantastic.\nA vertical win!\nYou're the Tic Tac Toe Master!\n");
                }
                else
                {
                    Console.WriteLine(
                        "Player 2, that was Fantastic.\nA vertical win!\nYou're the Tic Tac Toe Master!\n");
                }

                //WinArt();
                Console.WriteLine("Please press any key to reset the game");
                Console.ReadKey();
                BoardReset();

                break;
            }
        }
    } //Method is called to check for a vertical win.  

    public static void DiagonalWin()
    {
        char[] playerSignatures = {'X', 'O'};

        foreach (char playerSignature in playerSignatures)
        {
            if ((ArrBoard[0].Contains(playerSignature)) && (ArrBoard[4].Contains(playerSignature)) && (ArrBoard[8].Contains(playerSignature))
                || (ArrBoard[6].Contains(playerSignature)) && (ArrBoard[4].Contains(playerSignature)) &&
                    (ArrBoard[2].Contains(playerSignature)))
            {
                Console.Clear();
                if (playerSignature == 'X')
                {
                    Console.WriteLine("WOW!, player 1 that's a diagonal win! " +
                                      "\nExcellently played, it's one for the ages! " +
                                      "\nYou're the Tic Tac Toe Legend!\n \n \n");
                }
                else
                {
                    Console.WriteLine("WOW!, player 2 that's a diagonal win! " +
                                      "\nExcellently played, it's one for the ages! " +
                                      "\nYou're the Tic Tac Toe Legend!\n \n \n");
                }

                //WinArt();
                Console.WriteLine("Please press any key to reset the game");
                Console.ReadKey();
                BoardReset();

                break;
            }
        }
    } //Method is called to check for a diagonal win.

    
    public static void Draw()
    {

        {
            Console.WriteLine("Aw gosh... it's a draw." +
                              "\nPlease press any key to reset the game and try again!");
            Console.ReadKey();
            BoardReset();

        }
    } //Method is called to check if the game is a draw.
 
}