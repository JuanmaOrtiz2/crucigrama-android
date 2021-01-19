using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class init : MonoBehaviour {
    // Start is called before the first frame update

    void Awake () {
        Debug.Log(Application.persistentDataPath);
        string pathJugadores = Application.persistentDataPath + "/jugadores.xml";
        string pathByv = Application.persistentDataPath + "/byv.xml";
        string pathHynoh = Application.persistentDataPath + "/hynoh.xml";
        string pathLlyy = Application.persistentDataPath + "/llyy.xml";
        string pathGyj = Application.persistentDataPath + "/gyj.xml";
        string pathCsyz = Application.persistentDataPath + "/csyz.xml";
        string pathMezcla = Application.persistentDataPath + "/mezcla.xml";
        string pathDiccionario = Application.persistentDataPath + "/diccionario.xml";

        XmlDocument xDoc = new XmlDocument ();

        if (!File.Exists (pathJugadores)) {
            xDoc.LoadXml (Resources.Load<TextAsset> ("jugadores").ToString ());
            xDoc.Save (pathJugadores);
        }

        if (!File.Exists (pathByv)) {
            xDoc.LoadXml (Resources.Load<TextAsset> ("byv").ToString ());
            xDoc.Save (pathByv);
        }
        if (!File.Exists (pathHynoh)) {
            xDoc.LoadXml (Resources.Load<TextAsset> ("hynoh").ToString ());
            xDoc.Save (pathHynoh);
        }
        if (!File.Exists (pathLlyy)) {
            xDoc.LoadXml (Resources.Load<TextAsset> ("llyy").ToString ());
            xDoc.Save (pathLlyy);
        }
        if (!File.Exists (pathGyj)) {
            xDoc.LoadXml (Resources.Load<TextAsset> ("gyj").ToString ());
            xDoc.Save (pathGyj);
        }
        if (!File.Exists (pathCsyz)) {
            xDoc.LoadXml (Resources.Load<TextAsset> ("csyz").ToString ());
            xDoc.Save (pathCsyz);
        }
        if (!File.Exists (pathMezcla)) {
            xDoc.LoadXml (Resources.Load<TextAsset> ("mezcla").ToString ());
            xDoc.Save (pathMezcla);
        }
        if (!File.Exists (pathDiccionario)) {
            xDoc.LoadXml (Resources.Load<TextAsset> ("diccionario").ToString ());
            xDoc.Save (pathDiccionario);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}