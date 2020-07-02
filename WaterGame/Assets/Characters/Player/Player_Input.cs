using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class Player_Input : MonoBehaviour
    {
        private Player_Controller controller;
        public enum GameStates
        {
            MainMenu,
            Play,
            Inventory
        }
        public GameStates gameState;
        private void Awake()
        {
            GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
            if (player.Length == 1)
            {
                controller = player[0].GetComponentInChildren<Player_Controller>();
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
                        controller.moveRight = true;
                    }
                    else
                    {
                        controller.moveRight = false;
                    }
                    if (VirtualInputManager.Instance.left)
                    {
                        controller.moveLeft = true;
                    }
                    else
                    {
                        controller.moveLeft = false;
                    }
                    if (VirtualInputManager.Instance.up)
                    {
                        controller.rise = true;
                    }
                    else
                    {
                        controller.rise = false;
                    }
                    if (VirtualInputManager.Instance.down)
                    {
                        controller.drop = true;
                    }
                    else
                    {
                        controller.drop = false;
                    }
                    break;
            }
        }
    }
}
