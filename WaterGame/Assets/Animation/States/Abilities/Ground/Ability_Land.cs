using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Grounded/Land")]
    public class Ability_Land : StateData
    {
        [Range(0.001f, 0.1f)]
        public float energyBuildDuration;

        public override void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Initialise Speeds for state
            controller.setInputSpeed(Controller.SpeedY.idle);

            // Set environment
            controller.env = Controller.EnvState.Ground;
            animator.SetInteger(controller.paraEnvironment, Controller.EnvState.Ground.GetHashCode());

            // hit ground
            controller.envVelocity.y = 0;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(StateBase playerStateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = playerStateBase.getController(animator);

            // Check if energy done building
            checkToExitState(controller, animator, stateInfo.normalizedTime, energyBuildDuration);
        }

        public override void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);
            
            // Energy released
            animator.SetBool(controller.paraEnergyBuilt, false);
        }
    }
}