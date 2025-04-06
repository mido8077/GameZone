using UnityEngine;
using Firebase.Database;
using Unity.Mathematics;

namespace GameSystem
{
    public class Game
    {
        protected string name;
        protected int numberOfPlayers;
        protected NetworkManager networkManager;
        
        protected DB_Manager db_manager;
        
        protected GameManager gameManager;


        public Game(string name, int numberOfPlayers)
        {
            this.name = name;
            this.numberOfPlayers = numberOfPlayers;
            networkManager = new NetworkManager();
            db_manager = new DB_Manager();
            gameManager = new GameManager();

        }




    }
} 