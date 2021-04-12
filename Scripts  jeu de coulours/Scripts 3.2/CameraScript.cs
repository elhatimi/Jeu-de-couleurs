using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
 float Yrot;

 RaycastHit hitPickup;

 GameObject grabbedObj;

 public Transform grabbedObjLocation;



 void Update()

    {

        Yrot -= Input.GetAxis("Mouse Y");

        Yrot = Mathf.Clamp(Yrot, -60, 60);

        transform.localRotation = Quaternion.Euler(Yrot, 0f, 0f);

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);



        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hitPickup) &&     hitPickup.transform.GetComponent<Rigidbody>())

        {

            grabbedObj = hitPickup.transform.gameObject;

        }

        else if(Input.GetMouseButtonUp(0))

        {

            grabbedObj = null;

        }



        if(grabbedObj)

        {

            grabbedObj.GetComponent<Rigidbody>().velocity = 10* ( grabbedObjLocation.position - grabbedObj.transform.position);

        }

    }
}