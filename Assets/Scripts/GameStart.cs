using GameSystem;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Screw screw;
    Dominos dominos;
    Idoubt idoubt;
    void Start()
    {
        //screwGame = new Screw();
        //idoubtGame = new Idoubt();
        //StartCoroutine(game.navigatedCards());
        //screw = new Screw();
        //dominos = new Dominos();
        idoubt = new Idoubt();
        
    }   

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(screwGame.navigatedCards());
        //StartCoroutine(screw.navigatedCards());    //screw navigation
        //StartCoroutine(dominos.navigatedCards());
        StartCoroutine(idoubt.navigatedCards());
    }
}
