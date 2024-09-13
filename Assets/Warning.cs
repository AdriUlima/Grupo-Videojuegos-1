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
        float rot = Random.Range(0, 360);
        Instantiate(enemy.obj, transform.position, Quaternion.Euler(Vector3.forward * rot)).GetComponent<Enemigo>().SetStartSpeed(enemy.velocidad);
        Destroy(gameObject);
    }

}