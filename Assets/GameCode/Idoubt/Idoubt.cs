using UnityEngine;
using GameSystem;
using System.Collections.Generic;
using System.Threading;
public class Idoubt :CardGame
{

    string prefabpath = "Prefabs/Card_Deck";
    public Idoubt() : base("Idoubt", 4)
    {
        oldscale = new Vector3(7f, 7f, 7f);
        GameObjects=prefabtoGamebojects(prefabpath);
        shuffledeck(GameObjects);
        DealCards();
        setupposition();
        MovetoPostion();


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
}