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
    [SerializeField] TextMeshProUGUI textTeclaW, textTeclaS, textTeclaD, textTeclaA, textTeclaShot, textTeclaHability;
    [SerializeField] bool keyUp, keyDown, keyRight, keyLeft, keyShot, keyHability;
    [SerializeField] public KeyCode teclaW, teclaS, teclaD, teclaA, flechaArriba, flechaAbajo, flechaDerecha, flechaIzquierda, teclaShot, teclaHability;
    [SerializeField] float timeChange, endTimeChange;

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
        keyShot = false;
        keyHability = false;

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

    // Update is called once per frame
    void Update()
    {
        textTeclaW.text = "" + teclaW.ToString();
        textTeclaS.text = "" + teclaS.ToString();
        textTeclaD.text = "" + teclaD.ToString();
        textTeclaA.text = "" + teclaA.ToString();
        textTeclaShot.text = "" + teclaShot.ToString();
        textTeclaHability.text = "" + teclaHability.ToString();
    }
    private void LateUpdate()
    {
        if (keyUp == true)
        {

            if (timeChange < endTimeChange)
            {
                timeChange += 1 * Time.deltaTime;
            }
            if (timeChange >= endTimeChange)
            {
                foreach (KeyCode tecla in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(tecla))
                    {
                        AsignarTeclaArriba(tecla);
                    }
                }
            }
        }
        if (keyDown == true)
        {
            if (timeChange < endTimeChange)
            {
                timeChange += 1 * Time.deltaTime;
            }
            if (timeChange >= endTimeChange)
            {
                foreach (KeyCode tecla in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(tecla))
                    {
                        AsignarTeclaAbajo(tecla);
                    }
                }
            }
        }
        if (keyRight == true)
        {
            if (timeChange < endTimeChange)
            {
                timeChange += 1 * Time.deltaTime;
            }
            if (timeChange >= endTimeChange)
            {
                foreach (KeyCode tecla in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(tecla))
                    {
                        AsignarTeclaDerecha(tecla);
                    }
                }
            }
        }
        if (keyLeft == true)
        {
            if (timeChange < endTimeChange)
            {
                timeChange += 1 * Time.deltaTime;
            }
            if (timeChange >= endTimeChange)
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
        if (keyShot == true)
        {
            if (timeChange < endTimeChange)
            {
                timeChange += 1 * Time.deltaTime;
            }
            if (timeChange >= endTimeChange)
            {
                foreach (KeyCode tecla in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(tecla))
                    {
                        AsignarTeclaShot(tecla);
                    }
                }
            }
        }
        if (keyHability == true)
        {
            if (timeChange < endTimeChange)
            {
                timeChange += 1 * Time.deltaTime;
            }
            if (timeChange >= endTimeChange)
            {
                foreach (KeyCode tecla in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(tecla))
                    {
                        AsignarTeclaHabilidad(tecla);
                    }
                }
            }
        }
    }
    //              ASIGNACNION DE TECLAS                //
    public void AsignarTeclaArriba(KeyCode nuevaTecla)
    {
        if (nuevaTecla == flechaArriba)
        {
            nuevaTecla = KeyCode.W;
            PlayerPrefs.SetInt("teclaArriba", (int)nuevaTecla);
            keyUp = false;
            timeChange = 0;
        }
        else
        {
            teclaW = nuevaTecla;
            PlayerPrefs.SetInt("teclaArriba", (int)nuevaTecla);
            keyUp = false;
            timeChange = 0;
        }

    }
    private void AsignarTeclaAbajo(KeyCode nuevaTecla)
    {
        if (nuevaTecla == flechaAbajo)
        {
            nuevaTecla = KeyCode.S;
            PlayerPrefs.SetInt("teclaAbajo", (int)nuevaTecla);
            keyDown = false;
            timeChange = 0;
        }
        else
        {
            teclaS = nuevaTecla;
            PlayerPrefs.SetInt("teclaAbajo", (int)nuevaTecla);
            keyDown = false;
            timeChange = 0;
        }

    }
    private void AsignarTeclaDerecha(KeyCode nuevaTecla)
    {
        if (nuevaTecla == flechaDerecha)
        {
            nuevaTecla = KeyCode.D;
            PlayerPrefs.SetInt("teclaDerecha", (int)nuevaTecla);
            keyRight = false;
            timeChange = 0;
        }
        else
        {
            teclaD = nuevaTecla;
            PlayerPrefs.SetInt("teclaDerecha", (int)nuevaTecla);
            keyRight = false;
            timeChange = 0;
        }
    }
    private void AsignarTeclaIzquierda(KeyCode nuevaTecla)
    {
        if (nuevaTecla == flechaIzquierda)
        {
            nuevaTecla = KeyCode.A;
            PlayerPrefs.SetInt("teclaIzquieda", (int)nuevaTecla);
            keyLeft = false;
            timeChange = 0;
        }
        else
        {
            teclaA = nuevaTecla;
            PlayerPrefs.SetInt("teclaIzquieda", (int)nuevaTecla);
            keyLeft = false;
            timeChange = 0;
        }
    }
    private void AsignarTeclaShot(KeyCode nuevaTecla)
    {
        teclaShot = nuevaTecla;
        PlayerPrefs.SetInt("teclaShot", (int)nuevaTecla);
        keyShot = false;
        timeChange = 0;
    }
    private void AsignarTeclaHabilidad(KeyCode nuevaTecla)
    {
        teclaHability = nuevaTecla;
        PlayerPrefs.SetInt("teclaHabilidad", (int)nuevaTecla);
        keyHability = false;
        timeChange = 0;
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
    public void BotonTeclaShot()
    {
        keyShot = !keyShot;
    }
    public void BotonTeclaHabilidad()
    {
        keyHability = !keyHability;
    }
    //                                                  //
}
