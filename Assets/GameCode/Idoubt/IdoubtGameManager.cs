using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
namespace GameSystem
{   
    public class IdoubtGameManager:GameManager
    {
    Idoubt idoubt;
    public List<GameObject> dropdownPrefab;

    bool doubtcall,isdoubt = false;
    public Transform parentCanvas;
    private Dropdown dropdownInstance;
    private bool isOpen = false;
    private int currentIndex = 0;
    public void Start()
    {
        idoubt = new Idoubt();
        dropdownPrefab = idoubt.prefabtoGamebojects("Prefabs/dropdown");
        Transform child = dropdownPrefab[0].transform.GetChild(0);
        dropdownInstance = child.gameObject.GetComponent<Dropdown>();
        currentTurn=firstplayer();
        idoubt.gamestate="start";
        dropdownPrefab[0].SetActive(false);
        if (dropdownPrefab == null)
        {
            Debug.LogError("Dropdown prefab or parentCanvas is not assigned!");
            return;
        }

        // Instantiate the dropdown
        if (dropdownInstance == null)
        {
            Debug.LogError("The prefab does not have a Dropdown component.");
            return;
        }

        currentIndex = dropdownInstance.value;
        HighlightOption(currentIndex);
        Debug.Log("current turn: " + currentTurn);
        
    }
    public void Update()
    {
        if(idoubt.gamestate=="end")
        {
            Debug.Log("Game Over");
            return;
        }
        Debug.Log("claim: " + idoubt.claim);
        if(idoubt.gamestate=="navigating" || idoubt.gamestate=="start")
        {
            if(dropdownPrefab[0].activeSelf)
            {
                dropdownPrefab[0].SetActive(false);
            }
            StartCoroutine(idoubt.navigatedCards(currentTurn));
            
            if(idoubt.gamestate=="start")
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    if(idoubt.hands[currentTurn][idoubt.navigatedCardindex].name=="Card_Heart-King")
                    {
                        idoubt.throwCard(currentTurn,idoubt.navigatedCardindex);
                        idoubt.gamestate="navigating";
                        idoubt.navigatedCardindex=0;
                        currentTurn=NextTurn(idoubt.numberOfPlayers);
                    }
                    else
                    {
                    Debug.Log("play the king of hearts");
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    {
                        idoubt.SelectCard(idoubt.navigatedCardindex,currentTurn);
                    }
            }
                if(Input.GetKeyDown(KeyCode.X))
                {
                    
                    doubtcall=true;
                    isdoubt=idoubt.doubt(currentTurn);
                    currentTurn=NextTurn(idoubt.numberOfPlayers);
                    
                }
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    idoubt.throwCards(currentTurn,idoubt.selectedCardsindex);
                    idoubt.selectedCardsindex.Clear();
                    currentTurn=NextTurn(idoubt.numberOfPlayers);
                }
                if(Input.GetKeyDown(KeyCode.P))
                {
                    currentTurn=NextTurn(idoubt.numberOfPlayers);
                }
        }
        else if(idoubt.gamestate=="claiming")
        {
            Debug.Log("claiming");
            dropdownPrefab[0].SetActive(true);
            if (dropdownInstance == null)
                return;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!isOpen)
                    OpenDropdown();
                else
                    dropdownMoveDown();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && isOpen)
            {
                dropdownMoveUp();
            }
            if ((Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)) && isOpen)
            {
                SelectOption();
            }
            if (Input.GetKeyDown(KeyCode.Escape) && isOpen)
            {
                CloseDropdown();
            }
        }
    }
    public override int firstplayer()
    {
        for(int i=0;i<idoubt.hands.Count;i++)
        {
            for(int j=0;j<idoubt.hands[i].Count;j++)
            {
                if(idoubt.hands[i][j].name=="Card_Heart-King")
                return i;
            }
        }
        return 0;
    }
    public override int NextTurn(int noOfPlayers)
    {
        if(doubtcall)
        {
            doubtcall=false;
            if(isdoubt)
            {
                return currentTurn;
            }
            else
            {
                return (currentTurn -1) % noOfPlayers;
            }
        }
        return (currentTurn + 1) % noOfPlayers;
    }
     
    void OpenDropdown()
    {
        isOpen = true;
        dropdownInstance.Show();
        HighlightOption(currentIndex);
    }

    void dropdownMoveDown()
    {
        currentIndex = (currentIndex + 1) % dropdownInstance.options.Count;
        HighlightOption(currentIndex);
    }

    void dropdownMoveUp()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = dropdownInstance.options.Count - 1;

        HighlightOption(currentIndex);
    }

    void HighlightOption(int index)
    {
        dropdownInstance.captionText.text = dropdownInstance.options[index].text;
    }

    void SelectOption()
    {
        dropdownInstance.value = currentIndex;
        dropdownInstance.Hide();
        dropdownInstance.onValueChanged.Invoke(currentIndex);
        isOpen = false;
        idoubt.gamestate="navigating";
        idoubt.claim=dropdownInstance.options[currentIndex].text;
    }

    void CloseDropdown()
    {
        dropdownInstance.Hide();
        isOpen = false;
        currentIndex = dropdownInstance.value; // Reset highlight
        HighlightOption(currentIndex);
    }

    }
    
}

