using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundSpawnerScript : MonoBehaviour
{
    public float distanceForward;
    public int numPieces;
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while(numPieces > 0)
        {
            ChooseDirection();
            //Debug.Break();
            StepForward();
            //Debug.Break();
            MakeGroundPiece();

            numPieces--;
        }
    }

    public void ChooseDirection()
    {
        int spawnerDir = Random.Range(0, 3);
        //if spawnerDir is 0 turn left, 1 go straight, 2 turn right
        if(spawnerDir == 0)
        {
            transform.Rotate(0, -90, 0);
        }else if(spawnerDir == 1)
        {
            //do nothing
        } else if(spawnerDir == 2)
        {
            transform.Rotate(0, 90, 0);
        }
        
    }

    public void StepForward()
    {
        transform.localPosition += transform.forward * 10;
    }

    public void MakeGroundPiece()
    {
        Instantiate(ground, transform.position, transform.rotation);
    }
}

