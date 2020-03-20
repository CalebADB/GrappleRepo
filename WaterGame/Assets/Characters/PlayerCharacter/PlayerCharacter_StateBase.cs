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
        public void updateAbilities(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator)
        {
            foreach (StateData ability in abilities)
            {
                ability.updateAbility(playerCharacter_StateBase, animator);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            updateAbilities(this, animator);
        }

    }
}
