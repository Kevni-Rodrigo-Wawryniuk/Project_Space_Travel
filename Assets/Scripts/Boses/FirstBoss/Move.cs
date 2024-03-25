using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Move : StateMachineBehaviour
{

    [SerializeField] Rigidbody2D rgb;
    [SerializeField] float timeShot, endTimeShot, forceShot;

    [SerializeField] Transform positionShotD, positionShotI;
    [SerializeField] GameObject bullet;
    [SerializeField] float speedX, randomNumber;
    [SerializeField] GameScene2 gameScene2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rgb = animator.GetComponent<Rigidbody2D>();
        gameScene2 = GameObject.Find("Scripts").GetComponent<GameScene2>();
        
        positionShotD = GameObject.Find("Shot_Point_D").transform;
        positionShotI = GameObject.Find("Shot_Point_I").transform;

        speedX = 5;

        endTimeShot = 0.5f;

        forceShot = 20;

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

        if (timeShot < endTimeShot)
        {
            timeShot += 1 * Time.deltaTime;
        }
        if (timeShot > endTimeShot)
        {
            timeShot = 0;

            GameObject bullets = Instantiate(bullet, positionShotD.position, quaternion.identity);
            bullets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -forceShot), ForceMode2D.Impulse);

            GameObject bullets0 = Instantiate(bullet, positionShotI.position, quaternion.identity);
            bullets0.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -forceShot), ForceMode2D.Impulse);
            
            gameScene2.DispararLazer();
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
