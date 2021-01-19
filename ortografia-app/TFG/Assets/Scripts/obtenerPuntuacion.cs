using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class obtenerPuntuacion : MonoBehaviour {
    public Text texto3;
    public Text texto4;
    public Text texto5;
    XmlDocument xDoc = new XmlDocument ();
    //string documentoXML = "";

    // Start is called before the first frame update
    void Start () {
        //documentoXML = Resources.Load<TextAsset>("jugadores").ToString();
        xDoc.Load (Application.persistentDataPath + "/jugadores.xml");
        XmlNodeList listaJugadores = xDoc.SelectNodes ("jugadores/jugador");
        for (int i = 0; i < listaJugadores.Count; i++) {
            if (usersController.jugadorActivo.Equals (listaJugadores.Item (i).SelectSingleNode ("nombre").InnerText)) {
                XmlNode puntuacion3;
                XmlNode puntuacion4;
                XmlNode puntuacion5;
                switch (optionsController.letras) {
                    case 1:
                        puntuacion3 = listaJugadores.Item (i).SelectSingleNode ("puntuacion3");
                        if (puntuacion3.SelectSingleNode ("byv").InnerText.Equals ("0")) {
                            texto3.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto3.text = "Mejor Puntuación: " + puntuacion3.SelectSingleNode ("byv").InnerText;
                        }

                        puntuacion4 = listaJugadores.Item (i).SelectSingleNode ("puntuacion4");
                        if (puntuacion4.SelectSingleNode ("byv").InnerText.Equals ("0")) {
                            texto4.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto4.text = "Mejor Puntuación: " + puntuacion4.SelectSingleNode ("byv").InnerText;
                        }

                        puntuacion5 = listaJugadores.Item (i).SelectSingleNode ("puntuacion5");
                        if (puntuacion5.SelectSingleNode ("byv").InnerText.Equals ("0")) {
                            texto5.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto5.text = "Mejor Puntuación: " + puntuacion5.SelectSingleNode ("byv").InnerText;
                        }

                        break;
                    case 2:
                        puntuacion3 = listaJugadores.Item (i).SelectSingleNode ("puntuacion3");
                        if (puntuacion3.SelectSingleNode ("hynoh").InnerText.Equals ("0")) {
                            texto3.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto3.text = "Mejor Puntuación: " + puntuacion3.SelectSingleNode ("hynoh").InnerText;
                        }

                        puntuacion4 = listaJugadores.Item (i).SelectSingleNode ("puntuacion4");
                        if (puntuacion4.SelectSingleNode ("hynoh").InnerText.Equals ("0")) {
                            texto4.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto4.text = "Mejor Puntuación: " + puntuacion4.SelectSingleNode ("hynoh").InnerText;
                        }

                        puntuacion5 = listaJugadores.Item (i).SelectSingleNode ("puntuacion5");
                        if (puntuacion5.SelectSingleNode ("hynoh").InnerText.Equals ("0")) {
                            texto5.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto5.text = "Mejor Puntuación: " + puntuacion5.SelectSingleNode ("hynoh").InnerText;
                        }
                        break;
                    case 3:
                        puntuacion3 = listaJugadores.Item (i).SelectSingleNode ("puntuacion3");
                        if (puntuacion3.SelectSingleNode ("llyy").InnerText.Equals ("0")) {
                            texto3.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto3.text = "Mejor Puntuación: " + puntuacion3.SelectSingleNode ("llyy").InnerText;
                        }

                        puntuacion4 = listaJugadores.Item (i).SelectSingleNode ("puntuacion4");
                        if (puntuacion4.SelectSingleNode ("llyy").InnerText.Equals ("0")) {
                            texto4.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto4.text = "Mejor Puntuación: " + puntuacion4.SelectSingleNode ("llyy").InnerText;
                        }

                        puntuacion5 = listaJugadores.Item (i).SelectSingleNode ("puntuacion5");
                        if (puntuacion5.SelectSingleNode ("llyy").InnerText.Equals ("0")) {
                            texto5.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto5.text = "Mejor Puntuación: " + puntuacion5.SelectSingleNode ("llyy").InnerText;
                        }
                        break;
                    case 4:
                        puntuacion3 = listaJugadores.Item (i).SelectSingleNode ("puntuacion3");
                        if (puntuacion3.SelectSingleNode ("gyj").InnerText.Equals ("0")) {
                            texto3.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto3.text = "Mejor Puntuación: " + puntuacion3.SelectSingleNode ("gyj").InnerText;
                        }

                        puntuacion4 = listaJugadores.Item (i).SelectSingleNode ("puntuacion4");
                        if (puntuacion4.SelectSingleNode ("gyj").InnerText.Equals ("0")) {
                            texto4.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto4.text = "Mejor Puntuación: " + puntuacion4.SelectSingleNode ("gyj").InnerText;
                        }

                        puntuacion5 = listaJugadores.Item (i).SelectSingleNode ("puntuacion5");
                        if (puntuacion5.SelectSingleNode ("gyj").InnerText.Equals ("0")) {
                            texto5.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto5.text = "Mejor Puntuación: " + puntuacion5.SelectSingleNode ("gyj").InnerText;
                        }
                        break;
                    case 5:
                        puntuacion3 = listaJugadores.Item (i).SelectSingleNode ("puntuacion3");
                        if (puntuacion3.SelectSingleNode ("csyz").InnerText.Equals ("0")) {
                            texto3.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto3.text = "Mejor Puntuación: " + puntuacion3.SelectSingleNode ("csyz").InnerText;
                        }

                        puntuacion4 = listaJugadores.Item (i).SelectSingleNode ("puntuacion4");
                        if (puntuacion4.SelectSingleNode ("csyz").InnerText.Equals ("0")) {
                            texto4.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto4.text = "Mejor Puntuación: " + puntuacion4.SelectSingleNode ("csyz").InnerText;
                        }

                        puntuacion5 = listaJugadores.Item (i).SelectSingleNode ("puntuacion5");
                        if (puntuacion5.SelectSingleNode ("csyz").InnerText.Equals ("0")) {
                            texto5.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto5.text = "Mejor Puntuación: " + puntuacion5.SelectSingleNode ("csyz").InnerText;
                        }
                        break;
                    case 6:
                        puntuacion3 = listaJugadores.Item (i).SelectSingleNode ("puntuacion3");
                        if (puntuacion3.SelectSingleNode ("mezcla").InnerText.Equals ("0")) {
                            texto3.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto3.text = "Mejor Puntuación: " + puntuacion3.SelectSingleNode ("mezcla").InnerText;
                        }

                        puntuacion4 = listaJugadores.Item (i).SelectSingleNode ("puntuacion4");
                        if (puntuacion4.SelectSingleNode ("mezcla").InnerText.Equals ("0")) {
                            texto4.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto4.text = "Mejor Puntuación: " + puntuacion4.SelectSingleNode ("mezcla").InnerText;
                        }

                        puntuacion5 = listaJugadores.Item (i).SelectSingleNode ("puntuacion5");
                        if (puntuacion5.SelectSingleNode ("mezcla").InnerText.Equals ("0")) {
                            texto5.text = "Mejor Puntuación: Por determinar";
                        } else {
                            texto5.text = "Mejor Puntuación: " + puntuacion5.SelectSingleNode ("mezcla").InnerText;
                        }
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {

    }
}