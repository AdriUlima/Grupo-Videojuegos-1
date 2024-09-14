using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [HideInInspector] public string nombre;
    [SerializeField] private int hp = 1;
    [HideInInspector] public float speed;
    public static float velRot;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Rigidbody2D rb;
    
    //public float bounceForce = 0.5f; // Fuerza de rebote adicional
    private Vector2 currentDirection; // Dirección de movimiento actual

    void Start()
    {
        sp.color = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
        currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rb.angularVelocity = velRot;
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
            int aux = (nombre == "Círculo" ? 0 : (nombre == "Cilindro" ? 1 : 2));
            GameManager.Instance.Killed(aux);
            GameManager.Instance.Explode(transform.position, sp.color);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Mover el cilindro en la dirección actual
        transform.Translate(currentDirection * speed * Time.deltaTime);
        //transform.Rotate(Vector3.forward * velRot * Time.deltaTime);
    }

    public void Rebote(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Arriba":
                currentDirection.y = -Mathf.Abs(currentDirection.y);
                break;
            case "Abajo":
                currentDirection.y = Mathf.Abs(currentDirection.y);
                break;
            case "Izquierda":
                currentDirection.x = Mathf.Abs(currentDirection.x);
                break;
            case "Derecha":
                currentDirection.x = -Mathf.Abs(currentDirection.x);
                break;
        }
    }

}