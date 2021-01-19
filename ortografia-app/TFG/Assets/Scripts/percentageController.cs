using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class percentageController : MonoBehaviour {
    public Text byv;
    public Text hynoh;
    public Text llyy;
    public Text gyj;
    public Text csyz;

    public Text mezclar;

    XmlDocument xDoc = new XmlDocument ();
    UnityEngine.Object documentoXML;

    // Start is called before the first frame update
    void Start () {
        porcentaje ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void porcentaje () {
        //byv
        //documentoXML = Resources.Load<TextAsset>("byv");
        xDoc.Load (Application.persistentDataPath + "/byv.xml");

        XmlNodeList listaPalabras = xDoc.GetElementsByTagName ("descripcion");
        XmlNodeList listaJugadas = xDoc.GetElementsByTagName (usersController.jugadorActivo);

        if (listaJugadas.Count != 0) {
            float completas = listaJugadas.Count;
            float total = listaPalabras.Count;
            float resultado = (completas / total) * 100;
            Math.Truncate (resultado);
            byv.text = "Resuelto: " + Math.Truncate (resultado) + "%";

            //StreamWriter outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
            //StreamWriter outStream = System.IO.File.CreateText(documentoXML.ToString());
            xDoc.Save (Application.persistentDataPath + "/byv.xml");
            //outStream.Close();
        }

        //hynoh
        //documentoXML = Resources.Load<TextAsset>("hynoh");
        xDoc.Load (Application.persistentDataPath + "/hynoh.xml");

        listaPalabras = xDoc.GetElementsByTagName ("descripcion");
        listaJugadas = xDoc.GetElementsByTagName (usersController.jugadorActivo);

        if (listaJugadas.Count != 0) {
            float completas = listaJugadas.Count;
            float total = listaPalabras.Count;
            float resultado = (completas / total) * 100;
            Math.Truncate (resultado);
            hynoh.text = "Resuelto: " + Math.Truncate (resultado) + "%";

            //StreamWriter outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
            //StreamWriter outStream = System.IO.File.CreateText(documentoXML.ToString());
            xDoc.Save (Application.persistentDataPath + "/hynoh.xml");
            //outStream.Close();
        }

        //llyy
        //documentoXML = Resources.Load<TextAsset>("llyy");
        xDoc.Load (Application.persistentDataPath + "/llyy.xml");

        listaPalabras = xDoc.GetElementsByTagName ("descripcion");
        listaJugadas = xDoc.GetElementsByTagName (usersController.jugadorActivo);

        if (listaJugadas.Count != 0) {
            float completas = listaJugadas.Count;
            float total = listaPalabras.Count;
            float resultado = (completas / total) * 100;
            Math.Truncate (resultado);
            llyy.text = "Resuelto: " + Math.Truncate (resultado) + "%";

            //StreamWriter outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
            //StreamWriter outStream = System.IO.File.CreateText(documentoXML.ToString());
            xDoc.Save (Application.persistentDataPath + "/llyy.xml");
            //outStream.Close();
        }

        //gyj
        //documentoXML = Resources.Load<TextAsset> ("gyj");
        xDoc.Load (Application.persistentDataPath + "/gyj.xml");

        listaPalabras = xDoc.GetElementsByTagName ("descripcion");
        listaJugadas = xDoc.GetElementsByTagName (usersController.jugadorActivo);

        if (listaJugadas.Count != 0) {
            float completas = listaJugadas.Count;
            float total = listaPalabras.Count;
            float resultado = (completas / total) * 100;
            Math.Truncate (resultado);
            gyj.text = "Resuelto: " + Math.Truncate (resultado) + "%";

            //StreamWriter outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
            //StreamWriter outStream = System.IO.File.CreateText (documentoXML.ToString ());
            xDoc.Save (Application.persistentDataPath + "/gyj.xml");
            //outStream.Close ();
        }

        //csyz
        //documentoXML = Resources.Load<TextAsset> ("csyz");
        xDoc.Load (Application.persistentDataPath + "/csyz.xml");

        listaPalabras = xDoc.GetElementsByTagName ("descripcion");
        listaJugadas = xDoc.GetElementsByTagName (usersController.jugadorActivo);

        if (listaJugadas.Count != 0) {
            float completas = listaJugadas.Count;
            float total = listaPalabras.Count;
            float resultado = (completas / total) * 100;
            Math.Truncate (resultado);
            csyz.text = "Resuelto: " + Math.Truncate (resultado) + "%";

            //StreamWriter outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
            //StreamWriter outStream = System.IO.File.CreateText (documentoXML.ToString ());
            xDoc.Save (Application.persistentDataPath + "/csyz.xml");
            //outStream.Close ();
        }
        //mezclar
        //documentoXML = Resources.Load<TextAsset> ("mezcla");
        xDoc.Load (Application.persistentDataPath + "/mezcla.xml");

        listaPalabras = xDoc.GetElementsByTagName ("descripcion");
        listaJugadas = xDoc.GetElementsByTagName (usersController.jugadorActivo);

        if (listaJugadas.Count != 0) {
            float completas = listaJugadas.Count;
            float total = listaPalabras.Count;
            float resultado = (completas / total) * 100;
            Math.Truncate (resultado);
            mezclar.text = "Resuelto: " + Math.Truncate (resultado) + "%";

            //StreamWriter outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
            //StreamWriter outStream = System.IO.File.CreateText (documentoXML.ToString ());
            xDoc.Save (Application.persistentDataPath + "/mezcla.xml");
            //outStream.Close ();
        }

    }

    public void Reset (int elegido) {
        string path = "";
        switch (elegido) {
            case 1:
                //documentoXML = Resources.Load<TextAsset> ("byv");
                path = Application.persistentDataPath + "/byv.xml";
                xDoc.Load (path);
                byv.text = "Resuelto: 0%";
                break;
            case 2:
                //documentoXML = Resources.Load<TextAsset> ("hynoh");
                path = Application.persistentDataPath + "/hynoh.xml";
                xDoc.Load (path);
                hynoh.text = "Resuelto: 0%";
                break;
            case 3:
                //documentoXML = Resources.Load<TextAsset> ("llyy");
                path = Application.persistentDataPath + "/llyy.xml";
                xDoc.Load (path);
                llyy.text = "Resuelto: 0%";
                break;
            case 4:
                //documentoXML = Resources.Load<TextAsset> ("gyj");
                path = Application.persistentDataPath + "/gyj.xml";
                xDoc.Load (path);
                gyj.text = "Resuelto: 0%";
                break;
            case 5:
                //documentoXML = Resources.Load<TextAsset> ("csyz");
                path = Application.persistentDataPath + "/csyz.xml";
                xDoc.Load (path);
                csyz.text = "Resuelto: 0%";
                break;
            case 6:
                //documentoXML = Resources.Load<TextAsset> ("mezcla");
                path = Application.persistentDataPath + "/byv.xml";
                xDoc.Load (path);
                mezclar.text = "Resuelto: 0%";
                break;
        }

        XmlNodeList listaJugadas = xDoc.GetElementsByTagName (usersController.jugadorActivo);
        XmlNode todas = xDoc.SelectSingleNode ("palabras");

        if (listaJugadas.Count != 0) {
            for (int i = 0; i < listaJugadas.Count; i++) {
                todas.RemoveChild (listaJugadas.Item (i));
                i--;
            }

            //StreamWriter outStream = System.IO.File.CreateText(AssetDatabase.GetAssetPath(documentoXML));
            //StreamWriter outStream = System.IO.File.CreateText (documentoXML.ToString ());
            xDoc.Save (path);
            //outStream.Close ();
        }
    }
}