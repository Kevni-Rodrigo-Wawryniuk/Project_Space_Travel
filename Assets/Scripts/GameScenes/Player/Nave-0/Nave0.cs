using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using Quaternion = UnityEngine.Quaternion;
using Unity.Mathematics;
using System;
using UnityEditor;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI;

public class Nave0 : MonoBehaviour
{
    public static Nave0 nave0;

    [Header("Componentes")]
    [SerializeField] Rigidbody2D rgb;
    [SerializeField] Animator ani;
    [SerializeField] KeyControlAssingPlay keyControlAssingPlay;
    [SerializeField] PowerUps powerUps;
    [SerializeField] ControlHabilityActive controlHabilityActive;

    [Header("Vidas")]
    public bool lifes;
    [SerializeField] GameObject[] lifeImage;
    [SerializeField] int lifePoint;

    [Header("Habilidades")]
    public bool hability;
    public int habilityActive;
    [SerializeField] bool ActiveDefense;

    [Header("Disparos")]
    public bool disparos;
    [SerializeField] int shotsSkills;
    public Transform[] positionsShots;
    [SerializeField] GameObject[] lazers;
    [SerializeField] float forceShotx, forceShoty, timeShot, endTimeShot, timeShotActive, endTimeShotActive;

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
        controlHabilityActive = GameObject.Find("Scripts").GetComponent<ControlHabilityActive>();
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
        UseHability();
        Life();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            powerUps = other.GetComponent<PowerUps>();

