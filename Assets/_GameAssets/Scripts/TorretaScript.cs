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
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject proyectil = Instantiate(prefabProyectil, 
                puntoGeneracion.position, 
                puntoGeneracion.rotation);
            proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerza);
        }
        float xR = Input.GetAxis("Vertical");
        float yR = Input.GetAxis("Horizontal");
        baseCanyon.Rotate(0, yR, 0);
        ejeCanyon.Rotate(xR*-1, 0, 0);

    }

}
