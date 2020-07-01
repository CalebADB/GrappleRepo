using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "_Move", menuName = "Abilities/Ground/Move")]
    public class Ability_Move : StateData
    {
        public override void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);
            // reset state parameters
            animator.SetBool(stateBase.getAnimatorHashCodes().jumping, false);
        }

        public override void updateAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Can initiate Jump
            checkToJump(animator, controller, stateBase.getAnimatorHashCodes());

            // Check to return to idle
            checkToIdle(animator, controller, stateBase.getAnimatorHashCodes());
        }

        public override void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}