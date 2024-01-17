using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene2 : MonoBehaviour
{
    public static GameScene2 gameScene2;

    [Header("Nave")]
    [SerializeField] int nave;
    [SerializeField] GameObject[] naves;

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

    }
}
