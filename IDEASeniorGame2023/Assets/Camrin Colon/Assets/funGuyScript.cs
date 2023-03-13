using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funGuyScript : MonoBehaviour
{
    // behavior 0 Walk to chill spot behavior 1.
    // behavior 1 walk to chill spot behavior 2.
    // behavior 2 chase th eplayer
    // Come in contact with you behavior 4.
    // Fight behavior 5. 
    // Make 2 empty gamobjects. Put them in the twp spots. write a code to walk towatrds 1 spot , flip a variable and then walk to antoehr spot.
    public int behavior; //the different parts of its AI
    public GameObject player;
    public float distanceToPlayer;
    public float activationRange;
    Rigidbody rb;
    public float walkSpeed;
    public float turnSpeed;
    public GameObject pos1;
    public GameObject pos2;
    public bool chasingPos1;
    public float waitTimer;
    public float distanceToPos1;
    public float distanceToPos2;
    public GameObject model;
    public Animator anim;
    public float shootTimer;
    public float attackRange;
    public GameObject bullet;
    public GameObject spawnpos;
    public AudioClip gunClip;
    public AudioClip talkingClip;
    public AudioSource badguySource;
    public int shotTicker;

    // Start is called before the first frame update
    void Start()
    {
        shotTicker = 10;
        anim = model.GetComponent<Animator>();
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        waitTimer = 5f;
        badguySource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
     
         
        //messure the distance between this enemy and the player
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        distanceToPos1 = Vector3.Distance(transform.position, pos1.transform.position);
        distanceToPos2 = Vector3.Distance(transform.position, pos2.transform.position);
        //Debug.Log("distanceToPlayer:" + distanceToPlayer);
        //Debug.Log("behavior mode is " + behavior);
        //Debug.Log("distance to pos1 " + distanceToPos1);
        //Debug.Log("distance to pos2 " + distanceToPos2);
        //Debug.Break();
        //gameplay
        if (behavior == 0)
        {
            if (distanceToPlayer < 4)
            //if the distance to the player is less than whatever, go to behavior 2 



            anim.SetBool("isWalking", true);
            badguySource.PlayOneShot(talkingClip, 5);

            // go back and forth between pos1 and pos2
            if (distanceToPos1 > 7)
            {
                //if(distance ) //write the code to go to pos1
                Vector3 targetDir = pos1.transform.position - transform.position;
                float step = turnSpeed * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDir);

                rb.velocity = transform.forward * walkSpeed * Time.deltaTime;


                float distance = Vector3.Distance(pos1.transform.position, this.transform.position);
                //IF DISTANCE TO POSTIION 1 < 1 YO UARE THERE. STOP WALKING FOR A WHILE 

            } else
            {
                anim.SetBool("isWalking", false);
                rb.velocity = Vector3.zero;
                waitTimer -= Time.deltaTime;
                if (waitTimer < 0)
                {
                    behavior = 1;

                    waitTimer = 5f;
                }
            }//next distance to pos 1


            //WHILE WALKING, A TIMER SHOULD COUNT DOWN, AND THEN YOU GO TO POSTIION 2

            //if the funguy is close enough to pos1 stop for a bit and then chase pos
        } else if (behavior == 1)
            if (distanceToPos2 > 6)
            {
                
                anim.SetBool("isWalking", true);
                //write the code to go to pos2
                Vector3 targetDir = pos2.transform.position - transform.position;
                float step = turnSpeed * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDir);

                rb.velocity = transform.forward * walkSpeed * Time.deltaTime;
            }
            else//when the character is close enough and needs to astart waiting
            {
                rb.velocity = Vector3.zero;
                waitTimer -= Time.deltaTime;
                anim.SetBool("isWalking", false);
                if (waitTimer < 0)
                {
                    behavior = 2;
                  
                    waitTimer = 5f;
                }
            }
            

        








        
        else if(behavior == 2)
        {
            //behaviorMode 1 behavior

            //move forward
            anim.SetBool("isWalking", true);
            rb.velocity = transform.forward * walkSpeed * Time.deltaTime;

            //turns towards the player
            Vector3 targetDir = player.transform.position - transform.position;
            float step = turnSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);

            if (distanceToPlayer < 10)
            {
                //stop player from moving rb.velocity....
                rb.velocity = Vector3.zero;
                anim.SetBool("isWalking", false);
                behavior = 3;
                //
                anim.SetBool("isShooting", true);
            }
           
            //if the distance to the player is less than whatever, make walking false, and go to behavior3
        }
        else if (behavior == 3)
        {
            //Shoot, timer shoot, Instantiate
            shootTimer -= Time.deltaTime;
            if (shootTimer < 0)
            {
                Shoot();
                shootTimer = 1f;
                shotTicker -= 1;
                if(shotTicker < 0)
                {
                    shotTicker = 10;
                    behavior = 1;
                    anim.SetBool("isWalking", true);


                }

            }
            if(distanceToPlayer < attackRange)
            {
                behavior = 3;
            }
        }
        else//behavior Mode 3 
        {

        }
    }

    public void Attack()
    {
        Debug.Log("The enemy attacked");


        Invoke("behvaior0", 5f); 
    }

    public void Behavior0()
    {
        behavior = 0;
    }
    public void Shoot()
    {
        Instantiate(bullet, spawnpos.transform.position, transform.rotation);
        badguySource.PlayOneShot(gunClip, 5);
    }
}
