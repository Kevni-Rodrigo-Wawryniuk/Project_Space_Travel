using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControlAssingPlay : MonoBehaviour
{
    public static KeyControlAssingPlay keyControlAssingPlay;

    [Header("Cambio de Teclas de Movimietos")]
    public bool controlKey;
    public KeyCode teclaW, teclaS, teclaD, teclaA, flechaArriba, flechaAbajo, flechaDerecha, flechaIzquierda, teclaShot, teclaHability;
    [SerializeField] int startKeys;

    // Start is called before the first frame update
    void Start()
    {
        if (keyControlAssingPlay == null)
        {
            keyControlAssingPlay = this;
        }

        startKeys = PlayerPrefs.GetInt("teclasIniciales");

        controlKey = true;

        if (controlKey == true)
        {
            flechaArriba = KeyCode.UpArrow;
            flechaAbajo = KeyCode.DownArrow;
            flechaDerecha = KeyCode.RightArrow;
            flechaIzquierda = KeyCode.LeftArrow;

            if (startKeys == 0)
            {
                PlayerPrefs.SetInt("teclaArriba", (int)KeyCode.W);
                PlayerPrefs.SetInt("teclaAbajo", (int)KeyCode.S);
                PlayerPrefs.SetInt("teclaDerecha", (int)KeyCode.D);
                PlayerPrefs.SetInt("teclaIzquieda", (int)KeyCode.A);
                PlayerPrefs.SetInt("teclaShot", (int)KeyCode.J);
                PlayerPrefs.SetInt("teclaHabilidad", (int)KeyCode.E);
            }
            if (startKeys == 1)
            {
                teclaW = (KeyCode)PlayerPrefs.GetInt("teclaArriba");
                teclaS = (KeyCode)PlayerPrefs.GetInt("teclaAbajo");
                teclaD = (KeyCode)PlayerPrefs.GetInt("teclaDerecha");
                teclaA = (KeyCode)PlayerPrefs.GetInt("teclaIzquieda");
                teclaShot = (KeyCode)PlayerPrefs.GetInt("teclaShot");
                teclaHability = (KeyCode)PlayerPrefs.GetInt("teclaHabilidad");
            }
        }
    }
}

