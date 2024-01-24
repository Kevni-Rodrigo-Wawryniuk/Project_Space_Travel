using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControlAssingPlay : MonoBehaviour
{
    public static KeyControlAssingPlay keyControlAssingPlay;

    [Header("Cambio de Teclas de Movimietos")]
    public bool controlKey;
    [SerializeField] public KeyCode teclaW, teclaS, teclaD, teclaA, flechaArriba, flechaAbajo, flechaDerecha, flechaIzquierda, teclaShot, teclaHability;


    // Start is called before the first frame update
    void Start()
    {
        if (keyControlAssingPlay == null)
        {
            keyControlAssingPlay = this;
        }

        controlKey = true;

        if (controlKey == true)
        {
            flechaArriba = KeyCode.UpArrow;
            flechaAbajo = KeyCode.DownArrow;
            flechaDerecha = KeyCode.RightArrow;
            flechaIzquierda = KeyCode.LeftArrow;

            teclaW = (KeyCode)PlayerPrefs.GetInt("teclaArriba");
            teclaS = (KeyCode)PlayerPrefs.GetInt("teclaAbajo");
            teclaD = (KeyCode)PlayerPrefs.GetInt("teclaDerecha");
            teclaA = (KeyCode)PlayerPrefs.GetInt("teclaIzquieda");
            teclaShot = (KeyCode)PlayerPrefs.GetInt("teclaShot");
            teclaHability = (KeyCode)PlayerPrefs.GetInt("teclaHabilidad");
        }
    }
}

