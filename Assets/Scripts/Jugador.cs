using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Jugador : MonoBehaviour
{
    [Header("Disparo")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private float velBullet = 10f;
    [SerializeField] private float cooldown = 0.4f;
    private float auxCooldown;
    
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(
                    transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * 4f,
                    transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * 4f
                );



        if (Input.GetMouseButton(0) && auxCooldown <= 0)
        {
            auxCooldown = cooldown;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
            Vector3 dir = (mousePosition - transform.position).normalized;
            b.GetComponent<Rigidbody2D>().velocity = dir * velBullet;
        }
        if (auxCooldown > 0)
        {
            auxCooldown -= Time.deltaTime;
        }
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.SufferDamage(transform);
    }

}