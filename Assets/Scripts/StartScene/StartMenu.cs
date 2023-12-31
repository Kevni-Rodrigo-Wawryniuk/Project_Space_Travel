using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public static StartMenu startMenu;
    [Header("Scripts")]
    [SerializeField] KeyControlAssing keyControlAssing;

    [Header("Start Screem")]
    public bool startScreemAnimations;
    [SerializeField] int objectSeletion;
    [SerializeField] bool canvasStartActive, canvasLevelsActive, canvasSettingsActive, canvasSettingsKeyControlActive, canvasQuitActive;
    [SerializeField] Canvas[] canvasStartScene;
    [SerializeField] RectTransform[] buttonStartScreem;
    [SerializeField] MeshRenderer[] backGroundStars;
    [SerializeField] float speedBackGround;

    // Start is called before the first frame update
    void Start()
    {
        if (startMenu == null)
        {
            startMenu = this;
        }

        keyControlAssing = GetComponent<KeyControlAssing>();

        PreAsignacionDeTeclas();

        startScreemAnimations = true;
        canvasStartActive = true;
        canvasLevelsActive = false;
        canvasSettingsActive = false;
        canvasSettingsKeyControlActive = false;
        canvasQuitActive = false;
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
    }

    // Update is called once per frame
    void Update()
    {
        // Menu
        Menus();
        MoveMenus();

        // mover el fondo
        MoveBackGround();
    }
    //      UTILIZANDO MENUS        //
    private void Menus()
    {
        canvasStartScene[0].enabled = canvasStartActive;
        canvasStartScene[1].enabled = canvasLevelsActive;
        canvasStartScene[2].enabled = canvasSettingsActive;
        canvasStartScene[3].enabled = canvasSettingsKeyControlActive;
        canvasStartScene[4].enabled = canvasQuitActive;

        if (canvasStartActive == true)
        {
            switch (objectSeletion)
            {
                default:
                    buttonStartScreem[0].localScale = new Vector3(1.1f, 1.1f, 1);
                    buttonStartScreem[1].localScale = new Vector3(1, 1, 1);
                    buttonStartScreem[2].localScale = new Vector3(1, 1, 1);

                    if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                    {
                        BotonLevels();
                    }
                    break;
                case 1:
                    buttonStartScreem[1].localScale = new Vector3(1.1f, 1.1f, 1);
                    buttonStartScreem[0].localScale = new Vector3(1, 1, 1);
                    buttonStartScreem[2].localScale = new Vector3(1, 1, 1);

                    if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                    {
                        BotonSettings();
                    }
                    break;
                case 2:
                    buttonStartScreem[2].localScale = new Vector3(1.1f, 1.1f, 1);
                    buttonStartScreem[0].localScale = new Vector3(1, 1, 1);
                    buttonStartScreem[1].localScale = new Vector3(1, 1, 1);

                    if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                    {
                        BotonQuit();
                    }
                    break;
            }
        }
    }
    private void MoveMenus()
    {
        if (canvasStartActive == true)
        {
            if (objectSeletion < 0)
            {
                objectSeletion = 2;
            }
            if (objectSeletion > 2)
            {
                objectSeletion = 0;
            }

            if (Input.GetKeyDown(keyControlAssing.teclaW) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                objectSeletion--;
            }
            if (Input.GetKeyDown(keyControlAssing.teclaS) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                objectSeletion++;
            }
        }
        if (canvasLevelsActive == true) { }
        if (canvasSettingsActive == true)
        {
            
        }
        if (canvasSettingsKeyControlActive == true) { }
        if (canvasQuitActive == true) { }
    }
    //                              //
    //      FUNCIONES DE BOTONES    //
    public void BotonLevels()
    {
        canvasStartActive = !canvasStartActive;
        canvasLevelsActive = !canvasLevelsActive;
    }
    public void BotonSettings()
    {
        canvasStartActive = !canvasStartActive;
        canvasSettingsActive = !canvasSettingsActive;
    }
    public void BotonSettingsKeyControl()
    {
        canvasSettingsActive = !canvasSettingsActive;
        canvasSettingsKeyControlActive = !canvasSettingsKeyControlActive;
    }
    public void BotonQuit()
    {
        canvasStartActive = !canvasStartActive;
        canvasQuitActive = !canvasQuitActive;
    }
    public void BotonQuitYes()
    {
        Debug.Log("Saliste del Juego");
        Application.Quit();
    }
    //                              //

    //      Mover las Estrellas     //
    private void MoveBackGround()
    {
        if (startScreemAnimations == true)
        {
            for (int i = 0; i < 16; i++)
            {
                backGroundStars[i].material.mainTextureOffset = backGroundStars[i].material.mainTextureOffset + new Vector2(0, speedBackGround) * Time.deltaTime;
            }
        }
    }
    //                              //
}
