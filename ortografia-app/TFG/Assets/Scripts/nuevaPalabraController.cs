using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nuevaPalabraController : MonoBehaviour {
    public Text titulo;
    public GameObject textoAviso;
    public GameObject textoCorrecto;
    private String palabraIntroducida;
    private String descripcionIntroducida;
    private bool palabraCorrecta = false;
    private bool existeEnDiccionario = false;

    // Start is called before the first frame update
    void Start () {
        textoAviso.SetActive (false);
        ponerTitulo ();
    }

    // Update is called once per frame
    void Update () {

    }

    private void ponerTitulo () {
        switch (optionsController.letras) {
            case 1:
                titulo.text = "Introduciendo nuevas palabras con B o V";
                break;
            case 2:
                titulo.text = "Introduciendo nuevas palabras con H o sin H";
                break;
            case 3:
                titulo.text = "Introduciendo nuevas palabras con LL o Y";
                break;
            case 4:
                titulo.text = "Introduciendo nuevas palabras con G o J";
                break;
            case 5:
                titulo.text = "Introduciendo nuevas palabras con C, S o Z";
                break;
            case 6:
                titulo.text = "Introduciendo nuevas palabras";
                break;
        }
    }

    public void getNuevaPalabra (string p) {
        palabraIntroducida = p;
    }

    public void getNuevaDescripcion (string d) {
        descripcionIntroducida = d;
    }

    public void insertarPalabra () {
        comprobarPalabra (palabraIntroducida);
        if (palabraCorrecta) {
            textoAviso.SetActive (false);
            guardarXML ();
            textoCorrecto.SetActive (true);
        } else {
            textoCorrecto.SetActive (false);
            textoAviso.SetActive (true);
        }
    }

    private void comprobarPalabra (string p) {
        palabraCorrecta = false;
        switch (optionsController.letras) {
            case 1:
                for (int i = 0; i < p.Length; i++) {
                    if (p[i] == 'b' || p[i] == 'v') {
                        palabraCorrecta = true;
                    }
                }
                if (descripcionIntroducida == "" || palabraIntroducida == "") {
                    palabraCorrecta = false;
                }
                break;
            case 2:
                palabraCorrecta = true;
                if (descripcionIntroducida == "" || palabraIntroducida == "") {
                    palabraCorrecta = false;
                }
            break;
            case 3:
                for (int i = 0; i < p.Length; i++) {
                    if (p[i] == 'l' || p[i] == 'y') {
                        palabraCorrecta = true;
                    }
                }
                if (descripcionIntroducida == "" || palabraIntroducida == "") {
                    palabraCorrecta = false;
                }
                break;
            case 4:
                for (int i = 0; i < p.Length; i++) {
                    if (p[i] == 'g' || p[i] == 'j') {
                        palabraCorrecta = true;
                    }
                }
                if (descripcionIntroducida == "" || palabraIntroducida == "") {
                    palabraCorrecta = false;
                }
                break;
            case 5:
                for (int i = 0; i < p.Length; i++) {
                    if (p[i] == 'c' || p[i] == 'z' || p[i] == 's') {
                        palabraCorrecta = true;
                    }
                }
                if (descripcionIntroducida == "" || palabraIntroducida == "") {
                    palabraCorrecta = false;
                }
                break;
            case 6:
                palabraCorrecta = true;
                if (descripcionIntroducida == "" || palabraIntroducida == "") {
                    palabraCorrecta = false;
                }
            break;
        }

        XmlDocument xDoc = new XmlDocument ();
        //UnityEngine.Object documentoXML;
        //documentoXML = Resources.Load<TextAsset> ("diccionario");
        xDoc.Load (Application.persistentDataPath + "/diccionario.xml");
        XmlNodeList listaDiccionario = xDoc.SelectNodes ("article/para");
        for (int i = 0; i < listaDiccionario.Count && !existeEnDiccionario; i++) {
            //if(palabraIntroducida.Equals(listaDiccionario.Item(i).InnerText))
            int iguales = string.Compare (palabraIntroducida, listaDiccionario.Item (i).InnerText, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace);
            if (iguales == 0) {
                existeEnDiccionario = true;
            } else {
                existeEnDiccionario = false;
            }
        }

        if(palabraCorrecta && existeEnDiccionario)
        {
            palabraCorrecta = true;
        }
        else
        {
            palabraCorrecta = false;
        }

    }

    private void guardarXML () {
        XmlDocument xDoc = new XmlDocument ();
        //UnityEngine.Object documentoXML;
        XmlNode xmlElegido;
        XmlElement descripcion;
        XmlAttribute attr;
        //StreamWriter outStream;
        switch (optionsController.letras) {
            case 1:
                //documentoXML = Resources.Load<TextAsset>("byv");
                xDoc.Load (Application.persistentDataPath + "/byv.xml");
                xmlElegido = xDoc.SelectSingleNode ("palabras");
                descripcion = xDoc.CreateElement ("descripcion");
                descripcion.InnerText = descripcionIntroducida;
                attr = xDoc.CreateAttribute ("palabra");
                attr.Value = palabraIntroducida;
                descripcion.SetAttributeNode (attr);
                xmlElegido.AppendChild (descripcion);
                //outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
                //outStream = System.IO.File.CreateText(documentoXML.ToString());
                xDoc.Save (Application.persistentDataPath + "/byv.xml");
                //outStream.Close();
                break;
            case 2:
                //documentoXML = Resources.Load<TextAsset>("hynoh");
                xDoc.Load (Application.persistentDataPath + "/hynoh.xml");
                xmlElegido = xDoc.SelectSingleNode ("palabras");
                descripcion = xDoc.CreateElement ("descripcion");
                descripcion.InnerText = descripcionIntroducida;
                attr = xDoc.CreateAttribute ("palabra");
                attr.Value = palabraIntroducida;
                descripcion.SetAttributeNode (attr);
                xmlElegido.AppendChild (descripcion);
                //outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
                //outStream = System.IO.File.CreateText(documentoXML.ToString());
                xDoc.Save (Application.persistentDataPath + "/hynoh.xml");
                //outStream.Close();
                break;
            case 3:
                //documentoXML = Resources.Load<TextAsset>("llyy");
                xDoc.Load (Application.persistentDataPath + "/llyy.xml");
                xmlElegido = xDoc.SelectSingleNode ("palabras");
                descripcion = xDoc.CreateElement ("descripcion");
                descripcion.InnerText = descripcionIntroducida;
                attr = xDoc.CreateAttribute ("palabra");
                attr.Value = palabraIntroducida;
                descripcion.SetAttributeNode (attr);
                xmlElegido.AppendChild (descripcion);
                //outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
                //outStream = System.IO.File.CreateText(documentoXML.ToString());
                xDoc.Save (Application.persistentDataPath + "/llyy.xml");
                //outStream.Close();
                break;
            case 4:
                //documentoXML = Resources.Load<TextAsset>("gyj");
                xDoc.Load (Application.persistentDataPath + "/gyj.xml");
                xmlElegido = xDoc.SelectSingleNode ("palabras");
                descripcion = xDoc.CreateElement ("descripcion");
                descripcion.InnerText = descripcionIntroducida;
                attr = xDoc.CreateAttribute ("palabra");
                attr.Value = palabraIntroducida;
                descripcion.SetAttributeNode (attr);
                xmlElegido.AppendChild (descripcion);
                //outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
                //outStream = System.IO.File.CreateText(documentoXML.ToString());
                xDoc.Save (Application.persistentDataPath + "/gyj.xml");
                //outStream.Close();
                break;
            case 5:
                //documentoXML = Resources.Load<TextAsset>("csyz");
                xDoc.Load (Application.persistentDataPath + "/csyz.xml");
                xmlElegido = xDoc.SelectSingleNode ("palabras");
                descripcion = xDoc.CreateElement ("descripcion");
                descripcion.InnerText = descripcionIntroducida;
                attr = xDoc.CreateAttribute ("palabra");
                attr.Value = palabraIntroducida;
                descripcion.SetAttributeNode (attr);
                xmlElegido.AppendChild (descripcion);
                //outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
                //outStream = System.IO.File.CreateText(documentoXML.ToString());
                xDoc.Save (Application.persistentDataPath + "/csyz.xml");
                //outStream.Close();
                break;
            case 6:
                //documentoXML = Resources.Load<TextAsset>("mezcla");
                xDoc.Load (Application.persistentDataPath + "/mezcla.xml");
                xmlElegido = xDoc.SelectSingleNode ("palabras");
                descripcion = xDoc.CreateElement ("descripcion");
                descripcion.InnerText = descripcionIntroducida;
                attr = xDoc.CreateAttribute ("palabra");
                attr.Value = palabraIntroducida;
                descripcion.SetAttributeNode (attr);
                xmlElegido.AppendChild (descripcion);
                //outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
                //outStream = System.IO.File.CreateText(documentoXML.ToString());
                xDoc.Save (Application.persistentDataPath + "/mezcla.xml");
                //outStream.Close();
                break;
        }
    }
}