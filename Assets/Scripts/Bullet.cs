using UnityEngine;

[RequireComponent (typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int dmg = 1;

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);
        collision.transform.parent.GetComponent<Enemigo>().Damage(dmg);
        GameManager.Instance.AddKill();
        Destroy(gameObject);
    }

}