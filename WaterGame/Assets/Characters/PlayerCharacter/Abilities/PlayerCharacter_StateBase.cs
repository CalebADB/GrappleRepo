using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class PlayerCharacter_StateBase : StateMachineBehaviour
    {
        private PlayerCharacter playerCharacter;
        public PlayerCharacter getPlayerCharacter(Animator animator)
        {
            if (playerCharacter == null)
            {
                playerCharacter = animator.GetComponentInParent<PlayerCharacter>();
            }
            return playerCharacter;
        }


        public List<StateData> abilities = new List<StateData>();


        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            startAbilities(this, animator, stateInfo);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            updateAbilities(this, animator, stateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            exitAbilities(this, animator, stateInfo);
        }

        public void startAbilities(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach (StateData ability in abilities)
            {
                ability.enterAbility(playerCharacter_StateBase, animator, stateInfo);
            }
        }

        public void updateAbilities(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach (StateData ability in abilities)
            {
                ability.updateAbility(playerCharacter_StateBase, animator, stateInfo);
            }
        }

        public void exitAbilities(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach (StateData ability in abilities)
            {
                ability.exitAbility(playerCharacter_StateBase, animator, stateInfo);
            }
        }
    }
}
