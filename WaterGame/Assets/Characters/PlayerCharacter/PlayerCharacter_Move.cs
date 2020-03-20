using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Move")]
    public class PlayerCharacter_Move : StateData
    {
        //      override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //      {
        //          moveSpeed = getPlayerCharacter(animator).moveSpeed;
        //      }
        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator)
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
    }
}