using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class PlayerCharacter_Input : MonoBehaviour
    {
        private PlayerCharacter playerCharacter;

        private void Awake()
        {
            playerCharacter = this.gameObject.GetComponent<PlayerCharacter>();
        }

        void Update()
        {
            bool mainGame = true;
            if (mainGame)
            {
                if (VirtualInputManager.Instance.right)
                {
                    playerCharacter.moveRight = true;
                }
                else
                {
                    playerCharacter.moveRight = false;
                }
                if (VirtualInputManager.Instance.left)
                {
                    playerCharacter.moveLeft = true;
                }
                else
                {
                    playerCharacter.moveLeft = false;
                }
                if (VirtualInputManager.Instance.up)
                {
                    playerCharacter.rise = true;
                }
                else
                {
                    playerCharacter.rise = false;
                }
            }
        }
    }
}
