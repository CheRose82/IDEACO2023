using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundPieceDecor : MonoBehaviour
{
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;
    public GameObject thisTree;
    
    // Start is called before the first frame update
    void Start()
    {
        int isTree = Random.Range(0, 3);
        if(isTree == 0)
        {
            PickTree();
            SpawnTree();

            //slightly movein all the trees away from the center of their square
            float randomX = Random.Range(0f, 5f);
            float randomY = Random.Range(0f, 5f);
            transform.position += new Vector3(randomX, 0, randomY);
            //this.transform.position += new Vector3(Random.Range(0f, 5f), 0, Random.Range(0f, 5f));

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickTree()
    {
        int whichTree = Random.Range(0, 3);
        if (whichTree == 0)
        {
            thisTree = t1;
        } else if (whichTree == 1)
        {
            thisTree = t2;
        } else if(whichTree == 2)
        {
            thisTree = t3;
        }
        else
        {
            thisTree = t4;
        }
    }

    public void SpawnTree()
    {
        Instantiate(thisTree, transform.position, transform.rotation);
    }
}
