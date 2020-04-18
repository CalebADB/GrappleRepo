using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class AnimatorHashCodes : MonoBehaviour
    {
        public int environment;
        public int velocityX;
        public int velocityY;
        public int moving;
        public int jumping;
        public int crouching;
        public int objectHolding;
        public int objectImmovable;
        public int collidedUp;
        public int collidedDown;

        private void Awake()
        {
            environment     = Animator.StringToHash("Environment");
            velocityX       = Animator.StringToHash("VelocityX");
            velocityY       = Animator.StringToHash("VelocityY");
            moving          = Animator.StringToHash("Moving");
            jumping         = Animator.StringToHash("Jumping");
            crouching       = Animator.StringToHash("Crouching");
            objectHolding   = Animator.StringToHash("ObjectHolding");
            objectImmovable = Animator.StringToHash("ObjectImmovable");
            collidedUp      = Animator.StringToHash("CollidedUp");
            collidedDown    = Animator.StringToHash("CollidedDown");
        }   
    }
}
