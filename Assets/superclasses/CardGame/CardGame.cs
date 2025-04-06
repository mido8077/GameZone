using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

namespace GameSystem
{
    public class CardGame : Game
    {
        protected List<GameObject> deck;
        protected List<GameObject> prefabs;
        protected List<List<GameObject>> hands;
        protected List<GameObject> centralPile;

        int[] playerrotations = { 0, -90, 180, 90 };

        protected List<List<Vector3>> playerPositions ;
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
                deck[i].transform.Translate(0, 0, sum);
                sum += 0.005f;
            }
            sum = 0;
        }

        public void collectprefabs(string prefabpath)
        {
           PrefabTest prefabTest = new PrefabTest();
           prefabs=prefabTest.getObjectsFromPrefab(prefabpath);
           shuffledeck(prefabs);
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
                    
                hands[i][j].transform.Rotate(0, 0, playerrotations[i]);
                hands[i][j].transform.localPosition = playerPositions[i][j];
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
        
        
        
        public List<GameObject> Deck => deck;
        public List<List<GameObject>> Hands => hands;
        public List<GameObject> CentralPile => centralPile;
        public List<List<Vector3>> PlayerPositions => playerPositions;

    }
} 