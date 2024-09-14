using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField] private float warning = 0.5f;
    private Enemy enemy;
    
    void Start()
    {
        Invoke("SpawnEnemy", warning);
    }

    public void SetEnemy(Enemy m)
    {
        gameObject.SetActive(true);
        enemy = m;
    }

    private void SpawnEnemy()
    {
        Enemigo aux = Instantiate(enemy.obj, transform.position, Quaternion.identity).GetComponent<Enemigo>();
        aux.SetStartSpeed(enemy.velocidad);
        aux.nombre = enemy.nombre;
        Destroy(gameObject);
    }

}