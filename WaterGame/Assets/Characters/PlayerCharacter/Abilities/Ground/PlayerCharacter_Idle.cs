using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Grounded/Idle")]
    public class PlayerCharacter_Idle : StateData
    {
        public override void enterAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }

        public override void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerCharacter playerCharacter = playerCharacter_StateBase.getPlayerCharacter(animator);

            if (playerCharacter.moveRight ^ playerCharacter.moveLeft)
            {
                animator.SetBool(playerCharacter.paraMove, true);
            }
            if (playerCharacter.rise)
            {
                animator.SetBool(playerCharacter.paraRise, true);
            }
        }

        public override void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
