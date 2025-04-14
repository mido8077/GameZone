using UnityEngine;

namespace GameSystem
{
    public class DominosGameManager:GameManager
    {
        Dominos dominos;
        //enum Gamestate gamestate ={navitgaing,choosing}

        public void Start() 
        {
            dominos = new Dominos();
            currentTurn=firstplayer();
            Debug.Log("Current turn: " + currentTurn);
        }
        public int firstplayer()
        {
            for(int i=0;i<dominos.hands.Count;i++)
            {
                for(int j=0;j<dominos.hands[i].Count;j++)
                {
                    if(dominos.hands[i][j].name=="Domino_6-6")
                    {
                        Debug.Log("Player " + i + " has 6-6");
                        return i;
                    }
                }
            }
            Debug.Log("No player has 6-6");
            return -1;
        }
        public void Update()
        {
            if(dominos.gamestate=="navigating")
            StartCoroutine(dominos.navigatedCards(currentTurn));

            if (Input.GetKeyDown(KeyCode.Return)||dominos.gamestate=="choosing")
            {
                if(dominos.centralPile.Count!=0)
                StartCoroutine(dominos.firstorlast());

                if(dominos.gamestate=="navigating")
                {
                int x =dominos.centralPile.Count;
                Debug.Log("Central pile count: " + x);
                dominos.throwCard(currentTurn,0,dominos.where);
                    if(x<dominos.centralPile.Count)
                    {
                        currentTurn=NextTurn(dominos.numberOfPlayers);
                        dominos.gamestate="navigating";
                    }  
                }
            }
        }  
    }
} 

