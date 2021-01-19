using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unidadMatriz : MonoBehaviour
{
    public int descripcion;
    public char letra;
    public GameObject boton;
    public Sprite cuadradoNormal;
    public Sprite cuadradoSeleccionado;
    public Sprite cuadradoMarcado;
    //ThisButton.GetComponentsInChildren.<Text>.text = "testing";
    //mybutton.image.sprite?
    public bool seleccionada = false; //Casilla seleccionada por el usuario
    public bool marcada = false; //Casilla marcada porque fue seleccionada una casilla de la palabra
    public int x,y;        //Posicion que ocupa en la matriz solucion
    public int posX,posY; //Posicion del cuadrado en la interfaz
    public string palabra;

    
    public unidadMatriz(){}

    public void OnMouseDown() {
        Debug.Log("Presionado");
        if(seleccionada)
        {
            Debug.Log("Ahora es falso");
            seleccionada = false;
            //boton.GetComponent<Button>().GetComponent<Image>().sprite = cuadradoSeleccionado;
        }
        else
        {
            Debug.Log("Ahora es true");
            seleccionada = true;
            //boton.GetComponent<Button>().GetComponent<Image>().sprite = cuadradoNormal;
        }
        /*if(seleccionada)
        {
            Debug.Log("Cambiando");
            boton.GetComponent<Button>().image.sprite = cuadradoSeleccionado;
            Debug.Log("Cambiado");
            //GameObject cuadrado = Instantiate(boton,new Vector3(posX,posY,0), Quaternion.identity);
            //cuadrado.transform.SetParent (GameObject.FindGameObjectWithTag("matriz").transform, false);
        }
        else
        {
            boton.GetComponent<Button>().image.sprite = cuadradoNormal;
            //GameObject cuadrado = Instantiate(boton,new Vector3(posX,posY,0), Quaternion.identity);
            //cuadrado.transform.SetParent (GameObject.FindGameObjectWithTag("matriz").transform, false);
        }*/
        
        
    }

    public void imagenSeleccionada()
    {
        this.boton.GetComponent<Button>().GetComponent<Image>().sprite = cuadradoSeleccionado;
    }

    public void imagenNormal()
    {
        this.boton.GetComponent<Button>().GetComponent<Image>().sprite = cuadradoNormal;
    }

    private void marcar(int x, int y)
    {

    }

    public void crear()
    {
        GameObject b = Instantiate(this.boton,new Vector3(posX,posY,0), Quaternion.identity);
        b.transform.SetParent (GameObject.FindGameObjectWithTag("matriz").transform, false);
        boton.SetActive(true);
    }

    public void destruir()
    {
        boton.SetActive(false);
    }


    public void insertarElementos(int d,char l,int x,int y,int posX,int posY, string p)
    {

        descripcion = d;
        letra = l;
        this.x = x;
        this.y = y;
        this.posX = posX;
        this.posY = posY;
        palabra = p;
        boton.GetComponent<Button>().GetComponent<Image>().sprite = cuadradoNormal;
        if(l!='0')
        {
            crear();
        }
        
        
        
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




        
    }
}
