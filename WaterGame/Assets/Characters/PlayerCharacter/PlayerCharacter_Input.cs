using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class PlayerCharacter_Input : MonoBehaviour
    {
        private PlayerCharacter_Controller controller;

        private void Awake()
        {
            controller = this.gameObject.GetComponent<PlayerCharacter_Controller>();
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
