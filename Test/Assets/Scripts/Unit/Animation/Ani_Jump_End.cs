using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani_Jump_End : StateMachineBehaviour
{
    UnitController unitController = null;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         animator.SetBool("MovePossible", false);
         animator.SetBool("Jump",false);

        if (unitController == null)
            unitController = animator.transform.parent.parent.GetComponent<UnitController>();
        unitController.Ani_Jump_End(UnitController.AniMotion.Enter);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("MovePossible", true);

        unitController.Ani_Jump_End(UnitController.AniMotion.Exit);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
