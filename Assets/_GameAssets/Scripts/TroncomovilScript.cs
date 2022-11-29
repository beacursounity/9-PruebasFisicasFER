using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // PARA UI

public class TroncomovilScript : MonoBehaviour {

    // POSICION VERTICAL Y POSICION HORIZONTAL
    private float vPos;
    private float hPos;

    private WheelCollider wcFrontL, wcFrontR, wcBackL, wcBackR;

    // ES LA FUERZA QUE LE QUIERO APLICAR AL MOTOR
    public float fuerzaMaximaMotor = 300;

    // GRADOS A ROTAR COMO MAXIMO
    public float anguloMaximoRotacion = 20;

    // VARIABLES DE FRENADOS
    public float fuerzaFrenado = 1;
    public int incrementoFrenado = 10;
    bool frenoManoActivo = false;
    public Text txtFrenoMano;

    // VELOCIDAD
    public Text txtSpeed;
    // MARCHA
    public Text txtMarcha;
    float fSpeed;

    // MATERIAL DEL FRENO
    public Material materialFreno;

    private void Start() {
        // BUSCAMOS LA RUEDA FRONTL Y RECOGEMOS SU COMPONENTE WHEELCOLLIDER
        // TAMBIEN SE PODRIA HACER CREANDO UNA VARIABLE PUBLICA Y ARRASTRANDO 
        // EL OBJ EN EL EDITOR. DA LOS MISMO HACERLO DE UNA MANERA QUE DE OTRA
        // DA MENOS PROBABILIDAD DE ERROR DE ARRASTRANDOLO PQ ASI NO NOS CONFUNDIMOS AL ESCRIBIR EL NOMBRE
        wcFrontL = GameObject.Find("FrontLeft").GetComponent<WheelCollider>();
        wcFrontR = GameObject.Find("FrontRight").GetComponent<WheelCollider>();
        wcBackL = GameObject.Find("BackLeft").GetComponent<WheelCollider>();
        wcBackR = GameObject.Find("BackRight").GetComponent<WheelCollider>();

        txtFrenoMano.text = "Handbrake: off";

        // DESACTIVA LA LUZ DE FRENADO AL PRINCIPIO
        materialFreno.DisableKeyword("_EMISSION");
    }


    private void Update() {
        // COGEMOS EL COMPONENTE RIGIDBODY PQ ES LA QUE NOS DA LAS FISICAS 
        // PARA PODER RECOGER LA VELOCIDAD
        // NO ES UNA REALIDAD MUY FIABLE
        // LA MAGNITUD NOS DEVUELVE LA LONGITUD DEL VECTOR
        // ES LA DISTANCIA ENTRE SU PUNTO DE ORIGEN Y SU PUNTO FINAL
        fSpeed = GetComponent<Rigidbody>().velocity.magnitude;

        // LA Z ES MAS FIABLE YA QUE ES LA QUE VA HACIA DELANTE
        //float fSpeed = GetComponent<Rigidbody>().velocity.z;
        // (int)fSpeed hacer un cash, casting, castear..
        // el int redondea.

        // LA CONVERTIMOS A ENTERA Y QUITAMOS LOS DECIMALES
        txtSpeed.text = ((int)fSpeed).ToString();

        // SI LE DAMOS A LA TECLA F
        if (Input.GetKeyDown(KeyCode.F)) {
            // ACTIVAMOS Y DESACTIVAMOS EL FRENO DE MANO
            frenoManoActivo = !frenoManoActivo;

            // SI ESTA EL FRENOACTIVO LE CAMBIAMOS EL TEXTO A ON/OFF
            if (frenoManoActivo) {
                txtFrenoMano.text = "Handbrake: on";
            } else txtFrenoMano.text = "Handbrake: off";
        }

        
    }
    // Update is called once per frame
    public void FixedUpdate() {

        // VAMOS A COGER LAS COORDENADAS CUANDO PULSEMOS
        vPos = Input.GetAxis("Vertical");
        hPos = Input.GetAxis("Horizontal");

        // RUEDAS DIRECTRICES LAS DELANTERAS
        // ANGULO DE GIRO steerAngle
        wcFrontL.steerAngle = anguloMaximoRotacion * hPos;
        wcFrontR.steerAngle = anguloMaximoRotacion * hPos;

        //print(vPos + ":" + hPos);
        //print("Velocidad: " + fSpeed);

        if (!frenoManoActivo) {
            //print("No frena");
            if (vPos > 0) { // AVANZA CON LA FLECHA HACIA DELANTE
                txtMarcha.text = "Marcha Adelante";

                // DESACTIVA LA LUZ DE FRENADO
                materialFreno.DisableKeyword("_EMISSION");

                SoltarFreno(); // SUELTO EL FRENO
                // VAMOS HACER TRACCION A LAS TRASERAS PARA QUE AVANCE
                wcBackL.motorTorque = fuerzaMaximaMotor * vPos;
                wcBackR.motorTorque = fuerzaMaximaMotor * vPos;

            } else if (vPos < 0 && fSpeed > 0.01) { // SI ESTOY ANDANDO DEPENDE DE LA VELOCIDAD
                // CUANDO LE DAMOS A LA FLECHA HACIA ABAJO(ATRAS)
                txtMarcha.text = "Esta Frenado";
                // ACTIVA LA LUZ DE FRENADO
                materialFreno.EnableKeyword("_EMISSION");
                Frenar();

            } else if (vPos < 0 && fSpeed <= 0.01) { // SI ESTOY FRENADO EL COCHE EMPEZARA A IR HACIA ATRAS.
                txtMarcha.text = "Marcha Atras";
                SoltarFreno();
               // print(vPos+ " fSpeed: " + fSpeed);
                wcBackL.motorTorque = fuerzaMaximaMotor * vPos;
                wcBackR.motorTorque = fuerzaMaximaMotor * vPos;
            }  
        } else { // te clava el coche
            // SE LE APLICA UNA FUERZA DE FRENADO INFINITA
            // CUANDO EL FRENO DE MANO ESTA ACTIVO
            //print("frena");
            Frenar();
            // CON ESTO CONTINUA ANDANDO 
            //wcFrontR.brakeTorque = Mathf.Infinity;
            //wcFrontL.brakeTorque = Mathf.Infinity;
            //wcBackR.brakeTorque = Mathf.Infinity;
            //wcBackL.brakeTorque = Mathf.Infinity;
        }     
    }

    public void Frenar() {
        //print(fuerzaFrenado);
        //print(incrementoFrenado);
        fuerzaFrenado = fuerzaFrenado + incrementoFrenado;
        wcFrontR.brakeTorque = fuerzaFrenado;
        wcFrontL.brakeTorque = fuerzaFrenado;
        wcBackR.brakeTorque = fuerzaFrenado;
        wcBackL.brakeTorque = fuerzaFrenado;
    }

    public void SoltarFreno() {
        wcFrontR.brakeTorque = 0;
        wcFrontL.brakeTorque = 0;
        wcBackR.brakeTorque = 0;
        wcBackL.brakeTorque = 0;
    }
}
