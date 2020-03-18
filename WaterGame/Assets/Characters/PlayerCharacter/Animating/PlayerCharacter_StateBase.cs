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
    }
}
