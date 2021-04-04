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

    public bool isPickedUp;
    


   


    void OnMouseDown()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        /*
        rigidbody.isKinematic = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        */

        isPickedUp = true;
        if(Vector3.Distance(this.transform.position, destination.position) <= range) {

            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            //rigidbody.constraints = RigidbodyConstraints.FreezeAll;




            this.transform.position = destination.position;
            this.transform.parent = GameObject.Find("Destination").transform;
        }
    }




    void OnMouseUp()
    {
        /*
        rigidbody.isKinematic = false;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        */
        
        isPickedUp = false;

        
        //envCollider = environment.GetComponent<Collider>();
        //itemCollider = item.GetComponent<Collider>();
        //Vector3 closestPoint = envCollider.ClosestPointOnBounds(destination.position);
        //float distance = Vector3.Distance(closestPoint, destination.position);
        
        //rigidbody.constraints = RigidbodyConstraints.None;
        this.transform.parent = environment.transform;

        GetComponent<Rigidbody>().useGravity = true;

        GetComponent<Rigidbody>().isKinematic = false;


        this.GetComponent<Rigidbody>().AddForce(-transform.right * thrust);
        
    }
    

    
}
