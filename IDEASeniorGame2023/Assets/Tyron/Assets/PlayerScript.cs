using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptTyron2 : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MetalchickHand"))
        {
            health--;
            Debug.Log("Got Hit");
        }

    }
    



    
}

