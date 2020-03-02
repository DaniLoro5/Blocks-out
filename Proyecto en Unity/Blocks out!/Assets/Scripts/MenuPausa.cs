using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    public static bool juegoPausado = false;
    public GameObject panelMenuPausa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                pausarJuego();
            }
            else
            {
                seguirJugando();
            }
        }

    }

    public void pausarJuego()
    {

        panelMenuPausa.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void seguirJugando()
    {
        panelMenuPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }
}
