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

        public void checkToMove(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            if (controller.moveRight ^ controller.moveLeft)
            {
                animator.SetBool(animatorHashCodes.moving, true);
            }
        }

        public void checkToJump(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            if (controller.rise)
            {
                animator.SetBool(animatorHashCodes.jumping, true);
            }
        }
        public void checkToCrouch(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            Debug.Log("Im an empty function:)");
        }

        public void checkToIdle(Animator animator, Controller controller, AnimatorHashCodes animatorHashCodes)
        {
            if (!controller.moveRight ^ controller.moveLeft)
            {
                animator.SetBool(animatorHashCodes.moving, false);
            }
        }
    }
}
