using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Grounded/JumpAnti")]
    public class PlayerCharacter_JumpAnti : StateData
    {
        [Range(0.001f, 0.1f)]
        public float energyBuildDuration;

        public override void enterAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = playerCharacter_StateBase.getController(animator);

            // Initialise Speeds for state
            controller.setInputSpeed(Controller.SpeedY.jump);

            // Jump has been initiated so it can be turned off
            animator.SetBool(controller.paraJump, false);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = playerCharacter_StateBase.getController(animator);

            // Set input velocity
            changeVelocityX(controller, animator);

            // Check if energy done building
            checkToExitState(controller, animator, stateInfo.normalizedTime, energyBuildDuration);
        }

        public override void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = playerCharacter_StateBase.getController(animator);

            // Energy was released
            animator.SetBool(controller.paraEnergyBuilt, false);

            // accelerate off ground
            controller.envVelocity.y = controller.stateSpeed.y;
            
            // Set environment
            controller.env = Controller.EnvState.Aerial;
            animator.SetInteger(controller.paraEnvironment, Controller.EnvState.Aerial.GetHashCode());
        }
    }
}