using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class PlayerCharacter_Move : PlayerCharacter_StateBase
    {
        private float moveSpeed = 0f;
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            moveSpeed = getPlayerCharacter(animator).moveSpeed;
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!VirtualInputManager.Instance.moveRight && VirtualInputManager.Instance.moveLeft)
            {
                getPlayerCharacter(animator).velocity.x = -moveSpeed;
            }
            else if (VirtualInputManager.Instance.moveRight && !VirtualInputManager.Instance.moveLeft)
            {
                getPlayerCharacter(animator).velocity.x = moveSpeed;
            }
            else if (!VirtualInputManager.Instance.moveRight && !VirtualInputManager.Instance.moveLeft)
            {
                animator.SetBool("Move", false);
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}