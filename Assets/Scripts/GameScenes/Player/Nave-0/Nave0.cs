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
using Image = UnityEngine.UI.Image;
using UnityEngine.Rendering;

public class Nave0 : MonoBehaviour
{
    public static Nave0 nave0;

    [Header("Componentes")]
    [SerializeField] Rigidbody2D rgb;
    [SerializeField] Animator ani;
    [SerializeField] KeyControlAssingPlay keyControlAssingPlay;
    [SerializeField] PowerUps powerUps;
    [SerializeField] ControlHabilityActive controlHabilityActive;
    [SerializeField] GameScene2 gameScene2;

    [Header("Escena Inicial")]
    public bool startScene;
    [SerializeField] float startSpeedY;
    public bool StartSceneActive;

    [Header("Vidas")]
    public bool lifes;
    [SerializeField] Image[] lifeImage;
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
    public float forceShotx, forceShoty, timeShot, endTimeShot, timeShotActive, endTimeShotActive;

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
        gameScene2 = GameObject.Find("Scripts").GetComponent<GameScene2>();

        // activar la escena inicial
        startScene = true;
        StartSceneActive = true;
        startSpeedY = 0.02f;
        // valores de las habilidades
        lifePoint = 3;
        forceShotx = 20;
        forceShoty = 30;
        speedX = 10;
        speedY = 10;
        // vidas
        lifeImage = new Image[3];
        lifeImage[0] = GameObject.FindGameObjectWithTag("L0").GetComponent<Image>();
        lifeImage[1] = GameObject.FindGameObjectWithTag("L1").GetComponent<Image>();
        lifeImage[2] = GameObject.FindGameObjectWithTag("L2").GetComponent<Image>();
        // posicion de disparos
        positionsShots = new Transform[6];
        positionsShots[0] = GameObject.Find("PositionShotNormal").transform;
        positionsShots[1] = GameObject.Find("PositionShotLazer0").transform;
        positionsShots[2] = GameObject.Find("PositionShotLazer1").transform;
        positionsShots[3] = GameObject.Find("PositionShotLazer2").transform;
        positionsShots[4] = GameObject.Find("PositionShotLazer3").transform;
        positionsShots[5] = GameObject.Find("PositionDefenses").transform;
    }
    void FixedUpdate()
    {
        // MOVIMIENTO
        Movimiento();
    }

    // Update is called once per frame
    void Update()
    {
        StartScene();
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
                if (powerUps.selection < 3)
                {
                    shotsSkills = powerUps.selection;
                }
                if (powerUps.selection > 2)
                {
                    habilityActive = powerUps.selection;
                }
                controlHabilityActive.activeHability = true;
                controlHabilityActive.habilityValue = habilityActive;
            }
        }
    }

    //  QUITAR VIDA //
    public void DownLife(int Value)
    {
        lifePoint -= Value;
    }

    //   ESCENA AL INICIAR   //
    private void StartScene()
    {
        if (startScene == true)
        {
            if (StartSceneActive == true)
            {
                if (transform.position.y < 0)
                {
                    transform.Translate(Vector3.up * startSpeedY, Space.World);

                    movimiento = false;
                    disparos = false;
                    hability = false;

                    gameScene2.canavasPlay = false;
                    gameScene2.canvasPause = false;
                }
                if (transform.position.y >= 0)
                {
                    movimiento = true;
                    disparos = true;
                    hability = true;
                    gameScene2.canavasPlay = true;
                    StartSceneActive = false;
                }
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
                        lifeImage[i].enabled = false;
                    }
                    break;
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        lifeImage[i].enabled = false;
                        if (i == 2)
                        {
                            lifeImage[i].enabled = true;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        lifeImage[i].enabled = false;
                        if (i == 1 || i == 2)
                        {
                            lifeImage[i].enabled = true;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        lifeImage[i].enabled = true;
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
                    endTimeShotActive = 1;

                    if (ActiveDefense == false)
                    {
                        StartCoroutine(DefenseGreen());
                    }
                    if (timeShotActive < endTimeShotActive)
                    {
                        LlamarDisparos(DisparoCeleste);
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
                        LlamarDisparos(DisparoCeleste);
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
                        LlamarDisparos(DisparoCeleste);
                        timeShotActive += 1 * Time.deltaTime;
                    }
                    else
                    {
                        ActiveDefense = false;
                        timeShotActive = 0;
                        shotsSkills = 0;
                    }
                    break;
                case 9:
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
                            LlamarDisparos(EsferaCeleste);
                        }
                    }
                    if (timeShotActive > endTimeShotActive)
                    {
                        timeShotActive = 0;
                        shotsSkills = 0;
                    }
                    break;
                case 10:
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
                            LlamarDisparos(EsferaAzul);
                        }
                    }
                    if (timeShotActive > endTimeShotActive)
                    {
                        timeShotActive = 0;
                        shotsSkills = 0;
                    }
                    break;
                case 11:
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
                            LlamarDisparos(EsferaRoja);
                        }
                    }
                    if (timeShotActive > endTimeShotActive)
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
    private void EsferaCeleste()
    {
        GameObject bulet = Instantiate(lazers[9], positionsShots[0].position, quaternion.identity);
        bulet.GetComponent<Transform>().localScale = new Vector3(2, 2, 1);
        bulet.GetComponent<Bullet>().bulletStatus = 0;
        bulet.GetComponent<Bullet>().lifeBullet = 5;
        bulet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);
    }
    private void EsferaAzul()
    {
        GameObject bulet = Instantiate(lazers[10], positionsShots[3].position, quaternion.identity);
        bulet.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        bulet.GetComponent<Bullet>().bulletStatus = 0;
        bulet.GetComponent<Bullet>().lifeBullet = 5;
        bulet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);

        GameObject bulets = Instantiate(lazers[10], positionsShots[4].position, quaternion.identity);
        bulets.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        bulets.GetComponent<Bullet>().bulletStatus = 0;
        bulets.GetComponent<Bullet>().lifeBullet = 5;
        bulets.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);

        GameObject bulet0 = Instantiate(lazers[10], positionsShots[1].position, quaternion.identity);
        bulet0.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        bulet0.GetComponent<Bullet>().bulletStatus = 0;
        bulet0.GetComponent<Bullet>().lifeBullet = 5;
        bulet0.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);

        GameObject bulet1 = Instantiate(lazers[10], positionsShots[2].position, quaternion.identity);
        bulet1.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        bulet1.GetComponent<Bullet>().bulletStatus = 0;
        bulet1.GetComponent<Bullet>().lifeBullet = 5;
        bulet1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);
    }
    private void EsferaRoja()
    {
        GameObject bulet = Instantiate(lazers[11], positionsShots[0].position, quaternion.identity);
        bulet.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 1);
        bulet.GetComponent<Bullet>().bulletStatus = 0;
        bulet.GetComponent<Bullet>().lifeBullet = 5;
        bulet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);

        GameObject bulet0 = Instantiate(lazers[11], positionsShots[1].position, quaternion.identity);
        bulet0.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 1);
        bulet0.GetComponent<Bullet>().bulletStatus = 0;
        bulet0.GetComponent<Bullet>().lifeBullet = 5;
        bulet0.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);

        GameObject bulet1 = Instantiate(lazers[11], positionsShots[2].position, quaternion.identity);
        bulet1.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 1);
        bulet1.GetComponent<Bullet>().bulletStatus = 0;
        bulet1.GetComponent<Bullet>().lifeBullet = 5;
        bulet1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);

        GameObject bulet2 = Instantiate(lazers[11], positionsShots[3].position, quaternion.identity);
        bulet2.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 1);
        bulet2.GetComponent<Bullet>().bulletStatus = 0;
        bulet2.GetComponent<Bullet>().lifeBullet = 5;
        bulet2.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);

        GameObject bulet3 = Instantiate(lazers[11], positionsShots[4].position, quaternion.identity);
        bulet3.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 1);
        bulet3.GetComponent<Bullet>().bulletStatus = 0;
        bulet3.GetComponent<Bullet>().lifeBullet = 5;
        bulet3.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);

        GameObject bulet4 = Instantiate(lazers[11], positionsShots[5].position, quaternion.identity);
        bulet4.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 1);
        bulet4.GetComponent<Bullet>().bulletStatus = 0;
        bulet4.GetComponent<Bullet>().lifeBullet = 5;
        bulet4.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceShoty), ForceMode2D.Impulse);

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
                        case 0:
                            controlHabilityActive.useHability = false;
                            break;
                        case 1:
                            controlHabilityActive.useHability = false;
                            break;
                        case 2:
                            controlHabilityActive.useHability = false;
                            break;
                        // Rafagas de lazers
                        case 3:
                            shotsSkills = 3;
                            break;
                        case 4:
                            shotsSkills = 4;
                            break;
                        case 5:
                            shotsSkills = 5;
                            break;
                        // defensas
                        case 6:
                            shotsSkills = 6;
                            break;
                        case 7:
                            shotsSkills = 7;
                            break;
                        case 8:
                            shotsSkills = 8;
                            break;
                        // Esferas lazers
                        case 9:
                            shotsSkills = 9;
                            break;
                        case 10:
                            shotsSkills = 10;
                            break;
                        case 11:
                            shotsSkills = 11;
                            break;
                    }
                }
            }
        }
    }
    //                          //
}
