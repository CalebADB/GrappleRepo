using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Grounded/Move")]
    public class Ability_Move : StateData
    {
        public override void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Initialise Speeds for state
            controller.setInputSpeed(Controller.SpeedX.run, Controller.SpeedY.idle);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Set input velocity
            changeVelocityX(animator, controller, stateBase.getAnimatorHashCodes());

            // Can return to idle
            checkToExitMove(animator, controller, stateBase.getAnimatorHashCodes());

            // Can initiate Jump
            checkToInitJump(animator, controller, stateBase.getAnimatorHashCodes());
        }

        public override void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}