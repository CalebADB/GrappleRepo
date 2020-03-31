using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Grounded/JumpAnti")]
    public class Ability_JumpAnti : StateData
    {
        [Range(0.001f, 0.1f)]
        public float energyBuildDuration;

        public override void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Initialise Speeds for state
            controller.setInputSpeed(Controller.SpeedY.jump);

            // Jump has been initiated so it can be turned off
            animator.SetBool(controller.paraJumping, false);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Set input velocity
            changeVelocityX(controller, animator);

            // Check if energy done building
            checkToExitState(controller, animator, stateInfo.normalizedTime, energyBuildDuration);
        }

        public override void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Energy was released
            animator.SetBool(controller.paraEnergyBuilt, false);

            // accelerate off ground
            controller.envVelocity.y = controller.stateSpeed.y;
            
            // Set environment
            controller.env = Controller.EnvState.Air;
            animator.SetInteger(controller.paraEnvironment, Controller.EnvState.Air.GetHashCode());
        }
    }
}