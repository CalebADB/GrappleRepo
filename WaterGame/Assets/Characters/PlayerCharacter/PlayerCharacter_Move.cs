using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Move")]
    public class PlayerCharacter_Move : StateData
    {
        public override void enterAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerCharacter playerCharacter = playerCharacter_StateBase.getPlayerCharacter(animator);

            if (!playerCharacter.moveRight && playerCharacter.moveLeft)
            {
                playerCharacter.velocity.x = -playerCharacter.moveSpeed;
            }
            else if (playerCharacter.moveRight && !playerCharacter.moveLeft)
            {
                playerCharacter.velocity.x = playerCharacter.moveSpeed;
            }
            else if (playerCharacter.moveRight && playerCharacter.moveLeft)
            {
                playerCharacter.velocity.x = 0f;
            }
            else
            {
                animator.SetBool("Move", false);
            }
        }

        public override void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}