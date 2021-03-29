using UnityEngine;

public class HueShift : MonoBehaviour
{
    public float Speed = 1;
    public Material material;

    void Start()
    {
       
    }

    void Update()
    {
        material.SetColor("_Color", Color.red);
        material.SetColor("_Color", Color.blue);
        //material.SetColor("_Color", Color.orange);
        material.SetColor("_Color", Color.green);
        material.SetColor("_Color", Color.yellow);
    }
}