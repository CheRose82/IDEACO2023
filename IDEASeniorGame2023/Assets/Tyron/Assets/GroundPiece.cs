
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPiece : MonoBehaviour
{
    public GameObject Ground;
    public GameObject Desk;
    public  float length;
    public Vector3 posLeft;
    public Vector3 posRight;
    public GameObject[] objs;
    public float size;
    public float sizeBarrier;
    // Start is called before the first frame update
    void Start()
    {
        size = Random.Range(5f, 12f);
        transform.localScale = new Vector3(size, 1, size);
        length = transform.localScale.x;
         //posLeft = new Vector3(-length / 2, 0, 0);
         //posRight = new Vector3(length / 2, 0, 0);

        //var newDesk = Instantiate

       SpawnLeftPiece();
       SpwanRightPiece();
    }

    // Update is called once per frame
    void Update()
    {
        size = 2;
    }

    public void SpawnLeftPiece()
    {
        if(size < sizeBarrier)
        {
        posLeft = new Vector3((-length / 2) + .5f, 1, 0);
        Instantiate(objs[0], transform.position + posLeft, transform.rotation);
        }
        else
        {
            //spawn left piece number one
            
            posLeft = new Vector3((-length / 2) + .5f, 1, 3.7f);
            Instantiate(Ground, transform.position + posLeft, transform.rotation);



            //spawn left piece number 2
            Instantiate(Ground, transform.position + posLeft, transform.rotation);
            posLeft = new Vector3((-length / 2) + .5f, 1, 0);
        }




    }
    public void SpwanRightPiece()
    {
        if (size < sizeBarrier)//regular size pieces
        {
            posRight = new Vector3((length / 2) - .5f, 4, 0);
            Instantiate(objs[0], transform.position + posRight, transform.rotation);
        }
        else
        {
            // spawn Right piece one
            
            posRight = new Vector3((length / 2) - .5f, 1, 0);
            Instantiate(Desk, transform.position + posRight, transform.rotation);




            // spawn Right piece 2
            Instantiate(Desk, transform.position + posRight, transform.rotation);
            posRight = new Vector3((length / 2) - .5f, 1, 0);
        }

    }



}


