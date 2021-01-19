using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsController : MonoBehaviour
{
    public static int dificultad;
    public static int letras;
    public static int sonido;
    public static int efectos;


    private string dif = "dificultad";
    private string
    let = "letras";
    private string son = "sonido";
    private string
    efe = "efectos";

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void seleccionarDificultad(int d)
    {
        dificultad = d;
    }

    public void seleccionarLetras(int l)
    {
        letras = l;
    }

    public void seleccionarSonido(int s)
    {
        sonido = s;
    }

    public void seleccionarEfectos(int e)
    {
        efectos = e;
    }

    public int getLetras () {
        return letras;
    }

    public int getDificultad () {
        return dificultad;
    }

    public int getSonido () {
        return sonido;
    }

    public int getEfectos () {
        return efectos;
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(dif, dificultad);
        PlayerPrefs.SetInt(let, letras);
        PlayerPrefs.SetInt(son, sonido);
        PlayerPrefs.SetInt(efe, efectos);
    }

    private void LoadData()
    {
        dificultad = PlayerPrefs.GetInt(dif, 0);
        letras = PlayerPrefs.GetInt(let, 0);
        sonido = PlayerPrefs.GetInt(son, 0);
        efectos = PlayerPrefs.GetInt(efe, 0);
    }

    private void OnDestroy()
    {
        SaveData();
    }
}