using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani_Block_02 : StateMachineBehaviour
{
    UnitController unitController = null;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Block",2);

        if (unitController == null)
            unitController = animator.transform.parent.parent.GetComponent<UnitController>();
        unitController.Ani_Block_02(UnitController.AniMotion.Enter, animator);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 끝모션이 부자연스러워서 그냥 스킵함
        animator.SetInteger("Block", -1);

        unitController.Ani_Block_02(UnitController.AniMotion.Exit, animator);
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
