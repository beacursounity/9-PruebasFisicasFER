using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPlanetasScript : MonoBehaviour {
    [SerializeField] GameObject[] prefabsPlaneta;
    [SerializeField] Transform tX0Y0Z0;
    [SerializeField] Transform tX1;
    [SerializeField] Transform tY1;
    [SerializeField] Transform tZ1;
    [SerializeField] int numeroPlanetas = 100;

    private void Start() {
        for(int i = 0; i < numeroPlanetas; i++) {
            GenerarPlaneta();
        }
    }

    private void GenerarPlaneta() {
        float x = Random.Range(tX0Y0Z0.position.x, tX1.position.x);
        float y = Random.Range(tX0Y0Z0.position.y, tY1.position.y);
        float z = Random.Range(tX0Y0Z0.position.z, tZ1.position.z);
        int posicionAleatoria = Random.Range(0, prefabsPlaneta.Length);
        GameObject planeta = Instantiate(prefabsPlaneta[posicionAleatoria]);
        planeta.transform.position = new Vector3(x, y, z);
    }
}
