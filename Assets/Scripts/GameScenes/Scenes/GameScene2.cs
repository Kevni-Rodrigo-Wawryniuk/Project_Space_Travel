using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using Random = UnityEngine.Random;
using System.Runtime.InteropServices;
using System.Linq.Expressions;
using System.Data.Common;

public class GameScene2 : MonoBehaviour
{
    public static GameScene2 gameScene2;
    [SerializeField] Nave0 nave0;
    [SerializeField] LevelsActive levelsActive;

    [Header("Puntos")]
    public int metheorosPoints;
    [SerializeField] TextMeshProUGUI textPoints;

    [Header("Niveles Activos")]
    public bool gameActive;
    [SerializeField] int levelValue;
    [SerializeField] float tiemGame, endTimeGame, timeMicroSecond;
    [SerializeField] int timeMinut, timeSecond;
    [SerializeField] TextMeshProUGUI textTimegame;
    [SerializeField] bool bossActive;

    [Header("Tiempo de invocacion: Meteoros, enemigos")]
    public bool obstacles;
    [SerializeField] GameObject[] meteoros;
    [SerializeField] float timeMeteoro, endTimeMeteoro;
    public bool enemy;
    [SerializeField] float timeEnemy, endTimeEnemy;

    [Header("Nave")]
    [SerializeField] Transform positionStart;
    public int nave;
    [SerializeField] GameObject[] naves;

    [Header("Power Ups")]
    public bool powers;
    [SerializeField] GameObject powerUp;

    [Header("Canvas Control")]
    public bool canvasControl;
    [SerializeField] Canvas[] canvas;
    public bool canavasPlay, canvasPause;

    // Start is called before the first frame update
    void Start()
    {
        if (gameScene2 == null)
        {
            gameScene2 = this;
        }

        nave = PlayerPrefs.GetInt("Nave");

        positionStart = GameObject.Find("PositionStart").transform;
        levelValue = GameObject.Find("Levels").GetComponent<LevelsActive>().backGroundActive;
        textPoints = GameObject.Find("TextPoint").GetComponent<TextMeshProUGUI>();
        textTimegame = GameObject.Find("TiempoDeJuego").GetComponent<TextMeshProUGUI>();

        gameActive = true;
        obstacles = true;
        enemy = true;

        switch (nave)
        {
            case 0:
                Instantiate(naves[0], positionStart.position, Quaternion.Euler(0, 0, 90));
                nave0 = GameObject.Find("Nave_0(Clone)").GetComponent<Nave0>();
                break;
            case 1:
                Instantiate(naves[1], positionStart.position, quaternion.identity);
                nave0 = GameObject.Find("Nave_1(Clone)").GetComponent<Nave0>();
                break;
            case 2:
                Instantiate(naves[2], positionStart.position, quaternion.identity);
                nave0 = GameObject.Find("Nave_2(Clone)").GetComponent<Nave0>();
                break;
            case 3:
                Instantiate(naves[3], positionStart.position, quaternion.identity);
                nave0 = GameObject.Find("Nave_3(Clone)").GetComponent<Nave0>();
                break;
            case 4:
                Instantiate(naves[4], positionStart.position, quaternion.identity);
                nave0 = GameObject.Find("Nave_4(Clone)").GetComponent<Nave0>();
                break;
            case 5:
                Instantiate(naves[5], positionStart.position, quaternion.identity);
                nave0 = GameObject.Find("Nave_5(Clone)").GetComponent<Nave0>();
                break;
        }

        if (gameActive == true)
        {
            switch (levelValue)
            {
                case 0:
                    endTimeMeteoro = 1;
                    endTimeEnemy = 5;
                    endTimeGame = 15;
                    break;
                case 1:
                    endTimeMeteoro = 1;
                    endTimeEnemy = 5;
                    endTimeGame = 15;
                    break;
                case 2:
                    endTimeMeteoro = 1;
                    endTimeEnemy = 5;
                    endTimeGame = 15;
                    break;
                case 3:
                    endTimeMeteoro = 1;
                    endTimeEnemy = 5;
                    endTimeGame = 15;
                    break;
                case 4:
                    endTimeMeteoro = 1;
                    endTimeEnemy = 5;
                    endTimeGame = 15;
                    break;
            }
        }
        canvasControl = true;
        bossActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        ControlGame();
        PowerUps();
        Obstacle();
        CanvasControl();
    }

