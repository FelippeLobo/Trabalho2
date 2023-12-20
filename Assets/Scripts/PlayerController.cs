using System.Threading;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    public float speed;
    public float gravity;
    public float rotSpeed;

    private static float speedBase = 100;
    private float rot;
    private UnityEngine.Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        bool isRun = false;
        if(controller.isGrounded){

            if(Input.GetKey(KeyCode.W)){
                moveDirection.y -= gravity * Time.deltaTime;
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
          
            moveDirection.y -= gravity * Time.deltaTime;
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new UnityEngine.Vector3(0, rot, 0);

        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * Time.deltaTime);
    }

}
