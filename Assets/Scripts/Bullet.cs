using UnityEngine;

[RequireComponent (typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        GameManager.Instance.AddKill();
        Destroy(gameObject);
    }

}