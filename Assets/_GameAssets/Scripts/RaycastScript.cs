using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastScript : MonoBehaviour {
    //public Transform origen;
    public Transform destino;
    public Text texto;
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Disparar();
        }
	}
    //RaycastAll
    //LANZAMOS EL RAYO Y NOS DEVUELVE UN ARRAY
    public void Disparar() {
        RaycastHit[] rhs = Physics.RaycastAll(
            transform.position,
            transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red, 4);
        if (rhs.Length != 0)
        {
            texto.text = "Impacto SI";
            for (int i = 0; i < rhs.Length; i++)
            {
                print(rhs[i].transform.gameObject.name);
            }
        }
        else texto.text = "Impacto NO";
        
    }



    // Raycast
    /*private void Disparar() {
        RaycastHit rh;
        // PARA SACAR LA INFORMACION DE CON QUIEN SE HA CHOCADO SOLO UN OBJETO
        //bool hayImpacto = Physics.Raycast(transform.position, transform.forward);
        bool hayImpacto = Physics.Raycast(
            transform.position, 
            transform.forward,
            out rh);
        Debug.DrawRay(transform.position, trasnform.forward, Color.red, 100);
        //texto.text = "" + hayImpacto;
       
        if (hayImpacto) {
         texto.text = "Impacto SI";
            string nombreObjectoImpactado = rh.transform.gameObject.name;
            texto.text = nombreObjectoImpactado;
        }
        texto.text = "Impacto NO";
        
    }*/
}
