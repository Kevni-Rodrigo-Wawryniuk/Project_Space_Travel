using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    public static LoadingScene loadingScene;

    [Header("Loading Scenes")]
    public bool load;
    [SerializeField] Slider sliderLoad;
    [SerializeField] int sceneValue;
    [SerializeField] float timePaseScene, endTimePaseScene;

    [Header("Pantalla De Carga")]
    public bool screemLoad;
    [SerializeField] MeshRenderer[] BackGroundStars;
    [SerializeField] float speedMeteorX, speedMeteorY;

    // Start is called before the first frame update
    void Start()
    {
        if (loadingScene == null)
        {
            loadingScene = this;
        }
        load = true;
        screemLoad = true;

        sceneValue = PlayerPrefs.GetInt("Level", 0);

        if (load == true)
        {
            StartCoroutine(ChargeScene(sceneValue));
        }
    }

    void Update()
    {
        ScreemLoad();
    }
    //          PANTALLA DE CARGA               //
    private void ScreemLoad()
    {
        if (screemLoad == true)
        {
            for (int i = 0; i < 16; i++)
            {
                BackGroundStars[i].material.mainTextureOffset = BackGroundStars[i].material.mainTextureOffset += new Vector2(speedMeteorX, speedMeteorY) * Time.deltaTime;
            }
        }
    }
    //                                          //

    //          CARGANDO SIGUIENTE ESCENA       //
    IEnumerator ChargeScene(int valueScene)
    {
        valueScene = sceneValue;

        AsyncOperation operation = SceneManager.LoadSceneAsync(valueScene);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            sliderLoad.value = operation.progress;

            if (operation.progress >= 0.9f)
            {
                timePaseScene += 1 * Time.deltaTime;
                if (timePaseScene > endTimePaseScene)
                {
                    timePaseScene = 0;
                    operation.allowSceneActivation = true;
                    Time.timeScale = 1;
                }
            }
            yield return null;
        }
    }
    //                                          //
}
