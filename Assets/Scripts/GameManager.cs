using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Enemy
{
    public string nombre;
    public float velocidad;
    public GameObject obj;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int kills;
    [SerializeField] private int hp = 3;
    [Header("Canvas")]
    [SerializeField] private Text Tkills, Thp;
    [SerializeField] private Enemy[] enemigos;
    private float timer;
    [SerializeField] private float frecuencia = 2f;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= frecuencia)
        {
            timer -= frecuencia;
            SpawnearEnemigo();
        }
    }

    private void SpawnearEnemigo()
    {
        Enemy enemy = enemigos[Random.Range(0, enemigos.Length)];
        Vector3 pos = Vector3.zero;
        float rot = Random.Range(0, 360);
        Instantiate(enemy.obj, pos, Quaternion.Euler(Vector3.forward * rot)).GetComponent<Enemigo>().speed = enemy.velocidad;
    }

    public void AddKill()
    {
        kills++;
        Tkills.text = "Kills: " + kills.ToString();
    }

    public void SufferDamage(Transform t)
    {
        hp--;
        Thp.text = "HP: " + hp.ToString();
        t.position = Vector3.zero;
    }

}