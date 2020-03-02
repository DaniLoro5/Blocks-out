using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueScript : MonoBehaviour
{

    public int puntos;
    public int golpesParaRomper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RomperBloque()
    {
        golpesParaRomper--;
    }
}
