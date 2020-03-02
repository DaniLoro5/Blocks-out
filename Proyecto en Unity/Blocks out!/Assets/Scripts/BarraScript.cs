using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraScript : MonoBehaviour
{

    public float velocidad;
    public float bordeDerecho; // Borde derecho de la pantalla
    public float bordeIzquierdo; // Borde izquierdo de la pantalla

    public GameManager gm;

    public AudioSource[] audio;
    public AudioSource audioVidaMas;
    public AudioSource audioVidaMenos;
    public AudioSource audioBarraCrece;
    public AudioSource audioPuntosMas;
    public AudioSource audioPuntosMenos;
    public AudioSource audioBarraDecrece;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponents<AudioSource>();
        audioVidaMas = audio[0];
        audioVidaMenos = audio[1];
        audioBarraCrece = audio[2];
        audioBarraDecrece = audio[3];
        audioPuntosMas = audio[4];
        audioPuntosMenos = audio[5];
    }

    // Update is called once per frame
    void Update()
    {

        if (gm.finjuego) // Si nos hemos quedado sin vidas, la barra no se moverá de su posición
        {
            return;
        }

        if (gm.finNivel)
        {
            transform.position = new Vector2(0.08f, transform.position.y);
        }

        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * velocidad);

        if(transform.position.x < bordeIzquierdo) // Evitamos que la barra se salga por el lado izquiero de la pantalla
        {
            transform.position = new Vector2(bordeIzquierdo, transform.position.y);
        }

        if (transform.position.x > bordeDerecho) // Evitamos que la barra se salga por el lado izquiero de la pantalla
        {
            transform.position = new Vector2(bordeDerecho, transform.position.y);
        }

    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("vidaExtra")) // Si el objeto que toca la barra es el sprite de vida extra
        {
            audioVidaMas.Play();
            gm.actualizarVidas(1); // Sumamos una vida al contador
            Destroy(c2d.gameObject); // El sprite de la vida extra se destruye
        }
        else if (c2d.CompareTag("vidaMenos"))
        {
            audioVidaMenos.Play();
            gm.actualizarVidas(-1); // Restar una vida al contador
            Destroy(c2d.gameObject); // El sprite de la vida menos se destruye
        }
        else if (c2d.CompareTag("diezPMas"))
        {
            audioPuntosMas.Play();
            gm.actualizarPuntuacion(10); // Sumar 10 puntos
            Destroy(c2d.gameObject); // El sprite se destruye
        }
        else if (c2d.CompareTag("diezPMenos"))
        {
            audioPuntosMenos.Play();
            gm.actualizarPuntuacion(-10); // Restar 10 puntos
            Destroy(c2d.gameObject); // El sprite se destruye
        }
        else if (c2d.CompareTag("veintePMas"))
        {
            audioPuntosMas.Play();
            gm.actualizarPuntuacion(20); // Sumar 20 puntos
            Destroy(c2d.gameObject); // El sprite se destruye
        }
        else if (c2d.CompareTag("veintePMenos"))
        {
            audioPuntosMenos.Play();
            gm.actualizarPuntuacion(-20); // Restar 20 puntos
            Destroy(c2d.gameObject); // El sprite se destruye
        }
        else if (c2d.CompareTag("cincuentaPMas"))
        {
            audioPuntosMas.Play();
            gm.actualizarPuntuacion(50); // Sumar 50 puntos
            Destroy(c2d.gameObject); // El sprite se destruye
        }
        else if (c2d.CompareTag("cincuentaPMenos"))
        {
            audioPuntosMenos.Play();
            gm.actualizarPuntuacion(-50); // Restar 50 puntos
            Destroy(c2d.gameObject); // El sprite se destruye
        }
        else if (c2d.CompareTag("cienPMas"))
        {
            audioPuntosMas.Play();
            gm.actualizarPuntuacion(100); // Sumar 100 puntos
            Destroy(c2d.gameObject); // El sprite se destruye
        }
        else if (c2d.CompareTag("cienPMenos"))
        {
            audioPuntosMenos.Play();
            gm.actualizarPuntuacion(-100); // Restar 100 puntos
            Destroy(c2d.gameObject); // El sprite se destruye
        }
        else if (c2d.CompareTag("barraCrece"))
        {
            audioBarraCrece.Play();
            if(transform.localScale.x <= 12.5) // Comprobar el tamaño de la barra y actualizarlo si es posible
            {
                float nuevaEscala = 0.5f;

                transform.localScale = new Vector2(transform.localScale.x + nuevaEscala, transform.localScale.y);
            }
            Destroy(c2d.gameObject); // El sprite se destruye
             

        }else if (c2d.CompareTag("barraDecrece"))
        {
            audioBarraDecrece.Play();
            if(transform.localScale.x >= 3.5) // Comprobar el tamaño de la barra y actualizarlo si es posible
            {
                float nuevaEscala = 0.5f;

                transform.localScale = new Vector2(transform.localScale.x - nuevaEscala, transform.localScale.y);
            }

            Destroy(c2d.gameObject); // El sprite se destruye

        }
        
    }
}
