using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

namespace GameSystem
{
    public class CardGame : Game
    {
        protected List<GameObject> deck,centralPile;
        protected List<List<GameObject>> hands;

        //int[] playerrotations = { 0, -90, 180, 90 };

        protected List<Vector3> playerrotations ; 

        protected List<List<Vector3>> handspostions ;
        protected float sum = 0.0f;
        protected Vector3 centralpileLocalpos = new Vector3(-1, 0, 0);

        public CardGame(string name, int numberOfPlayers) : base(name, numberOfPlayers)
        {
            deck = new List<GameObject>();
            hands =new()
                {
                new List<GameObject> {},new List<GameObject> {},new List<GameObject> {},new List<GameObject> {},
                };
            centralPile = new List<GameObject>();
        }

        protected void Assemble(List<GameObject> deck)
        {
            for (int i = 0; i < deck.Count; i++)
            {
                deck[i].transform.localPosition = new Vector3(0, sum, 0);
                sum += 0.005f;
            }
            sum = 0;
        }



        public void shuffledeck(List<GameObject> cards)
        {
            System.Random rand = new System.Random();
            while (cards.Count > 0)
            {
                int x = cards.Count;
                int randomIndex = rand.Next(0, x);
                GameObject temp = cards[randomIndex];
                cards.RemoveAt(randomIndex);    
                deck.Add(temp);
            }

        }
        public virtual void DealCards(int numberofcards)
        {
            Debug.Log(deck.Count);

            for (int i = 0; i < numberOfPlayers; i++)
            {
                for (int j = 0; j <numberofcards; j++)
                {
                    Debug.Log(i);
                    hands[i].Add(deck[deck.Count - 1]);
                    deck.RemoveAt(deck.Count - 1);  
                }
            }
            Assemble(deck);
        }
        public void DealCards()
        {
            while(deck.Count>0)
            {
                for (int i = 0; i < numberOfPlayers; i++)
                {

                    hands[i].Add(deck[deck.Count - 1]);
                    deck.RemoveAt(deck.Count - 1);  
                }
            }
            Assemble(deck);
        }
        protected virtual void movetopostion()
        {
            for (int i = 0; i < hands.Count; i++)
            {
                for (int j = 0; j < hands[i].Count; j++)
                {
                    
                hands[i][j].transform.Rotate(playerrotations[i]);
                hands[i][j].transform.localPosition = handspostions[i][j];
                }
        }
        }

        public GameObject PickCard(int player)
        {
            if (deck.Count == 0)
            {
                Debug.LogWarning("Deck is empty!");
                return null;
            }

            GameObject card = deck[deck.Count - 1];
            deck.RemoveAt(deck.Count - 1);
            return card;
        }
        public virtual void setupposition(){}


    }
} 