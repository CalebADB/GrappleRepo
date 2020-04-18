using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "_GroundToRise", menuName = "Abilities/Ground/GroundToRise")]
    public class Ability_GroundToRise : StateData
    {
        [Range(0.001f, 0.1f)]
        public float energyBuildDuration;

        public override void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Initialise Speeds for state
            controller.setInputSpeed(Controller.SpeedY.jump);

            // Jump has been initiated so it can be turned off
            animator.SetBool(stateBase.getAnimatorHashCodes().jumping, false);
        }

        public override void updateAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Set input velocity
            changeVelocityX(animator, controller, stateBase.getAnimatorHashCodes());

            // Check if energy done building
            checkToExitState(animator, controller, stateBase.getAnimatorHashCodes(), stateInfo.normalizedTime, energyBuildDuration);
        }

        public override void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // accelerate off ground
            controller.envVelocity.y = controller.stateSpeed.y;

            // Set environment
            controller.env = Controller.EnvState.Air;
            animator.SetInteger(stateBase.getAnimatorHashCodes().environment, Controller.EnvState.Air.GetHashCode());

            animator.SetBool(stateBase.getAnimatorHashCodes().energyBuilt, false);
        }
    }
}