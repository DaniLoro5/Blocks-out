using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicioScript : MonoBehaviour
{
    
    public void iniciar()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void salir() // Función para cerrar el juego
    {
        Application.Quit();
    }


}
