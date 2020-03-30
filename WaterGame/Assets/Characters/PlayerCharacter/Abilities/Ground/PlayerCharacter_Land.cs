using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Grounded/Land")]
    public class PlayerCharacter_Land : StateData
    {
        [Range(0.001f, 0.1f)]
        public float energyBuildDuration;

        public override void enterAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = playerCharacter_StateBase.getController(animator);

            // Initialise Speeds for state
            controller.setInputSpeed(Controller.SpeedY.idle);

            // Set environment
            controller.env = Controller.EnvState.Grounded;
            animator.SetInteger(controller.paraEnvironment, Controller.EnvState.Grounded.GetHashCode());

            // hit ground
            controller.envVelocity.y = 0;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = playerCharacter_StateBase.getController(animator);

            // Check if energy done building
            checkToExitState(controller, animator, stateInfo.normalizedTime, energyBuildDuration);
        }

        public override void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = playerCharacter_StateBase.getController(animator);
            
            // Energy released
            animator.SetBool(controller.paraEnergyBuilt, false);
        }
    }
}