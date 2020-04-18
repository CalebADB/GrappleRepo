using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace masterFeature
{
    public abstract class StateData : ScriptableObject
    {
        public abstract void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void updateAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo);

        public void checkToInitMove(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            if (controller.moveRight ^ controller.moveLeft)
            {
                animator.SetBool(animatorHashCodes.moving, true);
            }
        }
        public void checkToInitJump(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            if (controller.rise)
            {
                animator.SetBool(animatorHashCodes.jumping, true);
            }
        }
        public void checkToInitCrouch(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            Debug.Log("Im an empty function:)");
        }

        public void changeVelocityX(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            if (!controller.moveRight && controller.moveLeft)
            {
                controller.inputVelocity.x = -controller.stateSpeed.x;
            }
            else if (controller.moveRight && !controller.moveLeft)
            {
                controller.inputVelocity.x = controller.stateSpeed.x;
            }
        }
        public void changeVelocityY(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            if (controller.rise)
            {
                controller.inputVelocity.y = controller.stateSpeed.y;
            }
        }

        public void checkCeiling(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            Debug.Log("Im an empty function:)");
        }

        public void checkToExitState(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes, float timePassed, float duration)
        {
            if (timePassed >= duration)
            {
                animator.SetBool(animatorHashCodes.energyBuilt, true);
            }
        }
        public void checkToExitMove(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            if (!controller.moveRight ^ controller.moveLeft)
            {
                animator.SetBool(animatorHashCodes.moving, false);
            }
        }
    }
}
