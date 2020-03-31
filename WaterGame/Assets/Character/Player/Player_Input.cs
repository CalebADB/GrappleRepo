using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class Player_Input : MonoBehaviour
    {
        private Player_Controller controller;

        private void Awake()
        {
            controller = this.gameObject.GetComponent<Player_Controller>();
        }

        void Update()
        {
            bool mainGame = true;
            if (mainGame)
            {
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
            }
        }
    }
}
