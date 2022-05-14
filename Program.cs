// See https://aka.ms/new-console-template for more information




//Programmer: Nathan Johnston
//Class:cs 141
//Assignment: Lab 4: Guessing Game
//Purpose: This program prints instructions, selects a random number, and asks a user to try
//and guess that number. The number of guesses and games played are stored during
//game play, then printed out after the player elects to quit.


namespace GuessingGame
{

    internal class Program
    {

        public static void Main(string[] args) {

            int guessLimit = 50;

            printInstructions(guessLimit);

            printStatistics(gameLoop(guessLimit));

        }//end of main


        private static void printInstructions(int guessLimit) {
            string instructions =

            "\n\nI will think of a number between 1 and " + guessLimit + ".\n"
                + "Type your guess below and hit 'enter'.\n"
                + "Each time you guess I will tell you if my number is higher or lower than "
                + "your guess\n";

            Console.WriteLine(instructions);

        }


        private static GameData gameLoop(int guessLimit) { 
        
            int totalAttempts = 0;
            int totalGames = 0;
            int lowestGuessNumber = int.MaxValue;


            bool running = true;
            while (running)
            {

                //generate random number for the user to guess, based on guess limit 
                Random random = new Random();
                int chosenNumber = random.Next(1, guessLimit+1);

                Console.WriteLine("Alright I have my Number. Guess!");

                int userGuess = 0;

                int userAttempts = 0;

                totalGames++;   

                do
                {
                    userAttempts++;
                    totalAttempts++;

                    userGuess = Convert.ToInt32(Console.ReadLine());

                    if (userGuess > chosenNumber)
                    {
                        Console.WriteLine("Nope, guess lower!");
                    }
                    else if (userGuess < chosenNumber)
                    {
                        Console.WriteLine("Nope, guess higher!");
                    }


                }while(userGuess != chosenNumber);


                if (userAttempts == 1)
                {
                    Console.WriteLine("Wow you got it in 1 attempt!");
                }
                Console.WriteLine("That's right! You got it in "+userAttempts+" attempts! ");

                //update lowestGuessNumber
                if (userAttempts < lowestGuessNumber)
                {
                    lowestGuessNumber = userAttempts;
                }

                bool asking = true;
                while (asking)
                {
                    Console.WriteLine("Would you like to play again? y|n");

                    string userRes = Console.ReadLine();

                    if (userRes.ToLower().Equals("y"))
                    {
                        Console.WriteLine("yes");
                        asking = false;
                        continue;

                    }else if (userRes.ToLower().Equals("n"))
                    {
                        Console.WriteLine("no");
                        asking = false;
                        running = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("other");
                        Console.WriteLine("Please enter 'y' for yes, or 'n' for no and hit" +
                            "'enter'.");
                        continue;
                    }
                }
               
               


            }

            //return gameplay staticists in an instance of GameData
            GameData gameData = new GameData(totalAttempts, totalGames, lowestGuessNumber);

            return gameData;
        }

        private static void printStatistics(GameData gameData)
        {

           
            Console.WriteLine(
                "Total Guesses: {0:N}\n" +
                "Total Games: {1:N}\n\n" +
                "Average Guesses Per Game: {2:D}\n\n" +
                "Fewest Guesses in a Game: {3:N}\n\n",
                gameData.GameDataArray[0],
                gameData.GameDataArray[1],
                gameData.GameDataArray[2],
                gameData.returnAveragePerGame());
        }
    }

    internal class GameData
    {
       private int[] _gameDataArray;

       public int[] GameDataArray
       {
            get { return this._gameDataArray; }
       }

        public GameData(int a, int b, int c)
        {
            fillGameDataArray(a,b,c);
        }

         void fillGameDataArray(int totalGuesses, int totalGames, int lowestGuessNumber)
        {
            int[] temp = new int[3];

            temp[0] = totalGuesses;
            temp[1] = totalGames;
            temp[2] = lowestGuessNumber;

            this._gameDataArray = temp;
        }


        public double returnAveragePerGame()
        {
            return _gameDataArray[0] / _gameDataArray[1];
        }
        


    }//end of game data
}


        

    
    
   
    
    



  


