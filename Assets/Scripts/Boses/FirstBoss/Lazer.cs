using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

public class Lazer : StateMachineBehaviour
{

    [SerializeField] GameObject lazerinstante;
    [SerializeField] Transform positionL;
    [SerializeField] float randomNumber, speedX;
    [SerializeField] Rigidbody2D rgb;
    [SerializeField] GameScene2 gameScene2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameScene2 = GameObject.Find("Scripts").GetComponent<GameScene2>();
        rgb = animator.GetComponent<Rigidbody2D>();
        positionL = GameObject.Find("Lazer_Point").transform;
        Instantiate(lazerinstante, positionL.position, quaternion.identity);
        gameScene2.DispararLazer();
        
        speedX = 5;

        randomNumber = Random.Range(0f, 1f);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (randomNumber < 0.5f)
        {
            rgb.velocity = new Vector2(speedX, 0);
        }
        if (randomNumber > 0.5f)
        {
            rgb.velocity = new Vector2(-speedX, 0);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rgb.velocity = new Vector2(0, 0);
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
