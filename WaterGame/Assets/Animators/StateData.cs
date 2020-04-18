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
                controller.setInputSpeed(Controller.SpeedY.jump);

                controller.envVelocity.y = controller.stateSpeed.y;

                // Set environment
                controller.env = Controller.EnvState.Air;
                animator.SetInteger(animatorHashCodes.environment, Controller.EnvState.Air.GetHashCode());
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

        public void checkToExitMove(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            if (!controller.moveRight ^ controller.moveLeft)
            {
                animator.SetBool(animatorHashCodes.moving, false);
            }
        }
    }
}
