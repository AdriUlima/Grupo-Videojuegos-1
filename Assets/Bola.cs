using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Vector3 mov;
    private float angle;
    public static float vel, dur, radio;

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public void SetAngle(float n)
    {
        angle = n;
        gameObject.SetActive(true);
        mov = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle));
        Invoke("Destroy", dur);
    }

    void Update()
    {
        transform.position += mov * vel * Time.unscaledDeltaTime;
    }

}