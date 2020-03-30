using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Aerial/Rise")]
    public class PlayerCharacter_Rise : StateData
    {
        public override void enterAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerCharacter playerCharacter = playerCharacter_StateBase.getPlayerCharacter(animator);
            if (playerCharacter.rise)
            {
                playerCharacter.inputVelocity.y += playerCharacter.riseSpeed;
            }
            if (playerCharacter.playerVelocity.y <= 0f)
            {
                exitAbility(playerCharacter_StateBase, animator, stateInfo);
            }
        }

        public override void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}