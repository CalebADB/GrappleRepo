using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Aerial/Rise")]
    public class PlayerCharacter_Rise : StateData
    {
        public override void enterAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = playerCharacter_StateBase.getController(animator);

            // Initialise Speeds for state
            controller.setInputSpeed(Controller.SpeedY.rise);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = playerCharacter_StateBase.getController(animator);

            // Set input velocity
            changeVelocityX(controller, animator);
            changeVelocityY(controller, animator);
        }

        public override void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}