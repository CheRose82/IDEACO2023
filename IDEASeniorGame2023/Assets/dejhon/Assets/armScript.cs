using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armScript : MonoBehaviour
{
    public GameObject source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void ColliderOn()
    {
        source.GetComponent<Barcode7Script>().ColliderOn();
    }

    public void ColliderOff()
    {
        source.GetComponent<Barcode7Script>().ColliderOff();
    }
}
