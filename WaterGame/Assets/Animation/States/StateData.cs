using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace masterFeature
{
    public abstract class StateData : ScriptableObject
    {
        public float duration;

        public abstract void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void updateAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo);


        public void checkToInitMove(Controller controller, Animator animator)
        {
            if (controller.moveRight ^ controller.moveLeft)
            {
                animator.SetBool(controller.paraMoving, true);
            }
        }

        public void checkToInitJump(Controller controller, Animator animator)
        {
            if (controller.rise)
            {
                animator.SetBool(controller.paraJumping, true);
            }
        }

        public void checkToInitCrouch(Controller controller, Animator animator)
        {
            Debug.Log("Im an empty function:)");
        }

        public void changeVelocityX(Controller controller, Animator animator)
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

        public void changeVelocityY(Controller controller, Animator animator)
        {
            if (controller.rise)
            {
                controller.inputVelocity.y = controller.stateSpeed.y;
            }
        }

        public void checkToExitMove(Controller controller, Animator animator)
        {
            if (!controller.moveRight ^ controller.moveLeft)
            {
                animator.SetBool(controller.paraMoving, false);
            }
        }

        public void checkToExitState(Controller controller, Animator animator, float timePassed, float duration)
        {
            if (timePassed >= duration)
            {
                animator.SetBool(controller.paraEnergyBuilt, true);
            }
        }
    }
}
