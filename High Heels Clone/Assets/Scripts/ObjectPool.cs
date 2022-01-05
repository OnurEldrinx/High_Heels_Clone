using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public List<GameObject> leftHeelPool;
    public List<GameObject> rightHeelPool;
    public GameObject leftHeelPrefab;
    public GameObject rightHeelPrefab;
    public int howMany;
    void Awake()
    {
        if(Instance == null)
        {

            Instance = this;


        }

        
    }
    void Start()
    {
        leftHeelPool = new List<GameObject>();
        rightHeelPool = new List<GameObject>();

        GameObject l;
        GameObject r;

        for (int i = 0; i < howMany; i++)
        {
            l = Instantiate(leftHeelPrefab);
            r = Instantiate(rightHeelPrefab);

            l.SetActive(false);
            r.SetActive(false);
            leftHeelPool.Add(l);
            rightHeelPool.Add(r);
        }
    }

    public GameObject GetPooledObject(string LR)
    {
        for (int i = 0; i < howMany; i++)
        {

            if (!leftHeelPool[i].activeInHierarchy && LR == "L")
            {
            
                return leftHeelPool[i];
                
            
            }else if (!rightHeelPool[i].activeInHierarchy && LR == "R"){

                return rightHeelPool[i];

            }
        }
        return null;
    }


}
