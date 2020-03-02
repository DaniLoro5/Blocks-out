using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotenciadorScript : MonoBehaviour
{

    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * velocidad);

        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
           
    }
}
