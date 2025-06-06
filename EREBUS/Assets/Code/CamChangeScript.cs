using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamChangeScript : MonoBehaviour
{
    public Camera cam;
    public void ChangeLocation()
    {
        cam.transform.position = transform.position;
        cam.transform.rotation = transform.rotation;
    }
}
