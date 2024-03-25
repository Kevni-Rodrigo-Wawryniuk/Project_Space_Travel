using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    public static Bombs bombs;

    [SerializeField] GameScene2 gameScene2;
    [SerializeField] Nave0 nave0;
    [SerializeField] Rigidbody2D rgb;
    [SerializeField] Animator animator;

    [Header("Vida")]
    public bool vida;
    [SerializeField] int lifeState;

    [Header("Habilitys")]
    [SerializeField] GameObject hability;
    [SerializeField] GameObject explocion;

    // Start is called before the first frame update
    void Start()
    {
        if (bombs == null)
        {
            bombs = this;
        }

        rgb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        gameScene2 = GameObject.Find("Scripts").GetComponent<GameScene2>();

        nave0 = gameScene2.nave0;

        vida = true;

        lifeState = 2;
    }
    // Update is called once per frame
    void Update()
    {
        Limit();
        EstadoVida();

        transform.Rotate(0, 0, 20 * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            gameScene2.Explociones();
            nave0.DownLife(1);
            Destroy(this.gameObject);
            Instantiate(explocion, transform.position, quaternion.identity);
        }
        if (other.CompareTag("Bullet"))
        {   
            gameScene2.Explociones();
            animator.SetTrigger("danger");
        }
        if (other.CompareTag("Defense"))
        {
            gameScene2.Explociones();
            Destroy(this.gameObject);
            Instantiate(explocion, transform.position, quaternion.identity);
        }
    }

    // limites //
    private void Limit()
    {
        rgb.velocity = new Vector2(0, -6f);

        if (transform.position.y < -12)
        {
            Destroy(this.gameObject);
        }
    }
    // vidas //
    private void EstadoVida()
    {
        switch (lifeState)
        {
            case 0:
                Instantiate(hability, transform.position, quaternion.identity);
                Destroy(this.gameObject);
                Instantiate(explocion, transform.position, quaternion.identity);
                break;
        }
    }
    public void PerderVida()
    {
        lifeState--;
    }
}
