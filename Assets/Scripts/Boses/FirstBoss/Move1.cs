using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using Random = UnityEngine.Random;
public class Move1 : StateMachineBehaviour
{

    [SerializeField] Rigidbody2D rgb;
    [SerializeField] float timeShot, endTimeShot, timeShot1, endTimeShot1, timeShot2, endTimeShot2;
    [SerializeField] Transform positionD, positionI, positionC;
    [SerializeField] GameObject bullet;
    [SerializeField] float randomNumber, speedX, timeMove, endTimeMove, forceShot;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rgb = animator.GetComponent<Rigidbody2D>();

        positionD = GameObject.Find("Shot_Point_D").transform;
        positionI = GameObject.Find("Shot_Point_I").transform;
        positionC = GameObject.Find("Lazer_Point").transform;

        endTimeShot = 0.5f;
        endTimeShot1 = 0.6f;
        endTimeShot2 = 0.7f;

        speedX = 5;

        endTimeMove = 1;

        forceShot = 10;

        randomNumber = Random.Range(0f, 1f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timeMove < endTimeMove)
        {
            timeMove += 1 * Time.deltaTime;
        }
        if (timeMove > endTimeMove)
        {
            timeMove = 0;
            randomNumber = Random.Range(0f, 1f);
        }

        if (randomNumber < 0.5f)
        {
            rgb.velocity = new Vector2(speedX, 0);
        }
        if (randomNumber > 0.5f)
        {
            rgb.velocity = new Vector2(-speedX, 0);
        }

        if (timeShot < endTimeShot)
        {
            timeShot += 1 * Time.deltaTime;
        }
        if (timeShot > endTimeShot)
        {
            timeShot = 0;
            GameObject bullets = Instantiate(bullet, positionD.position, quaternion.identity);
            bullets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -forceShot), ForceMode2D.Impulse);
        }

        if (timeShot1 < endTimeShot1)
        {
            timeShot1 += 1 * Time.deltaTime;
        }
        if (timeShot1 > endTimeShot1)
        {
            timeShot1 = 0;
            GameObject bullets = Instantiate(bullet, positionI.position, quaternion.identity);
            bullets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -forceShot), ForceMode2D.Impulse);
        }

        if (timeShot2 < endTimeShot2)
        {
            timeShot2 += 1 * Time.deltaTime;
        }
        if (timeShot2 > endTimeShot2)
        {
            timeShot2 = 0;
            GameObject bullets = Instantiate(bullet, positionC.position, quaternion.identity);
            bullets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -forceShot), ForceMode2D.Impulse);
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
