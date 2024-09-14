using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Color freeze, move;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 frecuencia;
    [SerializeField] private float vel = 5f;
    private bool isFreeze;
    private Vector3 initialPos;
    
    void Start()
    {
        initialPos = transform.position;
        Invoke("Spawn", Random.Range(frecuencia.x, frecuencia.y));
    }

    private void Spawn()
    {
        isFreeze = Random.Range(0, 2) == 0 ? true : false;
        tag = isFreeze ? "Freeze" : "Move";
        sp.color = isFreeze? freeze : move;
        transform.position = initialPos;
        rb.velocity = Vector2.right * vel;
    }

    void OnBecameInvisible()
    {
        rb.velocity = Vector2.zero;
        Invoke("Spawn", Random.Range(frecuencia.x, frecuencia.y));
    }

}