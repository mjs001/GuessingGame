using System;
using System.Linq;
using System.Threading.Tasks;
namespace Guess
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables //
            string game = RandomGameChooser();
            string description = RandomGamesDescription(game);
            int totalNumOfWords = HowManyWordsInStr(game);
            int guessCount = 0;
            int maxGuesses = 8;
            string guess = "";


            // start of game //
            Console.WriteLine("----VIDEO GAME GUESSING GAME---- \n\n");
            Console.WriteLine("RULES:\nWhen prompted input the name of the video game I am thinking of. If you get it wrong that is ok.\nHowever, You only get a total of 5 guesses. Does this seem too difficult?\nDon't worry! I will give you hints along the way.\nJust keep in mind, each time you exit the game a different game will be chosen.\nYou will be given a total of 4 hints. One at the beginning of the game and one for every wrong guess.\n\n\nHave fun! (:\n\n");
            Console.WriteLine("----GAME START----\n\n");
            Console.WriteLine("HINT 1:\nThe game I'm thinking of is a game that " + description + "\n");
            Console.WriteLine("Now, its your time to shine! Please enter what you think the game is.");

            // while loop //
            while ( guess.Contains(game, StringComparison.OrdinalIgnoreCase) != true && guessCount != maxGuesses)
            {


                guess = Console.ReadLine();
                
                guessCount++;
                if (guessCount == 1)
                {
                    Console.WriteLine("HINT 2:\nHaving a lil trouble? Well, I'll give you your second hint. The game starts with the letter " + game[0]);
                }
                else if (guessCount == 2 || guessCount == 4)
                {
                    Console.WriteLine("Unfortunately that wasn't it. Keep trying!");
                }
                else if (guessCount == 3)
                {
                    Console.WriteLine("HINT 3:\nNeed some more help? I have you covered! The game is " + totalNumOfWords + " words long.");
                }
                else if (guessCount == 5)
                {
                    string correctLetters = WhatLettersAreCorrect(guess, game).Result;
                    Console.WriteLine("HINT 4:\nI'll help you out once more. You have the following letters correct:" + correctLetters.ToLower());
                }
                else if (guessCount >= 6)
                {
                    Console.WriteLine("Sorry, you have lost the game. The right answer was: " + game);
                    Console.WriteLine("\n\n\n\n\n------YOU HAVE LOST. ):------\n\n");
                }


            };

            Console.WriteLine("Wow! You got it right!!! YOU WIN!!!!\n\n\n\n\n------CONGRATS! YOU BEAT THE GAME! :D------\n\n");
            Console.ReadLine();

        }

        static string RandomGameChooser()
        {
            string chosenGame;
            string[] games =
            {
                "Minecraft", "Grand Theft Auto V", "Wii Sports", "Tetris", "Pokemon Red", "Pac-Man", "Mario Kart 8", "New Super Mario Bros.", "Terraria", "Pokemon Gold", "Diablo III", "Duck Hunt", "The Witcher 3: Wild Hunt", "FIFA 18", "Borderlands 2", "Frogger"
            };
            Random randomNum = new Random();
            int index = randomNum.Next(games.Length);
            chosenGame = games[index];
            return chosenGame;
        }
        static string RandomGamesDescription(string game)
        {
            string description = "";
            switch (game)
            {
                case "Minecraft":
                    description = "involves creativity, animals, mining--do I have to say much more?";
                    break;
                case "Grand Theft Auto V":
                    description = "involves shooting things and or people,\nopen world, very popular with people that like multiplayer games,\ninvolves drugs and is rated M, also has been out for a long time.";
                    break;
                case "Wii Sports":
                    description = "involves moving around, or atleast that was the goal,\nwas very popular with people that bought wiis,\npretty much everyone was playing it at the time and still has some fun minigames to this day.";
                    break;
                case "Tetris":
                    description = "involves moving something around the screen at a rapid pace,\npretty much everyone has played it\nand it is an integral part of video game history.";
                    break;
                case "Pokemon Red":
                    description = "involves a certain primary color as the only color you see during the game.";
                    break;
                case "Pac-Man":
                    description = "involves enemies going about on the screen chasing after you and you can get\npower ups.\nA classic.";
                    break;
                case "Mario Kart 8":
                    description = "involves driving a car of sorts, has customizable vehicle\n and is a very popular game on a particular\nconsole that may or may not ryhme with Shmintendo.";
                    break;
                case "New Super Mario Bros.":
                    description = "involves two men with mustaches, and power ups,\nenemies the whole shabang, a newer release but not that new.";
                    break;
                case "Terraria":
                    description = "involves mining but its not THAT mining game.\nside scroller, enemies abound, can play with others.";
                    break;
                case "Pokemon Gold":
                    description = "involves a particular color but it is not integral.\nLovable creatures abound, people to battle and trade with.\nPretty old.";
                    break;
                case "Diablo III":
                    description = "involves slaying monsters, can be with other people or solo.\nMade a interesting rerelease on the switch.";
                    break;
                case "Duck Hunt":
                    description = "involves a hunting and its a classic.";
                    break;
                case "The Witcher 3: Wild Hunt":
                    description = "involves a grey haired person with awesome skills,\nand there is a netflix series based on this series of games.";
                    break;
                case "FIFA 18":
                    description = "involves a ball, and people kicking it. It came out decently recently.\nI'll throw you one more bone, it came out within the last 4 years.";
                    break;
                case "Borderlands 2":
                    description = "involves loot, lots of loot, interesting characters, different visuals,\nnot the first in the series and to be\nhonest I think it came out on the ps3.";
                    break;
                case "Frogger":
                    description = "involves a frog and jumping.";
                    break;
            }
            return description;
        }
        static int HowManyWordsInStr(string game)
        {
            int num;
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            num = game.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            return num;
        }
        static async Task<string> WhatLettersAreCorrect(string currentGuess, string game)
        {
            string correctLetters = "";

            await Task.Run(() =>
            {
                for (int i = 0; i < game.Length; i++)
                {
                    if (currentGuess.Contains(game[i], StringComparison.OrdinalIgnoreCase))
                    {
                        if (correctLetters.Contains(game[i], StringComparison.OrdinalIgnoreCase) != true)
                        {
                            correctLetters += Convert.ToString(game[i] + ", " );
                            
                        }
                        
                    }
                }

                return correctLetters;
            });
            return correctLetters;
        }
    } } 


