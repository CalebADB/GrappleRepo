using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Grounded/Idle")]
    public class Ability_Idle : StateData
    {
        public override void enterAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Initialise Speeds for state
            controller.setInputSpeed(Controller.SpeedX.idle, Controller.SpeedY.idle);
        }

        public override void updateAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = stateBase.getController(animator);

            // Can initiate Move
            checkToInitMove(controller, animator);

            // Can initiate Jump
            checkToInitJump(controller, animator);
        }

        public override void exitAbility(StateBase stateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
