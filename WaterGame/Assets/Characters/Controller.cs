using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [RequireComponent(typeof(LocalPhysicsEngine), typeof(Animator))]
    public class Controller : MonoBehaviour
    {
        // Debug
        public int debugInt;
        public int debugBool;

        // Input
        public bool moveRight;
        public bool moveLeft;
        public bool rise;

        // Environment
        public enum EnvState
        {
            Empty,
            Water,
            Ground,
            Hang,
            Air
        }
        public EnvState env;

        // Physics:
        // Prep
        public LocalPhysicsEngine localPhysicsEngine;

        // Animation:
        // Prep
        private Animator animator;

        // Sprite Direction
        public Vector2 spriteScale;

        // HashCodes
        public AnimatorHashCodes animatorHashCodes;

        private void Start()
        {
            localPhysicsEngine = getLocalPhysicsEngine();
            animator = getAnimator();
        }

        private void Update()
        {
            // Physics

            localPhysicsEngine.updateEngine();

            // Animation
            updateAnimatorParameters();

            //Debug
            //Debug.Log("debugInt" + debugInt)

            // Reset
            localPhysicsEngine.frameReset();
        }

        public Vector2 calculateInputVelocity()
        {
            return Vector2.zero;
        }

        public LocalPhysicsEngine getLocalPhysicsEngine()
        {
            if (localPhysicsEngine == null)
            {
                localPhysicsEngine = this.GetComponentInParent<LocalPhysicsEngine>();
            }
            return localPhysicsEngine;
        }

        public Animator getAnimator()
        {
            if (animator == null)
            {
                animator = this.GetComponentInParent<Animator>();
            }
            return animator;
        }

        public void updateAnimatorParameters()
        {
            LocalCollisionManager.CollisionData collisionData = localPhysicsEngine.localCollisionManager.collisionData;
            if (collisionData.vertCollision && (collisionData.vertCollisionDistance < -0.000001))
            {
                Debug.Log("down" + collisionData.vertCollisionDistance);
                animator.SetBool(animatorHashCodes.collidedDown, true);
            }
            else if (collisionData.vertCollision && (collisionData.vertCollisionDistance > 0.000001))
            {
                Debug.Log("up" + collisionData.vertCollisionDistance);
                animator.SetBool(animatorHashCodes.collidedUp, true);
            }
            else
            {
                animator.SetBool(animatorHashCodes.collidedUp, false);
                animator.SetBool(animatorHashCodes.collidedDown, false);
            }

            animator.SetFloat(animatorHashCodes.velocityX, localPhysicsEngine.velocity.x);
            animator.SetFloat(animatorHashCodes.velocityY, localPhysicsEngine.velocity.y);

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
    }
}

