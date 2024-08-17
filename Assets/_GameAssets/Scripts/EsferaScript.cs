using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaScript : MonoBehaviour
{
 
    public int velocidad = 5;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        // RECOJO LA FLECHA VERTICAL ARRIBA/ABAJO
        float vPos = Input.GetAxis("Vertical");
        // RECOJO LA FLECHA HORIZONTAL DERECHA/IZQUIERDA
        float hPos = Input.GetAxis("Horizontal");


        transform.Translate(hPos * Time.deltaTime * velocidad, vPos * Time.deltaTime * velocidad, 0);

        //transform.Translate(posX * Time.deltaTime * velocidad, 0, 0);

      
    }
}
