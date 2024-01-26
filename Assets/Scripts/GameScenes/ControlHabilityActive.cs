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
                    endTimeHability = 5;
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
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;
                        activeHability = false;
                    }
                    break;
                case 1:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 1)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 2)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 3)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 4)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                case 5:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 5)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                case 6:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 6)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                case 7:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 7)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                case 8:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 8)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                case 9:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 9)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                case 10:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 10)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                case 11:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 11)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
                case 12:
                    for (int i = 0; i <= 12; i++)
                    {
                        imageHabilitys[i].enabled = false;

                        if (i == 12)
                        {
                            imageHabilitys[i].enabled = true;
                        }
                    }
                    break;
            }
        }
    }
}
