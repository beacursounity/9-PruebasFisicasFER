using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {
    [SerializeField] Transform target;
    Rigidbody miRigidBody;

    private void Start() {
        miRigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        // DISTANCIA ENTRE DOS PUNTOS
        Vector3 distancia = target.position - this.transform.position;
        // LA NORMALIZAMOS E INDICA DIRECCIÓN Y SENTIDO
        Vector3 distanciaNormalizada = distancia.normalized;
        // INTERVALO EN SEGUNDO DEL ULTIMO FOTOGRAMA HASTA EL ACTUAL
        Vector3 deltaPosition = distanciaNormalizada * Time.deltaTime;
        // Y LO MOVEMOS
        if (distancia.magnitude > 0.1f) {
            miRigidBody.MovePosition(miRigidBody.position + deltaPosition);
        }
    }
}
