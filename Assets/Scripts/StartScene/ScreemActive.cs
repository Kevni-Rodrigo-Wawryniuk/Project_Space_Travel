using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScreemActive : MonoBehaviour
{
    public static ScreemActive screemActive;
    [Header("Screems")]
    public bool activeScreem;
    public bool canvasStartActive, canvasLevelsActive, canvasSettingsActive, canvasSettingsKeyControlActive, canvasQuitActive;
    [SerializeField] Canvas[] canvasStartScene;
    [SerializeField] GameObject PlanetActive;
    
    // Start is called before the first frame update
    void Start()
    {
        if (screemActive == null)
        {
            screemActive = this;
        }

        canvasStartActive = true;
        canvasLevelsActive = false;
        canvasSettingsActive = false;
        canvasSettingsKeyControlActive = false;
        canvasQuitActive = false;
    }
    void Update()
    {
        PlanetActive.SetActive(canvasLevelsActive);

        canvasStartScene[0].enabled = canvasStartActive;
        canvasStartScene[1].enabled = canvasLevelsActive;
        canvasStartScene[2].enabled = canvasSettingsActive;
        canvasStartScene[3].enabled = canvasSettingsKeyControlActive;
        canvasStartScene[4].enabled = canvasQuitActive;
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
        SceneManager.LoadScene(1);
    }
    //                     //
}
