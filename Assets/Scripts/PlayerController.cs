using System.Threading;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private Rigidbody rigidBody;

    public GameObject painelVitoria;
    public TMP_Text count;
    public float speed;
    public float gravity;
    public float rotSpeed;
    public float jumpForce;

    private int checkPoints;

    private static float speedBase = 75;
    private float rot;
    private UnityEngine.Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        checkPoints = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        Move();

        if(checkPoints == 3){
            painelVitoria.SetActive(true);
        }
    }

    void Move(){
        bool isRun = false;
        if(controller.isGrounded){

            if(Input.GetKey(KeyCode.W)){
                moveDirection = UnityEngine.Vector3.forward * speed;


                if(Input.GetKey(KeyCode.LeftShift)){
                    speed = speedBase * 2;
                    animator.SetInteger("transition", 2);
                }else{
                    animator.SetInteger("transition", 1);
                }   

                if(Input.GetKeyUp(KeyCode.LeftShift)){
                    speed = speedBase / 2;
                }

            }

            if(Input.GetKeyUp(KeyCode.W)){
                    moveDirection.y -= gravity * Time.deltaTime;
                    moveDirection = UnityEngine.Vector3.zero;
                    animator.SetInteger("transition", 0);
            }
            
            if(Input.GetKeyUp(KeyCode.LeftShift)){
                speed = speedBase ;
            }

            moveDirection.y -= 2* gravity * Time.deltaTime;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new UnityEngine.Vector3(0, rot, 0);

        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void reachCheckpoint(){

        this.checkPoints++;
        count.text = this.checkPoints+"/3";

    }

}
