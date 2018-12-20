using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionScript : MonoBehaviour {
    public int speed = 100;

	void Update () {
        float vPos = Input.GetAxis("Vertical");
        float hPos = Input.GetAxis("Horizontal");
        //AVANZAR SIN PULSAR NADA
        GetComponent<CharacterController>().Move(
            transform.forward * 
            Time.deltaTime  *
            speed
        );
        //Rotamos el avion
        transform.Rotate(new Vector3(vPos, hPos, hPos*-1));

        /*
         * PARA UN ELEMENTO TERRESTRE
        bool estaEnTierra = GetComponent<CharacterController>().SimpleMove(
            Vector3.forward * 
            Time.deltaTime * 
            speed *
            vPos);
        */

	}
}
