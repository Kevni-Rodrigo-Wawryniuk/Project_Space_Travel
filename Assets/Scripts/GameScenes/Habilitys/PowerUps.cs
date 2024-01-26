using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public static PowerUps powerUps;

    [Header("Componentes")]
    Rigidbody2D rgb;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprite;

    [Header("Determinar Habilidad")]
    public bool hability;
    public int selection;
    [SerializeField] GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        if (powerUps == null)
        {
            powerUps = this;
        }
        rgb = GetComponent<Rigidbody2D>();

        spriteRenderer = powerUp.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Limits();
        SelectionPowerUp();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    //      LIMITES      //
    public void Limits()
    {
        if (transform.position.y < -13)
        {
            Destroy(this.gameObject);
        }
    }
    //                   //

    //      ELEGIR POWER UP     //
    private void SelectionPowerUp()
    {
        if (hability == true)
        {
            selection = Random.Range(0, 12);

            switch (selection)
            {
                case 0:
                    spriteRenderer.sprite = sprite[0];
                    break;
                case 1:
                    spriteRenderer.sprite = sprite[1];
                    break;
                case 2:
                    spriteRenderer.sprite = sprite[2];
                    break;
                case 3:
                    spriteRenderer.sprite = sprite[3];
                    break;
                case 4:
                    spriteRenderer.sprite = sprite[4];
                    break;
                case 5:
                    spriteRenderer.sprite = sprite[5];
                    break;
                case 6:
                    spriteRenderer.sprite = sprite[6];
                    break;
                case 7:
                    spriteRenderer.sprite = sprite[7];
                    break;
                case 8:
                    spriteRenderer.sprite = sprite[8];
                    break;
                case 9:
                    spriteRenderer.sprite = sprite[9];
                    break;
                case 10:
                    spriteRenderer.sprite = sprite[10];
                    break;
                case 11:
                    spriteRenderer.sprite = sprite[11];
                    break;
                case 12:
                    spriteRenderer.sprite = sprite[12];
                break;
                case 13:
                    spriteRenderer.sprite = sprite[13];
                break;
                case 14:
                    spriteRenderer.sprite = sprite[14];
                break;
            }
        }
    }
    //                          //
}
