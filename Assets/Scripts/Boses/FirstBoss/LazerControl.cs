using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerControl : MonoBehaviour
{
    public static LazerControl lazerControl;

    [SerializeField] Nave0 nave0;
    [SerializeField] Vector2 positionPlayer;
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] GameScene2 gameScene2;

    public bool activePosition;
    // Start is called before the first frame update
    void Start()
    {
        if (lazerControl == null)
        {
            lazerControl = this;
        }
        boxCollider2D = GetComponent<BoxCollider2D>();
        nave0 = GameObject.FindGameObjectWithTag("Player").GetComponent<Nave0>();
        gameScene2 = GameObject.Find("Scripts").GetComponent<GameScene2>();
    }

    // Update is called once per frame
    void Update()
    {
        positionPlayer = transform.position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            gameScene2.Explociones();
            nave0.DownLife(1);
        }
    }
    public void DestroyLazer()
    {
        Destroy(this.gameObject);
    }
    public void ActivePosition()
    {
        activePosition = true;
    }
    public void DesactivePosition()
    {
        activePosition = false;
    }
    public void DesactivarCollider()
    {
        boxCollider2D.enabled = false;
    }
    public void ActivarCollider()
    {
        boxCollider2D.enabled = true;
    }
}
