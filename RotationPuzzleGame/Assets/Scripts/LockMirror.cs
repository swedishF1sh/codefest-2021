using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockMirror : MonoBehaviour
{
   
    public Transform player;
    public Transform camera;
    private bool locked = false;
    public Text LockSign;
    public Text UnlockSign;

    public GameObject textUI;

    private RaycastHit hitItem;

    private RaycastHit hit, hit2;
    private int numUnlockSigns, numLockSigns;
    public Canvas canvas;

    float xVelocity, yVelocity, zVelocity;

    float timer = 0;


    public GameObject[] mirrors;
    public void Lock(Rigidbody item)
    {
        item.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        item.isKinematic = true;
       
        locked = true;
    }


    public void Unlock(Rigidbody item)
    {
        item.collisionDetectionMode = CollisionDetectionMode.Continuous;
        
        item.isKinematic = false;
        item.WakeUp();

        locked = false;
    }

    void Start()
    {
        mirrors = GameObject.FindGameObjectsWithTag("Mirror");
        
    }


    // Update is called once per frame
    void Update()
    {

        
        
        if (Physics.Raycast(player.transform.position, camera.transform.forward, out hit, 3))
        {
            if (hit.collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                xVelocity = hit.collider.gameObject.GetComponent<Rigidbody>().velocity.x;
                yVelocity = hit.collider.gameObject.GetComponent<Rigidbody>().velocity.y;
                zVelocity = hit.collider.gameObject.GetComponent<Rigidbody>().velocity.z;
            }

            if (hit.collider.tag == "Mirror" && Mathf.Abs(xVelocity) < 0.5 && Mathf.Abs(yVelocity) < 0.5 && Mathf.Abs(zVelocity) < 0.5 && hit.collider.gameObject.GetComponent<PickUp>().isPickedUp == false)
            {

                if (locked == false)
                {
                    hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    textUI.GetComponent<UnityEngine.UI.Text>().text = "LOCK MIRROR";
                }

                else
                {
                    hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    textUI.GetComponent<UnityEngine.UI.Text>().text = "UNLOCK MIRROR";
                }


            } 
            

            for (int i = 0; i < mirrors.Length; i++)
            {

                    
                if (mirrors[i] != hit.transform.gameObject)
                {
                    mirrors[i].transform.GetChild(0).gameObject.SetActive(false);
                }

                   



            }

               


            if (hit.collider.tag == "Mirror" && Mathf.Abs(xVelocity) < 0.5 && Mathf.Abs(yVelocity) < 0.5 && Mathf.Abs(zVelocity) < 0.5)
            {


                if (timer <= .2)
                    timer += Time.deltaTime;


                if (Input.GetKey(KeyCode.F) && timer >= .2)
                {
                    timer = 0;
                    if (locked == false)
                        Lock(hit.collider.gameObject.GetComponent<Rigidbody>());
                    else
                        Unlock(hit.collider.gameObject.GetComponent<Rigidbody>());
                }
            }
            if (Physics.Raycast(player.transform.position, camera.transform.forward, out hit, 3))
            {
                if (hit.collider.gameObject.GetComponent<PickUp>() != null)
                {
                    if (hit.collider.gameObject.GetComponent<PickUp>().isPickedUp == true)
                        Unlock(hit.collider.gameObject.GetComponent<Rigidbody>());
                }
            }
        }
        else
        {
            for (int i = 0; i < mirrors.Length; i++)
            {


                
                    mirrors[i].transform.GetChild(0).gameObject.SetActive(false);
                

            }
        } 
        
       
    }
}
