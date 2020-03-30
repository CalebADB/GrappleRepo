using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class PlayerCharacter : MonoBehaviour
    {
        // player input
        public bool moveRight;
        public bool moveLeft;
        public bool rise;

        public float moveSpeed;
        public float jumpSpeed;
        public float riseSpeed;

        // Character Environment
        public enum EnvState
        {
            Grounded,
            Aerial,
            Verticals,
            Subaqueous
        }
        public EnvState env;

        // player physics
        public Vector2 inputVelocity;
        public Vector2 envVelocity;
        public Vector2 playerVelocity;

        // Sprite Direction
        public Vector2 spriteScale;

        // TEMPORARY GRAVITY LOCATION
        public float gravity;

        // Animation
        private Animator animator;
        public int paraVelocityX;
        public int paraVelocityY;
        public int paraMove;
        public int paraRise;
        public int paraEnergyBuilt;
        public int paraEnvironmentSelection; 

        private void Awake()
        {
            paraVelocityX = Animator.StringToHash("VelocityX");
            paraVelocityY = Animator.StringToHash("VelocityY");
            paraMove = Animator.StringToHash("Move");
            paraRise = Animator.StringToHash("Rise");
            paraEnergyBuilt = Animator.StringToHash("EnergyBuilt");
            paraEnvironmentSelection = Animator.StringToHash("EnvironmentSelection");
        }

        void Update()
        {
            // Physics: 
            // Enviromental velocity
            switch (env)
            {
                case EnvState.Grounded:
                    break;
                case EnvState.Aerial:
                    envVelocity.y += gravity * Time.deltaTime;
                    Debug.Log("I'm in the air!");
                    break;
                case EnvState.Verticals:
                    break;
                case EnvState.Subaqueous:
                    break;
                default:
                    Debug.Log("Enviroment Missing");
                    break;
            }

            //Displacement
            playerVelocity = envVelocity + inputVelocity;
            this.gameObject.transform.Translate(playerVelocity * Time.deltaTime);
            inputVelocity.Set(0f, 0f);

            // Animation:
            // Prep
            animator = getAnimator();
            // Update Parameters
            animator.SetFloat(paraVelocityX, playerVelocity.x);
            animator.SetFloat(paraVelocityY, playerVelocity.y);

            // player sprite direction
            if (moveRight && !moveLeft)
            {
                spriteScale.x = Mathf.Abs(spriteScale.x);
            }
            else if (!moveRight && moveLeft)
            {
                spriteScale.x = -Mathf.Abs(spriteScale.x);
            }
            this.gameObject.transform.localScale = spriteScale;
        }

        public Animator getAnimator()
        {
            if (animator == null)
            {
                animator = this.GetComponentInParent<Animator>();
            }
            return animator;
        }
    }
}

