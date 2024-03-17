using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class LevelsActive : MonoBehaviour
{
    public static LevelsActive levelsActive;

    [SerializeField] Nave0 nave0;
    [SerializeField] int naveSelection;

    [Header("Nivel Activado")]
    public bool levelActive, activarNave;
    public int backGroundActive;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Texture[] textures;
    [SerializeField] float speedBackGround;

    // Start is called before the first frame update
    void Start()
    {
        if (levelsActive == null)
        {
            levelsActive = this;
        }

        backGroundActive = PlayerPrefs.GetInt("LevelSelection", 0);
        meshRenderer = GetComponent<MeshRenderer>();
        naveSelection = PlayerPrefs.GetInt("Nave", 0);
        speedBackGround = 0.5f;

        activarNave = true;
    }

    // Update is called once per frame
    void Update()
    {
        ActiveLevel();
        MoveLevel();
    }
    //  ACTIVAR NIVEL   //
    private void ActiveLevel()
    {
        if (levelActive == true)
        {
            switch (backGroundActive)
            {
                case 0:
                    meshRenderer.material.mainTexture = textures[0];
                    break;
                case 1:
                    meshRenderer.material.mainTexture = textures[1];
                    break;
                case 2:
                    meshRenderer.material.mainTexture = textures[2];
                    break;
                case 3:
                    meshRenderer.material.mainTexture = textures[3];
                    break;
                case 4:
                    meshRenderer.material.mainTexture = textures[4];
                    break;
            }
        }
    }
    //  ACTIVAR NIVEL   //
    private void MoveLevel()
    {

        if (activarNave == true)
        {
            switch (naveSelection)
            {
                case 0:
                    nave0 = GameObject.Find("Nave_0(Clone)").GetComponent<Nave0>();
                    break;
                case 1:
                    nave0 = GameObject.Find("Nave_1(Clone)").GetComponent<Nave0>();
                    break;
                case 2:
                    nave0 = GameObject.Find("Nave_2(Clone)").GetComponent<Nave0>();
                    break;
                case 3:
                    nave0 = GameObject.Find("Nave_3(Clone)").GetComponent<Nave0>();
                    break;
                case 4:
                    nave0 = GameObject.Find("Nave_4(Clone)").GetComponent<Nave0>();
                    break;
                case 5:
                    nave0 = GameObject.Find("Nave_5(Clone)").GetComponent<Nave0>();
                    break;
            }

            if (nave0.StartSceneActive == false)
            {
                meshRenderer.material.mainTextureOffset = meshRenderer.material.mainTextureOffset += new Vector2(0, speedBackGround) * Time.deltaTime;
            }
        }
    }
}
