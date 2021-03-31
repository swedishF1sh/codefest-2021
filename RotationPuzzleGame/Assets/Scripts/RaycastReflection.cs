using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]

public class RaycastReflection : MonoBehaviour
{
    public int reflections;
    public float maxLength;

    [SerializeField]
    GameObject door;

    private LineRenderer lr;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        lr.positionCount = 1;
        lr.SetPosition(0, transform.position);
        float remainingLength = maxLength;

        for(int i = 0; i < reflections; i++)
        {
            if(Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            {
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, hit.point);
                remainingLength -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
               
               if (hit.collider.tag == "Sensor")
                    door.SetActive(false);
                if (hit.collider.tag != "Sensor")
                    door.SetActive(true);
                if (hit.collider.tag != "Mirror")
                {

                    break;

                }
                
            }
        }


        
    }
}
