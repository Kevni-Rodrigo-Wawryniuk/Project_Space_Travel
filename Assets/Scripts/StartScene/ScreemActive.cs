using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class ScreemActive : MonoBehaviour
{
    public static ScreemActive screemActive;

    [SerializeField] StartMenu startMenu;

    [Header("Screems")]
    public bool activeScreem;
    public bool canvasStartActive, canvasLevelsActive, canvasSettingsActive, canvasSettingsKeyControlActive, canvasQuitActive;
    [SerializeField] Canvas[] canvasStartScene;
    [SerializeField] GameObject PlanetActive;
    [SerializeField] int valorLevel;
    [SerializeField] bool mostrarText;
    [SerializeField] float time, endTime;

    // Start is called before the first frame update
    void Start()
    {
        if (screemActive == null)
        {
            screemActive = this;
        }

        startMenu = GameObject.Find("Scripts").GetComponent<StartMenu>();

        canvasStartActive = true;
        canvasLevelsActive = false;
        canvasSettingsActive = false;
        canvasSettingsKeyControlActive = false;
        canvasQuitActive = false;

        endTime = 1;
    }
    void Update()
    {
        valorLevel = startMenu.objectLevelsScreemSelection;

        PlanetActive.SetActive(canvasLevelsActive);

        canvasStartScene[0].enabled = canvasStartActive;
        canvasStartScene[1].enabled = canvasLevelsActive;
        canvasStartScene[2].enabled = canvasSettingsActive;
        canvasStartScene[3].enabled = canvasSettingsKeyControlActive;
        canvasStartScene[4].enabled = canvasQuitActive;

        startMenu.advertencia.enabled = mostrarText;

        if (mostrarText == true)
        {
            if (time < endTime)
            {
                time += 1 * Time.deltaTime;
            }
            else
            {
                time = 0;
                mostrarText = false;
            }
        }

    }
    // Animations Functions //
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
        Application.Quit();
        Debug.Log("Saliste Del Juego");
    }
    //                      //

    // Pasar a otra scena  //
    public void PassLoadScene()
    {
        if (valorLevel == 1)
        {
            if (startMenu.valueLevel1 >= 400)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                mostrarText = true;
                startMenu.advertencia.text = "you need to get 400 points";
            }
        }
        if (valorLevel == 0)
        {
            SceneManager.LoadScene(1);
        }

    }
    //                     //
}
