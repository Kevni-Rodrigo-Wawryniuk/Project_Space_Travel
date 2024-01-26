using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScene2 : MonoBehaviour
{
    public static GameScene2 gameScene2;

    [Header("Nave")]
    [SerializeField] int nave;
    [SerializeField] GameObject[] naves;
    [Header("Power Ups")]
    public bool powers;
    [SerializeField] GameObject powerUp;
    [Header("Canvas Control")]
    public bool canvasControl;
    [SerializeField] Canvas[] canvas;
    [SerializeField] bool canavasPlay, canvasPause;

    // Start is called before the first frame update
    void Start()
    {
        if (gameScene2 == null)
        {
            gameScene2 = this;
        }
        nave = PlayerPrefs.GetInt("Nave");
        switch (nave)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }

        canvasPause = false;
        canavasPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        PowerUps();
        CanvasControl();
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
    //                      //

    //   PRUEBA DE HABILIDADES   //
    private void PowerUps()
    {
        if (powers == true)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                float positionX, positionY = 12;
                positionX = Random.Range(-18, 18);
                Instantiate(powerUp, new Vector2(positionX, positionY), Quaternion.identity);
            }
        }
    }
    //                          //
}
