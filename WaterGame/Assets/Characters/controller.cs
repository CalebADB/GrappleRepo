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
            Grounded,
            Aerial,
            Verticals,
            Subaqueous
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
            duck,
            slide
        }
        public Dictionary<SpeedX, float> SpeedXs = new Dictionary<SpeedX, float>()
        {
            {SpeedX.idle, 0.0f },
            {SpeedX.walk, 1.0f },
            {SpeedX.run, 2.0f  },
            {SpeedX.duck, 0.5f },
            {SpeedX.slide, 2.5f}

        };

        public enum SpeedY
        {
            idle,
            jump,
            rise
        }
        public Dictionary<SpeedY, float> SpeedYs = new Dictionary<SpeedY, float>()
        {
            {SpeedY.idle, 0.0f },
            {SpeedY.jump, 6.0f },
            {SpeedY.rise, 5.0f  }
        };
        public Vector2 stateSpeed;

        // Velocity
        public Vector2 inputVelocity;
        public Vector2 envVelocity;
        public Vector2 velocity;

        // Animation
        // prep
        private Animator animator;

        // Hashcodes
        public int paraEnvironment;
        public int paraVelocityX;
        public int paraVelocityY;
        public int paraMove;
        public int paraJump;
        public int paraRise;
        public int paraEnergyBuilt;

        // Sprite Direction
        public Vector2 spriteScale;

        private void Awake()
        {
            paraEnvironment = Animator.StringToHash("Environment");
            paraVelocityX = Animator.StringToHash("VelocityX");
            paraVelocityY = Animator.StringToHash("VelocityY");
            paraMove = Animator.StringToHash("Move");
            paraJump = Animator.StringToHash("Jump");
            paraRise = Animator.StringToHash("Rise");
            paraEnergyBuilt = Animator.StringToHash("EnergyBuilt");
        }

        void Update()
        {
            // Physics: 
            // Enviromental velocity
            switch (env)
            {
                case EnvState.Grounded:
                    envVelocity.y = 0;
                    break;
                case EnvState.Aerial:
                    envVelocity.y += gravity * Time.deltaTime;
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
            velocity = envVelocity + inputVelocity;
            this.gameObject.transform.Translate(velocity * Time.deltaTime);
            //Reset Input
            inputVelocity.Set(0f, 0f);

            // Animation:
            // Prep
            animator = getAnimator();
            // Update Parameters
            animator.SetFloat(paraVelocityX, velocity.x);
            animator.SetFloat(paraVelocityY, velocity.y);

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

