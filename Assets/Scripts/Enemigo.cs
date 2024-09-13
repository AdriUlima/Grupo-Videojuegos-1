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
    
    public float moveSpeed = 3f; // Velocidad de movimiento
    public float bounceForce = 0.5f; // Fuerza de rebote adicional
    private Vector2 currentDirection; // Dirección de movimiento actual


    void Start()
    {
        sp.color = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
        rb.angularVelocity = Random.Range(rangoRot.x, rangoRot.y) * Random.Range(0,2)==0?-1:1;

        currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
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

    void Update()
    {
        // Mover el cilindro en la dirección actual
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Obtener la normal de colisión para calcular el rebote
        Vector2 normal = collision.contacts[0].normal;

        // Invertir la dirección dependiendo de la normal de la colisión
        currentDirection = Vector2.Reflect(currentDirection, normal);

        
    }

}