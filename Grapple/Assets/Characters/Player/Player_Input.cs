using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class Player_Input : MonoBehaviour
    {
        private Player_Controller player;
        public enum GameStates
        {
            MainMenu,
            Play,
            Inventory
        }
        public GameStates gameState;
        
        private void Awake()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length == 1)
            {
                player = players[0].GetComponentInChildren<Player_Controller>();
            }
            else { Debug.Log("More then one object with player tag"); };
        }

        void Update()
        {
            switch (gameState)
            {
                case GameStates.Play:
                    
                    if (VirtualInputManager.Instance.right)
                    {
                        player.moveRight = true;
                    }
                    else
                    {
                        player.moveRight = false;
                    }
                    if (VirtualInputManager.Instance.left)
                    {
                        player.moveLeft = true;
                    }
                    else
                    {
                        player.moveLeft = false;
                    }
                    if (VirtualInputManager.Instance.up)
                    {
                        player.rise = true;
                    }
                    else
                    {
                        player.rise = false;
                    }
                    if (VirtualInputManager.Instance.down)
                    {
                        player.drop = true;
                    }
                    else
                    {
                        player.drop = false;
                    }
                    break;
            }
        }
    }
}
