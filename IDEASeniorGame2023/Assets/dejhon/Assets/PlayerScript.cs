using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        Health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knuckles"))
        {

            Health--;
            Debug.Log("Ouch");
        }


    }

}
