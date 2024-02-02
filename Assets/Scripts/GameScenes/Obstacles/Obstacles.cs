using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public static Obstacles obstacles;

    [Header("Nave")]
    [SerializeField] Nave0 nave0;
    [SerializeField] int naveSelection;

    // Start is called before the first frame update
    void Start()
    {
        if(obstacles == null)
        {
            obstacles = this;
        }        
        naveSelection = PlayerPrefs.GetInt("Nave", 0);
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.CompareTag("Player"))
        {
            nave0.DownLife(1);
            Destroy(this.gameObject);
        }
        if(other.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
