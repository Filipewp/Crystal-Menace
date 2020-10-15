using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Door, Elevator, Card, instructions, damage;
    private float shapeScale ;
    GunSystem Dam;
    DoorController DoorUnlock, ElevatorUnlock;
    private bool Mutation = false;
    public Camera ThirdPersonCam;
    public Camera AimCam;

    

    public float speed = 10f;
    public Rigidbody rb;

    bool doubleTap;
    public bool OnGround;
    Animator animator;
    Vector2 input;
    public Transform prefab;


    bool change1 = false;
    bool change2 = false;
    bool change3 = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");


        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);
    }
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        ThirdPersonCam.GetComponent<Camera>().enabled = true;
        AimCam.GetComponent<Camera>().enabled = false;

        //if (Input.GetKeyDown(KeyCode.Alpha1) && change1 == true)
        //{
        //    Weapon0.SetActive(false);
        //    Weapon1.SetActive(true);
        //    Weapon2.SetActive(false);
        //    Weapon3.SetActive(false);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha2) && change2 == true)
        //{
        //    Weapon0.SetActive(false);
        //    Weapon1.SetActive(false);
        //    Weapon2.SetActive(true);
        //    Weapon3.SetActive(false);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3) && change3 == true)
        //{
        //    Weapon0.SetActive(false);
        //    Weapon1.SetActive(false);
        //    Weapon2.SetActive(false);
        //    Weapon3.SetActive(true);
        //}


        transform.Translate(horizontal, 0, vertical);
        if (Input.GetMouseButton(1) && (Mutation == false))
        {
            animator.Play("AimLocomotion");
            ThirdPersonCam.GetComponent<Camera>().enabled = false;
            AimCam.GetComponent<Camera>().enabled = true;
        }
        else if(Mutation == false)
        {
            animator.Play("Locomotion");
        }
        if (Input.GetMouseButton(1) && (Mutation == true))
        {
            animator.Play("SymbAimLocomotion");
            ThirdPersonCam.GetComponent<Camera>().enabled = false;
            AimCam.GetComponent<Camera>().enabled = true;
        }
        else if (Mutation == true)
        {
            animator.Play("SymbLocomotion");
        }
        if (Input.GetButtonDown("Jump"))
        {

            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            OnGround = false;
        }





    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Card")
        {
            instructions.SetActive(true);
            DoorUnlock = Door.GetComponent<DoorController>();
            ElevatorUnlock = Elevator.GetComponent<DoorController>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorUnlock.Locked = false;
                ElevatorUnlock.Locked = false;
                Destroy(Card);
            }
        }
        if (other.tag == "Symb")
        {
            Dam = damage.GetComponent<GunSystem>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                Mutation = true;
                InvokeRepeating("Scale", 0.0f, 0.01f);
               
                Dam.damage = 10;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Card")
        {
            instructions.SetActive(false);
        }
    }
    void Scale()
    {
        if (shapeScale >= 100.0f)
        {
            //CancelInvoke("Scale");
            shapeScale = 100;
        }
        GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(0, shapeScale++);
        GetComponentInChildren<SkinnedMeshRenderer>().SetBlendShapeWeight(1, shapeScale++);
    }
}


