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
using System.Numerics;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class GameScene2 : MonoBehaviour
{
    public static GameScene2 gameScene2;
    public Nave0 nave0;
    [SerializeField] KeyControlAssingPlay keyControlAssingPlay;
    [SerializeField] LevelsActive levelsActive;
    [SerializeField] EventSystem eventSystem;

    [Header("Puntos")]
    public int metheorosPoints;
    [SerializeField] TextMeshProUGUI textMetheors;

    [Header("Niveles Activos")]
    public bool gameActive;
    public int levelValue;
    [SerializeField] float endTimeGame, timeMicroSecond;
    [SerializeField] int timeMinut, timeSecond;
    [SerializeField] TextMeshProUGUI textTimegame;

    [Header("jefes finales")]
    public bool bossActive, bossCombat;
    [SerializeField] GameObject[] boss;
    [SerializeField] Slider sliderBoss;
    [SerializeField] Transform positionBoss;

    [Header("Tiempo de invocacion: Meteoros, enemigos")]
    public bool obstacles;
    [SerializeField] GameObject[] meteoros;
    [SerializeField] float timeMeteoro, endTimeMeteoro;
    public bool bomb;
    [SerializeField] GameObject bombs;
    [SerializeField] float timeBombs, endTimeBombs;

    [Header("Nave")]
    [SerializeField] Transform positionStart;
    public int nave;
    [SerializeField] GameObject[] naves;

    [Header("Canvas Control")]
    public bool canvasControl;
    [SerializeField] Canvas[] canvas;
    public bool canavasPlay, canvasPause, canvasDead, canvasWin;
    [SerializeField] TMP_Text[] pointsText;
    [SerializeField] int moveMenu;
    [SerializeField] GameObject[] botones;

    public int levelValue1, levelValue2;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        if (gameScene2 == null)
        {
            gameScene2 = this;
        }

        nave = PlayerPrefs.GetInt("Nave");

        positionStart = GameObject.Find("PositionStart").transform;
        positionBoss = GameObject.Find("PositionStartBoss").transform;
        levelValue = GameObject.Find("Levels").GetComponent<LevelsActive>().backGroundActive;
        textMetheors = GameObject.Find("TextMetheorosPoint").GetComponent<TextMeshProUGUI>();
        textTimegame = GameObject.Find("TiempoDeJuego").GetComponent<TextMeshProUGUI>();
        sliderBoss = GameObject.Find("Slider").GetComponent<Slider>();
        keyControlAssingPlay = GameObject.Find("Scripts").GetComponent<KeyControlAssingPlay>();
        eventSystem = GetComponent<EventSystem>();

        gameActive = true;

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
            // control de niveles
            switch (levelValue)
            {
                case 0:
                    levelValue1 = PlayerPrefs.GetInt("pointLevel1", 0);
                    obstacles = true;
                    bomb = true;

                    endTimeMeteoro = 0.3f;
                    endTimeBombs = 5;
                    endTimeGame = 5;
                    break;
                case 1:

                    levelValue2 = PlayerPrefs.GetInt("pointLevel2", 0);
                    obstacles = true;
                    bomb = true;

                    endTimeMeteoro = 0.5f;
                    endTimeBombs = 5;
                    endTimeGame = 3;
                    break;
                case 2:
                    obstacles = true;
                    bomb = true;

                    endTimeMeteoro = 1;
                    endTimeBombs = 10;
                    endTimeGame = 2;
                    break;
                case 3:
                    obstacles = true;
                    bomb = true;

                    endTimeMeteoro = 1;
                    endTimeBombs = 15;
                    endTimeGame = 2;
                    break;
                case 4:
                    obstacles = true;
                    bomb = true;

                    endTimeMeteoro = 1;
                    endTimeBombs = 20;
                    endTimeGame = 2;
                    break;
            }
        }

        canvasControl = true;
        bossActive = true;
        bossCombat = false;
    }

    // Update is called once per frame
    void Update()
    {
        ControlGame();

        Obstacle();
        Bombs();

        CanvasControl();
    }

    //  CONTROL DE NIVEL    //
    private void ControlGame()
    {
        if (gameActive == true)
        {
            if (nave0.StartSceneActive == false)
            {
                textMetheors.text = metheorosPoints.ToString();

                if (timeMinut > 10 && timeSecond < 10)
                {
                    textTimegame.text = timeMinut.ToString() + " : 0" + timeSecond.ToString();
                }
                if (timeMinut > 10 && timeSecond > 10)
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
                    timeMicroSecond += 60 * Time.deltaTime;
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

                // control de niveles mientras se esta jugando
                switch (levelValue)
                {
                    // Tiempo de juego simple 2 minutos 
                    // una vez pasan los dos minutos termina el nivel uno 
                    case 0:
                        if (timeMinut >= endTimeGame)
                        {
                            canvasWin = true;
                            Time.timeScale = 0;
                        }
                        break;
                    case 1:
                        //  una ves se terminan los dos minutos se inicia el boss
                        if (timeMinut >= endTimeGame)
                        {
                            // invocar al jefe y falsear el booleno
                            if (bossActive == true)
                            {
                                // colocar al juego
                                Instantiate(boss[0], positionBoss.position, quaternion.identity);
                                bossActive = false;
                                bossCombat = true;
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
            canvas[2].enabled = canvasWin;
            canvas[3].enabled = canvasDead;
            sliderBoss.gameObject.SetActive(bossCombat);

            pointsText[0].text = "Points: " + metheorosPoints;
            pointsText[1].text = "Points: " + metheorosPoints;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }

            if (canavasPlay == true && canvasDead == false && canvasWin == false)
            {
                if (canvasPause == true)
                {
                    switch (moveMenu)
                    {
                        case 0:
                            botones[0].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1.1f);
                            botones[1].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                            eventSystem.SetSelectedGameObject(botones[0]);

                            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                            {
                                Resume();
                            }
                            break;
                        case 1:
                            botones[1].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1.1f);
                            botones[0].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                            eventSystem.SetSelectedGameObject(botones[1]);
                            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                            {
                                ReturnMenu();
                            }
                            break;
                    }
                    if (Input.GetKeyDown(keyControlAssingPlay.teclaW) || Input.GetKeyDown(keyControlAssingPlay.flechaArriba))
                    {
                        moveMenu++;
                    }
                    if (Input.GetKeyDown(keyControlAssingPlay.teclaS) || Input.GetKeyDown(keyControlAssingPlay.flechaAbajo))
                    {
                        moveMenu--;
                    }
                    if (moveMenu < 0)
                    {
                        moveMenu = 1;
                    }
                    if (moveMenu > 1)
                    {
                        moveMenu = 0;
                    }
                }
            }
            if (canavasPlay == true && canvasDead == true && canvasWin == false)
            {
                switch (moveMenu)
                {
                    case 2:
                        botones[2].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1.1f);
                        botones[3].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

                        eventSystem.SetSelectedGameObject(botones[2]);

                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                        {
                            Resume();
                        }
                        break;
                    case 3:
                        botones[3].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1.1f);
                        botones[2].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

                        eventSystem.SetSelectedGameObject(botones[3]);

                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                        {
                            ReturnMenu();
                        }
                        break;
                }
                if (Input.GetKeyDown(keyControlAssingPlay.teclaW) || Input.GetKeyDown(keyControlAssingPlay.flechaArriba))
                {
                    moveMenu++;
                }
                if (Input.GetKeyDown(keyControlAssingPlay.teclaS) || Input.GetKeyDown(keyControlAssingPlay.flechaAbajo))
                {
                    moveMenu--;
                }
                if (moveMenu > 3)
                {
                    moveMenu = 2;
                }
                if (moveMenu < 2)
                {
                    moveMenu = 3;
                }
            }
            if (canavasPlay == true && canvasDead == false && canvasWin == true)
            {
                switch (moveMenu)
                {
                    case 4:
                        botones[4].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1.1f);
                        botones[5].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

                        eventSystem.SetSelectedGameObject(botones[4]);

                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                        {
                            Resume();
                        }
                        break;
                    case 5:
                        botones[5].GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1.1f);
                        botones[4].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

                        eventSystem.SetSelectedGameObject(botones[5]);

                        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                        {
                            ReturnMenu();
                        }
                        break;
                }
                if (Input.GetKeyDown(keyControlAssingPlay.teclaW) || Input.GetKeyDown(keyControlAssingPlay.flechaArriba))
                {
                    moveMenu++;
                }
                if (Input.GetKeyDown(keyControlAssingPlay.teclaS) || Input.GetKeyDown(keyControlAssingPlay.flechaAbajo))
                {
                    moveMenu--;
                }
                if (moveMenu > 5)
                {
                    moveMenu = 4;
                }
                if (moveMenu < 4)
                {
                    moveMenu = 5;
                }
            }
        }
    }
    //  PAUSAR JUEGO  //
    private void Pause()
    {
        if (canavasPlay == true && canvasDead == false && canvasWin == false)
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
    }
    public void Resume()
    {
        if (canavasPlay == true && canvasDead == false && canvasWin == false)
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
    }

    //  METHEOROS   //
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
    //  BOMBAS  //
    private void Bombs()
    {
        if (bomb == true)
        {
            if (nave0.StartSceneActive == false)
            {
                if (timeBombs < endTimeBombs)
                {
                    timeBombs += 1 * Time.deltaTime;
                }
                if (timeBombs >= endTimeBombs)
                {
                    float positionX, positionY = 12;
                    positionX = Random.Range(-18, 18);
                    Instantiate(bombs, new Vector2(positionX, positionY), quaternion.identity);
                    timeBombs = 0;
                }
            }
        }
    }


    // Botones
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void ReturnMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("Level", 0);
    }
}