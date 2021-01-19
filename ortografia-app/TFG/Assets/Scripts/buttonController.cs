using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    public Sprite cuadradoNormal;
    public Sprite cuadradoSeleccionado;
    public Sprite cuadradoMarcado;
    public int numero = 1;
    public int descripcion;
    public char letra;
    public string palabra;
    public int x,y;        //Posicion que ocupa en la matriz solucion
    public int posX,posY; //Posicion del cuadrado en la interfaz
    private startController controlador;
    private Button boton;
    private Image imagen;
    public Text texto;
    public bool seleccionar = true; //Si se pueden seleccionar o no  




    public void insertarElementos(int d,char l,int x,int y,int posX,int posY, string p,startController s)
    {

        descripcion = d;
        letra = l;
        this.x = x;
        this.y = y;
        this.posX = posX;
        this.posY = posY;
        palabra = p;    
        controlador = s;
    }   

    //OnClickEvent
    void OnButtonClick()
    {
        if(seleccionar)
        {
            controlador.cambiarActivo(this);
        }
        
    }

    public void QuitarSeleccion()
    {
       imagen.overrideSprite = null;
    }

    public void Seleccionar()
    {
        if(seleccionar)
        {
            imagen.overrideSprite = cuadradoSeleccionado;
        }
        
    }

    public void Correcta()
    {
        imagen.overrideSprite = cuadradoMarcado;
    }

    public void CambiarTexto()
    {
        texto.text = letra.ToString();
    }



    // Start is called before the first frame update
    void Start()
    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(OnButtonClick);
        imagen = GetComponent<Image>();
        texto = GetComponentInChildren<Text>();
        //texto.text = letra.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       if(!seleccionar)
       {
           imagen.overrideSprite = cuadradoMarcado;
       }
    }
}
