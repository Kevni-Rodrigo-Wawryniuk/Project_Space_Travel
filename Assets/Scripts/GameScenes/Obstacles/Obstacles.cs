using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class Obstacles : MonoBehaviour
{
    public static Obstacles obstacles;
    [SerializeField] GameScene2 gameScene2;

    [SerializeField] Rigidbody2D rgb;

    [Header("Nave")]
    [SerializeField] Nave0 nave0;
    [SerializeField] int naveSelection;

    [Header("Moviment")]
    [SerializeField] int moviments;
    [SerializeField] float speedX, speedY;

    [Header("Explocion")]
    [SerializeField] GameObject explocion;

    // Start is called before the first frame update
    void Start()
    {
        if (obstacles == null)
        {
            obstacles = this;
        }
        rgb = GetComponent<Rigidbody2D>();

        moviments = Random.Range(0, 2);

        naveSelection = PlayerPrefs.GetInt("Nave", 0);

        gameScene2 = GameObject.Find("Scripts").GetComponent<GameScene2>();

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

        speedY = -10;
    }
    void Update()
    {
        if (transform.position.y < -13)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        switch (moviments)
        {
            case 0:
                speedX = 0;
                rgb.velocity = new Vector2(speedX, speedY);
                break;
            case 1:
                speedX = 2;
                rgb.velocity = new Vector2(speedX, speedY);
                break;
            case 2:
                speedX = -2;
                rgb.velocity = new Vector2(speedX, speedY);
                break;
            case 3:
                speedX = 0;
                rgb.velocity = new Vector2(speedX, speedY);
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            nave0.DownLife(1);
            Destroy(this.gameObject);
            Instantiate(explocion, transform.position, quaternion.identity);
        }
        if (other.CompareTag("Bullet"))
        {
            gameScene2.metheorosPoints++;
            Destroy(this.gameObject);
            Instantiate(explocion, transform.position, quaternion.identity);  
        }
        if(other.CompareTag("Defense"))
        {
            Destroy(this.gameObject);
            Instantiate(explocion, transform.position, quaternion.identity);      
        }
    }
}
