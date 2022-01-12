using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{

    public static Stack Instance;

    public Transform leftParent;
    public Transform rightParent;
    public Transform leftPrevious;
    public Transform rightPrevious;

    public int stackOffset;

    public List<Transform> leftHeelsOnPlayer;
    public List<Transform> rightHeelsOnPlayer;

    public int lastActiveIndex;




    private void Awake()
    {

        if(Instance == null)
        {

            Instance = this;

        }


    }


    // Start is called before the first frame update
    void Start()
    {

        lastActiveIndex = -1;



    }

    // Update is called once per frame
    void Update()
    {



    }

    

}
