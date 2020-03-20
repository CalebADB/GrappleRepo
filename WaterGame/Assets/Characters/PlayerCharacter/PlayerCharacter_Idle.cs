using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Idle")]
    public class PlayerCharacter_Idle : StateData
    {
//        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//        {
//            getPlayerCharacter(animator).velocity.x = 0;
//        }

        public override void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator)
        {
            PlayerCharacter playerCharacter = playerCharacter_StateBase.getPlayerCharacter(animator);

            if (playerCharacter.moveRight ^ playerCharacter.moveLeft)
            {
                animator.SetBool("Move", true);
            }
        }
    }
}
