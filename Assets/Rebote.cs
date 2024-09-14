using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{
    [SerializeField] private Enemigo enem;

    void OnTriggerEnter2D(Collider2D collision)
    {
        enem.Rebote(collision);
    }

}