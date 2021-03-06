﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSystem : MonoBehaviour
{
       //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    public AudioStory audioBool;
    public AudioSource audioFire;
    public AudioSource audioFireSymb;
    public AudioSource reload;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public GameObject GunBarrel;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    //public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    Text ammoText;
    public GameObject barrel;

    public bool symb = false;

    // //Graphics
    // public GameObject muzzleFlash, bulletHoleGraphic;


    //public TextMeshProUGUI text;

    void Start()
    {
       
    }

    private void Awake()
    {
        
        bulletsLeft = magazineSize;
        readyToShoot = true;
        ammoText = GetComponent<Text>();
       
    }
    private void Update()
    {
        MyInput();

        ammoText.text = bulletsLeft.ToString();
        //SetText
        //text.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
            else shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }


        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }
        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        if (symb == false)
        {
            audioFire.Play();
        }
        if (symb == true)
        {
            audioFireSymb.Play();
        }
        //Rigidbody clone;
        //clone = Instantiate(projectile, transform.position, transform.rotation);

        muzzleFlash.Play();
       
        // Give the cloned object an initial velocity along the current
        // object's Z axis
        //clone.velocity = transform.TransformDirection(Vector3.forward * range);
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = GunBarrel.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(GunBarrel.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            GameObject Audio = GameObject.FindGameObjectWithTag("Player");
            audioBool = Audio.GetComponent<AudioStory>();
            Target target = rayHit.transform.GetComponent<Target>();
           
            if (target != null)
            {
                audioBool.shootHit = true;
                target.TakeDamage(damage);
               
            }
            
            OnShoot part = rayHit.transform.GetComponent<OnShoot>();
            if (part != null)
            {
                
                part.Vanish(damage);
                audioBool.shootHit = true;
            }
            OnShootChest chestPart = rayHit.transform.GetComponent<OnShootChest>();
            if (chestPart != null)
            {

                chestPart.Vanish(damage);
                audioBool.shootHit = true;
            }
            OnShootHip hipPart = rayHit.transform.GetComponent<OnShootHip>();
            if (hipPart != null)
            {

                hipPart.Vanish(damage);
                audioBool.shootHit = true;
            }
            OnShootLeftArm leftArmPart = rayHit.transform.GetComponent<OnShootLeftArm>();
            if (leftArmPart != null)
            {

                leftArmPart.Vanish(damage);
                audioBool.shootHit = true;
            }
            OnShootRightArm rightArmPart = rayHit.transform.GetComponent<OnShootRightArm>();
            if (rightArmPart != null)
            {

                rightArmPart.Vanish(damage);
                audioBool.shootHit = true;
            }
            OnShootLeftLeg leftLegPart = rayHit.transform.GetComponent<OnShootLeftLeg>();
            if (leftLegPart != null)
            {

                leftLegPart.Vanish(damage);
                audioBool.shootHit = true;
            }
            OnShootRightLeg rightLegPart = rayHit.transform.GetComponent<OnShootRightLeg>();
            if (rightLegPart != null)
            {

                rightLegPart.Vanish(damage);
                audioBool.shootHit = true;
            }
            //if (rayHit.collider.CompareTag("Enemy"))
            //    rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
            GameObject impactGO = Instantiate(impactEffect, rayHit.point, Quaternion.LookRotation(rayHit.normal));
            Destroy(impactGO, 2f);
           

        }

        //ShakeCamera
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reload.Play();
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}

