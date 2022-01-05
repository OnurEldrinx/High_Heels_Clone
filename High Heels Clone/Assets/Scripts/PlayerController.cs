using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private float horizontalInput;
    public float xBound;

    private float colliderOffset = 0.2f;

    private BoxCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {

        playerCollider = GetComponent<BoxCollider>();
        colliderOffset = 0.2f;

    }

    // Update is called once per frame
    void Update()
    {


        Move();
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

            GameObject l = ObjectPool.Instance.GetPooledObject("L");
            

            l.transform.parent = Stack.Instance.leftPrevious;
            l.transform.localPosition = Stack.Instance.leftPrevious.position + (Vector3.forward * Stack.Instance.stackOffset);
            l.transform.rotation = Stack.Instance.leftPrevious.rotation;
            l.SetActive(true);

            Stack.Instance.leftPrevious = l.transform;

            GameObject r = ObjectPool.Instance.GetPooledObject("R");

            r.transform.parent = Stack.Instance.rightPrevious;
            r.transform.localPosition = Stack.Instance.rightPrevious.position + (Vector3.forward * Stack.Instance.stackOffset);
            r.transform.rotation = Stack.Instance.rightPrevious.rotation;
            r.SetActive(true);

            Stack.Instance.rightPrevious= r.transform;

            playerCollider.center = new Vector3(playerCollider.center.x,playerCollider.center.y-colliderOffset);


        }
    }

}
