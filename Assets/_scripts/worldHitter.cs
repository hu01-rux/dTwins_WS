using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class worldHitter : MonoBehaviour
{

    Camera cam;
    public TMP_Text debugTxt;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        float rayDistance = 10f;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        //Debug.DrawRay(ray.origin, ray.direction * rayDistance);


        float minDist = 1.0f;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag != null)
            {
                Debug.Log("hit" + hit.collider.tag);

                if (hit.distance < minDist)
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