            if (controlHabilityActive.activeHability == false)
            {
                habilityActive = powerUps.selection;
                controlHabilityActive.activeHability = true;
                controlHabilityActive.habilityValue = habilityActive;
            }
        }
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
    //       VIDAS         //
    private void Life()
    {
        if (lifes == true)
        {
            switch (lifePoint)
            {
                case 0:
                    for (int i = 0; i < 3; i++)
                    {
                        lifeImage[i].SetActive(false);
                    }
                    break;
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        lifeImage[i].SetActive(false);
                        if (i == 2)
                        {
                            lifeImage[i].SetActive(true);
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        lifeImage[i].SetActive(false);
                        if (i == 1 || i == 2)
                        {
                            lifeImage[i].SetActive(true);
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        lifeImage[i].SetActive(true);
                    }
                    break;
            }
        }
    }
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
                    endTimeShotActive = 5;
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
                    endTimeShotActive = 5;
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
                case 3:
                    endTimeShotActive = 5;

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
                            LlamarDisparos(LazerRedBurst);
                        }
                    }
                    else
                    {
                        timeShotActive = 0;
                        shotsSkills = 0;
                    }
                    break;
                case 4:
                    endTimeShotActive = 5;

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
                            LlamarDisparos(LazerCelestialBurst);
                        }
                    }
                    else
                    {
                        timeShotActive = 0;
                        shotsSkills = 0;
                    }
                    break;
                case 5:
                    endTimeShotActive = 5;

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
                            LlamarDisparos(LazerBlueBurst);
                        }
                    }
                    else
                    {
                        timeShotActive = 0;
                        shotsSkills = 0;
                    }
                    break;
                case 6:
                    endTimeShotActive = 2;

                    if (ActiveDefense == false)
                    {
                        StartCoroutine(DefenseGreen());
                    }
                    if (timeShotActive < endTimeShotActive)
                    {
                        timeShotActive += 1 * Time.deltaTime;
                    }
                    else
                    {
                        ActiveDefense = false;
                        timeShotActive = 0;
                        shotsSkills = 0;
                    }
                    break;
                case 7:
                    endTimeShotActive = 10;

                    if (ActiveDefense == false)
                    {
                        StartCoroutine(DefenseRed());
                    }
                    if (timeShotActive < endTimeShotActive)
                    {
                        timeShotActive += 1 * Time.deltaTime;
                    }
                    else
                    {
                        ActiveDefense = false;
                        timeShotActive = 0;
                        shotsSkills = 0;
                    }
                    break;
                case 8:
                    endTimeShotActive = 10;

                    if (ActiveDefense == false)
                    {
                        StartCoroutine(DefenseAzul());
                    }
                    if (timeShotActive < endTimeShotActive)
                    {
                        timeShotActive += 1 * Time.deltaTime;
                    }
                    else
                    {
                        ActiveDefense = false;
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
    //                                                  //

    //      DISPAROS        //
    private void DisparoCeleste()
    {
        GameObject bulets = Instantiate(lazers[0], positionsShots[0].position, quaternion.identity);
        bulets.GetComponent<Bullet>().bulletStatus = 0;
        bulets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);
    }
    private void DisparoAzul()
    {
        GameObject bulets = Instantiate(lazers[2], positionsShots[0].position, quaternion.identity);
        bulets.GetComponent<Bullet>().bulletStatus = 1;
        bulets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);
    }
    private void DisparoRojo()
    {
        GameObject bulets = Instantiate(lazers[1], positionsShots[0].position, quaternion.identity);
        bulets.GetComponent<Bullet>().bulletStatus = 2;
        bulets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);

    }

    //       HABILIDADES        //
    private void LazerRedBurst()
    {
        GameObject bulet = Instantiate(lazers[3], positionsShots[0].position, quaternion.identity);
        bulet.GetComponent<Bullet>().bulletStatus = 0;
        bulet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);
    }
    private void LazerCelestialBurst()
    {
        GameObject bulet = Instantiate(lazers[4], positionsShots[1].position, quaternion.identity);
        bulet.GetComponent<Bullet>().bulletStatus = 0;
        bulet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);

        GameObject bulets = Instantiate(lazers[4], positionsShots[2].position, quaternion.identity);
        bulets.GetComponent<Bullet>().bulletStatus = 0;
        bulets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);
    }
    private void LazerBlueBurst()
    {
        GameObject bulet = Instantiate(lazers[5], positionsShots[3].position, quaternion.identity);
        bulet.GetComponent<Transform>().localEulerAngles = new Vector3(0, 0, 30);
        bulet.GetComponent<Bullet>().bulletStatus = 0;
        bulet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-forceShotx, forceShoty), ForceMode2D.Impulse);

        GameObject bulets = Instantiate(lazers[5], positionsShots[4].position, quaternion.identity);
        bulets.GetComponent<Transform>().localEulerAngles = new Vector3(0, 0, -30);
        bulets.GetComponent<Bullet>().bulletStatus = 0;
        bulets.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceShotx, forceShoty), ForceMode2D.Impulse);
    }
    private IEnumerator DefenseGreen()
    {
        GameObject defensest = Instantiate(lazers[6], positionsShots[5].position, quaternion.identity);
        defensest.GetComponent<Defense>().useDefense = 1;

        ActiveDefense = true;
        yield return new WaitForSeconds(0.1f);

        ActiveDefense = true;
    }
    private IEnumerator DefenseRed()
    {
        GameObject defense = Instantiate(lazers[7], positionsShots[5].position, Quaternion.identity);
        defense.GetComponent<Defense>().endTimeActive = endTimeShotActive;
        defense.GetComponent<Defense>().useDefense = 2;
        ActiveDefense = true;
        yield return new WaitForSeconds(0.1f);
        ActiveDefense = true;
    }
    private IEnumerator DefenseAzul()
    {
        GameObject defense = Instantiate(lazers[8], positionsShots[5].position, Quaternion.identity);
        defense.GetComponent<Defense>().endTimeActive = endTimeShotActive;
        defense.GetComponent<Defense>().useDefense = 3;
        ActiveDefense = true;
        yield return new WaitForSeconds(0.1f);
        ActiveDefense = true;
    }
    // ACTIVAR LAS HABILIDADES  //
    private void UseHability()
    {
        if (hability == true)
        {
            if (Input.GetKeyDown(keyControlAssingPlay.teclaHability))
            {
                if (controlHabilityActive.useHability == false)
                {
                    controlHabilityActive.useHability = true;
                    switch (habilityActive)
                    {
                        // Rafagas de lazers
                        case 1:
                            shotsSkills = 3;
                            break;
                        case 2:
                            shotsSkills = 4;
                            break;
                        case 3:
                            shotsSkills = 5;
                            break;
                        // defensas
                        case 4:
                            shotsSkills = 6;
                            break;
                        case 5:
                            shotsSkills = 7;
                            break;
                        case 6:
                            shotsSkills = 8;
                            break;
                        // Esferas lazers
                        case 7:

                            break;
                        case 8:

                            break;
                        case 9:

                            break;

                        case 10:

                            break;
                        case 11:

                            break;
                        case 12:

                            break;
                    }
                }
            }
        }
    }
    //                          //
}
