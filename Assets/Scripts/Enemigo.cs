using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Enemigo : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp.color = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
