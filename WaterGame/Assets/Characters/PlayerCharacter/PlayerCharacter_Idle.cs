using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Idle")]
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
                animator.SetBool("Move", true);
            }
        }

        public override void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
