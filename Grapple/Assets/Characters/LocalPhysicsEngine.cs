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

        // Speeds
        public enum SpeedXs
        {
            newSpeed,
            zero,
            walk,
            run,
            crawl,
            slide,
            air
        }
        public Dictionary_SpeedXfloat speedXDict = new Dictionary_SpeedXfloat();
        public enum SpeedYs
        {
            newSpeed,
            zero,
            jump,
            rise
        }
        public Dictionary_SpeedYfloat speedYDict = new Dictionary_SpeedYfloat();
        public Vector2 stateSpeed;

        // Velocity
        public Vector2 inputVelocity;
        public Vector2 envVelocity;
        public Vector2 velocity;

        // Acceleration
        public float antiGravity;

        // final displacement
        private Vector2 displacement;

        // Start is called before the first frame update
        private void Start()
        {
            localCollisionManager = GetComponent<LocalCollisionManager>();
            speedXDict.Add(SpeedXs.zero, 0.0f);
            speedXDict.Add(SpeedXs.walk, 2.0f);
            speedXDict.Add(SpeedXs.run, 3.5f);
            speedXDict.Add(SpeedXs.crawl, 0.5f);
            speedXDict.Add(SpeedXs.slide, 2.5f);
            speedXDict.Add(SpeedXs.air, 2.0f);

            speedYDict.Add(SpeedYs.zero, 0.0f);
            speedYDict.Add(SpeedYs.jump, 5.0f);
            speedYDict.Add(SpeedYs.rise, 5.0f);
        }

        // Update is called once per frame
        public void updateEngine()
        {
            //setup
            frameReset();
            parentController = getController();

            // Calculate Velocity
            calculateInputVelocity();
            calculateEnvVelocity();
            velocity = envVelocity + inputVelocity;

            // Calculate displacement
            displacement = velocity * Time.deltaTime;

            // Collisions Management
            displacement = localCollisionManager.checkDisplacement(displacement);
            if (localCollisionManager.collisionData.bottomCollision)
            {
                setStateSpeedY(SpeedYs.zero);
                parentController.env = Controller.EnvState.Ground;
            }
            if (localCollisionManager.collisionData.topCollision)
            {
                envVelocity.y = -inputVelocity.y;
            }

            // Displace object
            this.gameObject.transform.Translate(displacement);
        }

        private void setStateSpeedX(SpeedXs speedX)
        {
            stateSpeed.x = speedXDict[speedX];
        }
        private void setStateSpeedY(SpeedYs speedY)
        {
            stateSpeed.y = speedYDict[speedY];
        }
        private void setStateSpeed(SpeedXs speedX, SpeedYs speedY)
        {
            stateSpeed.x = speedXDict[speedX];
            stateSpeed.y = speedYDict[speedY];
        }

        public Controller getController()
        {
            if (parentController == null)
            {
                parentController = GetComponentInParent<Controller>();
            }
            return parentController;
        }

        public void calculateInputVelocity()
        {
            switch (parentController.env)
            {
                case Controller.EnvState.Empty:
                    Debug.Log("Environment is not set.");
                    break;
                case Controller.EnvState.Water:
                    break;
                case Controller.EnvState.Ground:
                    setStateSpeed(SpeedXs.run, SpeedYs.zero);
                    if (parentController.rise)
                    {
                        envVelocity.y += speedYDict[SpeedYs.jump];
                        parentController.env = Controller.EnvState.Air;
                    }
                    break;
                case Controller.EnvState.Hang:
                    break;
                case Controller.EnvState.Air:
                    setStateSpeedY(SpeedYs.rise);
                    break;
                default:
                    Debug.Log("Enviroment Missing");
                    break;
            }

            if (parentController.rise) { inputVelocity.y = stateSpeed.y; }
            if (parentController.moveRight ^ parentController.moveLeft)
            {
                if (parentController.moveRight) { inputVelocity.x = stateSpeed.x ; }
                else { inputVelocity.x = -stateSpeed.x; }
            }
        }
        private void calculateEnvVelocity()
        {
            switch (parentController.env)
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
                    //Accelerate due to gravity
                    break;
                default:
                    Debug.Log("Enviroment Missing");
                    break;
            }
            envVelocity += physicsEngine.gravity.calculateGravity(this.transform.position) * Time.deltaTime;
        }

        private void frameReset()
        {
            inputVelocity.Set(0f, 0f);
            displacement.Set(0f, 0f);
        }
    }
}