using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezaOvejaScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        //Esto no se ejecuta porque en la jerarquía hay un padre con RigidBody
        print("CABEZA OVEJA TRIGGER ENTER:" + gameObject.name);
    }
}
