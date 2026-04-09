using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class worldHitter : MonoBehaviour
{

    Camera cam;                 // object to pass the camera
    public TMP_Text debugTxt;   // text to debug and pass inot the UI

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Physics.Raycast.html

        RaycastHit hit;
        float rayDistance = 10f;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction * rayDistance);

        float minDist = 1.0f;  // 1 Unity unit is 1 meter

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag != null)           // you can tag the objects with a specific Tag's only those will be 'hittable'
            {
                Debug.Log("hit" + hit.collider.tag);

                if (hit.distance < minDist)         // using the min distance / proximity as a trigger
                {
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    debugTxt.text = "HIT " + hit.collider.name;

                }
                else
                {
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.white;
                    debugTxt.text = "NO HIT..";
                }

            }
            
        }
    }
}
