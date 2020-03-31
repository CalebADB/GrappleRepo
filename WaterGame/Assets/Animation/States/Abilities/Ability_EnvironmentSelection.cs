using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/EnvironmentSelection")]
    public class Ability_EnvironmentSelection : StateData
    {
        public override void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void updateAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);
            animator.SetInteger(controller.paraEnvironment, controller.env.GetHashCode());
        }

        public override void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
