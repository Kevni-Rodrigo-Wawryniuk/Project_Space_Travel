using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using Unity.Mathematics;
using System;
public class Nave0 : MonoBehaviour
{
    public static Nave0 nave0;

    [Header("Componentes")]
    [SerializeField] Rigidbody2D rgb;
    [SerializeField] Animator ani;
    [SerializeField] KeyControlAssingPlay keyControlAssingPlay;

    [Header("Disparos")]
    public bool disparos;
    [SerializeField] int shotsSkills;
    [SerializeField] Transform[] positionsShots;
    [SerializeField] GameObject[] lazers;
    [SerializeField] float forceShot, timeShot, endTimeShot, timeShotActive, endTimeShotActive;

    [Header("Movimiento")]
    public bool movimiento;
    [SerializeField] float speedX, speedY, positionNaveX, positionNaveY;
    // Start is called before the first frame update
    void Start()
    {
        if (nave0 == null)
        {
            nave0 = this;
        }

        rgb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        keyControlAssingPlay = GameObject.Find("Scripts").GetComponent<KeyControlAssingPlay>();
    }
    void FixedUpdate()
    {
        // MOVIMIENTO
        Movimiento();
    }

    // Update is called once per frame
    void Update()
    {
        HabilitysAndShots();
    }
    //      MOVIMIENTO      //
    public void Movimiento()
    {
        if (movimiento == true)
        {
            // position y + speedY 
            if (Input.GetKey(keyControlAssingPlay.teclaW) || Input.GetKey(keyControlAssingPlay.flechaArriba))
            {
                rgb.velocity = new Vector2(0, speedY);
            }
            // position y - speedY
            else if (Input.GetKey(keyControlAssingPlay.teclaS) || Input.GetKey(keyControlAssingPlay.flechaAbajo))
            {
                rgb.velocity = new Vector2(0, -speedY);
            }
            // position x + speedX
            else if (Input.GetKey(keyControlAssingPlay.teclaD) || Input.GetKey(keyControlAssingPlay.flechaDerecha))
            {
                rgb.velocity = new Vector2(speedX, 0);
            }
            // position X - speedX
            else if (Input.GetKey(keyControlAssingPlay.teclaA) || Input.GetKey(keyControlAssingPlay.flechaIzquierda))
            {
                rgb.velocity = new Vector2(-speedX, 0);
            }
            else
            {
                rgb.velocity = new Vector2(0, 0);
            }

            positionNaveX = transform.position.x;
            positionNaveY = transform.position.y;

            positionNaveX = Mathf.Clamp(positionNaveX, -18, 18);
            positionNaveY = Mathf.Clamp(positionNaveY, -10, 10);

            transform.position = new Vector2(positionNaveX, positionNaveY);
        }
    }
    //                      //

    //      DISPAROS        //
    public void HabilitysAndShots()
    {
        if (disparos == true)
        {
            switch (shotsSkills)
            {
                case 0:
                    endTimeShot = 0.3f;
                    if (timeShot < endTimeShot)
                    {
                        timeShot += 1 * Time.deltaTime;
                    }
                    if (timeShot > endTimeShot)
                    {
                        LlamarDisparos(DisparoCeleste);
                    }
                    break;
                case 1:
                    if (timeShotActive < endTimeShotActive)
                    {
                        timeShotActive += 1 * Time.deltaTime;

                        endTimeShot = 0.2f;

                        if (timeShot < endTimeShot)
                        {
                            timeShot += 1 * Time.deltaTime;
                        }
                        else
                        {
                            LlamarDisparos(DisparoAzul);
                        }
                    }
                    if (timeShotActive > endTimeShotActive)
                    {
                        timeShotActive = 0;
                        shotsSkills = 0;
                    }
                    break;
                case 2:
                    if (timeShotActive < endTimeShotActive)
                    {
                        timeShotActive += 1 * Time.deltaTime;
                        endTimeShot = 0.1f;
                        if (timeShot < endTimeShot)
                        {
                            timeShot += 1 * Time.deltaTime;
                        }
                        else
                        {
                            LlamarDisparos(DisparoRojo);
                        }
                    }
                    else
                    {
                        timeShotActive = 0;
                        shotsSkills = 0;
                    }
                    break;
            }
        }
    }

    //          LLAMADO DE DISPAROS Y HABILIDADES       //
    private void LlamarDisparos(Action funcion)
    {
        if (Input.GetKeyDown(keyControlAssingPlay.teclaShot))
        {
            funcion();
            timeShot = 0;
        }
    }
    private void LlamarHabilidades(Action funcion)
    {
        if (Input.GetKeyDown(keyControlAssingPlay.teclaHability))
        {
            funcion();
        }
    }
    //                                                  //

    //      DISPAROS        //
    private void DisparoCeleste()
    {
        GameObject bulets = Instantiate(lazers[0], positionsShots[0].position, quaternion.identity);
        bulets.GetComponent<Bullet>().bulletStatus = 0;
        bulets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShot), ForceMode2D.Impulse);
    }
    private void DisparoAzul()
    {
        GameObject bulets = Instantiate(lazers[2], positionsShots[0].position, quaternion.identity);
        bulets.GetComponent<Bullet>().bulletStatus = 1;
        bulets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShot), ForceMode2D.Impulse);
    }
    private void DisparoRojo()
    {
        GameObject bulets = Instantiate(lazers[1], positionsShots[0].position, quaternion.identity);
        bulets.GetComponent<Bullet>().bulletStatus = 2;
        bulets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShot), ForceMode2D.Impulse);

    }
    //                      //

}
