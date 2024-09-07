using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Enemigo : MonoBehaviour
{
    //[SerializeField] private string nombre;
    [SerializeField] private int hp = 1;
    public float speed;
    [SerializeField] private float speedRot = 20f;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Rigidbody2D rb;
    
    void Start()
    {
        sp.color = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
        rb.angularVelocity = speedRot;
    }

    public void Damage(int n)
    {
        hp -= n;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}