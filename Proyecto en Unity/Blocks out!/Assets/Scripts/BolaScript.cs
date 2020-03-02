using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool enMovimiento; // La bola se está moviendo
    public Transform barra;
    public float velocidad;
    public Transform explosion;
    public GameManager gm;
    public AudioSource[] audio;
    public AudioSource audioGolpeBloque;
    public AudioSource audioGolpeParedBarra;
    public AudioSource audioBordeInferior;
    public Transform vidaExtra;
    public Transform vidaMenos;
    public Transform diezPMas;
    public Transform diezPMenos;
    public Transform veintePMas;
    public Transform veintePMenos;
    public Transform cincuentaPMas;
    public Transform cincuentaPMenos;
    public Transform cienPMas;
    public Transform cienPMenos;
    public Transform barraCrece;
    public Transform barraEncoge;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        audio = GetComponents<AudioSource>();
        audioGolpeBloque = audio[0];
        audioGolpeParedBarra = audio[1];
        audioBordeInferior = audio[2];

    }

    // Update is called once per frame
    void Update()
    {
        if(gm.finjuego) // Si el juego ha finalizado, la bola no se regenera
        {
            transform.position = barra.position;
            enMovimiento = false;
            //rb.velocity = Vector2.zero;
            return;
        }



        if (!enMovimiento) // La bola se resetea encima de la barra
        {
            transform.position = barra.position;
        }

        if (Input.GetButtonDown("Jump") && !enMovimiento && !gm.finNivel ) // Si se pulsa la barra espaciadora y la bola no está en movimiento, esta se despega de la barra y comienza a moverse
        {
            enMovimiento = true;
            rb.AddForce(Vector2.up * velocidad);
        }

        if (gm.finNivel || (gm.finNivel && Input.GetButtonDown("Jump")))
        {
            enMovimiento = false;
            transform.position = barra.position;
        }
    }

    public void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("inferior")) // Comprobamos que la bola choca con el borde inferior mediante su tag
        {
            rb.velocity = Vector2.zero;
            enMovimiento = false;
            gm.actualizarVidas(-1); // Perdemos una vida y actualizamos el contador

            if(gm.vidas > 0)
            {
                audioBordeInferior.Play();
            }
        }


    }

    public void OnCollisionEnter2D(Collision2D c2d)
    {
        if (c2d.transform.CompareTag("bloque")) // Comprobamos que la bola golpea un bloque mediante su tag
        {
            BloqueScript bloqueScript = c2d.gameObject.GetComponent<BloqueScript>();
            if (bloqueScript.golpesParaRomper > 1)
            {

                bloqueScript.RomperBloque();

            }
            else
            {
                //Número aleatorios para cada uno de los potenciadores
                int numRandomVidaExtra = Random.Range(1, 101);
                int numRandomVidaMenos = Random.Range(1, 101);
                int numRandomDiezPMas = Random.Range(1, 101);
                int numRandomDiezPMenos = Random.Range(1, 101);
                int numRandomVeintePMas = Random.Range(1, 101);
                int numRandomVeintePMenos = Random.Range(1, 101);
                int numRandomCincuentaPMas = Random.Range(1, 101);
                int numRandomCincuentaPMenos = Random.Range(1, 101);
                int numRandomCienPMas = Random.Range(1, 101);
                int numRandomCienPMenos = Random.Range(1, 101);
                int numRandomBarraCrece = Random.Range(1, 101);
                int numRandomBarraEncoge = Random.Range(1, 101);

                // Si el número aleatorio del potenciador está en el rango permitido, se instancia dicho potencicador en la pantalla

                if(gm.indiceNivelActual < 4) // Dificultad baja
                {
                    if (numRandomVidaExtra <= 13)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 40;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 30;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 20;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 100;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 100;
                        numRandomBarraEncoge = 0;

                        Instantiate(vidaExtra, c2d.transform.position, c2d.transform.rotation);
                    }

                    if (numRandomDiezPMas < 30)
                    {
                        numRandomVidaMenos = 4;
                        numRandomVidaExtra = 14;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 30;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 20;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 100;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 100;
                        numRandomBarraEncoge = 0;

                        Instantiate(diezPMas, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomBarraCrece <= 10)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 40;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 30;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 20;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 100;
                        numRandomCienPMenos = 0;
                        numRandomVidaExtra = 14;
                        numRandomBarraEncoge = 0;

                        Instantiate(barraCrece, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomVeintePMas < 20)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 10;
                        numRandomDiezPMenos = 30;
                        numRandomVidaExtra = 14;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 20;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 100;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 100;
                        numRandomBarraEncoge = 0;

                        Instantiate(veintePMas, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomCincuentaPMas < 15)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 40;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 30;
                        numRandomVeintePMenos = 20;
                        numRandomVidaExtra = 14;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 100;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 100;
                        numRandomBarraEncoge = 0;

                        Instantiate(cincuentaPMas, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomCienPMas <= 5)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 40;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 30;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 20;
                        numRandomCincuentaPMenos = 10;
                        numRandomVidaExtra = 14;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 100;
                        numRandomBarraEncoge = 0;

                        Instantiate(cienPMas, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomVidaMenos <= 3)
                    {

                        numRandomVidaExtra = 4;
                        numRandomDiezPMas = 40;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 30;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 20;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 100;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 100;
                        numRandomBarraEncoge = 0;

                        Instantiate(vidaMenos, c2d.transform.position, c2d.transform.rotation);
                    }

                    if (numRandomDiezPMenos < 20 && gm.puntuacion > 0)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 40;
                        numRandomVidaExtra = 14;
                        numRandomVeintePMas = 30;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 20;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 100;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 100;
                        numRandomBarraEncoge = 0;

                        Instantiate(diezPMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomBarraEncoge == 10)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 40;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 30;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 20;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 100;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 100;
                        numRandomVidaExtra = 14;

                        Instantiate(barraEncoge, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomVeintePMenos < 10 && gm.puntuacion > 0)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 40;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 30;
                        numRandomVidaExtra = 14;
                        numRandomCincuentaPMas = 20;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 100;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 100;
                        numRandomBarraEncoge = 0;

                        Instantiate(veintePMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomCincuentaPMenos < 5 && gm.puntuacion > 0)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 40;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 30;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 20;
                        numRandomVidaExtra = 14;
                        numRandomCienPMas = 100;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 100;
                        numRandomBarraEncoge = 0;

                        Instantiate(cincuentaPMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomCienPMenos == 1 && gm.puntuacion > 30)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 40;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 30;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 20;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 100;
                        numRandomVidaExtra = 14;
                        numRandomBarraCrece = 100;
                        numRandomBarraEncoge = 0;

                        Instantiate(cienPMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                }else if(gm.indiceNivelActual>= 4 && gm.indiceNivelActual < 8) // Dificultad media
                {
                    if (numRandomVidaExtra <= 3)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 0;

                        Instantiate(vidaExtra, c2d.transform.position, c2d.transform.rotation);
                    }

                    if (numRandomVidaMenos <= 3)
                    {

                        numRandomVidaExtra = 4;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 0;

                        Instantiate(vidaMenos, c2d.transform.position, c2d.transform.rotation);
                    }

                    if (numRandomDiezPMas < 20)
                    {
                        numRandomVidaMenos = 4;
                        numRandomVidaExtra = 4;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 0;

                        Instantiate(diezPMas, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomDiezPMenos < 20 && gm.puntuacion > 0)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 30;
                        numRandomVidaExtra = 4;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 0;

                        Instantiate(diezPMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomBarraCrece == 10)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 0;
                        numRandomVidaExtra = 4;
                        numRandomBarraEncoge = 0;

                        Instantiate(barraCrece, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomBarraEncoge == 10)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 0;
                        numRandomVidaExtra = 4;

                        Instantiate(barraEncoge, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomVeintePMas < 10)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 30;
                        numRandomVidaExtra = 4;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 0;

                        Instantiate(veintePMas, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomVeintePMenos < 10 && gm.puntuacion > 0)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 20;
                        numRandomVidaExtra = 4;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 0;

                        Instantiate(veintePMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomCincuentaPMas < 5)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 20;
                        numRandomVidaExtra = 4;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 0;

                        Instantiate(cincuentaPMas, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomCincuentaPMenos < 5 && gm.puntuacion > 0)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 10;
                        numRandomVidaExtra = 4;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 0;

                        Instantiate(cincuentaPMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomCienPMas == 1)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 10;
                        numRandomVidaExtra = 4;
                        numRandomCienPMenos = 0;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 0;

                        Instantiate(cienPMas, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomCienPMenos == 1 && gm.puntuacion > 30)
                    {
                        numRandomVidaMenos = 4;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 30;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 20;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 10;
                        numRandomCienPMas = 0;
                        numRandomVidaExtra = 4;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 0;

                        Instantiate(cienPMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                }else // Dificultad alta
                {
                    if (numRandomVidaMenos <= 13)
                    {

                        numRandomVidaExtra = 4;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 40;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 30;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 20;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 100;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 100;

                        Instantiate(vidaMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomDiezPMenos < 30 && gm.puntuacion > 0)
                    {
                        numRandomVidaMenos = 14;
                        numRandomDiezPMas = 30;
                        numRandomVidaExtra = 4;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 30;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 20;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 100;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 100;

                        Instantiate(diezPMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomBarraEncoge <= 10)
                    {
                        numRandomVidaMenos = 14;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 20;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 30;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 20;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 100;
                        numRandomBarraCrece = 0;
                        numRandomVidaExtra = 4;

                        Instantiate(barraEncoge, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomVeintePMenos < 20 && gm.puntuacion > 0)
                    {
                        numRandomVidaMenos = 14;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 40;
                        numRandomVeintePMas = 20;
                        numRandomVidaExtra = 4;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 20;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 100;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 100;

                        Instantiate(veintePMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomCincuentaPMenos < 15 && gm.puntuacion > 0)
                    {
                        numRandomVidaMenos = 14;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 40;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 30;
                        numRandomCincuentaPMas = 10;
                        numRandomVidaExtra = 4;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 100;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 100;

                        Instantiate(cincuentaPMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomCienPMenos <= 5 && gm.puntuacion > 30)
                    {
                        numRandomVidaMenos = 14;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 40;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 30;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 20;
                        numRandomCienPMas = 0;
                        numRandomVidaExtra = 4;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 100;

                        Instantiate(cienPMenos, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomVidaExtra <= 3)
                    {
                        numRandomVidaMenos = 14;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 40;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 30;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 20;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 100;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 100;

                        Instantiate(vidaExtra, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomDiezPMas < 20)
                    {
                        numRandomVidaMenos = 14;
                        numRandomVidaExtra = 4;
                        numRandomDiezPMenos = 40;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 30;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 20;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 100;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 100;

                        Instantiate(diezPMas, c2d.transform.position, c2d.transform.rotation);
                    }
                    
                    if (numRandomBarraCrece == 10)
                    {
                        numRandomVidaMenos = 14;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 20;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 30;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 20;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 100;
                        numRandomVidaExtra = 4;
                        numRandomBarraEncoge = 100;

                        Instantiate(barraCrece, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomVeintePMas < 10)
                    {
                        numRandomVidaMenos = 14;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 40;
                        numRandomVidaExtra = 4;
                        numRandomVeintePMenos = 30;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 20;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 100;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 100;

                        Instantiate(veintePMas, c2d.transform.position, c2d.transform.rotation);
                    }
                    
                    if (numRandomCincuentaPMas < 5)
                    {
                        numRandomVidaMenos = 14;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 40;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 30;
                        numRandomVidaExtra = 4;
                        numRandomCincuentaPMenos = 20;
                        numRandomCienPMas = 0;
                        numRandomCienPMenos = 100;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 100;

                        Instantiate(cincuentaPMas, c2d.transform.position, c2d.transform.rotation);
                    }
                    if (numRandomCienPMas == 1)
                    {
                        numRandomVidaMenos = 14;
                        numRandomDiezPMas = 30;
                        numRandomDiezPMenos = 40;
                        numRandomVeintePMas = 20;
                        numRandomVeintePMenos = 30;
                        numRandomCincuentaPMas = 10;
                        numRandomCincuentaPMenos = 20;
                        numRandomVidaExtra = 4;
                        numRandomCienPMenos = 100;
                        numRandomBarraCrece = 0;
                        numRandomBarraEncoge = 100;

                        Instantiate(cienPMas, c2d.transform.position, c2d.transform.rotation);
                    }
                }

                

                Transform nuevaExplosion = Instantiate(explosion, c2d.transform.position, c2d.transform.rotation); // Se crea el efecto de la explosión cuando el bloque se va a romper
                Destroy(nuevaExplosion.gameObject, 2.5f); // Se destruye de la jerarquía de Assets los efectos de las explosiones después de 2 segundos y medio

                gm.actualizarPuntuacion(bloqueScript.puntos);
                gm.actualizarNumeroBloques(); // Cuando se destruye un bloque, el número que hay de estos se actualiza
                Destroy(c2d.gameObject); // El bloque se destruye
                
            }

            audioGolpeBloque.Play();

        }else if(c2d.transform.CompareTag("bloqueInd")){

            audioGolpeBloque.Play();
        }

        if((c2d.transform.CompareTag("barra") || c2d.transform.CompareTag("bordeIDS")) && enMovimiento)
        {
            audioGolpeParedBarra.Play();
        }

    }
}
