using System;
using System.Collections.Generic;
using System.Linq;

class NumberWars
{
    static void Main(string[] args)
    {
        string[] playerOne = Console.ReadLine()
            .Split();
        string[] playerTwo = Console.ReadLine()
            .Split();

        Queue<Card> playerOneDeck = ReadDeck(playerOne);
        Queue<Card> playerTwoDeck = ReadDeck(playerTwo);
        Queue<Card> boardCards = new Queue<Card>();
        int turn = 0;

        while (turn < 1000000)
        {
            turn++;
            Card playerOneCard = playerOneDeck.Dequeue();
            Card playerTwoCard = playerTwoDeck.Dequeue();

            if (playerOneCard.MainPower > playerTwoCard.MainPower)
            {
                playerOneDeck.Enqueue(playerOneCard);
                playerOneDeck.Enqueue(playerTwoCard);
            }
            else if (playerOneCard.MainPower < playerTwoCard.MainPower)
            {
                playerTwoDeck.Enqueue(playerTwoCard);
                playerTwoDeck.Enqueue(playerOneCard);
            }
            else
            {
                boardCards.Enqueue(playerOneCard);
                boardCards.Enqueue(playerTwoCard);

                while (true)
                {
                    int playerOnePower = 0;
                    int playerTwoPower = 0;
                    Card warCard = new Card();


                    if (playerOneDeck.Count >= 3 && playerTwoDeck.Count >= 3)
                    {
                        for (int counter = 0; counter < 3; counter++)
                        {
                            warCard = playerOneDeck.Dequeue();
                            boardCards.Enqueue(warCard);
                            playerOnePower += warCard.WarPower;
                            warCard = playerTwoDeck.Dequeue();
                            boardCards.Enqueue(warCard);
                            playerTwoPower += warCard.WarPower;
                        }
                    }
                    else if (playerOneDeck.Count < 3)
                    {
                        Console.WriteLine($"Second player wins after {turn} turns");
                        Environment.Exit(0);
                    }
                    else if (playerTwoDeck.Count < 3)
                    {
                        Console.WriteLine($"First player wins after {turn} turns");
                        Environment.Exit(0);
                    }

                    if (playerOnePower > playerTwoPower)
                    {
                        GetWinnings(playerOneDeck, boardCards);
                        break;
                    }
                    else if (playerOnePower < playerTwoPower)
                    {
                        GetWinnings(playerTwoDeck, boardCards);
                        break;
                    }

                    CheckForWinner(playerOneDeck, playerTwoDeck, turn);
                }
            }

            CheckForWinner(playerOneDeck, playerTwoDeck, turn);
            boardCards.Clear();
        }

        CheckForWinner(playerOneDeck, playerTwoDeck, turn);
    }

    private static void GetWinnings(Queue<Card> playerOneDeck, Queue<Card> boardCards)
    {
        foreach (var card in boardCards.OrderByDescending(c => c.MainPower).ThenByDescending(c => c.WarPower))
        {
            playerOneDeck.Enqueue(card);
        }
    }

    static void CheckForWinner(Queue<Card> playerOneDeck, Queue<Card> playerTwoDeck, int turn)
    {
        if (turn < 1000000)
        {
            if (playerOneDeck.Count == 0 && playerTwoDeck.Count == 0)
            {
                Console.WriteLine($"Draw after {turn} turns");
                Environment.Exit(0);
            }
            else if (playerOneDeck.Count == 0)
            {
                Console.WriteLine($"Second player wins after {turn} turns");
                Environment.Exit(0);
            }
            else if (playerTwoDeck.Count == 0)
            {
                Console.WriteLine($"First player wins after {turn} turns");
                Environment.Exit(0);
            }
        }
        else
        {
            if (playerOneDeck.Count < playerTwoDeck.Count)
            {
                Console.WriteLine($"Second player wins after {turn} turns");
                Environment.Exit(0);
            }
            else if (playerTwoDeck.Count < playerOneDeck.Count)
            {
                Console.WriteLine($"First player wins after {turn} turns");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Draw after {turn} turns");
                Environment.Exit(0);
            }
        }
    }

    static Queue<Card> ReadDeck(string[] player)
    {
        Queue<Card> deck = new Queue<Card>();

        foreach (string cardInfo in player)
        {
            int mainPower = int.Parse(cardInfo.Remove(cardInfo.Length - 1));
            int warPower = cardInfo[cardInfo.Length - 1];
            Card card = new Card
            {
                MainPower = mainPower,
                WarPower = warPower
            };
            deck.Enqueue(card);
        }

        return deck;
    }
}

class Card
{
    public int MainPower { get; set; }
    public int WarPower { get; set; }
}