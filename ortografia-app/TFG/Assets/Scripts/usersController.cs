using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class usersController : MonoBehaviour {
    private string nuevoUsuario;
    XmlDocument xDoc = new XmlDocument ();
    UnityEngine.Object documentoXML;
    public GameObject correcto;
    public GameObject error;
    private int y = 0;
    public GameObject jugador;
    private List<int> huecosEliminados = new List<int> ();

    public static string jugadorActivo;
    private string jug = "jugadorActivo";
    private GameObject jugadorFinalBorrar;
    private int copiaY;
    public GameObject canvasEmergente;

    // Start is called before the first frame update
    void Start () {
        //documentoXML = Resources.Load<TextAsset>("jugadores");

        xDoc.Load (Application.persistentDataPath + "/jugadores.xml");
        correcto.SetActive (false);
        error.SetActive (false);

        listarJugadores ();
        LoadData ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void getNewUser (string s) {
        if (s.Length > 0) {
            nuevoUsuario = s;
            if (!existeJugador (nuevoUsuario)) {
                XmlNode jugadorXML = crearJugador (nuevoUsuario);
                XmlNode root = xDoc.DocumentElement;
                root.InsertAfter (jugadorXML, root.LastChild);

                xDoc.Save (Application.persistentDataPath + "/jugadores.xml");

                error.SetActive (false);
                correcto.SetActive (true);
                jugador.GetComponent<Jugador> ().nombreJugador.text = nuevoUsuario;
                listarJugadores ();
            } else {
                correcto.SetActive (false);
                error.SetActive (true);
            }
        }

    }

    private XmlNode crearJugador (string nombre) {
        XmlNode jugador = xDoc.CreateElement ("jugador");

        XmlElement xnombre = xDoc.CreateElement ("nombre");
        xnombre.InnerText = nombre;
        jugador.AppendChild (xnombre);

        XmlNode puntuacion3 = xDoc.CreateElement ("puntuacion3");
        XmlNode puntuacion4 = xDoc.CreateElement ("puntuacion4");
        XmlNode puntuacion5 = xDoc.CreateElement ("puntuacion5");

        XmlElement byv3 = xDoc.CreateElement ("byv");
        byv3.InnerText = "0";
        XmlElement byv4 = xDoc.CreateElement ("byv");
        byv4.InnerText = "0";
        XmlElement byv5 = xDoc.CreateElement ("byv");
        byv5.InnerText = "0";
        puntuacion3.AppendChild (byv3);
        puntuacion4.AppendChild (byv4);
        puntuacion5.AppendChild (byv5);

        XmlElement csyz3 = xDoc.CreateElement ("csyz");
        csyz3.InnerText = "0";
        XmlElement csyz4 = xDoc.CreateElement ("csyz");
        csyz4.InnerText = "0";
        XmlElement csyz5 = xDoc.CreateElement ("csyz");
        csyz5.InnerText = "0";
        puntuacion3.AppendChild (csyz3);
        puntuacion4.AppendChild (csyz4);
        puntuacion5.AppendChild (csyz5);

        XmlElement hynoh3 = xDoc.CreateElement ("hynoh");
        hynoh3.InnerText = "0";
        XmlElement hynoh4 = xDoc.CreateElement ("hynoh");
        hynoh4.InnerText = "0";
        XmlElement hynoh5 = xDoc.CreateElement ("hynoh");
        hynoh5.InnerText = "0";
        puntuacion3.AppendChild (hynoh3);
        puntuacion4.AppendChild (hynoh4);
        puntuacion5.AppendChild (hynoh5);

        XmlElement llyy3 = xDoc.CreateElement ("llyy");
        llyy3.InnerText = "0";
        XmlElement llyy4 = xDoc.CreateElement ("llyy");
        llyy4.InnerText = "0";
        XmlElement llyy5 = xDoc.CreateElement ("llyy");
        llyy5.InnerText = "0";
        puntuacion3.AppendChild (llyy3);
        puntuacion4.AppendChild (llyy4);
        puntuacion5.AppendChild (llyy5);

        XmlElement gyj3 = xDoc.CreateElement ("gyj");
        gyj3.InnerText = "0";
        XmlElement gyj4 = xDoc.CreateElement ("gyj");
        gyj4.InnerText = "0";
        XmlElement gyj5 = xDoc.CreateElement ("gyj");
        gyj5.InnerText = "0";
        puntuacion3.AppendChild (gyj3);
        puntuacion4.AppendChild (gyj4);
        puntuacion5.AppendChild (gyj5);

        XmlElement mezcla3 = xDoc.CreateElement ("mezcla");
        mezcla3.InnerText = "0";
        XmlElement mezcla4 = xDoc.CreateElement ("mezcla");
        mezcla4.InnerText = "0";
        XmlElement mezcla5 = xDoc.CreateElement ("mezcla");
        mezcla5.InnerText = "0";
        puntuacion3.AppendChild (mezcla3);
        puntuacion4.AppendChild (mezcla4);
        puntuacion5.AppendChild (mezcla5);

        jugador.AppendChild (puntuacion3);
        jugador.AppendChild (puntuacion4);
        jugador.AppendChild (puntuacion5);

        return jugador;

    }

    private void listarJugadores () {
        y = 0;
        XmlNodeList listaJugadores = xDoc.SelectNodes ("jugadores/jugador");

        GameObject listaJugadoresGame = GameObject.FindGameObjectWithTag ("listaJugadores");

        foreach (Transform children in listaJugadoresGame.transform) {
            Destroy (children.gameObject, 0.0f);

        }

        for (int i = 0; i < listaJugadores.Count; i++) {
            string nombre = listaJugadores.Item (i).SelectSingleNode ("nombre").InnerText;
            jugador.GetComponent<Jugador> ().nombreJugador.text = nombre;
            GameObject jugadorFinal = Instantiate (jugador, new Vector3 (0, y, 0), Quaternion.identity);
            jugadorFinal.transform.SetParent (GameObject.FindGameObjectWithTag ("listaJugadores").transform, false);
            jugadorFinal.GetComponent<Jugador> ().acceder.onClick.AddListener (delegate { comenzarJuego (nombre); });
            int auxY = y;
            jugadorFinal.GetComponent<Jugador> ().borrar.onClick.AddListener (delegate { borrarSeguro (jugadorFinal, auxY); });
            y = y - 750;
        }
    }

    private void borrarSeguro (GameObject j, int y) {
        jugadorFinalBorrar = j;
        copiaY = y;
        canvasEmergente.SetActive (true);
    }

    public void borrarSi () {
        borrarJugador (jugadorFinalBorrar, copiaY);
        canvasEmergente.SetActive (false);
    }

    public void borrarNo () {
        canvasEmergente.SetActive (false);
    }

    private bool existeJugador (string n) {
        bool existe = false;
        XmlNodeList listaJugadores = xDoc.SelectNodes ("jugadores/jugador");

        for (int i = 0; i < listaJugadores.Count; i++) {
            string nombre = listaJugadores.Item (i).SelectSingleNode ("nombre").InnerText;
            if (nombre.Equals (n)) {
                existe = true;
            }
        }

        return existe;
    }

    public void comenzarJuego (string jugador) {
        jugadorActivo = jugador;
        SceneManager.LoadScene ("menuPrincipal");
    }

    public void borrarJugador (GameObject jugadorEliminado, int position) {

        XmlNode jugadores = xDoc.DocumentElement;
        XmlNodeList listaJugadores = xDoc.SelectNodes ("jugadores/jugador");
        string nombre = jugadorEliminado.GetComponent<Jugador> ().nombreJugador.text;
        foreach (XmlNode item in listaJugadores) {
            if (nombre.Equals (item.SelectSingleNode ("nombre").InnerText)) {
                jugadores.RemoveChild (item);
            }
        }

        xDoc.Save (Application.persistentDataPath + "/jugadores.xml");

        huecosEliminados.Add (position);
        Destroy (jugadorEliminado);

        listarJugadores ();
    }

    private void SaveData () {
        PlayerPrefs.SetString (jug, jugadorActivo);
    }

    private void LoadData () {
        jugadorActivo = PlayerPrefs.GetString (jug, "0");
    }

    private void OnDestroy () {
        SaveData ();
    }
}