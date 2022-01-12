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

    private GameObject pool;

    void Awake()
    {
        if(Instance == null)
        {

            Instance = this;


        }

        
    }
    void Start()
    {

        pool = GameObject.Find("Pool");

        leftHeelPool = new List<GameObject>();
        rightHeelPool = new List<GameObject>();

        Stack.Instance.rightHeelsOnPlayer = new List<Transform>();
        Stack.Instance.leftHeelsOnPlayer = new List<Transform>();


        GameObject l;
        GameObject r;

        for (int i = 0; i < howMany; i++)
        {
            l = Instantiate(leftHeelPrefab);
            r = Instantiate(rightHeelPrefab);

            l.transform.parent = Stack.Instance.leftPrevious.transform;
            l.transform.localScale = new Vector3(1, 1, 1);
            l.transform.rotation = Stack.Instance.leftPrevious.rotation;
            l.transform.localPosition = new Vector3(Stack.Instance.leftPrevious.position.x, Stack.Instance.leftPrevious.position.y, Stack.Instance.leftPrevious.position.z + Stack.Instance.stackOffset);
            l.SetActive(false);

            Stack.Instance.leftHeelsOnPlayer.Add(l.transform);

            r.transform.parent = Stack.Instance.rightPrevious.transform;
            r.transform.localScale = new Vector3(1, 1, 1);
            r.transform.rotation = Stack.Instance.rightPrevious.rotation;
            r.transform.localPosition = new Vector3(Stack.Instance.rightPrevious.position.x, Stack.Instance.rightPrevious.position.y, Stack.Instance.rightPrevious.position.z + Stack.Instance.stackOffset);
            r.SetActive(false);

            Stack.Instance.rightHeelsOnPlayer.Add(r.transform);

            Stack.Instance.leftPrevious = l.transform;
            Stack.Instance.rightPrevious = r.transform;

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
