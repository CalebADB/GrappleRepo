using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [RequireComponent(typeof(CollisionManager))]
    public class Controller : MonoBehaviour
    {
        // Debug
        public int debugInt;
        
        // Environment
        public enum EnvState
        {
            Water,
            Ground,
            Hang,
            Air
        }
        public EnvState env;

        // Physics:
        // Prep
        public PhysicsEngine physicsEngine;

        // Collision Manager
        public CollisionManager collisionManager;

        // Input
        public bool moveRight;
        public bool moveLeft;
        public bool rise;

        // Speeds
        public enum SpeedX
        {
            newSpeed,
            idle,
            walk, 
            run,  
            crawl,
            slide,
            air
        }
        public Dictionary_SpeedXfloat SpeedXs = new Dictionary_SpeedXfloat();        
        public enum SpeedY
        {
            newSpeed,
            idle,
            jump,
            rise
        }
        public Dictionary_SpeedYfloat SpeedYs = new Dictionary_SpeedYfloat();
        public Vector2 stateSpeed;

        // Velocity
        public Vector2 inputVelocity;
        public Vector2 envVelocity;
        public Vector2 velocity;

        // displacement
        private Vector2 displacement;

        // Animation:
        // Prep
        private Animator animator;

        // Sprite Direction
        public Vector2 spriteScale;

        // HashCodes
        public AnimatorHashCodes animatorHashCodes;

        private void Start()
        {
            collisionManager = GetComponent<CollisionManager>();
            SpeedXs.Add(SpeedX.idle, 0.0f);
            SpeedXs.Add(SpeedX.walk, 2.0f);
            SpeedXs.Add(SpeedX.run,  3.5f);
            SpeedXs.Add(SpeedX.crawl,0.5f);
            SpeedXs.Add(SpeedX.slide,2.5f);
            SpeedXs.Add(SpeedX.air,  2.0f);

            SpeedYs.Add(SpeedY.idle, 0.0f);
            SpeedYs.Add(SpeedY.jump, 8.0f);
            SpeedYs.Add(SpeedY.rise, 2.5f);
        }

        private void Update()
        {
            debugInt++;
            // Physics: 
            // Enviromental velocity
            switch (env)
            {
                case EnvState.Water:
                    break;
                case EnvState.Ground:
                    envVelocity = physicsEngine.gravity.calculateGravity(this.transform.position) * Time.deltaTime;
                    break;
                case EnvState.Hang:
                    break;
                case EnvState.Air:
                    if (collisionManager.collisionData.vertCollision) { envVelocity.y = 0f; }
                    envVelocity += physicsEngine.gravity.calculateGravity(this.transform.position) * Time.deltaTime;
                    //Accelerate due to gravity
                    break;
                default:
                    Debug.Log("Enviroment Missing");
                    break;
            }

            // Calculate Velocity
            velocity = envVelocity + inputVelocity;

            // Calculate displacement
            displacement = velocity * Time.deltaTime;

            // Check for collisions
            displacement = collisionManager.updateManager(displacement);
            
            // Displace object
            this.gameObject.transform.Translate(displacement);


            // Animation:
            // Prep
            animator = getAnimator();
            // Update Parameters
            if (collisionManager.collisionData.vertCollision)
            {
                animator.SetBool(animatorHashCodes.grounded, collisionManager.collisionData.vertCollision);
            }
            
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


            //Reset
            inputVelocity.Set(0f, 0f);
            displacement.Set(0f, 0f);
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

