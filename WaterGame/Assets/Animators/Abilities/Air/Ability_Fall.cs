using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "_Fall", menuName = "Abilities/Aerial/Fall")]
    public class Ability_Fall : StateData
    {
        public override void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Initialise Speeds for state
            controller.setInputSpeed(Controller.SpeedX.air);
            controller.setInputSpeed(Controller.SpeedY.rise);
            animator.SetBool(stateBase.getAnimatorHashCodes().grounded, false);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void updateAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);
            
            // Set input velocity
            changeVelocityX(animator, controller, stateBase.getAnimatorHashCodes());
            changeVelocityY(animator, controller, stateBase.getAnimatorHashCodes());

            // check for ground
            if (controller.collisionManager.collisionData.vertCollision)
            {
                animator.SetBool(stateBase.getAnimatorHashCodes().grounded, true);
            }
        }

        public override void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}