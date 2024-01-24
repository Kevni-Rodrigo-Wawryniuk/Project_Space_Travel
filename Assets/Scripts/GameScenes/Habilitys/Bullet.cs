using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet bullet;

    public int lifeBullet, bulletStatus;

    // Start is called before the first frame update
    void Start()
    {
        if (bullet == null)
        {
            bullet = this;
        }
        switch (bulletStatus)
        {
            case 0:
                lifeBullet = 1;
                break;
            case 1:
                lifeBullet = 2;
                break;
            case 2:
                lifeBullet = 5;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Limit();
    }

    // Limitar las posiciones donde puede estar la bala //
    public void Limit()
    {
        if (transform.position.y > 10.5f)
        {
            Destroy(this.gameObject);
        }
        if (lifeBullet == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
