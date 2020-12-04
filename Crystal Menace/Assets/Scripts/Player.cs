using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public GameObject doorControl;
    public GameObject Door, Elevator, Card, instructions, damage;
    private float shapeScale ;
    public GameObject CanvasReal;
    public GameObject CanvasFake;
    public GameObject LaserSymb;
    public GameObject LaserNormal;

    DoorController DoorUnlock, ElevatorUnlock;
    private bool Mutation = false;
    public Camera ThirdPersonCam;
    public Camera AimCam;
    public GameObject Gun;

    private int _attackTrigger = 0;

    public AudioClip[] dialoguesSymb;
    public AudioSource audSource;
    public GameObject trigger;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject spawn7;
    public GameObject spawn8;
    public GameObject spawn9;
    public GameObject spawn10;
    public GameObject spawn11;
    public GameObject EnemyPawn;

    public float speed = 10f;
    public Rigidbody rb;

    bool doubleTap;
    public bool OnGround;
    public Animator animator;
    Vector2 input;
    public Transform prefab;


    bool change1 = false;
    bool change2 = false;
    bool change3 = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        _attackTrigger = Animator.StringToHash("AttackTrigger");
        CanvasReal.GetComponentInChildren<Text>().enabled = false;
        CanvasReal.GetComponentInChildren<Image>().enabled = false;
        CanvasFake.GetComponentInChildren<GunSystem>().damage = 0;
        LaserSymb.SetActive(false);
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

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
             horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed*30;
             vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed*30;
        }
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

        if (Input.GetKeyDown(KeyCode.V) )
        {
           
            animator.SetTrigger(_attackTrigger);
           
        }






    }
    private IEnumerator OnTriggerStay(Collider other)
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
                GameObject clone1 = GameObject.Instantiate(EnemyPawn, spawn1.transform.position, spawn1.transform.rotation);
                GameObject clone2 = GameObject.Instantiate(EnemyPawn, spawn2.transform.position, spawn2.transform.rotation);
                GameObject clone3 = GameObject.Instantiate(EnemyPawn, spawn3.transform.position, spawn3.transform.rotation);
                GameObject clone4 = GameObject.Instantiate(EnemyPawn, spawn4.transform.position, spawn4.transform.rotation);
                GameObject clone5 = GameObject.Instantiate(EnemyPawn, spawn5.transform.position, spawn5.transform.rotation);
                GameObject clone6 = GameObject.Instantiate(EnemyPawn, spawn6.transform.position, spawn6.transform.rotation);
                GameObject clone7 = GameObject.Instantiate(EnemyPawn, spawn7.transform.position, spawn7.transform.rotation);
                GameObject clone8 = GameObject.Instantiate(EnemyPawn, spawn8.transform.position, spawn8.transform.rotation);
                GameObject clone9 = GameObject.Instantiate(EnemyPawn, spawn9.transform.position, spawn9.transform.rotation);
                GameObject clone10 = GameObject.Instantiate(EnemyPawn, spawn10.transform.position, spawn10.transform.rotation);
            }
        }
        if (other.tag == "Symb")
        {
            instructions.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                instructions.SetActive(false);
                Mutation = true;
                InvokeRepeating("Scale", 0.0f, 0.01f);
                Destroy(Gun);
                CanvasFake.GetComponentInChildren<Text>().enabled = false;
                CanvasFake.GetComponentInChildren<Image>().enabled = false;
                CanvasReal.GetComponentInChildren<Text>().enabled = true;
                CanvasReal.GetComponentInChildren<Image>().enabled = true;
                CanvasFake.GetComponentInChildren<GunSystem>().damage = 0;
                CanvasReal.GetComponentInChildren<GunSystem>().damage = 10;
                LaserSymb.SetActive(true);
                LaserNormal.SetActive(false);

                trigger.SetActive(false);
                //1.Loop through each AudioClip
                for (int i = 0; i < dialoguesSymb.Length; i++)
                {
                    //2.Assign current AudioClip to audiosource
                    audSource.clip = dialoguesSymb[i];

                    //3.Play Audio
                    audSource.Play();

                    //4.Wait for it to finish playing
                    while (audSource.isPlaying)
                    {
                        yield return null;
                    }
                }
                GameObject clone1 = GameObject.Instantiate(EnemyPawn, spawn11.transform.position, spawn11.transform.rotation);
                doorControl.GetComponent<DoorController>().Locked = false;
                doorControl.GetComponentInChildren<Animator>().SetTrigger("OpenClose");

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Card")
        {
            instructions.SetActive(false);
          
        }
        if (other.tag == "Symb")
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


