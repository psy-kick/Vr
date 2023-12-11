using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public Transform Player;
    void Calculator()
    {
        Ray ray = new Ray(Player.position, Player.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1.0f);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            float dist = Vector3.Distance(hit.point, Player.position);
            Debug.Log(dist);
            if (hit.collider.gameObject.tag == "Wall")
            {
                Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green, 1.0f);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Calculator();
    }
}
