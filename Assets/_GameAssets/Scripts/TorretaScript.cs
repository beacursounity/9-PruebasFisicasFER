using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaScript : MonoBehaviour {
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform puntoGeneracion;
    [SerializeField] Transform baseCanyon;
    [SerializeField] Transform ejeCanyon;
    [SerializeField] float fuerza = 100;

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
        baseCanyon.Rotate(0, yR, 0);
        // ROTAMOS EL EJE DEL CAÑON EN EL EJE DE LA X EN VERTICAL PARA SUBIR Y BAJAR
        ejeCanyon.Rotate(xR*-1, 0, 0);

    }

}
