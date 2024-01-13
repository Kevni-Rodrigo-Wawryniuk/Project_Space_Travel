using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class StartMenu : MonoBehaviour
{
    public static StartMenu startMenu;
    [Header("Scripts")]
    [SerializeField] KeyControlAssing keyControlAssing;
    [SerializeField] InputSystemUIInputModule inputSystemUIInputModule;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] ControlResolution_1 controlResolution_1;
    [SerializeField] ControlQuality controlQuality;
    [SerializeField] ScreemActive screemActive;


    [Header("Start Screem")]
    public bool startScreemAnimations;
    [SerializeField] int objectStartScreemSeletion, objectLevelsScreemSelection, objetoLevelButtonSelection, objectSettingScreemSeletion, objectSettingKeyControlScreemSeletion, objectQuitScreemSeletion;
    [SerializeField] GameObject[] buttonStartScreem, buttonLevelScreem, buttonSettingsScreem, buttonSettingKeyControl, buttonQuitScreem;
    [SerializeField] public GameObject[] buttonStartScreemEventSystem, buttonSettingScreemEventSystem, buttonSettingKeyControlEventSystem, buttonQuitScreemEventSystem, buttonLevelScreemEventSystem;
    [SerializeField] GameObject[] backGroundPlanets;
    [SerializeField] float speedPlanets;
    // Start is called before the first frame update
    void Start()
    {
        if (startMenu == null)
        {
            startMenu = this;
        }

        keyControlAssing = GetComponent<KeyControlAssing>();
        eventSystem = GetComponent<EventSystem>();
        inputSystemUIInputModule = GetComponent<InputSystemUIInputModule>();
        controlResolution_1 = GetComponent<ControlResolution_1>();
        controlQuality = GetComponent<ControlQuality>();
        screemActive = GetComponent<ScreemActive>();

        PreAsignacionDeTeclas();

        startScreemAnimations = true;
    }
    private void PreAsignacionDeTeclas()
    {
        if (PlayerPrefs.HasKey("teclaArriba"))
        {
            keyControlAssing.teclaW = (KeyCode)PlayerPrefs.GetInt("teclaArriba");
        }
        else
        {
            keyControlAssing.teclaW = KeyCode.W;
        }
        if (PlayerPrefs.HasKey("teclaAbajo"))
        {
            keyControlAssing.teclaS = (KeyCode)PlayerPrefs.GetInt("teclaAbajo");
        }
        else
        {
            keyControlAssing.teclaS = KeyCode.S;
        }
        if (PlayerPrefs.HasKey("teclaDerecha"))
        {
            keyControlAssing.teclaD = (KeyCode)PlayerPrefs.GetInt("teclaDerecha");
        }
        else
        {
            keyControlAssing.teclaD = KeyCode.D;
        }
        if (PlayerPrefs.HasKey("teclaIzquierda"))
        {
            keyControlAssing.teclaA = (KeyCode)PlayerPrefs.GetInt("teclaIzquierda");
        }
        else
        {
            keyControlAssing.teclaA = KeyCode.A;
        }
        if (PlayerPrefs.HasKey("teclaShot"))
        {
            keyControlAssing.teclaShot = (KeyCode)PlayerPrefs.GetInt("teclaShot");
        }
        else
        {
            keyControlAssing.teclaShot = KeyCode.J;
        }
        if (PlayerPrefs.HasKey("teclaHabilidad"))
        {
            keyControlAssing.teclaHability = (KeyCode)PlayerPrefs.GetInt("teclaHabilidad");
        }
        else
        {
            keyControlAssing.teclaHability = KeyCode.E;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Menu
        MoveMenus();
        Menus();

        // mover los planetas que representan los niveles
        MovePlanets();
    }

    //      CARGAR SCENA    //
    public void PassScene()
    {
        switch (objectLevelsScreemSelection)
        {
            default:
            PlayerPrefs.SetInt("Level",2);
            break;
            case 1:
            PlayerPrefs.SetInt("Level",3);
            break;
            case 2:
            PlayerPrefs.SetInt("Level",4);
            break;
            case 3:
            PlayerPrefs.SetInt("Level",5);
            break;
            case 4:
            PlayerPrefs.SetInt("Level",6);
            break;
        }
    }
    //                      //

    //      UTILIZANDO MENUS        //
    private void Menus()
    {
        if (screemActive.canvasStartActive == true)
        {
            switch (objectStartScreemSeletion)
            {
                default:
                    eventSystem.SetSelectedGameObject(buttonStartScreemEventSystem[0]);

                    for (int i = 0; i < 9; i++)
                    {
                        if (i > -1 && i < 3)
                        {
                            buttonStartScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 0)
                            {
                                buttonStartScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 2)
                        {
                            buttonStartScreem[i].SetActive(false);
                            if (i == 3 || i == 4)
                            {
                                buttonStartScreem[i].SetActive(true);
                            }
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        screemActive.BotonLevels();
                    }
                    break;
                case 1:
                    eventSystem.SetSelectedGameObject(buttonStartScreemEventSystem[1]);

                    for (int i = 0; i < 9; i++)
                    {
                        if (i > -1 && i < 3)
                        {
                            buttonStartScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 1)
                            {
                                buttonStartScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 2)
                        {
                            buttonStartScreem[i].SetActive(false);
                            if (i == 5 || i == 6)
                            {
                                buttonStartScreem[i].SetActive(true);
                            }
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        screemActive.BotonSettings();
                    }
                    break;
                case 2:
                    eventSystem.SetSelectedGameObject(buttonStartScreemEventSystem[2]);

                    for (int i = 0; i < 9; i++)
                    {
                        if (i > -1 && i < 3)
                        {
                            buttonStartScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 2)
                            {
                                buttonStartScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 2)
                        {
                            buttonStartScreem[i].SetActive(false);
                            if (i == 7 || i == 8)
                            {
                                buttonStartScreem[i].SetActive(true);
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        screemActive.BotonQuit();
                    }
                    break;
            }
        }
        if (screemActive.canvasLevelsActive == true)
        {
            switch (objectLevelsScreemSelection)
            {
                default:
                    backGroundPlanets[0].transform.position = new Vector3(0, 0, 0);
                    backGroundPlanets[1].transform.position = new Vector3(20, 0, 0);
                    backGroundPlanets[2].transform.position = new Vector3(40, 0, 0);
                    backGroundPlanets[3].transform.position = new Vector3(60, 0, 0);
                    backGroundPlanets[4].transform.position = new Vector3(80, 0, 0);
                    break;
                case 1:
                    backGroundPlanets[0].transform.position = new Vector3(-20, 0, 0);
                    backGroundPlanets[1].transform.position = new Vector3(0, 0, 0);
                    backGroundPlanets[2].transform.position = new Vector3(20, 0, 0);
                    backGroundPlanets[3].transform.position = new Vector3(40, 0, 0);
                    backGroundPlanets[4].transform.position = new Vector3(60, 0, 0);
                    break;
                case 2:
                    backGroundPlanets[0].transform.position = new Vector3(-40, 0, 0);
                    backGroundPlanets[1].transform.position = new Vector3(-20, 0, 0);
                    backGroundPlanets[2].transform.position = new Vector3(0, 0, 0);
                    backGroundPlanets[3].transform.position = new Vector3(20, 0, 0);
                    backGroundPlanets[4].transform.position = new Vector3(40, 0, 0);
                    break;
                case 3:
                    backGroundPlanets[0].transform.position = new Vector3(-60, 0, 0);
                    backGroundPlanets[1].transform.position = new Vector3(-40, 0, 0);
                    backGroundPlanets[2].transform.position = new Vector3(-20, 0, 0);
                    backGroundPlanets[3].transform.position = new Vector3(0, 0, 0);
                    backGroundPlanets[4].transform.position = new Vector3(20, 0, 0);
                    break;
                case 4:
                    backGroundPlanets[0].transform.position = new Vector3(-80, 0, 0);
                    backGroundPlanets[1].transform.position = new Vector3(-60, 0, 0);
                    backGroundPlanets[2].transform.position = new Vector3(-40, 0, 0);
                    backGroundPlanets[3].transform.position = new Vector3(-20, 0, 0);
                    backGroundPlanets[4].transform.position = new Vector3(0, 0, 0);
                    break;
            }
            switch (objetoLevelButtonSelection)
            {
                default:
                    eventSystem.SetSelectedGameObject(buttonLevelScreemEventSystem[0]);
                    for (int i = 0; i < 6; i++)
                    {
                        if (i < 2)
                        {
                            buttonLevelScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 0)
                            {
                                buttonLevelScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 1)
                        {
                            buttonLevelScreem[i].SetActive(false);
                            if (i == 2 || i == 3)
                            {
                                buttonLevelScreem[i].SetActive(true);
                            }
                        }
                    }
                    break;
                case 1:
                    eventSystem.SetSelectedGameObject(buttonLevelScreemEventSystem[1]);
                    for (int i = 0; i < 6; i++)
                    {
                        if (i < 2)
                        {
                            buttonLevelScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 1)
                            {
                                buttonLevelScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 1)
                        {
                            buttonLevelScreem[i].SetActive(false);
                            if (i == 4 || i == 5)
                            {
                                buttonLevelScreem[i].SetActive(true);
                            }
                        }
                    }
                    break;
            }
        }
        if (screemActive.canvasSettingsActive == true)
        {
            switch (objectSettingScreemSeletion)
            {
                default:
                    eventSystem.SetSelectedGameObject(buttonSettingScreemEventSystem[0]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i > -1 && i < 7)
                        {
                            buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 0)
                            {
                                buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }

                        if (i > 6)
                        {
                            buttonSettingsScreem[i].SetActive(false);
                            if (i == 7 || i == 8)
                            {
                                buttonSettingsScreem[i].SetActive(true);
                            }
                        }
                    }

                    break;
                case 1:
                    eventSystem.SetSelectedGameObject(buttonSettingScreemEventSystem[1]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i > -1 && i < 7)
                        {
                            buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 1)
                            {
                                buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }

                        if (i > 6)
                        {
                            buttonSettingsScreem[i].SetActive(false);
                            if (i == 9 || i == 10)
                            {
                                buttonSettingsScreem[i].SetActive(true);
                            }
                        }

                    }
                    break;
                case 2:
                    eventSystem.SetSelectedGameObject(buttonSettingScreemEventSystem[2]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i > -1 && i < 7)
                        {
                            buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 2)
                            {
                                buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }

                        if (i > 6)
                        {
                            buttonSettingsScreem[i].SetActive(false);
                            if (i == 11 || i == 12)
                            {
                                buttonSettingsScreem[i].SetActive(true);
                            }
                        }

                    }
                    break;
                case 3:
                    eventSystem.SetSelectedGameObject(buttonSettingScreemEventSystem[3]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i > -1 && i < 7)
                        {
                            buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 3)
                            {
                                buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }

                        if (i > 6)
                        {
                            buttonSettingsScreem[i].SetActive(false);
                            if (i == 13 || i == 14)
                            {
                                buttonSettingsScreem[i].SetActive(true);
                            }
                        }

                    }
                    if (Input.GetKeyDown(keyControlAssing.teclaD) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        controlResolution_1.tMP_Dropdown.value++;
                    }
                    if (Input.GetKeyDown(keyControlAssing.teclaA) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        controlResolution_1.tMP_Dropdown.value--;
                    }
                    break;
                case 4:
                    eventSystem.SetSelectedGameObject(buttonSettingScreemEventSystem[4]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i > -1 && i < 7)
                        {
                            buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 4)
                            {
                                buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }

                        if (i > 6)
                        {
                            buttonSettingsScreem[i].SetActive(false);
                            if (i == 15 || i == 16)
                            {
                                buttonSettingsScreem[i].SetActive(true);
                            }
                        }

                    }
                    if (Input.GetKeyDown(keyControlAssing.teclaD) || Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        controlQuality.tMP_DropdownQuality.value++;
                    }

                    if (Input.GetKeyDown(keyControlAssing.teclaA) || Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        controlQuality.tMP_DropdownQuality.value--;
                    }
                    break;
                case 5:
                    eventSystem.SetSelectedGameObject(buttonSettingScreemEventSystem[5]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i > -1 && i < 7)
                        {
                            buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 5)
                            {
                                buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }

                        if (i > 6)
                        {
                            buttonSettingsScreem[i].SetActive(false);
                            if (i == 17 || i == 18)
                            {
                                buttonSettingsScreem[i].SetActive(true);
                            }
                        }

                    }
                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                    }

                    break;
                case 6:
                    eventSystem.SetSelectedGameObject(buttonSettingScreemEventSystem[6]);
                    for (int i = 0; i < 21; i++)
                    {
                        if (i > -1 && i < 7)
                        {
                            buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 6)
                            {
                                buttonSettingsScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }

                        if (i > 6)
                        {
                            buttonSettingsScreem[i].SetActive(false);
                            if (i == 19 || i == 20)
                            {
                                buttonSettingsScreem[i].SetActive(true);
                            }
                        }

                    }
                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                    }
                    break;
            }
        }
        if (screemActive.canvasSettingsKeyControlActive == true)
        {
            switch (objectSettingKeyControlScreemSeletion)
            {
                default:
                    eventSystem.SetSelectedGameObject(buttonSettingKeyControlEventSystem[0]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i < 7)
                        {
                            buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 0)
                            {
                                buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 6)
                        {
                            buttonSettingKeyControl[i].SetActive(false);
                            if (i == 7 || i == 8)
                            {
                                buttonSettingKeyControl[i].SetActive(true);
                            }
                        }
                    }
                    break;
                case 1:
                    eventSystem.SetSelectedGameObject(buttonSettingKeyControlEventSystem[1]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i < 7)
                        {
                            buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 1)
                            {
                                buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 6)
                        {
                            buttonSettingKeyControl[i].SetActive(false);
                            if (i == 9 || i == 10)
                            {
                                buttonSettingKeyControl[i].SetActive(true);
                            }
                        }
                    }
                    break;
                case 2:
                    eventSystem.SetSelectedGameObject(buttonSettingKeyControlEventSystem[2]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i < 7)
                        {
                            buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 2)
                            {
                                buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 6)
                        {
                            buttonSettingKeyControl[i].SetActive(false);
                            if (i == 11 || i == 12)
                            {
                                buttonSettingKeyControl[i].SetActive(true);
                            }
                        }
                    }
                    break;
                case 3:
                    eventSystem.SetSelectedGameObject(buttonSettingKeyControlEventSystem[3]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i < 7)
                        {
                            buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 3)
                            {
                                buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 6)
                        {
                            buttonSettingKeyControl[i].SetActive(false);
                            if (i == 13 || i == 14)
                            {
                                buttonSettingKeyControl[i].SetActive(true);
                            }
                        }
                    }
                    break;
                case 4:
                    eventSystem.SetSelectedGameObject(buttonSettingKeyControlEventSystem[4]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i < 7)
                        {
                            buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 4)
                            {
                                buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 6)
                        {
                            buttonSettingKeyControl[i].SetActive(false);
                            if (i == 15 || i == 16)
                            {
                                buttonSettingKeyControl[i].SetActive(true);
                            }
                        }
                    }
                    break;
                case 5:
                    eventSystem.SetSelectedGameObject(buttonSettingKeyControlEventSystem[5]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i < 7)
                        {
                            buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 5)
                            {
                                buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 6)
                        {
                            buttonSettingKeyControl[i].SetActive(false);
                            if (i == 17 || i == 18)
                            {
                                buttonSettingKeyControl[i].SetActive(true);
                            }
                        }
                    }
                    break;
                case 6:
                    eventSystem.SetSelectedGameObject(buttonSettingKeyControlEventSystem[6]);

                    for (int i = 0; i < 21; i++)
                    {
                        if (i < 7)
                        {
                            buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 6)
                            {
                                buttonSettingKeyControl[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 6)
                        {
                            buttonSettingKeyControl[i].SetActive(false);
                            if (i == 19 || i == 20)
                            {
                                buttonSettingKeyControl[i].SetActive(true);
                            }
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                    }
                    break;
            }
        }
        if (screemActive.canvasQuitActive == true)
        {
            switch (objectQuitScreemSeletion)
            {
                default:
                    eventSystem.SetSelectedGameObject(buttonQuitScreemEventSystem[0]);

                    for (int i = 0; i < 6; i++)
                    {
                        if (i < 2)
                        {
                            buttonQuitScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 0)
                            {
                                buttonQuitScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 1)
                        {
                            buttonQuitScreem[i].SetActive(false);
                            if (i == 2 || i == 3)
                            {
                                buttonQuitScreem[i].SetActive(true);
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                    }
                    break;
                case 1:
                    eventSystem.SetSelectedGameObject(buttonQuitScreemEventSystem[1]);

                    for (int i = 0; i < 6; i++)
                    {
                        if (i < 2)
                        {
                            buttonQuitScreem[i].GetComponent<Animator>().SetBool("Seleccionado", false);
                            if (i == 1)
                            {
                                buttonQuitScreem[i].GetComponent<Animator>().SetBool("Seleccionado", true);
                            }
                        }
                        if (i > 1)
                        {
                            buttonQuitScreem[i].SetActive(false);
                            if (i == 4 || i == 5)
                            {
                                buttonQuitScreem[i].SetActive(true);
                            }
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                    }
                    break;
            }
        }
    }

    //   ESTO ES SOLO PARA LOS CONTROLES DE POSICION DE LOS MENUS   //
    private void MoveMenus()
    {
        if (screemActive.canvasStartActive == true)
        {
            if (objectStartScreemSeletion < 0)
            {
                objectStartScreemSeletion = 2;
            }
            if (objectStartScreemSeletion > 2)
            {
                objectStartScreemSeletion = 0;
            }

            if (Input.GetKeyDown(keyControlAssing.teclaW) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                objectStartScreemSeletion--;
            }
            if (Input.GetKeyDown(keyControlAssing.teclaS) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                objectStartScreemSeletion++;
            }
        }
        if (screemActive.canvasLevelsActive == true)
        {
            if (objetoLevelButtonSelection == 0)
            {
                if (objectLevelsScreemSelection < 0)
                {
                    objectLevelsScreemSelection = 4;
                }
                if (objectLevelsScreemSelection > 4)
                {
                    objectLevelsScreemSelection = 0;
                }
                if (Input.GetKeyDown(keyControlAssing.teclaD) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    objectLevelsScreemSelection++;
                }
                if (Input.GetKeyDown(keyControlAssing.teclaA) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    objectLevelsScreemSelection--;
                }
            }

            if (objetoLevelButtonSelection < 0)
            {
                objetoLevelButtonSelection = 1;
            }
            if (objetoLevelButtonSelection > 1)
            {
                objetoLevelButtonSelection = 0;
            }
            if (Input.GetKeyDown(keyControlAssing.teclaW) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                objetoLevelButtonSelection++;
            }
            if (Input.GetKeyDown(keyControlAssing.teclaS) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                objetoLevelButtonSelection--;
            }

        }
        if (screemActive.canvasSettingsActive == true)
        {
            if (objectSettingScreemSeletion < 0)
            {
                objectSettingScreemSeletion = 6;
            }
            if (objectSettingScreemSeletion > 6)
            {
                objectSettingScreemSeletion = 0;
            }

            if (Input.GetKeyDown(keyControlAssing.teclaW) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                objectSettingScreemSeletion--;
            }
            if (Input.GetKeyDown(keyControlAssing.teclaS) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                objectSettingScreemSeletion++;
            }
        }
        if (screemActive.canvasSettingsKeyControlActive == true)
        {
            if (objectSettingKeyControlScreemSeletion < 0)
            {
                objectSettingKeyControlScreemSeletion = 6;
            }
            if (objectSettingKeyControlScreemSeletion > 6)
            {
                objectSettingKeyControlScreemSeletion = 0;
            }
            if (Input.GetKeyDown(keyControlAssing.teclaW) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                objectSettingKeyControlScreemSeletion--;
            }
            if (Input.GetKeyDown(keyControlAssing.teclaS) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                objectSettingKeyControlScreemSeletion++;
            }
        }
        if (screemActive.canvasQuitActive == true)
        {
            if (objectQuitScreemSeletion < 0)
            {
                objectQuitScreemSeletion = 1;
            }
            if (objectQuitScreemSeletion > 1)
            {
                objectQuitScreemSeletion = 0;
            }

            if (Input.GetKeyDown(keyControlAssing.teclaD) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                objectQuitScreemSeletion++;
            }
            if (Input.GetKeyDown(keyControlAssing.teclaA) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                objectQuitScreemSeletion--;
            }
        }
    }
    //                                                              //

    private void MovePlanets()
    {
        if (startScreemAnimations == true)
        {
            for (int i = 0; i < 5; i++)
            {
                backGroundPlanets[i].transform.eulerAngles = backGroundPlanets[i].transform.eulerAngles += new Vector3(0, 0, speedPlanets) * Time.deltaTime;
            }
        }
    }
    //                              //
}
