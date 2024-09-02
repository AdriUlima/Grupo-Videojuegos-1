using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int kills;
    [Header("Canvas")]
    [SerializeField] private Text Tkills;

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

    public void AddKill()
    {
        kills++;
        Tkills.text = "Kills: " + kills.ToString();
    }

}