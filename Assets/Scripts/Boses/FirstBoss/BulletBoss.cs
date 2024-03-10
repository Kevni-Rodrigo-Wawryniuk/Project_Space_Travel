using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    public static BulletBoss bulletBoss;

    [SerializeField] Nave0 nave0;
 
    // Start is called before the first frame update
    void Start()
    {
        nave0 = GameObject.FindGameObjectWithTag("Player").GetComponent<Nave0>();
    }
 
    // Update is called once per frame
    void Update()
    {
        Limit();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            nave0.DownLife(1);
            Destroy(this.gameObject);
        }
    }
    // Limit //
    void Limit()
    {
        if(transform.position.y < -13)
        {
            Destroy(this.gameObject);
        }
    }

}
