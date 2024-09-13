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
    [Header("Parámetros")]
    [SerializeField] private int hp = 3;
    [SerializeField] private Enemy[] enemigos;
    private float timer;
    [SerializeField] private float frecuencia = 1.5f;
    [Header("Punteros")]
    [SerializeField] private GameObject warning;
    [SerializeField] private Text Tkills, Thp;

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
            SpawnWarning();
        }
    }

    private void SpawnWarning()
    {
        Enemy enemy = enemigos[Random.Range(0, enemigos.Length)];
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height)));
        pos.z = 0;
        Instantiate(warning, pos, Quaternion.identity).GetComponent<Warning>().SetEnemy(enemy);
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