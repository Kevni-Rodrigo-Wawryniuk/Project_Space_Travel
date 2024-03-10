using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        if (bullet == null)
        {
            bullet = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Limit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Meteoro"))
        {
            Destroy(this.gameObject);
        }
    }

    // Limitar las posiciones donde puede estar la bala //
    public void Limit()
    {
        if (transform.position.y > 10.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
