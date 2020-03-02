using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int vidas;
    public int puntuacion;

    public Text textoVidas;
    public Text textoPuntuacion;
    public Text textoRecord;
    public InputField recordNombre;

    public bool finjuego;
    public bool finNivel;
    public bool menuPausa = false;

    public GameObject panelFinDeJuego;
    public GameObject panelCargarNivel;
    public GameObject panelMenuPausa;

    public int numeroBloques;

    public Transform[] niveles;
    public int indiceNivelActual = 0;

    public AudioSource[] audio;
    public AudioSource audioSinVidas;
    public AudioSource audioSiguienteNivel;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponents<AudioSource>();
        audioSinVidas = audio[0];
        audioSiguienteNivel = audio[1];

        panelCargarNivel.GetComponentInChildren<Text>().text = "Nivel 1 \n ¡GO!"; // Panel para la carga del primer nivel
        panelCargarNivel.SetActive(true);
        audioSiguienteNivel.Play();

        finNivel = true;
        StartCoroutine(ejecutarDespues(2));
        textoVidas.text = "Vidas: " + vidas; // Vidas al iniciar el juego
        textoPuntuacion.text = "Puntuación: " + puntuacion; // Puntución al iniciar el juego
        numeroBloques = GameObject.FindGameObjectsWithTag("bloque").Length; // Número de bloques que hay en el nivel
           
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuPausa)
            {
                seguirJugando();
            }else
            {
                pausarJuego();
            }
        }
           
    }

    public void actualizarVidas(int cambioVidas) // Actualizamos las vidas que ganamos o perdemos (cambioVidas)
    {
        vidas += cambioVidas;

        if (vidas <= 0) // Comprobamos si aún nos quedan vidas. Si no, el juego finaliza
        {
            vidas = 0;
            finDelJuego();
        }

        textoVidas.text = "Vidas: " + vidas;
    }

    public void actualizarPuntuacion(int cambioPuntuacion) // Actualizamos las vidas que ganamos o perdemos (cambioVidas)
    {
        puntuacion += cambioPuntuacion;

        if(puntuacion < 0)
        {
            puntuacion = 0;
        }

        textoPuntuacion.text = "Puntuacion: " + puntuacion;
    }

    public void actualizarNumeroBloques()
    {

        numeroBloques--;
        if (numeroBloques <= 0)
        {
            if (indiceNivelActual >= niveles.Length - 1) // Si se han acabado los niveles, finaliza el juego.
            {

                finDelJuego();

            }else
            {
                panelCargarNivel.GetComponentInChildren<Text>().text = "Nivel " + (indiceNivelActual + 2) + "\n ¡GO!"; // Panel para la carga de a partir del segundo nivel
                panelCargarNivel.SetActive(true);
                audioSiguienteNivel.Play();
                finNivel = true;
                Invoke("cargarNivel", 4f); // Llamamos al método cargarNivel
            }
        }
    }

    public void cargarNivel() // Cargamos un nuevo nivel, en caso de haber más
    {
        indiceNivelActual++;
        Instantiate(niveles[indiceNivelActual], Vector2.zero, Quaternion.identity); // Se carga la pantalla del siguiente nivel
        numeroBloques = GameObject.FindGameObjectsWithTag("bloque").Length; // Se cuentan los bloques del nuevo nivel
        finNivel = false;
        panelCargarNivel.SetActive(false);
    }

    public void finDelJuego() // El juego finaliza
    {
        audioSinVidas.Play();
        finjuego = true;
        panelFinDeJuego.SetActive(true);
        int record = PlayerPrefs.GetInt("HIGHSCORE");

        if(puntuacion > record) // Si hay un nuevo record, se actualizar
        {
            PlayerPrefs.SetInt("HIGHSCORE", puntuacion);
            recordNombre.gameObject.SetActive(true);
            textoRecord.text = "¡Nuevo record! \nIntroduce tu nombre:";

        }else // Si no hay un nuevo récord, se muestra el actual
        {
            if(PlayerPrefs.GetString("HIGHSCORENAME") == "")
            {
                textoRecord.text = "Record actual: " + record + " de" + "\n anónimo";
            }else
            {
                textoRecord.text = "Record actual: " + record + " de" + "\n" + PlayerPrefs.GetString("HIGHSCORENAME");
            }

        }

    }

    public void nuevoRecord()
    {
        string nombre = recordNombre.text;

        if (nombre == "")
        {
            nombre = "anónimo";
        }

        PlayerPrefs.GetString("HIGHSCORENAME", nombre);
        recordNombre.gameObject.SetActive(false);
        textoRecord.text = "¡Enhorabuena " + nombre + "! \nTu nuevo record es: " +"\n  " + puntuacion;
    }

    public void volverAJugar() // Vuelve a cargar el juego desde el primer nivel
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void menuPrincipal() // Cierra el juego
    {
        SceneManager.LoadScene("Menú Inicio");
    }

    public void pausarJuego()
    {

        panelMenuPausa.SetActive(true);
        Time.timeScale = 0f;
        menuPausa = true;
    }

    public void seguirJugando()
    {
        panelMenuPausa.SetActive(false);
        Time.timeScale = 1f;
        menuPausa = false;
    }

    public void salir() // Función para cerrar el juego
    {
        Application.Quit();
    }

    public IEnumerator ejecutarDespues(float tiempo) // Método para ejecutar código después de 'tiempo' segundos
    {
        yield return new WaitForSeconds(tiempo);
        finNivel = false;
        panelCargarNivel.SetActive(false);
    }
}
