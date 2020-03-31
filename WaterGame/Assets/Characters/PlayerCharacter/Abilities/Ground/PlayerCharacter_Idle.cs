using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace masterFeature
{
    [CreateAssetMenu(fileName = "New File", menuName = "Abilities/Grounded/Idle")]
    public class PlayerCharacter_Idle : StateData
    {
        public override void enterAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = playerCharacter_StateBase.getController(animator);

            // Initialise Speeds for state
            controller.setInputSpeed(Controller.SpeedX.idle, Controller.SpeedY.idle);
        }

        public override void updateAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {
            Controller controller = playerCharacter_StateBase.getController(animator);

            // Can initiate Move
            checkToInitMove(controller, animator);

            // Can initiate Jump
            checkToInitJump(controller, animator);
        }

        public override void exitAbility(PlayerCharacter_StateBase playerCharacter_StateBase, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }
}
