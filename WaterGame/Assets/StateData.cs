using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace masterFeature
{
    public abstract class StateData : ScriptableObject
    {
        public float duration;

        public abstract void enterAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo);
        public abstract void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo);
    }
}
