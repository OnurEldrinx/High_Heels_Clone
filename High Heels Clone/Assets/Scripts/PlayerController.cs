using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private float horizontalInput;
    public float xBound;

    public float colliderOffset;

    public BoxCollider playerCollider;

    public bool isOnPipeObstacle;

    public int collisionCounter = 0;
    

    


    // Start is called before the first frame update
    void Start()
    {

        playerCollider = GetComponent<BoxCollider>();
        colliderOffset = 0.235f;
        

    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.isGameEnded == false && !GameManager.Instance.isFailed)
        {

            Move();

        }

        if (GameManager.isGameEnded || GameManager.Instance.isFailed)
        {

            GetComponent<Animator>().enabled = false;

        }
        
            
        
        if(!isOnPipeObstacle)
            ResetPosition();

    }

    private void Move()
    {

        MoveForward();

        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

    }

    private void ResetPosition()
    {

        if(transform.position.x <= -xBound)
        {

            transform.position = new Vector3(-xBound,transform.position.y,transform.position.z);

        }else if (transform.position.x >= xBound)
        {

            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);

        }

    }

    private void MoveForward()
    {

        transform.Translate(Vector3.forward * (speed / 4) * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shoes")
        {


            other.gameObject.SetActive(false);

            Stack.Instance.leftHeelsOnPlayer[Stack.Instance.lastActiveIndex + 1].gameObject.SetActive(true);
            Stack.Instance.rightHeelsOnPlayer[Stack.Instance.lastActiveIndex + 1].gameObject.SetActive(true);

            Stack.Instance.lastActiveIndex++;

            playerCollider.center = new Vector3(playerCollider.center.x,playerCollider.center.y-colliderOffset);


        }
        else if (other.tag == "Diamond")
        {

            other.gameObject.SetActive(false);
            GameManager.Instance.diamondScore++;

        }
        else if(other.tag == "B_Enter")
        {

            isOnPipeObstacle = true;
            GetComponent<BoxCollider>().isTrigger = true;
            GetComponent<Animator>().Play("Spagat");
            

        }
        else if (other.tag == "FinishLine")
        {

            GameManager.Instance.isLevelFinished = true;

        }
        else if (other.tag == "2" && !GameManager.isGameEnded && !GameManager.Instance.isFailed)
        {
            collisionCounter++;

            Debug.Log(2);

            if (collisionCounter == 1)
            {
                GameManager.Instance.diamondScore *= int.Parse(other.tag);
            }
        }
        else if (other.tag == "3" && !GameManager.isGameEnded && !GameManager.Instance.isFailed)
        {

            collisionCounter++;

            Debug.Log(3);

            if (collisionCounter == 2)
            {
                GameManager.Instance.diamondScore *= int.Parse(other.tag);
            }
        }
        else if (other.tag == "4" && !GameManager.isGameEnded && !GameManager.Instance.isFailed)
        {

            collisionCounter++;

            Debug.Log(4);

            if (collisionCounter == 3)
            {
                GameManager.Instance.diamondScore *= int.Parse(other.tag);
            }

        }
        else if (other.tag == "5" && !GameManager.isGameEnded && !GameManager.Instance.isFailed)
        {

            collisionCounter++;

            Debug.Log(5);

            if (collisionCounter == 4)
            {
                GameManager.Instance.diamondScore *= int.Parse(other.tag);
            }

        }
        else if (other.tag == "6" && !GameManager.isGameEnded && !GameManager.Instance.isFailed)
        {

            collisionCounter++;

            Debug.Log(6);

            if (collisionCounter == 5)
            {
                GameManager.Instance.diamondScore *= int.Parse(other.tag);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "B_Exit")
        {
            isOnPipeObstacle = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Animator>().Play("Catwalk");
        }


    }

    

    

}
