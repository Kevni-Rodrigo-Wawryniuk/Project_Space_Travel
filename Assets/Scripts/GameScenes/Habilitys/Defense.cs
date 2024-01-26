using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public static Defense defense;

    [Header("Activar defensas")]
    public bool defenseActive;
    public int useDefense;
    [SerializeField] Nave0 nave0;
    [SerializeField] Transform positionDefense;
    public float timeActive, endTimeActive, speedFollow;

    // Start is called before the first frame update
    void Start()
    {
        if (defense == null)
        {
            defense = this;
        }
        defenseActive = true;

        nave0 = GameObject.FindGameObjectWithTag("Player").GetComponent<Nave0>();

        positionDefense = nave0.positionsShots[5];

        speedFollow = 16;
    }

    // Update is called once per frame
    void Update()
    {
        Defenses();
    }

    private void Defenses()
    {
        if (defenseActive == true)
        {
            switch (useDefense)
            {
                // defensa verde
                case 1:
                    endTimeActive = 2;

                    if (timeActive < endTimeActive)
                    {
                        timeActive += 1 * Time.deltaTime;

                        transform.position = Vector3.Lerp(transform.position, positionDefense.position, speedFollow * Time.deltaTime);
                    }
                    if (timeActive >= endTimeActive)
                    {
                        Destroy(this.gameObject);
                        timeActive = 0;
                    }
                    break;
                // defensa Roja
                case 2:
                    if (timeActive < endTimeActive)
                    {
                        timeActive += 1 * Time.deltaTime;

                        transform.position = Vector3.Lerp(transform.position, positionDefense.position, speedFollow * Time.deltaTime);
                    }
                    if (timeActive >= endTimeActive)
                    {
                        Destroy(this.gameObject);
                        timeActive = 0;
                    }
                    break;
                    // defensa azul
                    case 3:
                    if (timeActive < endTimeActive)
                    {
                        timeActive += 1 * Time.deltaTime;

                        transform.position = Vector3.Lerp(transform.position, positionDefense.position, speedFollow * Time.deltaTime);
                    }
                    if (timeActive >= endTimeActive)
                    {
                        Destroy(this.gameObject);
                        timeActive = 0;
                    }
                    break;
            }
        }
    }
}
