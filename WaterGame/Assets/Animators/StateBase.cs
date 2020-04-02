using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class StateBase : StateMachineBehaviour
    {
        private Controller controller;
        public Controller getController(Animator animator)
        {
            if (controller == null)
            {
                controller = animator.GetComponentInParent<Controller>();
            }
            return controller;
        }

        private AnimatorHashCodes animatorHashCodes;
        public AnimatorHashCodes getAnimatorHashCodes()
        {
            if (animatorHashCodes == null)
            {
                animatorHashCodes = GameObject.Find("HashCodes").GetComponent<AnimatorHashCodes>();
            }
            return animatorHashCodes;
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

        public void startAbilities(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach (StateData ability in abilities)
            {
                ability.enterAbility(stateBase, animator, stateInfo);
            }
        }

        public void updateAbilities(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach (StateData ability in abilities)
            {
                ability.updateAbility(stateBase, animator, stateInfo);
            }
        }

        public void exitAbilities(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            foreach (StateData ability in abilities)
            {
                ability.exitAbility(stateBase, animator, stateInfo);
            }
        }
    }
}
