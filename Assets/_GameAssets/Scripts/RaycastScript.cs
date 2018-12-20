using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastScript : MonoBehaviour {
    public Transform origen;
    public Transform destino;
    public Text texto;
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Disparar();
        }
	}
    //RaycastAll
    /*
    public void Disparar() {
        RaycastHit[] rhs = Physics.RaycastAll(
            origen.position,
            origen.forward);
        if (rhs.Length != 0) {
            for (int i = 0; i < rhs.Length; i++) {
                print(rhs[i].transform.gameObject.name);
            }
        }
    }
    */


    // Raycast
    private void Disparar() {
        RaycastHit rh;
        //bool hayImpacto = Physics.Raycast(origen.position, origen.forward);
        bool hayImpacto = Physics.Raycast(
            origen.position, 
            origen.forward,
            out rh);
        //Debug.DrawRay(origen.position, origen.forward, Color.red, 50);
        texto.text = "" + hayImpacto;
        if (hayImpacto) {
            string nombreObjectoImpactado = rh.transform.gameObject.name;
            texto.text = nombreObjectoImpactado;
        }
        
    }
}
