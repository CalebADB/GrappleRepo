using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/EnvironmentSelection")]
    public class PlayerCharacter_EnvironmentSelection : StateData
    {
        public override void enterAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        public override void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerCharacter playerCharacter = playerCharacter_StateBase.getPlayerCharacter(animator);
            animator.SetInteger(playerCharacter.paraEnvironmentSelection, playerCharacter.env.GetHashCode());
        }

        public override void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
