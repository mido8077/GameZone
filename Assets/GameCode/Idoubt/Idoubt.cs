using UnityEngine;
using GameSystem;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
public class Idoubt :CardGame
{

    string prefabpath = "Prefabs/Card_Deck";
    string claim ="";
    public Idoubt() : base("Idoubt", 4)
    {
        oldscale = new Vector3(7f, 7f, 7f);
        GameObjects=prefabtoGamebojects(prefabpath);
        shuffledeck(GameObjects);
        DealCards();
        setupposition();
        MovetoPostion();
        selectedCardsindex = new List<int>();
        centralpileLocalpos = new List<Vector3> {new Vector3(0, 0, 0)};
        discard_pilespcaing= new List<Vector3> {new Vector3(0, 0, 0.005f)};

    }
    public override void setupposition()
    {
        cardSpacing = new List<Vector3>()
            {
                new Vector3(-0.034975f, 0.001f, 0)*6,
                new Vector3(0.001f, -0.034975f, 0)*6,
                new Vector3(-0.034975f, 0.001f, 0)*6,
                new Vector3(0.001f, -0.034975f, 0)*6,
            };
        playerrotations = new List<Vector3>
                {
                    new Vector3(-90, 0, 0), new Vector3(0, -90, -90), new Vector3(90,0 ,180 ), new Vector3(0,90, 90)
                };

        handspostions = new List<List<Vector3>>()
            {
                new List<Vector3> { new Vector3(0.25f, -0.49f, 0.3f)*5 },
                new List<Vector3> { new Vector3(-0.612f, 0.231f, 0.3f)*5 },
                new List<Vector3> { new Vector3(0.25f, 0.49f, 0.3f)*5 },
                new List<Vector3> { new Vector3(0.612f, 0.231f, 0.3f)*5},
            };
        for (int i = 0; i < hands.Count; i++)
            {
                for (int j = 0; j < hands[i].Count; j++)
                {
                    handspostions[i].Add(handspostions[i][handspostions[i].Count-1]+ cardSpacing[i]);
                }
            }
    }
    public void SelectCard(int index,int player)
    {
        if(selectedCardsindex.Count<4)
        {
            if (selectedCardsindex.Contains(index))
            {
                selectedCardsindex.Remove(index);
                hands[player][index].transform.localScale=oldscale;
                hands[player][index].GetComponent<Renderer>().material.color=Color.white;
            }
            else
            {
                selectedCardsindex.Add(index);
                hands[player][index].transform.localScale = oldscale*1.2f;
                hands[player][index].GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
        else
        {
            Debug.Log("You can't select more than 4 cards");
        }
    }
    public void throwCards(int player,List<int> cardsindex)
    {
        List<GameObject> cards = new List<GameObject>();
        for(int i=0;i<cardsindex.Count;i++)
        {
            cards.Add(hands[player][cardsindex[i]]);
        }
        for(int i=0;i<cards.Count;i++)
        {
            cards[i].transform.localScale = oldscale;
            cards[i].GetComponent<Renderer>().material.color=Color.white;
            throwCard(player,hands[player].IndexOf(cards[i]));
        } 

    }
    public void doubt()
    {
        
    }
    

}