using UnityEngine;

namespace GameSystem
{
    public class GameManager:MonoBehaviour
    {
        private int currentTurn;

        public GameManager()
        {

        }

        public virtual void StartGame()
        {

        }

        public virtual void EndGame()
        {
            
        }
        public virtual void playerturn(int player)
        {

        }

        public virtual void NextTurn(int noOfPlayers)
        {
            currentTurn= (currentTurn + 1) % noOfPlayers;
        }

    }
} 