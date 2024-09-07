using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmediateGUI : MonoBehaviour
{
    public bool IsShown;
    public string ElementoSpawn = "0";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            IsShown = !IsShown;
        }
    }

    void OnGUI()
    {
        if (IsShown)
        {
            GUI.Box(new Rect(10, 10, 100, 90), "Opciones");
            ElementoSpawn = GUI.TextField(new Rect(20, 40, 80, 20), ElementoSpawn);
        }
    }

}