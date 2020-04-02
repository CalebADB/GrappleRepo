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
        public int crouching;
        public int jumping;
        public int rising;
        public int holding;
        public int energyBuilt;

        private void Awake()
        {
            environment =   Animator.StringToHash("Environment");
            velocityX =     Animator.StringToHash("VelocityX");
            velocityY =     Animator.StringToHash("VelocityY");
            moving =        Animator.StringToHash("Moving");
            crouching =     Animator.StringToHash("Crouching");
            jumping =       Animator.StringToHash("Jumping");
            rising =        Animator.StringToHash("Rising");
            holding =       Animator.StringToHash("Holding");
            energyBuilt =   Animator.StringToHash("EnergyBuilt");
        }
    }
}
