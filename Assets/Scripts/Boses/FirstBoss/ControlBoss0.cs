using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

public class ControlBoss0 : MonoBehaviour
{
    public static ControlBoss0 controlBoss0;

    [SerializeField] GameScene2 gameScene2;

    [Header("Live")]
    public bool live;
    [SerializeField] int liveValue;
    [SerializeField] GameObject explocion;


    [Header("Posicionar jefe")]
    public bool positionBoss;
    [SerializeField] float speedY;
    [SerializeField] Animator animator;

    [Header("Pantalla de vida")]
    public bool pantallaActiva;
    [SerializeField] Slider sliderVida;
    [SerializeField] AudioSource sonido;

    // Start is called before the first frame update
    void Start()
    {
        if (controlBoss0 == null)
        {
            controlBoss0 = this;
        }
        live = true;
        positionBoss = true;

        speedY = 0.02f;

        gameScene2 = GameObject.Find("Scripts").GetComponent<GameScene2>();
        explocion = Resources.Load<GameObject>("Explocion");

        sliderVida = GameObject.Find("Slider").GetComponent<Slider>();

        sliderVida.maxValue = 60;
        sliderVida.wholeNumbers = true;
        liveValue = 60;

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float positionX = transform.position.x;

        if (positionBoss == false)
        {
            positionX = Mathf.Clamp(positionX, -11, 11);

            transform.position = new Vector2(positionX, 11);
        }

        sliderVida.value = liveValue;

        Life();

        PositionarNave();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (liveValue > 0)
            {
                liveValue--;
                gameScene2.Explociones();
            }
        }
    }
    private void PositionarNave()
    {
        if (positionBoss == true && transform.position.y > 11)
        {
            transform.Translate(Vector3.down * speedY, Space.World);

            animator.SetBool("Active", false);
        }
        else
        {
            animator.SetBool("Active", true);
        }

        if (transform.position.y < 11)
        {
            positionBoss = false;
        }
    }
    private void Life()
    {
        if (live == true)
        {
            if (liveValue <= 0)
            {
                gameScene2.bossCombat = false;
                animator.SetBool("Active", false);
                animator.SetTrigger("Destroy");
            }
        }
    }
    public void Explociones()
    {
        Instantiate(explocion, transform.position, quaternion.identity);
        gameScene2.Explociones();
    }
    public void Destroyer()
    {
        Destroy(this.gameObject);
        gameScene2.canvasWin = true;
        gameScene2.playAudioFondo = 2;
        Time.timeScale = 0;
        live = false;
        gameScene2.playAudioWin = 2;
    }

    public void SonidoLazerPLay()
    {
        sonido.Play();
    }
    public void SonidoLazerStop()
    {
        sonido.Stop();
    }
}