using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaScript : MonoBehaviour {
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform puntoGeneracion;
    [SerializeField] Transform baseCanyon;
    [SerializeField] Transform ejeCanyon;
    [SerializeField] float fuerza = 100;


    //
    float rotacionHorizontal, rotacionVertical;


    private void Start()
    {
        rotacionHorizontal = baseCanyon.rotation.y;
        rotacionVertical = ejeCanyon.rotation.x;
    }
    private void Update() {
        // CON ESPACIO DISPARAMOS
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject proyectil = Instantiate(prefabProyectil, 
                puntoGeneracion.position, 
                puntoGeneracion.rotation);
            proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerza);
        }
        // RECOJO LA FLECHA VERTICAL ARRIBA/ABAJO
        float xR = Input.GetAxis("Vertical");
        // RECOJO LA FLECHA HORIZONTAL DERECHA/IZQUIERDA
        float yR = Input.GetAxis("Horizontal");

        // ROTAMOS EL CAÑON EN HORIZONTAL EN EL EJE DE LA Y
        //baseCanyon.Rotate(0, yR, 0);
        // ROTAMOS EL CAÑON EN VERTICAL EN EL EJE DE LA X
        //ejeCanyon.transform.Rotate(xR * -1, yR, 0);

        // NEW NOV-25
        // PONDREMOS LIMITES EN EL MOVIMIENTO
        // RECOGER EL AXIS
        // ROTACION ACUMULADA HORIZONTAL
        rotacionHorizontal += yR;

        // PONEMOS EL LIMITE HORIZONTAL
        rotacionHorizontal = Mathf.Clamp(rotacionHorizontal, -90, 90);
        baseCanyon.rotation = Quaternion.Euler(0, rotacionHorizontal, 0);

        // ROTACION ACUMULADA VERTICAL
        rotacionVertical += xR;

        // PONEMOS EL LIMITE VERTICAL
        rotacionVertical = Mathf.Clamp(rotacionVertical, -20, 20);
        // ROTAMOS EL EJE DEL CAÑON EN EL EJE DE LA X EN VERTICAL PARA SUBIR Y BAJAR
        // EN EL EJE Y TAMBIEN LO PONGO PARA QUE NO QUEDE RARO EL EJECANYON Y ESTE EN LA MISMA POSICION
        // Y NO SE META EN LA BASECANYON
        ejeCanyon.rotation = Quaternion.Euler(rotacionVertical * -1, rotacionHorizontal, 0);


    }

}
