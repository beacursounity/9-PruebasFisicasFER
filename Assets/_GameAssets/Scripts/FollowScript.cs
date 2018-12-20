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
        Vector3 distancia = target.position - this.transform.position;
        Vector3 distanciaNormalizada = distancia.normalized;
        Vector3 deltaPosition = distanciaNormalizada * Time.deltaTime;
        if (distancia.magnitude > 0.1f) {
            miRigidBody.MovePosition(miRigidBody.position + deltaPosition);
        }
    }
}
