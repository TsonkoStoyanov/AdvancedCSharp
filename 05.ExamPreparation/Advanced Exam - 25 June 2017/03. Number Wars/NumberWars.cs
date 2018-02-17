using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03._Number_Wars
{
    class NumberWars
    {

        static void Main()
        {
            var firstPlayerAllCards = new Queue<string>(Console.ReadLine().Split());
            var secondPlayerAllCards = new Queue<string>(Console.ReadLine().Split());


            int turns = 0;
            bool gameOver = false;

            while (turns < 1_000_000 && firstPlayerAllCards.Count > 0 && secondPlayerAllCards.Count > 0 && !gameOver)
            {
                turns++;

                var firstCard = firstPlayerAllCards.Dequeue();
                var secondCard = secondPlayerAllCards.Dequeue();

                if (GetCardValue(firstCard) > GetCardValue(secondCard))
                {
                    firstPlayerAllCards.Enqueue(firstCard);
                    firstPlayerAllCards.Enqueue(secondCard);
                }
                else if (GetCardValue(secondCard) > GetCardValue(firstCard))
                {
                    secondPlayerAllCards.Enqueue(secondCard);
                    secondPlayerAllCards.Enqueue(firstCard);
                }
                else
                {
                    List<string> deckList = new List<string>();

                    deckList.Add(firstCard);
                    deckList.Add(secondCard);

                    while (!gameOver)
                    {
                        if (firstPlayerAllCards.Count >= 3 && secondPlayerAllCards.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;

                            for (int i = 0; i < 3; i++)
                            {
                                string firstDeckCard = firstPlayerAllCards.Dequeue();
                                string secondDeckCard = secondPlayerAllCards.Dequeue();
                                firstSum += GetCharValue(firstDeckCard);
                                secondSum += GetCharValue(secondDeckCard);
                                deckList.Add(firstDeckCard);
                                deckList.Add(secondDeckCard);
                            }
                            if (firstSum > secondSum)
                            {
                                AddCards(firstPlayerAllCards, deckList);
                                break;
                            }
                            else if (firstSum < secondSum)
                            {
                                AddCards(secondPlayerAllCards, deckList);
                                break;
                            }

                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }
            }

            var result = "";
            if (firstPlayerAllCards.Count == secondPlayerAllCards.Count)
            {
                result = "Draw";
            }
            else if (firstPlayerAllCards.Count > secondPlayerAllCards.Count)
            {
                result = "First player wins";
            }
            else
            {
                result = "Second player wins";
            }
            Console.WriteLine($"{result} after {turns} turns");
        }

        static void AddCards(Queue<string> firstPlayerAllCards, List<string> deckList)
        {
            foreach (var card in deckList.OrderByDescending(x => GetCardValue(x)).ThenByDescending(x => GetCharValue(x)))
            {
                firstPlayerAllCards.Enqueue(card);
            }
        }

        static int GetCardValue(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        static int GetCharValue(string card)
        {
            return card[card.Length - 1];
        }
    }
}
