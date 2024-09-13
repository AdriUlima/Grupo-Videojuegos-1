using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Color freeze, move;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Vector2 frecuencia;
    
    void Start()
    {
        Invoke("Spawn", Random.Range(frecuencia.x, frecuencia.y));
    }

    private void Spawn()
    {
        sp.color = Random.Range(0, 2) == 0 ? freeze : move;
        Invoke("Spawn", Random.Range(frecuencia.x, frecuencia.y));
    }

}