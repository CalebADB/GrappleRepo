using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class PlayerCharacter : MonoBehaviour
    {
        public float moveSpeed;
        public Vector2 velocity;
        public Vector2 spriteScale;


        void Update()
        {
            if (VirtualInputManager.Instance.moveRight && !VirtualInputManager.Instance.moveLeft)
            {
                this.gameObject.transform.Translate(velocity * Time.deltaTime);
                this.gameObject.transform.localScale = spriteScale;
            }

            else if (!VirtualInputManager.Instance.moveRight && VirtualInputManager.Instance.moveLeft)
            {
                this.gameObject.transform.Translate(velocity * Time.deltaTime);
                this.gameObject.transform.localScale = spriteScale;
            }
        }
    }
}

