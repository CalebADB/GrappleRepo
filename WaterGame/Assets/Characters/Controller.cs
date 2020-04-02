using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class Controller : MonoBehaviour
    {
        // Environment
        public enum EnvState
        {
            Ground,
            Air,
            Vertical,
            Water
        }
        public EnvState env;

        // Physics:
        // TEMPORARY GRAVITY LOCATION // TEMPORARY GRAVITY LOCATION //
        public float gravity;

        // Input
        public bool moveRight;
        public bool moveLeft;
        public bool rise;

        // Speeds
        public enum SpeedX
        {
            idle,
            walk, 
            run,  
            crawl,
            slide
        }
        public Dictionary_SpeedXfloat SpeedXs = new Dictionary_SpeedXfloat();
        /*{
            {SpeedX.idle, 0.0f },
            {SpeedX.walk, 2.0f },
            {SpeedX.run, 3.5f  },
            {SpeedX.crawl, 0.5f },
            {SpeedX.slide, 2.5f}
        };
        */

        public enum SpeedY
        {
            idle,
            jump,
            rise
        }
        public Dictionary_SpeedYfloat SpeedYs = new Dictionary_SpeedYfloat();
        /*{
            {SpeedY.idle, 0.0f },
            {SpeedY.jump, 6.0f },
            {SpeedY.rise, 5.0f }
        };*/
        public Vector2 stateSpeed;

        // Velocity
        public Vector2 inputVelocity;
        public Vector2 envVelocity;
        public Vector2 velocity;

        // Animation
        // prep
        private Animator animator;

        // Sprite Direction
        public Vector2 spriteScale;

        // HashCodes
        public AnimatorHashCodes animatorHashCodes;

        private void Start()
        {
            animatorHashCodes = GameObject.FindWithTag("HashCodes").GetComponent<AnimatorHashCodes>();
        }

        void Update()
        {
            // Physics: 
            // Enviromental velocity
            switch (env)
            {
                case EnvState.Ground:
                    envVelocity.y = 0;
                    break;
                case EnvState.Air:
                    envVelocity.y += gravity * Time.deltaTime;
                    break;
                case EnvState.Vertical:
                    break;
                case EnvState.Water:
                    break;
                default:
                    Debug.Log("Enviroment Missing");
                    break;
            }

            //Displacement
            velocity = envVelocity + inputVelocity;
            this.gameObject.transform.Translate(velocity * Time.deltaTime);
            //Reset Input
            inputVelocity.Set(0f, 0f);

            // Animation:
            // Prep
            animator = getAnimator();
            // Update Parameters
            animator.SetFloat(animatorHashCodes.velocityX, velocity.x);
            animator.SetFloat(animatorHashCodes.velocityY, velocity.y);

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

        public void setInputSpeed(SpeedX speedX)
        {
            stateSpeed.x = SpeedXs[speedX];
        }
        public void setInputSpeed(SpeedY speedY)
        {
            stateSpeed.y = SpeedYs[speedY];
        }
        public void setInputSpeed(SpeedX speedX, SpeedY speedY)
        {
            stateSpeed.x = SpeedXs[speedX];
            stateSpeed.y = SpeedYs[speedY];
        }
    }
}

