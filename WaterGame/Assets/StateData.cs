using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace masterFeature
{
    public abstract class StateData : ScriptableObject
    {
        public float duration;

        public abstract void enterAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo);


        public void checkToInitMove(Controller controller, Animator animator)
        {
            if (controller.moveRight ^ controller.moveLeft)
            {
                animator.SetBool(controller.paraMove, true);
            }
        }

        public void checkToInitJump(Controller controller, Animator animator)
        {
            if (controller.rise)
            {
                animator.SetBool(controller.paraJump, true);
            }
        }

        public void checkToInitDuck(Controller controller, Animator animator)
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
                animator.SetBool(controller.paraMove, false);
            }
        }

        public void checkToExitState(Controller controller, Animator animator, float timePassed, float duration)
        {
            Debug.Log(duration);
            Debug.Log(timePassed);
            if (timePassed >= duration)
            {
                animator.SetBool(controller.paraEnergyBuilt, true);
            }
        }
    }
}
