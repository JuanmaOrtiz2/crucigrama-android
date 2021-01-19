using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    AudioSource musica;
    private optionsController op;
    
    // Start is called before the first frame update
    void Start()
    {
        musica = GetComponent<AudioSource>();
        op = GetComponent<optionsController>();
        musica.mute = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(op.getSonido()==1)
        {
            musica.mute = true;
        }
        else
        {
            musica.mute = false;
        }
    }

}
