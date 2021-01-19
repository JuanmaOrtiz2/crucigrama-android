using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Jugador : MonoBehaviour
{
    public Text nombreJugador;
    public Button acceder;
    public Button borrar;

    private int y;

    private usersController user;

    public Jugador(){}

    public int getY()
    {return y;}

    public void setY(int y)
    {
        this.y = y;
    }

  /*  private void accederMenu()
    {
        user.comenzarJuego(nombreJugador.ToString());
    }

    private void borrarJugador()
    {
        user.borrarJugador(nombreJugador.ToString(),0);
    }

    void Start()
    {
        acceder.onClick.AddListener(accederMenu);
        borrar.onClick.AddListener(borrarJugador);
    }*/

}
