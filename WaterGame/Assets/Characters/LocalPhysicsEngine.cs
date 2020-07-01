using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [RequireComponent(typeof(PhysicsEngine), typeof(LocalCollisionManager))]
    public class LocalPhysicsEngine : MonoBehaviour
    {
        // Prep
        private Controller parentController;
        public PhysicsEngine physicsEngine;
        public LocalCollisionManager localCollisionManager;
        public Controller.EnvState env = Controller.EnvState.Empty;

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

        // Start is called before the first frame update
        private void Start()
        {
            env = getController().env;
            localCollisionManager = GetComponent<LocalCollisionManager>();
            SpeedXs.Add(SpeedX.idle, 0.0f);
            SpeedXs.Add(SpeedX.walk, 2.0f);
            SpeedXs.Add(SpeedX.run, 3.5f);
            SpeedXs.Add(SpeedX.crawl, 0.5f);
            SpeedXs.Add(SpeedX.slide, 2.5f);
            SpeedXs.Add(SpeedX.air, 2.0f);

            SpeedYs.Add(SpeedY.idle, 0.0f);
            SpeedYs.Add(SpeedY.jump, 8.0f);
            SpeedYs.Add(SpeedY.rise, 0.4f);
        }

        // Update is called once per frame
        public void updateEngine()
        {
            // Enviromental velocity
            switch (env)
            {
                case Controller.EnvState.Empty:
                    Debug.Log("Environment is not set.");
                    break;
                case Controller.EnvState.Water:
                    break;
                case Controller.EnvState.Ground:
                    envVelocity.y = 0f;
                    break;
                case Controller.EnvState.Hang:
                    break;
                case Controller.EnvState.Air:
                    if (localCollisionManager.collisionData.vertCollision) { envVelocity.y = 0f; }
                    //Accelerate due to gravity
                    break;
                default:
                    Debug.Log("Enviroment Missing");
                    break;
            }
            envVelocity += physicsEngine.gravity.calculateGravity(this.transform.position) * Time.deltaTime;
            
            // Calculate Velocity
            velocity = envVelocity + inputVelocity;

            // Calculate displacement
            displacement = velocity * Time.deltaTime;

            // Collisions Management
            displacement = localCollisionManager.updateManager(displacement);
            if (localCollisionManager.collisionData.vertCollision)
            {
                Debug.Log("No Env collision velo code");
            }

            // Displace object
            this.gameObject.transform.Translate(displacement);
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

        public Controller getController()
        {
            if (parentController == null)
            {
                parentController = GetComponentInParent<Controller>();
            }
            return parentController;
        }

        public void frameReset()
        {
            inputVelocity.Set(0f, 0f);
            displacement.Set(0f, 0f);
        }
    }
}