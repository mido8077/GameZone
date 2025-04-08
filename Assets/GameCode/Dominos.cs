using UnityEngine;
using GameSystem;
using System.Collections.Generic;
using System.Threading;
public class Dominos:CardGame
{
    float[] coordinates = { -0.405f, -0.24f, -0.405f, -0.24f };

    public Dominos():base("Dominos",4)
    {
        playerrotations = new List<Vector3> 
        {
            new Vector3(0, 0, 0), new Vector3(0, 90, 0), new Vector3(0, 180, 0), new Vector3(0, -90, 0)
        };
        handspostions= new() 
        {
        new List<Vector3> {new Vector3(-0.405f, 0, 0.571f) },
        new List<Vector3> {new Vector3(0.5f, 0, -0.24f) },
        new List<Vector3> {new Vector3(-0.405f, 0, -0.571f) },
        new List<Vector3> {new Vector3(-0.5f, 0, 0.24f) },
        };
        GameObjects=prefabtoGamebojects("Prefabs/DominoTable");
        shuffledeck(GameObjects);
        DealCards();
        setupposition();
        movetopostion();
    }
    public override void setupposition()
    {
    for (int i = 0; i < hands.Count; i++)
        {
            for (int j = 0; j < hands[i].Count; j++)
            {
                
                
                coordinates[i] += 0.1f;
                if (i == 0)
                {
                    handspostions[i].Add(new Vector3(coordinates[i], 0, 0.571f)); 
                }
                else if (i == 1)
                {
                    handspostions[i].Add(new Vector3(0.5f, 0, coordinates[i]));
                }
                else if (i == 2)
                {
                    handspostions[i].Add(new Vector3(coordinates[i], 0, -0.571f));
                }
                else
                {
                    handspostions[i].Add(new Vector3(-0.5f, 0, coordinates[i]));
                }

            }


        }


    }


        
    }
    

