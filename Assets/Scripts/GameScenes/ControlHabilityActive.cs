using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security;
using System.Runtime.Serialization.Formatters;

public class ControlHabilityActive : MonoBehaviour
{
    public static ControlHabilityActive controlHabilityActive;

    [SerializeField] Nave0 nave0;

    [Header("Habilidades")]
    public bool habilitys;
    public int habilityValue;
    [SerializeField] Image[] imageHabilitys;
    [SerializeField] float timeHability, endTimeHability;
    public bool activeHability, useHability;

    // Start is called before the first frame update
    void Start()
    {
        if (controlHabilityActive == null)
        {
            controlHabilityActive = this;
        }

        habilitys = true;
    }

    // Update is called once per frame
    void Update()
    {
        ControlHability();
    }

    private void ControlHability()
    {
        if (habilitys == true)
        {
            if (activeHability == true)
            {
                if (useHability == true)
                {
                    if (timeHability < endTimeHability)
                    {
                        timeHability += 1 * Time.deltaTime;
                    }
                    if (timeHability > endTimeHability)
                    {
                        activeHability = false;
                        useHability = false;
                        habilityValue = 0;
                        timeHability = 0;
                        nave0 = GameObject.FindGameObjectWithTag("Player").GetComponent<Nave0>();
                        nave0.habilityActive = 0;
                    }
                }
            }

            switch (habilityValue)
            {
                case 0:
                    for (int i = 0; i <= 9; i++)
                    {
                        imageHabilitys[i].enabled = false;
                        activeHability = false;
                    }
                    break;
                // rafaga roja
                case 3:
                    endTimeHability = 5;
                    for (int i = 0; i <= 9; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 1)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                // rafaga celeste
                case 4:
                    endTimeHability = 5;
                    for (int i = 0; i <= 9; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 2)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                // rafage azul
                case 5:
                    endTimeHability = 5;
                    for (int i = 0; i <= 9; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 3)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                // defensa verde
                case 6:
                    endTimeHability = 1;
                    for (int i = 0; i <= 9; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 4)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                // defensa roja
                case 7:
                    endTimeHability = 10;
                    for (int i = 0; i <= 9; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 5)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                // defensa azul
                case 8:
                    endTimeHability = 10;
                    for (int i = 0; i <= 9; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 6)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                // Esfera celeste
                case 9:
                    endTimeHability = 5;
                    for (int i = 0; i <= 9; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 7)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                // Esfera azul
                case 10:
                    endTimeHability = 5;
                    for (int i = 0; i <= 9; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 8)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                // Esfera roja
                case 11:
                    endTimeHability = 5;
                    for (int i = 0; i <= 9; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 9)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
            }
        }
    }
}
