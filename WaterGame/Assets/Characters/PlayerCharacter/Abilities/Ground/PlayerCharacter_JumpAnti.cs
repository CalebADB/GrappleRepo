using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Grounded/JumpAnti")]
    public class PlayerCharacter_JumpAnti : StateData
    {
        [Range(0.01f, 1f)]
        public float energyBuildDuration;

        public override void enterAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerCharacter playerCharacter = playerCharacter_StateBase.getPlayerCharacter(animator);
            if (stateInfo.normalizedTime >= energyBuildDuration)
            {
                animator.SetBool(playerCharacter.paraEnergyBuilt, true);
            }
        }

        public override void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            PlayerCharacter playerCharacter = playerCharacter_StateBase.getPlayerCharacter(animator);
            playerCharacter.env = PlayerCharacter.EnvState.Aerial;
            playerCharacter.envVelocity.y = playerCharacter.jumpSpeed;
            Debug.Log(playerCharacter.envVelocity.y);

            //animator.SetBool("EnergyBuilt", false);
        }
    }
}