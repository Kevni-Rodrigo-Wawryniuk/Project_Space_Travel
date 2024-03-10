using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idel : StateMachineBehaviour
{
    [SerializeField] Animator animator1;
    [SerializeField] int animatorValue;
    [SerializeField] float mayor, medio, menor, randomNumber;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator1 = animator;

        menor = 0.3f;
        medio = 0.6f;
        mayor = 1f;

        randomNumber = Random.Range(0f, 1.5f);

        // cuando el valor es menor
        if(randomNumber < mayor && randomNumber < medio)
        {
            animatorValue = 1;
        }
        // valor medio
        else if(randomNumber > menor && randomNumber >= medio && randomNumber < mayor)
        {
            animatorValue = 2;
        }
        // valor mayor
        else if(randomNumber > menor && randomNumber > medio && randomNumber >= mayor)
        {
            animatorValue = 3;
        }

        animator1.SetInteger("State",animatorValue);    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  /*   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    } */

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   /*  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    } */

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
