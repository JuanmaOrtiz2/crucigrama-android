using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text text;
    private static int segundos;
    private static int minutos;
    private static float tiempo = 0.0f;
    private static float tiempoConservado = 0.0f;
    public static bool fin = false;
    private string t = "tiempo";
    private bool limpiarRegistro = false;

    void Start () {
        tiempo = 0.0f;
        LoadData ();
    }

    public void Update () {
        if (limpiarRegistro) {
            limpiarRegistro = false;
            tiempo = 0;
            tiempoConservado = 0;
        }
        if (!fin) {
            tiempo += Time.deltaTime;
            minutos = (int) tiempo / 60;
            segundos = (int) tiempo % 60;
            text.text = minutos.ToString ("00") + ":" + segundos.ToString ("00");

        } else {
            tiempoConservado = tiempo;
            minutos = (int) tiempoConservado / 60;
            segundos = (int) tiempoConservado % 60;
            text.text = "Puntuación: " + minutos.ToString ("00") + ":" + segundos.ToString ("00");
        }

    }

    public void Terminar () {
        fin = true;
    }

    public void Empezar () {
        fin = false;
        tiempo = 0;
        tiempoConservado = 0;
        limpiarRegistro = true;
    }

    public void LoadData () {
        tiempo = PlayerPrefs.GetFloat (t, 0);
    }

    public void SaveData () {
        PlayerPrefs.SetFloat (t, tiempoConservado);
    }

    private void OnDestroy () {
        SaveData ();
    }

    public void guardarTiempo () {
        XmlDocument xDoc = new XmlDocument ();
        //UnityEngine.Object documentoXML;
        //documentoXML = Resources.Load<TextAsset> ("jugadores");
        xDoc.Load (Application.persistentDataPath + "/jugadores.xml");
        string jugador = usersController.jugadorActivo;
        string letra = "";
        string dificultad = "";

        switch (optionsController.letras) {
            case 1:
                letra = "byv";
                break;
            case 2:
                letra = "hynoh";
                break;
            case 3:
                letra = "llyy";
                break;
            case 4:
                letra = "gyj";
                break;
            case 5:
                letra = "csyz";
                break;
            case 6:
                letra = "mezcla";
                break;
        }

        switch (optionsController.dificultad) {
            case 1:
                dificultad = "puntuacion3";
                break;
            case 2:
                dificultad = "puntuacion4";
                break;
            case 3:
                dificultad = "puntuacion5";
                break;
        }

        XmlNodeList listaJugadores = xDoc.SelectNodes ("jugadores/jugador");

        for (int i = 0; i < listaJugadores.Count; i++) {
            if (jugador.Equals (listaJugadores.Item (i).SelectSingleNode ("nombre").InnerText)) {
                string mejorPuntuacion = listaJugadores.Item (i).SelectSingleNode (dificultad).SelectSingleNode (letra).InnerText;
                int mP = Int32.Parse (mejorPuntuacion);
                string tiempoPuntuacion = minutos.ToString () + segundos.ToString ();
                int tP = Int32.Parse (tiempoPuntuacion);

                Debug.Log ("Mejor puntuacion: " + mP);
                Debug.Log ("Tiempo puntuacion: " + tP);

                int puntuacionFinal = 1000 - tP;

                if (puntuacionFinal >= 0) {
                    if (mP == 0 || mP < puntuacionFinal) {
                        listaJugadores.Item (i).SelectSingleNode (dificultad).SelectSingleNode (letra).InnerText = puntuacionFinal.ToString ();
                    }
                }

            }
        }

        //StreamWriter outStream = System.IO.File.CreateText (AssetDatabase.GetAssetPath (documentoXML));
        //StreamWriter outStream = System.IO.File.CreateText (documentoXML.ToString());
        xDoc.Save (Application.persistentDataPath + "/jugadores.xml");
        //outStream.Close ();
    }
}