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
            if (VirtualInputManager.Instance.moveRight)
            {
                playerCharacter.moveRight = true;
            }
            else
            {
                playerCharacter.moveRight = false;
            }
            if (VirtualInputManager.Instance.moveLeft)
            {
                playerCharacter.moveLeft = true;
            }
            else
            {
                playerCharacter.moveLeft = false;
            }
        }
    }
}
