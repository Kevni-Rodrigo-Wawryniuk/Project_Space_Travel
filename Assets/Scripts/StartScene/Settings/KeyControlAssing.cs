using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class KeyControlAssing : MonoBehaviour
{
    public static KeyControlAssing keyControlAssing;

    [Header("Cambio de Teclas de Movimietos")]
    public bool controlKey;
    [SerializeField] TextMeshProUGUI textTeclaW, textTeclaS, textTeclaD, textTeclaA;
    [SerializeField] bool keyUp, keyDown, keyRight, keyLeft;
    [SerializeField] public KeyCode teclaW, teclaS, teclaD, teclaA;

    // Start is called before the first frame update
    void Start()
    {
        if (keyControlAssing == null)
        {
            keyControlAssing = this;
        }

        keyUp = false;
        keyDown = false;
        keyRight = false;
        keyLeft = false;
    }

    // Update is called once per frame
    void Update()
    {

        textTeclaW.text = "" + teclaW.ToString();
        textTeclaS.text = "" + teclaS.ToString();
        textTeclaD.text = "" + teclaD.ToString();
        textTeclaA.text = "" + teclaA.ToString();

        if (keyUp == true)
        {
            foreach (KeyCode tecla in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(tecla))
                {
                    AsignarTeclaArriba(tecla);
                }
            }
        }
        if (keyDown == true)
        {
            foreach (KeyCode tecla in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(tecla))
                {
                    AsignarTeclaAbajo(tecla);
                }
            }
        }
        if (keyRight == true)
        {
            foreach (KeyCode tecla in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(tecla))
                {
                    AsignarTeclaDerecha(tecla);
                }
            }
        }
        if (keyLeft == true)
        {
            foreach (KeyCode tecla in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(tecla))
                {
                    AsignarTeclaIzquierda(tecla);
                }
            }
        }
    }
    //              ASIGNACNION DE TECLAS                //
    private void AsignarTeclaArriba(KeyCode nuevaTecla)
    {
        teclaW = nuevaTecla;
        PlayerPrefs.SetInt("teclaArriba", (int)nuevaTecla);
        keyUp = false;
    }
    private void AsignarTeclaAbajo(KeyCode nuevaTecla)
    {
        teclaS = nuevaTecla;
        PlayerPrefs.SetInt("teclaAbajo", (int)nuevaTecla);
        keyDown = false;
    }
    private void AsignarTeclaDerecha(KeyCode nuevaTecla)
    {
        teclaD = nuevaTecla;
        PlayerPrefs.SetInt("teclaDerecha", (int)nuevaTecla);
        keyRight = false;
    }
    private void AsignarTeclaIzquierda(KeyCode nuevaTecla)
    {
        teclaA = nuevaTecla;
        PlayerPrefs.SetInt("teclaIzquieda", (int)nuevaTecla);
        keyLeft = false;
    }
    //                                                  //

    //              FUNCIONE DE BOTONES                 //
    public void BotonTeclaArriba()
    {
        keyUp = !keyUp;
    }
    public void BotonTeclaAbajo()
    {
        keyDown = !keyDown;
    }
    public void BotonTeclaDerecha()
    {
        keyRight = !keyRight;
    }
    public void BotonTeclaIzquierda()
    {
        keyLeft = !keyLeft;
    }
    //                                                  //
}
