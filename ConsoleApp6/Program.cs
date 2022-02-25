using System.Security.Cryptography.X509Certificates;

class Program
{

    public static char playerSignature = ' ';

    static int turns = 0; //Will count each turn.  Once == 10 then the game is a draw.

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
        turns = 0;
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
        string userInput = " NW .CC , NW .NW , NW . SE , CW . CC , CW .NW , CW .SE , SW .CC , SW .NW , SW . SE";
        userInput = string.Concat(userInput.Where(c => !char.IsWhiteSpace(c)));
        string[] moves = userInput.Split(',');


      

        int player = 2; // Player 1 Starts
        string input = "";

        //skapar upp dragen
        List<string> movesX = new List<string>();
        List<string> movesO = new List<string>();

        //delar upp strängen som matas in för vardera spelare
        //problemet är att den sätter allt i stringen till en egen index


        for (var index = 0; index < moves.Length; index++)
        {
            if (index % 2 == 0)
            {
                movesO.Add(moves[index]);


            }
            else if (index % 2 != 0)
            {
                movesX.Add(moves[index]);


            }
        }
        
        
        bool inputCorrect = true;

        
        var inputX = "";


        //Egen klass som brytas ut för att returnera input för spelarens drag?
        do //Alternates player turns.
        {
            if (player == 1)
            {
                player = 2;
                foreach (var VARIABLE in movesX)
                {
                    Console.WriteLine(VARIABLE);
                }
              
                 input = movesX.FirstOrDefault(); 
                for (int i = movesX.Count - 1; i >= 0; i--)
                {
                    movesX.RemoveAt(i);
                    Console.WriteLine(movesX + "test");
                    XorO(player, movesX);

                    
                }

              
            }

         
            else if (player == 2)
            {
                player = 1;
                foreach (var VARIABLE in movesO)
                {
                    Console.WriteLine(VARIABLE);
                }
                input = movesO.FirstOrDefault();
                for (int i = movesO.Count - 1; i >= 0; i--)
                {
              
                        movesO.RemoveAt(i);
                    Console.WriteLine(movesO +"test");
                    XorO(player, movesO);
                    

                }

            }         


            DrawBoard();
            turns++;

            //Check Game Status.
            HorizontalWin();
            VerticalWin();
            DiagonalWin();

            if (turns == 10)
            {
                Draw();
            }

            

            do
            {


                //Console.WriteLine("\nReady Player {0}: It's your move!", player);
                //try
                //{
                //    //listan av drag för spelare 1 och 2

                //    input = Convert.ToInt32(Console.ReadLine());
                // foreach (var move in list of moves)
                // plocka varannan värde från listorna av drag 

                //if (player =1){
                //get element from movesX
                // else if (playcwer = 2){
                //get element from movesO

                //}
                //catch
                //{
                //    Console.WriteLine("Please enter a number!");
                //}
                //inputen kommer från spelare 1 (movesX) och spelare 2 (movesO)
                //inputen ska sedan sättas in i if satsen för att avgöra var positionen ska läggas

                //   "NW", "NC", "NE", "CW", "CC", "CE", "SW", "SC", "SE"
                
                if ((input.Equals("NW")) && (ArrBoard[0].Equals("NW")))
                    inputCorrect = true;
                else if ((input.Equals("NC")) && (ArrBoard[1].Contains("NC")))
                    inputCorrect = true;
                else if ((input.Equals("NE")) && (ArrBoard[2].Contains("NE")))
                    inputCorrect = true;
                else if ((input.Equals("CW")) && (ArrBoard[3].Contains("CW")))
                    inputCorrect = true;
                else if ((input.Equals("CC")) && (ArrBoard[4].Contains("CC")))
                    inputCorrect = true;
                else if ((input.Equals("CE")) && (ArrBoard[5].Contains("CE")))
                    inputCorrect = true;
                else if ((input.Equals("SW")) && (ArrBoard[6].Contains("SW")))
                    inputCorrect = true;
                else if ((input.Equals("SC")) && (ArrBoard[7].Contains("SC")))
                    inputCorrect = true;
                else if ((input.Equals("SE")) && (ArrBoard[8].Contains("SE")))
                    inputCorrect = true;
                //else
                //{
                //    Console.WriteLine("Whoops, I didn't get that.  \nPlease try again...");
                //    inputCorrect = false;
                //}


            } while (!inputCorrect);
        } while (true);

    } //Gameplay loop.  Controls player turns & overrides the array with players input.



    public static void XorO(int player, List<string> moves)
    {

        if (player == 1) playerSignature = 'X';
        else if (player == 2) playerSignature = 'O';

        switch (moves)
        {
            case var _ when moves.Contains("NW"):
                ArrBoard[0] = playerSignature.ToString();
                break;
            case var _ when moves.Contains("NC"):
                ArrBoard[1] = playerSignature.ToString();
                break;
            case var _ when moves.Contains("NE"):
                ArrBoard[2] = playerSignature.ToString();
                break;
            case var _ when moves.Contains("CW"):
                // The program must not use downcasting or type checking. Är tostring downcasting?
                ArrBoard[3] = playerSignature.ToString();
                break;
            case var _ when moves.Contains("CC"):
                ArrBoard[4] = playerSignature.ToString();
                break;
            case var _ when moves.Contains("CE"):
                ArrBoard[5] = playerSignature.ToString();
                break;
            case var _ when moves.Contains("SW"):
                ArrBoard[6] = playerSignature.ToString();
                break;
            case var _ when moves.Contains("SC"):
                ArrBoard[7] = playerSignature.ToString();
                break;
            case var _ when moves.Contains("SE"):
                ArrBoard[8] = playerSignature.ToString();
                break;
        }

    } //Controls if the player is X or O.

    public static void HorizontalWin()
    {
        char[] playerSignatures = {'X', 'O'};

        foreach (var playerSignature in playerSignatures)
        {
            if (((ArrBoard[0].Equals(playerSignature)) && (ArrBoard[1].Equals(playerSignature)) && (ArrBoard[2].Equals(playerSignature)))
                || ((ArrBoard[3].Equals(playerSignature)) && (ArrBoard[4].Equals(playerSignature)) &&
                    (ArrBoard[5].Equals(playerSignature)))
                || ((ArrBoard[6].Equals(playerSignature)) && (ArrBoard[7].Equals(playerSignature)) &&
                    (ArrBoard[8].Equals(playerSignature))))
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


                WinArt();
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
            if (((ArrBoard[0].Equals(playerSignature)) && (ArrBoard[3].Equals(playerSignature)) && (ArrBoard[6].Equals(playerSignature)))
                || ((ArrBoard[1].Equals(playerSignature)) && (ArrBoard[4].Equals(playerSignature)) &&
                    (ArrBoard[7].Equals(playerSignature)))
                || ((ArrBoard[2].Equals(playerSignature)) && (ArrBoard[5].Equals(playerSignature)) &&
                    (ArrBoard[8].Equals(playerSignature))))
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

                WinArt();
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
            if ((ArrBoard[0].Equals(playerSignature)) && (ArrBoard[4].Equals(playerSignature)) && (ArrBoard[8].Equals(playerSignature))
                || (ArrBoard[6].Equals(playerSignature)) && (ArrBoard[4].Equals(playerSignature)) &&
                    (ArrBoard[2].Equals(playerSignature)))
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

                WinArt();
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

    public static void WinArt()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" ÛÛÛÛÛ ÛÛÛÛÛ                        ÛÛÛÛÛ   ÛÛÛ   ÛÛÛÛÛ                     ÛÛÛ ÛÛÛ     ");
        Console.WriteLine("°°ÛÛÛ °°ÛÛÛ                        °°ÛÛÛ   °ÛÛÛ  °°ÛÛÛ                     °ÛÛÛ°ÛÛÛ     ");
        Console.WriteLine(" °°ÛÛÛ ÛÛÛ    ÛÛÛÛÛÛ  ÛÛÛÛÛ ÛÛÛÛ    °ÛÛÛ   °ÛÛÛ   °ÛÛÛ   ÛÛÛÛÛÛ  ÛÛÛÛÛÛÛÛ  °ÛÛÛ°ÛÛÛ     ");
        Console.WriteLine("  °°ÛÛÛÛÛ    ÛÛÛ°°ÛÛÛ°°ÛÛÛ °ÛÛÛ     °ÛÛÛ   °ÛÛÛ   °ÛÛÛ  ÛÛÛ°°ÛÛÛ°°ÛÛÛ°°ÛÛÛ °ÛÛÛ°ÛÛÛ     ");
        Console.WriteLine("   °°ÛÛÛ    °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ     °°ÛÛÛ  ÛÛÛÛÛ  ÛÛÛ  °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ°ÛÛÛ     ");
        Console.WriteLine("    °ÛÛÛ    °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ      °°°ÛÛÛÛÛ°ÛÛÛÛÛ°   °ÛÛÛ °ÛÛÛ °ÛÛÛ °ÛÛÛ °°° °°°      ");
        Console.WriteLine("    ÛÛÛÛÛ   °°ÛÛÛÛÛÛ  °°ÛÛÛÛÛÛÛÛ       °°ÛÛÛ °°ÛÛÛ     °°ÛÛÛÛÛÛ  ÛÛÛÛ ÛÛÛÛÛ ÛÛÛ ÛÛÛ     ");
        Console.WriteLine("    °°°°°     °°°°°°    °°°°°°°°         °°°   °°°       °°°°°°  °°°° °°°°° °°° °°°     ");
        Console.ResetColor();
    } //ASCII Art setup in it's own method to help keep the code tidy.  
}