using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : MonoBehaviour
{

    public Transform destination;
    public GameObject environment;
    public GameObject item;
    public Rigidbody rigidbody;
    public float thrust;
    public float range = 5;

    public Collider envCollider, itemCollider;

    public Collider playerCollider;

    public bool isPickedUp;
    private Vector3 oldPos;
    public bool onTrigger = false;


 
    void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        /*
        rigidbody.isKinematic = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        */

        isPickedUp = true;
        
    }




    void OnMouseUp()
    {
        /*
        rigidbody.isKinematic = false;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        */
        
        isPickedUp = false;
        
        
        
     
        
    
        
    }
    
    void Update()
    {
        
        if (isPickedUp == false)
        {
            itemCollider.isTrigger = false;
            //rigidbody.constraints = RigidbodyConstraints.None;
            this.transform.parent = environment.transform;

            GetComponent<Rigidbody>().useGravity = true;

            GetComponent<Rigidbody>().isKinematic = false;


            //this.GetComponent<Rigidbody>().AddForce(-transform.right * thrust);
        }
        else {
            itemCollider.isTrigger = true;
            if (Vector3.Distance(this.transform.position, destination.position) <= range)
            {

                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;
                //rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                Physics.IgnoreCollision(playerCollider, itemCollider);



                this.transform.position = destination.position;
                this.transform.parent = GameObject.Find("Destination").transform;
            }
        }
        if(onTrigger == false)
            oldPos = transform.position;

    }
    void OnTriggerEnter(Collider col )
    {
        onTrigger = true;
        transform.position = oldPos;
        isPickedUp = false;

    }
    void OnTriggerExit(Collider exitCol)
    {
        onTrigger = false;
        
        
    }
}
