using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MouseDetect : MonoBehaviour
{
    public static MouseDetect mouseDetect;
    [SerializeField] string objetoCliqueado;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] Canvas canvasGeneral;
    private void Update()
    {
        /*
    if(Input.GetMouseButtonDown(0)){
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)){
                GameObject objetoAClickear = hit.transform.gameObject;

                objetoCliqueado = objetoAClickear.name.ToString();

            }
        }
    */

        /*
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 pos;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasGeneral.transform as RectTransform, Input.mousePosition, canvasGeneral.worldCamera, out pos);

                    GameObject botonPresionado = null;
                    foreach (Transform child in canvasGeneral.transform){
                        RectTransform rectTransform = child.GetComponent<RectTransform>();
                        if(rectTransform != null && rectTransform.rect.Contains(pos)){
                            botonPresionado = child.gameObject;
                            break;
                        }
                    }
                    if(botonPresionado != null){
                        objetoCliqueado = botonPresionado.ToString();
                    }
                }
        */

        if(EventSystem.current.currentSelectedGameObject != null){
            GameObject objetoSeleccionado = EventSystem.current.currentSelectedGameObject;
            //Debug.Log("El objeto seleccionado: " + objetoSeleccionado);
        }

    }


    private void OnMouseDown()
    {

    }
}
