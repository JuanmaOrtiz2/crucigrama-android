using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostrarCreditos : MonoBehaviour
{
    public GameObject canvasEmergente;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mostrar()
    {
        canvasEmergente.SetActive(true);
    }
    
    public void cerrar()
    {
        canvasEmergente.SetActive(false);
    }
}
