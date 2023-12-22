using System.Threading;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckpoint : MonoBehaviour
{
    [SerializeField] private UnityEngine.Vector3 rotationAngle;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float floatSpeed;
    [SerializeField] private float floatRate;
    [SerializeField] private float floatTimer;
    [SerializeField] private bool goingUp = true;
    void Update()
    {
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
        floatTimer += Time.deltaTime;

        UnityEngine.Vector3 moveDirection = new UnityEngine.Vector3(0.0f, floatSpeed, 0.0f);
        transform.Translate(moveDirection);

        if(goingUp && floatTimer >= floatRate){
            goingUp = false;
            floatTimer = 0;
            floatSpeed = -floatSpeed;

        }else if(!goingUp && floatTimer >= floatRate){
            goingUp = true;
            floatTimer = 0;
            floatSpeed = -floatSpeed;
        }
    }


    void OnTriggerEnter(Collider other){
         UnityEngine.Debug.Log("Entrei");
        if(other.gameObject.name == "Player"){
            UnityEngine.Debug.Log("Entrei");
            other.gameObject.GetComponent<PlayerController>().reachCheckpoint();
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.red);
        }
    }

      void OnTriggerExit(Collider other){
        if(other.gameObject.name == "Player"){
            UnityEngine.Debug.Log("Sai");
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", UnityEngine.Color.blue);
        }
    }
}
