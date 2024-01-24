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
    }

    // Update is called once per frame
    void Update()
    {
        PowerUps();
    }
    private void CanvasControl()
    {
        if (canvasControl == true)
        {

        }
    }

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
