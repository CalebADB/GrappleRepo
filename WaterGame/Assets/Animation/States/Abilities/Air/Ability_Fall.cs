using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Aerial/Fall")]
    public class Ability_Fall : StateData
    {
        public override void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Initialise Speeds for state
            controller.setInputSpeed(Controller.SpeedY.rise);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Set input velocity
            changeVelocityX(controller, animator);
            changeVelocityY(controller, animator);
        }

        public override void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}