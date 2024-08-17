using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionScript : MonoBehaviour {
    public int speed = 100;

	void Update () {
        // VALORES DEL GETAXIS ENTRE -1....1
        float vPos = Input.GetAxis("Vertical");
        float hPos = Input.GetAxis("Horizontal");
        //AVANZAR SIN PULSAR NADA USAR MOVE NOS DA UN VECTOR DE DESPLAZAMIENTO HACIA DONDE QUIERO IR
        // EL CHARACTER CONTROLER SE USA PARA PERSONAJES Y NO PARA UN AVION 
        GetComponent<CharacterController>().Move(
            transform.forward * 
            Time.deltaTime  *
            speed
        );
        //Rotamos el avion 
        //X VERTICAL FLECHA ABAJO EN NEGATIVO VA HACIA ARRIBA/F.ARRIBA EN POSITIVO VA HACIA ABAJO
        //Y HORIZONTAL FLECHA DERECHA EN POSITIVO /F.IZQUIERDA EN NEGATIVO
        //Z A LA F.DERECHA ROTA EN NEGATIVO /F.IZQUIERDA POSITIVO
        transform.Rotate(new Vector3(vPos, hPos, hPos*-1));

        /*
         * PARA UN ELEMENTO TERRESTRE APLICA VECTOR DE VELOCIDAD Y GRAVEDAD
        bool estaEnTierra = GetComponent<CharacterController>().SimpleMove(
            Vector3.forward * 
            Time.deltaTime * 
            speed *
            vPos);
        */

	}
}
