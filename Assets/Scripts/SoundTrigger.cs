using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    private bool flag = true;
    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Player"){
            if(flag){
                audioSource.Play();
                flag = false;
            }
            
        }
    }
}
