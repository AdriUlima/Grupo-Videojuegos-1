using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Jugador : MonoBehaviour
{
    [Header("Parámetros")]
    public static float velJugador = 4f;
    [SerializeField] private float velBullet = 10f;
    [SerializeField] private float cooldown = 0.4f;
    [Header("Punteros")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private SpriteRenderer sp;
    private float auxCooldown;
    private Vector3 mov;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        mov = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += mov * Time.deltaTime * velJugador;

        if (Input.GetMouseButton(0) && auxCooldown <= 0)
        {
            auxCooldown = cooldown;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
            Vector3 dir = (mousePosition - transform.position).normalized;
            b.SetActive(true);
            b.GetComponent<Rigidbody2D>().velocity = dir * velBullet;
        }
        if (auxCooldown > 0)
        {
            auxCooldown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Freeze"))
        {
            if (new Vector2(mov.x, mov.y) != Vector2.zero) SufferDamage();
        }
        else if (collision.CompareTag("Move"))
        {
            if (new Vector2(mov.x, mov.y) == Vector2.zero) SufferDamage();
        }
        else
        {
            SufferDamage();
        }
    }

    private void SufferDamage()
    {
        gameManager.SufferDamage(transform, sp.color);
    }

}