using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreem : MonoBehaviour
{
    public static FullScreem fullScreem;

    [Header("Full Screem")]
    public bool fullScreems;
    [SerializeField] Toggle toggleScreem;

    // Start is called before the first frame update
    void Start()
    {
        StartProgram();
    }

    private void StartProgram(){
        if(fullScreem == null){
            fullScreem = this;
        }
        fullScreems = true;

        if(fullScreems == true){
            if(Screen.fullScreen == true){
                toggleScreem.isOn = true;
            }else{
                toggleScreem.isOn = false;
            }
        }
    }

    public void ScreemFull(bool fullScreemss){
        Screen.fullScreen = fullScreemss;
    }
    public void changeScreen(){
        Screen.fullScreen =! Screen.fullScreen;
        toggleScreem.isOn =! toggleScreem.isOn;
    }
}
