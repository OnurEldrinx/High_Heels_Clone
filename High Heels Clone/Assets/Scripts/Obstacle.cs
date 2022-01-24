using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public static int collisionIndex;
    public static List<int> colIndexes;
    private int howMany;

    private PlayerController p;

    // Start is called before the first frame update
    void Start()
    {

        p = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        

        if(other.tag == "Heel")
        {

            colIndexes = new List<int>();

            GetComponent<BoxCollider>().isTrigger = false;

            if (Stack.Instance.leftHeelsOnPlayer.Contains(other.transform))
            {

                collisionIndex = Stack.Instance.leftHeelsOnPlayer.IndexOf(other.transform);
            }
            else
            {

                collisionIndex = Stack.Instance.rightHeelsOnPlayer.IndexOf(other.transform);

            }


            colIndexes.Add(collisionIndex);

            

            for (int i= 0; i < colIndexes.Count; i++)
            {
                if (colIndexes[i]< 0)
                {

                    colIndexes.RemoveAt(i);

                }

            }


            colIndexes.Sort();
            colIndexes.Reverse();
            

            for (int i=0;i<colIndexes.Count;i++)
            {

                Debug.Log(colIndexes[i] + " ");

            }

            if (collisionIndex >= 0)
            {
                // Cutting the Heels
                //----------------------------------------------------------------------------------------------------
                GameObject leftDrop = Instantiate(Stack.Instance.leftHeelsOnPlayer[collisionIndex].gameObject, null);
                leftDrop.transform.position = Stack.Instance.leftHeelsOnPlayer[collisionIndex].position;
                leftDrop.transform.rotation = Stack.Instance.leftHeelsOnPlayer[collisionIndex].rotation;
                leftDrop.transform.localScale = Stack.Instance.leftHeelsOnPlayer[collisionIndex].lossyScale;

                GameObject rightDrop = Instantiate(Stack.Instance.rightHeelsOnPlayer[collisionIndex].gameObject, null);
                rightDrop.transform.position = Stack.Instance.rightHeelsOnPlayer[collisionIndex].position;
                rightDrop.transform.rotation = Stack.Instance.rightHeelsOnPlayer[collisionIndex].rotation;
                rightDrop.transform.localScale = Stack.Instance.rightHeelsOnPlayer[collisionIndex].lossyScale;

                //----------------------------------------------------------------------------------------------------


                



                Stack.Instance.leftHeelsOnPlayer[colIndexes[0]].gameObject.SetActive(false);
                Stack.Instance.rightHeelsOnPlayer[colIndexes[0]].gameObject.SetActive(false);



                howMany = Stack.Instance.lastActiveIndex - colIndexes[0] + 1;

                p.playerCollider.center = new Vector3(p.playerCollider.center.x, p.playerCollider.center.y + (howMany * p.colliderOffset));


                Stack.Instance.lastActiveIndex = colIndexes[0] - 1;

            }


        }else if(other.tag == "Head")
        {

            GameManager.Instance.isFailed = true;

        }

    }

}