    //  CONTROL DE NIVEL    //
    private void ControlGame()
    {
        if (gameActive == true)
        {
            if (nave0.StartSceneActive == false)
            {
                textPoints.text = metheorosPoints.ToString();

                if (timeMinut > 10 && timeSecond < 10)
                {
                    textTimegame.text = timeMinut.ToString() + " : 0" + timeSecond.ToString();
                }
                if(timeMinut > 10 && timeSecond > 10)
                {
                    textTimegame.text = timeMinut.ToString() + " : " + timeSecond.ToString();    
                }
                if (timeMinut < 10)
                {
                    textTimegame.text = " 0" + timeMinut.ToString() + " : " + timeSecond.ToString();

                    if (timeSecond < 10)
                    {
                        textTimegame.text = timeMinut.ToString() + " : 0" + timeSecond.ToString();
                    }
                    if (timeSecond < 10 && timeMinut < 10)
                    {
                        textTimegame.text = "0" + timeMinut.ToString() + " : 0" + timeSecond.ToString();
                    }
                }

                if (timeMicroSecond < 60)
                {
                    timeMicroSecond += 20 * Time.deltaTime;
                }
                if (timeMicroSecond >= 60)
                {
                    timeSecond++;
                    timeMicroSecond = 0;
                }
                if (timeSecond >= 60)
                {
                    timeMinut++;
                    timeSecond = 0;
                }

                switch (levelValue)
                {
                    case 0:
                        if (tiemGame < 5)
                        {
                            tiemGame += 1 * Time.deltaTime;
                        }
                        if (tiemGame > 5)
                        {
                            tiemGame += 1 * Time.deltaTime;
                            endTimeMeteoro = 1;
                        }
                        if (tiemGame > 10)
                        {
                            tiemGame += 1 * Time.deltaTime;
                            endTimeMeteoro = 1;
                        }
                        if (tiemGame > 15)
                        {
                            // invocar al jefe y falsear el booleno
                            if (bossActive == true)
                            {

                            }
                        }
                        break;
                }
            }
        }
    }
    //  CONTROL DE LOS CANVAS   //
    private void CanvasControl()
    {
        if (canvasControl == true)
        {
            canvas[0].enabled = canavasPlay;
            canvas[1].enabled = canvasPause;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
    }
    //  PAUSAR JUEGO  //
    private void Pause()
    {
        if (canvasPause == true)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        canvasPause = !canvasPause;

    }
    //   PRUEBA DE HABILIDADES   //
    private void PowerUps()
    {
        if (powers == true)
        {
            if (nave0.StartSceneActive == false)
            {
                if (Input.GetKeyDown(KeyCode.Keypad1))
                {
                    float positionX, positionY = 12;
                    positionX = Random.Range(-18, 18);
                    Instantiate(powerUp, new Vector2(positionX, positionY), Quaternion.identity);
                }
            }
        }
    }
    //  PRUEBA DE OBSTACULOS   //
    private void Obstacle()
    {
        if (obstacles == true)
        {
            if (nave0.StartSceneActive == false)
            {
                if (timeMeteoro < endTimeMeteoro)
                {
                    timeMeteoro += 1 * Time.deltaTime;
                }
                if (timeMeteoro >= endTimeMeteoro)
                {
                    float positionX, positionY = 12;
                    positionX = Random.Range(-18, 18);
                    int meteoroValue;
                    meteoroValue = Random.Range(0, 3);
                    Instantiate(meteoros[meteoroValue], new Vector2(positionX, positionY), Quaternion.identity);
                    timeMeteoro = 0;
                }
            }
        }
    }
}