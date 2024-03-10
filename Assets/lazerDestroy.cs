using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerDestroy : StateMachineBehaviour
{
    public static LazerDestroy lazerDestroy;
    [SerializeField] LazerControl lazerControl;
    [SerializeField] Transform positionL;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lazerControl = GameObject.Find("Lazer_0(Clone)").GetComponent<LazerControl>();
        positionL = GameObject.Find("Lazer_Point").transform;

        if (lazerDestroy == null)
        {
            lazerDestroy = this;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (lazerControl.activePosition == false)
        {
            animator.transform.position = animator.transform.position = positionL.position;
        }
        if (lazerControl.activePosition == true)
        {
            animator.transform.position = animator.transform.position = new Vector3(positionL.position.x, positionL.position.y - 7, positionL.position.z);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lazerControl.DestroyLazer();
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
