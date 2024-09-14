using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class InmediateGUI : MonoBehaviour
{
    private GUIStyle styleCenter, style2;
    private bool IsShown;
    //public string ElementoSpawn = "0";
    private string velJugador="4", hpJugador="3", spawnEnemy="2", rotEnemy="20", velExp="10", durExp="0.2", radioExp="1";
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;

        styleCenter = new GUIStyle();
        styleCenter.fontSize = 24;
        styleCenter.alignment = TextAnchor.UpperCenter;
        styleCenter.normal.textColor = Color.white;

        Texture2D backgroundTexture = new Texture2D(1, 1);
        Color color = new Color(0f, 0f, 0f, 0.9f); // Negro translúcido con 50% de opacidad
        backgroundTexture.SetPixel(0, 0, color);
        backgroundTexture.Apply();
        styleCenter.normal.background = backgroundTexture;

        style2 = new GUIStyle(styleCenter);
        style2.alignment = TextAnchor.UpperLeft;

        UpdateJugador();
        UpdateEnemigos();
        UpdateExplosion();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            IsShown = !IsShown;
            Time.timeScale = IsShown? 0 : 1;
        }
    }

    void OnGUI()
    {
        if (IsShown)
        {
            GUI.Box(new Rect(0, 0, 400, 900), "Opciones", styleCenter);
            //ElementoSpawn = GUI.TextField(new Rect(20, 40, 80, 20), ElementoSpawn);
            GUI.Label(new Rect(0, 40, 200, 20), "Jugador", styleCenter);
            GUI.Label(new Rect(10, 80, 100, 20), "SPEED:", style2);
            velJugador = GUI.TextField(new Rect(110, 80, 90, 20), velJugador, 3, style2);
            velJugador = Regex.Replace(velJugador, @"[^0-9.-]", "");
            GUI.Label(new Rect(10, 120, 100, 20), "HP:", style2);
            hpJugador = GUI.TextField(new Rect(110, 120, 90, 20), hpJugador, 3, style2);
            hpJugador = Regex.Replace(hpJugador, @"[^0-9.-]", "");
            if (GUI.Button(new Rect(10, 160, 180, 20), "Actualizar Jugador")) UpdateJugador();
            GUI.Label(new Rect(200, 40, 200, 20), "Enemigos", styleCenter);
            GUI.Label(new Rect(210, 80, 100, 20), "SPAWN:", style2);
            spawnEnemy = GUI.TextField(new Rect(310, 80, 90, 20), spawnEnemy, 3, style2);
            spawnEnemy = Regex.Replace(spawnEnemy, @"[^0-9.-]", "");
            GUI.Label(new Rect(210, 120, 100, 20), "ROTATE:", style2);
            rotEnemy = GUI.TextField(new Rect(310, 120, 90, 20), rotEnemy, 3, style2);
            rotEnemy = Regex.Replace(rotEnemy, @"[^0-9.-]", "");
            if (GUI.Button(new Rect(210, 160, 180, 20), "Actualizar Enemigos")) UpdateEnemigos();
            GUI.Label(new Rect(0, 200, 200, 20), "Explosión", styleCenter);
            GUI.Label(new Rect(10, 240, 100, 20), "SPEED:", style2);
            velExp = GUI.TextField(new Rect(110, 240, 90, 20), velExp, 3, style2);
            velExp = Regex.Replace(velExp, @"[^0-9.-]", "");
            GUI.Label(new Rect(10, 280, 100, 20), "TIME:", style2);
            durExp = GUI.TextField(new Rect(110, 280, 90, 20), durExp, 3, style2);
            durExp = Regex.Replace(durExp, @"[^0-9.-]", "");
            GUI.Label(new Rect(10, 320, 100, 20), "RADIO:", style2);
            radioExp = GUI.TextField(new Rect(110, 320, 90, 20), radioExp, 3, style2);
            radioExp = Regex.Replace(radioExp, @"[^0-9.-]", "");
            if (GUI.Button(new Rect(10, 360, 180, 20), "Actualizar Explosión")) UpdateExplosion();
        }
    }

    private void UpdateJugador()
    {
        Jugador.velJugador = float.Parse(velJugador);
        gameManager.SetHp(int.Parse(hpJugador));
    }

    private void UpdateEnemigos()
    {
        gameManager.frecuencia = float.Parse(spawnEnemy);
        Enemigo.velRot = float.Parse(rotEnemy);
    }

    private void UpdateExplosion()
    {
        Bola.vel = float.Parse(velExp);
        Bola.dur = float.Parse(durExp);
        Bola.radio = float.Parse(radioExp);
    }

}