The goal of the game is to guess the weight of a fruit basket. 
The weight of the basket will be between 40 – 140 kilos. (Whole numbers)

Rules:
The game ends when a player identifies the weight correctly or there were 100 attempts.

They game has 5 types of players:
1) Random player: guesses a random number between 40 and 140.
2) Memory player: guesses a random number between 40 and 140 but doesn’t try the same number more than once.
3) Thorough player: tries all numbers by order – 41,42,43 …
4) Cheater player: guesses a random number between 40 and 140 – but doesn’t try any of the numbers that other players had already tried.
5) Thorough Cheater player: tries all numbers by order – 41, 42, 43 … but skips numbers that were already been tried before by any of the players.
If a player guessed a number incorrectly – he will have to wait the absolute delta (between the real number and his guess) in milliseconds.
For an example: real number is 100 – the guess was 70 – the player will sleep for 30 milliseconds. If his guess is 130 – he will also sleep for 30 milliseconds.

Inputs:
1. The amount of participating players – 2 through 8
2. For each player – his name and his type.

Outputs:
1. At the begging of the game – the real weight of the basket.
2. At the end of the game:
a. If there was a winner – his name and total amount of attempts in the game.
b. In case there wasn’t a winner – the name of the player who was the closest (absolute) and his guess. If there were more than one – the one that was the first. Also, his guess should be printed as well.

Finish the game not only if there were 100 attempts but also if 1500 milliseconds passed.
