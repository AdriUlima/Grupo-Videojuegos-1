using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

[System.Serializable]
public struct Enemy
{
    public string nombre;
    public float velocidad;
    public GameObject obj;
    [HideInInspector] public int killed;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int kills;
    [Header("Parámetros")]
    [SerializeField] private int hp = 3;
    [SerializeField] private Enemy[] enemigos;
    private float timer;
    public float frecuencia = 1.5f;
    [Header("Punteros")]
    [SerializeField] private GameObject warning, bola;
    [SerializeField] private Text Tkills, Thp, Ttime, GameOver;
    [SerializeField] private GameObject goCanvas;
    private float tTotal;

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

    void Update()
    {
        timer += Time.deltaTime;
        tTotal += Time.deltaTime;
        Ttime.text = "Time: " + tTotal.ToString();
        if(timer >= frecuencia)
        {
            timer -= frecuencia;
            SpawnWarning();
        }
        /*if(Input.GetMouseButton(0) && hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/
    }

    private void SpawnWarning()
    {
        Enemy enemy = enemigos[Random.Range(0, enemigos.Length)];
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(10, Screen.width-10), Random.Range(10, Screen.height-10)));
        pos.z = 0;
        Instantiate(warning, pos, Quaternion.identity).GetComponent<Warning>().SetEnemy(enemy);
    }

    public void AddKill()
    {
        kills++;
        Tkills.text = "Kills: " + kills.ToString();
    }

    public void SetHp(int n)
    {
        hp = n;
        Thp.text = "HP: " + hp.ToString();
    }

    public void SufferDamage(Transform t, Color color)
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Explode(t.position, color);
            hp--;
            if (hp <= 0)
            {
                goCanvas.SetActive(true);
                GameOver.text = $"CÍRCULOS: {enemigos[0].killed}\nCILINDROS: {enemigos[1].killed}\nROMBOS: {enemigos[2].killed}\n\nTIEMPO: {tTotal}";
            }
            else
            {
                Thp.text = "HP: " + hp.ToString();
                t.position = Vector3.zero;
                StartCoroutine(EsperarPausa());
            }
        }
    }

    private IEnumerator EsperarPausa()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1;
    }

    public void Killed(int i)
    {
        enemigos[i].killed++;
    }

    public void Explode(Vector3 pos, Color color)
    {
        for(int i=1; i<9; i++)
        {
            float a = i * 45;
            GameObject b = Instantiate(bola, MoverSegunAngulo(pos, a, Bola.radio), Quaternion.identity);
            b.GetComponent<SpriteRenderer>().color = color;
            b.GetComponent<Bola>().SetAngle(a * Mathf.Deg2Rad);
        }
    }

    Vector2 MoverSegunAngulo(Vector2 origen, float angulo, float distancia)
    {
        // Convertir el ángulo de grados a radianes
        float anguloEnRadianes = angulo * Mathf.Deg2Rad;

        // Calcular el desplazamiento en los ejes X e Y
        float deltaX = Mathf.Cos(anguloEnRadianes) * distancia;
        float deltaY = Mathf.Sin(anguloEnRadianes) * distancia;

        // Sumar el desplazamiento a la posición original
        Vector2 nuevaPosicion = new Vector2(origen.x + deltaX, origen.y + deltaY);

        return nuevaPosicion;
    }

}