using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "_GroundToFall", menuName = "Abilities/Ground/GroundToFall")]
    public class Ability_GroundToFall : StateData
    {
        public override void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void updateAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Set environment
            controller.env = Controller.EnvState.Air;
            animator.SetInteger(stateBase.getAnimatorHashCodes().environment, Controller.EnvState.Air.GetHashCode());
        }
    }
}