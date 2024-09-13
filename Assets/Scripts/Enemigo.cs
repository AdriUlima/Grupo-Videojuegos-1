using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Enemigo : MonoBehaviour
{
    //[SerializeField] private string nombre;
    [SerializeField] private int hp = 1;
    public float speed;
    [SerializeField] private Vector2 rangoRot = new Vector2(30f, 50f);
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Rigidbody2D rb;
    
    void Start()
    {
        sp.color = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
        rb.angularVelocity = Random.Range(rangoRot.x, rangoRot.y) * Random.Range(0,2)==0?-1:1;
    }

    public void SetStartSpeed(float s)
    {
        speed = s;
        gameObject.SetActive(true);
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