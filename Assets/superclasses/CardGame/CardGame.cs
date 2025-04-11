using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Linq;

namespace GameSystem
{
    public class CardGame : Game
    {
        protected List<GameObject> deck,centralPile;
        protected List<List<GameObject>> hands;

        protected Vector3 oldscale ;

        int cplayer = 0;
        int navigatedCardindex = 0;

        protected List<Vector3> playerrotations ; 

        protected List<List<Vector3>> handspostions ;
        protected float sum = 0.0f;
        protected Vector3 centralpileLocalpos = new Vector3(-1, 0, 0);
        protected List<Vector3> cardSpacing = new List<Vector3>(){};

        protected List<Vector3> pickposition = new List<Vector3>
            {
            };
        public CardGame(string name, int numberOfPlayers) : base(name, numberOfPlayers)
        {
            deck = new List<GameObject>();
            hands =new()
                {
                new List<GameObject> {},new List<GameObject> {},new List<GameObject> {},new List<GameObject> {},
                };
            centralPile = new List<GameObject>();
        }

        protected virtual void Assemble(List<GameObject> deck)
        {
            for (int i = 0; i < deck.Count; i++)
            {
                deck[i].transform.localPosition = new Vector3(0, 0, sum);
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
        protected virtual void MovetoPostion()
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

        public IEnumerator navigatedCards()
        {

            foreach (GameObject card in hands[cplayer])
                {
                    card.transform.localScale = oldscale;
                    card.GetComponent<Renderer>().material.color = Color.white;
                }
            if (Input.GetKeyDown(KeyCode.Q))
                {
                    navigatedCardindex =((navigatedCardindex - 1)+hands[cplayer].Count )% hands[cplayer].Count;
                }
            else if (Input.GetKeyDown(KeyCode.W))
                {
                    navigatedCardindex = (navigatedCardindex + 1) % hands[cplayer].Count;
                }

            GameObject navigatedCard = hands[cplayer][navigatedCardindex];
            navigatedCard.transform.localScale = oldscale * 1.5f;
            navigatedCard.GetComponent<Renderer>().material.color = Color.cyan;
            yield return null;
        }
        public virtual void throwCard(int player, int cardIndex)
        {
            if (cardIndex < 0 || cardIndex >= hands[player].Count)
            {
                Debug.LogWarning("Invalid card index!");
                return;
            }
            GameObject card = hands[player][cardIndex];
            hands[player].RemoveAt(cardIndex);
            centralPile.Add(card);
            card.transform.localPosition = centralpileLocalpos;
        }
        


    }
} 