using UnityEngine;
using Firebase.Database;
using Unity.Mathematics;
using System.Collections.Generic;
namespace GameSystem
{
    public class Game
    {
        protected string name;
        protected int numberOfPlayers;
        protected NetworkManager networkManager;
        
        protected DB_Manager db_manager;

        protected List<GameObject> GameObjects;
        

        public Game(string name, int numberOfPlayers)
        {
            this.name = name;
            this.numberOfPlayers = numberOfPlayers;
            networkManager = new NetworkManager();
            db_manager = new DB_Manager();

        }
        public virtual List<GameObject> prefabtoGamebojects(string path)
        {
        GameObject prefab;  
        List<GameObject> allObjectsInPrefab = new List<GameObject>();
        prefab = Resources.Load<GameObject>(path);

        if (prefab == null)
        {
            Debug.LogError("Prefab could not be loaded! Ensure it is inside a 'Resources' folder.");
            return null;
        }

        GameObject prefabInstance = GameObject.Instantiate(prefab);

        allObjectsInPrefab.Clear();

        foreach (Transform child in prefabInstance.transform)
        {
            allObjectsInPrefab.Add(child.gameObject);  // Add each child GameObject to the list
        }
        return allObjectsInPrefab;  
        }




    }
} 