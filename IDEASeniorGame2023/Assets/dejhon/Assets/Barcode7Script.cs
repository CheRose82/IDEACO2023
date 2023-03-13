     using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barcode7Script : MonoBehaviour
    //behavior 0 Enemy looks and walk around 
    //behavior 1 Enemy walks toward player if in vicinity and stops if within vicinity of the player
    //behavior 2 Enemy charges attack at player
    //behavior 3 resetting after a a charge 
    

{ 
    public float distanceToPlayer; 
    public GameObject player;
    public int behavior;
    //public GameObject player;
    //public float distanceToPlayer;
    public float activationRange;
    public float chargeRange;
    public float attackRange;
    Rigidbody rb;
    public float walkSpeed;
    public float turnSpeed;
    public float resetTimer;
    public GameObject model;
    public Animator anim;
    public int Health;
    public SphereCollider coll;
    public AudioClip punchClip;
    public AudioClip activationClip;
    public AudioSource badguySource;
    
    // Start is called before the first frame update
    void Start()
    {
        badguySource = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        resetTimer = 3f;

        anim = model.GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        //measure the distance between yourself and the player
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);


        //gameplay
        if(behavior == 0)
        {

            //behaviormode 0 walk around from point a to b
            if (distanceToPlayer < activationRange)
            {
                behavior = 1;
                anim.SetBool("isWalking", true);
            }

        }

        else if(behavior == 1)
        {
            
            //rotate towards the player
            Vector3 targetDir = player.transform.position - transform.position;
            float step = turnSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
            //move forward
            rb.velocity = transform.forward * walkSpeed * Time.deltaTime;

            if(distanceToPlayer < chargeRange)
            {
                behavior = 2;
                //call the attack animation trigger
                anim.SetTrigger("attack");

                
            }


        }
        else if (behavior == 2)
         {
            //move forward
            rb.velocity = transform.forward *(walkSpeed * 5) * Time.deltaTime;

            //do the charge attack animation


            //if the player is within the attackRange stop charging range)

            if(distanceToPlayer < attackRange)
            {
                behavior = 3;


            }

             

        }
        else //behavior mode 3
        {
            resetTimer -= Time.deltaTime;
            rb.velocity = transform.forward * ( -walkSpeed * 2) * Time.deltaTime;
            if (resetTimer< 0)
            {
                behavior = 1;

                resetTimer = 3f;
            }
        }

        

    }

    public void Attack()
    {
        Debug.Log("The enemy attacked");
        //animation

        //sound effects

        //spawn the bullets

        Invoke("Behavior0", 5f);



    }



    public void Behavior0()
    {
        behavior = 0;
    }

    public void ColliderOn()
    {
        coll.enabled = true;
        badguySource.PlayOneShot(punchClip, 5);
    }

    public void ColliderOff()
    {
        coll.enabled = false;
    }







}


