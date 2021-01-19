using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startController : MonoBehaviour {
    public static char[, ] solucion = new char[9, 9];
    public static int[, ] numeroDescripciones = new int[9, 9];
    private int palabras;

    private string[] titulos = new string[5];
    private string[] descripciones = new string[5];

    XmlDocument xDoc = new XmlDocument ();

    optionsController op;
    Timer tiempo;

    public GameObject objeto;
    AudioSource efecto;

    bool escrito = false;

    private buttonController letraActiva = null;

    //private TouchScreenKeyboard teclado = null;

    string letraCandidata = "";
    string letraCandidataAcentuada = "";

    public Text descripcionActual;

    private int numLetrasColocadas = 0;

    UnityEngine.Object documentoXML;

    string path;

    // Start is called before the first frame update
    void Start () {
        iniciarJuego ();
        instanciarMatriz ();
        tiempo = GetComponent<Timer> ();
        tiempo.Empezar ();
        efecto = GetComponent<AudioSource> ();
        //agregarPalabrasJugadas();

    }

    // Update is called once per frame
    void Update () {
        if (escrito) {
            Debug.Log ("Hola");

            if (letraCandidata[0] == letraActiva.letra || letraCandidataAcentuada[0] == letraActiva.letra) {
                Debug.Log ("Entro");
                letraActiva.CambiarTexto ();
                letraActiva.seleccionar = false;
                letraActiva.Correcta ();
                if (op.getEfectos () == 0) {
                    efecto.Play ();
                }
                numLetrasColocadas--;
            } else {
                if (letraActiva.seleccionar == true) letraActiva.texto.text = letraCandidata;

            }
            letraCandidata = "";
            letraCandidataAcentuada = "";
            escrito = false;
        }
        if (numLetrasColocadas == 0) {
            tiempo.Terminar ();
            tiempo.guardarTiempo ();
            agregarPalabrasJugadas ();
            SceneManager.LoadScene ("Fin");
        }

    }

    private void iniciarJuego ()

    {

        op = GetComponent<optionsController> ();

        switch (op.getLetras ()) {
            case 1:
                //xDoc.Load ("../XML/byv.xml");
                //documentoXML = Resources.Load<TextAsset>("byv");
                path = Application.persistentDataPath + "/byv.xml";
                break;
            case 2:
                //xDoc.Load ("../XML/hynoh.xml");
                //documentoXML = Resources.Load<TextAsset> ("hynoh");
                path = Application.persistentDataPath + "/hynoh.xml";
                break;
            case 3:
                //xDoc.Load ("../XML/llyy.xml");
                //documentoXML = Resources.Load<TextAsset> ("llyy");
                path = Application.persistentDataPath + "/llyy.xml";
                break;
            case 4:
                //xDoc.Load ("../XML/gyj.xml");
                //documentoXML = Resources.Load<TextAsset> ("gyj");
                path = Application.persistentDataPath + "/gyj.xml";
                break;
            case 5:
                //xDoc.Load ("../XML/csyz.xml");
                //documentoXML = Resources.Load<TextAsset> ("csyz");
                path = Application.persistentDataPath + "/csyz.xml";
                break;
            case 6:
                //documentoXML = Resources.Load<TextAsset> ("mezcla");
                path = Application.persistentDataPath + "/mezcla.xml";
                break;
        }

        switch (op.getDificultad ()) {
            case 1:
                palabras = 3;
                break;
            case 2:
                palabras = 4;
                break;
            case 3:
                palabras = 5;
                break;
        }

        xDoc.Load (path);

        //SACAR PALABRAS DEL DOCUMENTO XML CORRESPONDIENTE ALEATORIAMENTE
        XmlNodeList documento = xDoc.GetElementsByTagName ("palabras");
        XmlNodeList xLista = ((XmlElement) documento[0]).GetElementsByTagName ("descripcion");

        var seed = Environment.TickCount;
        var random = new System.Random (seed);
        int[] colocadas = new int[xLista.Count]; //Contiene los numeros que van saliendo
        int k = 0;
        bool colocar = true;
        //string[] titulos = new string[palabras];
        Array.Resize (ref titulos, palabras);
        //string[] descripciones = new string[palabras];
        Array.Resize (ref descripciones, palabras);

        XmlNodeList listaJugadas = xDoc.GetElementsByTagName (usersController.jugadorActivo);

        for (int i = 0; i < palabras; i++) {
            colocar = true;
            var value = random.Next (0, xLista.Count - 1);
            for (int j = 0; j < colocadas.Length; j++) {
                if (value == colocadas[j]) {
                    colocar = false;
                }
            }
            for (int j = 0; j < listaJugadas.Count; j++) {
                string descripcionJugada = listaJugadas.Item (j).InnerText;
                if (descripcionJugada.Equals (xLista.Item (value).InnerText)) {
                    colocar = false;
                }
            }
            if (colocar) {
                titulos[i] = xLista.Item (value).Attributes["palabra"].Value;
                descripciones[i] = xLista.Item (value).InnerText;
                colocadas[k] = value;
                k++;
            } else {
                i--;
            }

        }

        //ORDENAR PALABRAS SACADAS DE MAYOR A MENOR

        string aux;
        for (int i = 0; i < titulos.Length; i++) {
            for (int j = 0; j < titulos.Length; j++) {
                if (titulos[i].Length < titulos[j].Length) {
                    aux = titulos[j];
                    titulos[j] = titulos[i];
                    titulos[i] = aux;
                    aux = descripciones[j];
                    descripciones[j] = descripciones[i];
                    descripciones[i] = aux;
                }
            }
        }

        //FORMAR MATRIZ SOLUCION

        int palabrasColocadas = 0;
        bool primeraPalabra = true;
        bool segundaPalabra = true;
        bool letraEncontrada;
        int letraCoincidenteTitulo = 0;
        bool[] candidatosColocados = new bool[palabras];
        int indiceCandidatosColocados = 0;
        int segundaPalabraColocada = 0;

        //RELLENAR CON 0 MATRIZ SOLUCION Y CANDIDATOS COLOCADOS FALSO. LOCALIZADOR DE DESCRIPCIONES A 0.
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                solucion[i, j] = '0';
                numeroDescripciones[i, j] = 0;
            }
        }

        for (int i = 0; i < palabras; i++) {
            candidatosColocados[i] = false;
        }

        //COMIENZO DE ALGORITMO DE FORMACION DEL CRUCIGRAMA
        while (palabrasColocadas < palabras || colocadas.Length < xLista.Count) {
            //PRIMERA PALABRA
            if (primeraPalabra) {
                int y = 0;
                while (y < titulos[0].Length) {

                    solucion[0, y] = titulos[0][y];
                    numeroDescripciones[0, y] = 0;
                    y++;
                    numLetrasColocadas++;
                }
                primeraPalabra = false;
                palabrasColocadas++;
                candidatosColocados[0] = true;
                segundaPalabra = true;
            }

            //SEGUNDA PALABRA

            if (segundaPalabra) {
                letraEncontrada = false;
                for (int i = 0; i < palabras && !letraEncontrada; i++) {
                    if (!candidatosColocados[i] && titulos[i].Length < 9) {
                        for (int j = 0; j < titulos[0].Length && !letraEncontrada; j++) {
                            if (titulos[0][j] == titulos[i][0]) {
                                letraCoincidenteTitulo = j;
                                segundaPalabraColocada = i;

                                for (int h = 0; h < titulos[i].Length; h++) {
                                    solucion[h, j] = titulos[i][h];

                                    if (h != 0) //Utilizado para que las descripciones no se pisen al unir palabras.
                                    {
                                        numeroDescripciones[h, j] = i;
                                        numLetrasColocadas++;
                                    }

                                }
                                candidatosColocados[i] = true;
                                letraEncontrada = true;
                                palabrasColocadas++;
                                segundaPalabra = false;
                            }
                        }
                    }
                }
            }

            //SIGUIENTES PALABRAS
            if (indiceCandidatosColocados == palabras) {
                Debug.Log ("NUEVAS PALABRAS");
                for (int i = 0; i < palabras; i++) {
                    if (!candidatosColocados[i]) {
                        colocar = true;
                        var aleatorio = random.Next (0, xLista.Count - 1);
                        for (int j = 0; j < colocadas.Length; j++) {
                            if (colocadas[j] == aleatorio) {
                                colocar = false;
                            }
                        }
                        if (colocar) {
                            titulos[i] = xLista.Item (aleatorio).Attributes["palabra"].Value;
                            descripciones[i] = xLista.Item (aleatorio).InnerText;
                            colocadas[k] = aleatorio;
                            k++;
                        }
                    }
                }
                indiceCandidatosColocados = 1;

            } else if (candidatosColocados[indiceCandidatosColocados]) {
                indiceCandidatosColocados++;
            } else {
                //HORIZONTAL
                letraEncontrada = false;
                int columnaPrincipal = letraCoincidenteTitulo;;
                for (int i = 0; i < titulos[indiceCandidatosColocados].Length && !letraEncontrada; i++) {
                    for (int j = 1; j < titulos[segundaPalabraColocada].Length && !letraEncontrada; j++) {
                        if (titulos[indiceCandidatosColocados][i] == titulos[segundaPalabraColocada][j]) {
                            letraEncontrada = true;
                            for (int n = i + 1; n < titulos[indiceCandidatosColocados].Length; n++) {
                                if (columnaPrincipal + 1 > 8) { letraEncontrada = false; } else if (solucion[j, columnaPrincipal + 1] != '0' || columnaPrincipal + 1 > 8 || solucion[j - 1, columnaPrincipal + 1] != '0' || solucion[j + 1, columnaPrincipal + 1] != '0') {
                                    letraEncontrada = false;
                                }
                                columnaPrincipal++;
                            }
                            columnaPrincipal = letraCoincidenteTitulo;
                            if (i != 0) {
                                for (int n = i - 1; n >= 0; n--) {
                                    if (columnaPrincipal - 1 < 0) {
                                        letraEncontrada = false;
                                    } else if (solucion[j, columnaPrincipal - 1] != '0' || solucion[j - 1, columnaPrincipal + 1] != '0' || solucion[j + 1, columnaPrincipal + 1] != '0') {
                                        letraEncontrada = false;
                                        columnaPrincipal--;
                                    } else { columnaPrincipal--; }

                                }
                            }

                            //COMPROBAR ARRIBA Y ABAJO EN HORIZONTAL.
                            //COMPROBAR IZQUIERDA Y DERECHA EN VERTICAL.
                            //MIRAR EN LOS EXTREMOS (PRIMERA Y ULTIMA LETRA DE CADA PALABRA)

                            columnaPrincipal = letraCoincidenteTitulo;
                            if (letraEncontrada) {
                                //Derecha
                                columnaPrincipal = letraCoincidenteTitulo;
                                bool banderaPrimeraLetra = true; //Utilizado para que las descripciones no se pisen al unir palabras.
                                for (int n = i; n < titulos[indiceCandidatosColocados].Length; n++) {
                                    solucion[j, columnaPrincipal] = titulos[indiceCandidatosColocados][n];
                                    if (!banderaPrimeraLetra) {
                                        numeroDescripciones[j, columnaPrincipal] = indiceCandidatosColocados;
                                        numLetrasColocadas++;
                                    }
                                    banderaPrimeraLetra = false;
                                    columnaPrincipal++;

                                }
                                //Izquierda
                                if (i != 0) {
                                    columnaPrincipal = letraCoincidenteTitulo;
                                    for (int n = i - 1; n >= 0; n--) {
                                        solucion[j, columnaPrincipal - 1] = titulos[indiceCandidatosColocados][n];
                                        numeroDescripciones[j, columnaPrincipal - 1] = indiceCandidatosColocados;
                                        columnaPrincipal--;
                                        numLetrasColocadas++;
                                    }
                                }
                                candidatosColocados[indiceCandidatosColocados] = true;
                                palabrasColocadas++;
                            }

                        }
                    }
                }

                //VERTICAL

                if (!candidatosColocados[indiceCandidatosColocados]) {
                    for (int i = 0; i < titulos[indiceCandidatosColocados].Length && !letraEncontrada; i++) {
                        for (int x = 0; x < 9 && !letraEncontrada; x++) {
                            for (int y = 0; y < 9 && !letraEncontrada; y++) {
                                if (titulos[indiceCandidatosColocados][i] == solucion[x, y]) {
                                    letraEncontrada = true;
                                    int auxX = x;
                                    for (int n = i + 1; n < titulos[indiceCandidatosColocados].Length && letraEncontrada; n++) {

                                        if (auxX + 1 > 8 || y > 8) {
                                            letraEncontrada = false;

                                        } else if (solucion[auxX + 1, y] != '0') {
                                            letraEncontrada = false;
                                        }
                                        if (y < 8 && auxX + 1 < 8) {
                                            if (solucion[auxX + 1, y + 1] != '0') {
                                                letraEncontrada = false;
                                            }
                                        }
                                        if (y > 0 && auxX + 1 < 8) {
                                            if (solucion[auxX + 1, y - 1] != '0') {
                                                letraEncontrada = false;
                                            }

                                        }
                                        auxX++;
                                    }
                                    if (i != 0) {
                                        auxX = x;
                                        for (int n = i - 1; n >= 0 && letraEncontrada; n--) {
                                            if (auxX - 1 < 0 || y > 8) {
                                                letraEncontrada = false;
                                            } else if (solucion[auxX - 1, y] != '0') {
                                                letraEncontrada = false;
                                            }
                                            if (y < 8 && auxX + 1 < 8) {
                                                if (solucion[auxX + 1, y + 1] != '0') {
                                                    letraEncontrada = false;
                                                }
                                            }
                                            if (y > 0 && auxX + 1 > 0) {
                                                if (solucion[auxX + 1, y - 1] != '0') {
                                                    letraEncontrada = false;
                                                }

                                            }
                                            auxX--;
                                        }
                                    }
                                    if (letraEncontrada) {
                                        //ABAJO
                                        auxX = x;
                                        bool banderaPrimeraLetra = true; //Utilizado para que las descripciones no se pisen al unir palabras.
                                        for (int n = i; n < titulos[indiceCandidatosColocados].Length; n++) {
                                            solucion[auxX, y] = titulos[indiceCandidatosColocados][n];
                                            if (!banderaPrimeraLetra) {
                                                numeroDescripciones[auxX, y] = indiceCandidatosColocados;
                                                numLetrasColocadas++;
                                            }
                                            banderaPrimeraLetra = false;
                                            auxX++;
                                        }
                                        //ARRIBA
                                        if (i != 0) {
                                            auxX = x;
                                            for (int n = i - 1; n >= 0; n--) {
                                                solucion[auxX - 1, y] = titulos[indiceCandidatosColocados][n];
                                                numeroDescripciones[auxX - 1, y] = indiceCandidatosColocados;
                                                auxX--;
                                                numLetrasColocadas++;
                                            }
                                        }
                                        palabrasColocadas++;
                                        candidatosColocados[indiceCandidatosColocados] = true;
                                    }
                                }
                            }
                        }
                    }

                }
                indiceCandidatosColocados++;
            }
        }

        Debug.Log ("LETRAS COLOCADAS: " + numLetrasColocadas);
    }

    private void instanciarMatriz () {
        int x, y;
        x = -675;
        y = 240;

        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                crearObjeto (i, j, x, y);
                x = x + 120;
            }
            x = -675;
            y = y - 120;
        }
    }

    private void crearObjeto (int i, int j, int x, int y) {
        int descripcion = numeroDescripciones[i, j];
        char letra = solucion[i, j];
        string palabra = titulos[descripcion];
        if (solucion[i, j] != '0') {
            GameObject cuadrado = Instantiate (objeto, new Vector3 (x, y, 0), Quaternion.identity);
            cuadrado.transform.SetParent (GameObject.FindGameObjectWithTag ("matriz").transform, false);
            cuadrado.GetComponent<buttonController> ().insertarElementos (descripcion, letra, i, j, x, y, palabra, this);
        }

    }

    public void cambiarActivo (buttonController botonNuevo) {
        if (letraActiva != null) {
            letraActiva.QuitarSeleccion ();
        }
        letraActiva = botonNuevo;
        letraActiva.Seleccionar ();
        descripcionActual.text = descripciones[letraActiva.descripcion];
    }

    public void Fin () {
        numLetrasColocadas = 0;
    }

    public void agregarPalabrasJugadas () {

        XmlNode jugadas = xDoc.SelectSingleNode ("palabras");

        for (int i = 0; i < titulos.Length; i++) {
            XmlElement descripcion = xDoc.CreateElement (usersController.jugadorActivo);
            descripcion.InnerText = descripciones[i];
            XmlAttribute attr = xDoc.CreateAttribute ("palabra");
            attr.Value = titulos[i];
            descripcion.SetAttributeNode (attr);

            jugadas.AppendChild (descripcion);
        }

        xDoc.Save (path);

    }

    public void botonTeclado (string letra) {

        letraCandidata = letra;
        if (letra.Equals ("a")) letraCandidataAcentuada = "á";
        else if (letra.Equals ("e")) letraCandidataAcentuada = "é";
        else if (letra.Equals ("i")) letraCandidataAcentuada = "í";
        else if (letra.Equals ("o")) letraCandidataAcentuada = "ó";
        else if (letra.Equals ("u")) letraCandidataAcentuada = "ú";
        else letraCandidataAcentuada = letra;
        escrito = true;
    }

}