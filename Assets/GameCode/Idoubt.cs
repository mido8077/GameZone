using UnityEngine;
using GameSystem;
using System.Collections.Generic;
using System.Threading;
public class Idoubt :CardGame
{

    string prefabpath = "Prefabs/Card_Deck";
    float[] Cardspacing =  {0.035f, 0.001f, 0};
    public Idoubt() : base("Idoubt", 4)
    {
        GameObjects=prefabtoGamebojects(prefabpath);
        shuffledeck(GameObjects);
        Assemble(deck);
        //setupposition();
    }
    public override void setupposition()
    {
            List<Vector3> cardSpacing = new List<Vector3>()
    {
        new Vector3(-0.034975f, 0.001f, 0),
        new Vector3(0.001f, -0.034975f, 0),
        new Vector3(-0.034975f, 0.001f, 0),
        new Vector3(0.001f, -0.034975f, 0),
    };

    handspostions = new List<List<Vector3>>()
    {
        new List<Vector3> { new Vector3(0.25f, -0.49f, 0.185f) },
        new List<Vector3> { new Vector3(-0.612f, 0.231f, 0.185f) },
        new List<Vector3> { new Vector3(0.25f, 0.49f, 0.185f) },
        new List<Vector3> { new Vector3(0.612f, 0.231f, 0.185f) }
    };
    }
}