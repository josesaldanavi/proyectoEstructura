using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    public Canvas principal;
    public Canvas ayuda;


    public void Start()
    {
        principal.enabled = true;
        ayuda.enabled = false;
    }

    public void StartJuego()
    {
        principal.enabled = false;
        ayuda.enabled = false;
    }
    public void Ayudasection()
    {
        principal.enabled = false;
        ayuda.enabled = true;
    }

}
