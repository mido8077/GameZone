using UnityEngine;
using GameSystem;
using System.Collections.Generic;
using System.Threading;
public class Screw :CardGame
{
    string prefabpath = "Prefabs/Screw_CardDeck";
    public Screw() : base("Screw", 4)
    {
        collectprefabs(prefabpath);
        playerPositions = new List<List<Vector3>>
            {
                new()
                {
                    new Vector3(0.12f, 0, 2.3f), new Vector3(-1, 0, 2.3f),new Vector3(0.12f, 0, 3.9f), new Vector3(-1, 0, 3.9f),
                },
                new()
                {
                    new Vector3(-2.9f, 0, 0.6f),new Vector3(-2.9f, 0, -0.5f),new Vector3(-4.5f, 0, 0.6f),new Vector3(-4.5f, 0, -0.5f)
                },
                new()
                {
                    new Vector3(0.12f, 0, -2.3f),new Vector3(-1, 0, -2.3f),new Vector3(0.12f, 0, -3.9f),new Vector3(-1, 0, -3.9f)
                },
                new()
                {
                    new Vector3(2f, 0, 0.6f),new Vector3(2f, 0, -0.5f),new Vector3(3.5f, 0, 0.6f),new Vector3(3.5f, 0, -0.5f)
                },
          };
          DealCards(4);
          movetopostion();
    }
    public override void DealCards(int numberofcards)
    {
        base.DealCards(numberofcards);
        centralPile.Add(deck[deck.Count - 1]);
        deck.RemoveAt(deck.Count - 1);
        Assemble(centralPile);

    }
    protected override void movetopostion() 
    {
        base.movetopostion();
        centralPile[0].transform.localPosition = centralpileLocalpos;
        centralPile[0].transform.Rotate(0, 180, 0);
    }

    
    
    

    
    

    
}
