using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class ControlBoss0 : MonoBehaviour
{
    public static ControlBoss0 controlBoss0;

    // Start is called before the first frame update
    void Start()
    {
        if (controlBoss0 == null)
        {
            controlBoss0 = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float positionX = transform.position.x;

        positionX = Mathf.Clamp(positionX, -11, 11);

        transform.position = new Vector2(positionX, 11);
    }
}
