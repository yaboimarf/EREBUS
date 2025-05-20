using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private GameObject focusObs;
    [SerializeField] private Camera playerCamera;

    

    // Update is called once per frame
    void Update()
    {
        if (focusObs != null)
        {
            Ray camray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camray, out RaycastHit hitInfo, 100000f))
            {
                focusObs.transform.position = hitInfo.point;
                focusObs.GetComponent<SphereCollider>().enabled = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out hit))
                {
                    return;
                }
                if (hit.collider.gameObject.CompareTag("Platform") && hit.normal.Equals(new Vector3(0, 1, 0)))
                {
                    hit.collider.gameObject.tag = "Occupied";
                    focusObs.transform.position = new Vector3(hit.collider.gameObject.transform.position.x, focusObs.transform.position.y, hit.collider.gameObject.transform.position.z);
                    focusObs.gameObject.GetComponent<SphereCollider>().enabled = true;
                }
                else
                {
                    Destroy(focusObs);
                }                
                focusObs = null;
            }
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if(!Physics.Raycast(ray, out hit))
        //    {
        //        return;
        //    }
        //    focusObs = Instantiate(tower, hit.point, tower.transform.rotation);
        //    focusObs.GetComponent<SphereCollider>().enabled = false;
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (!Physics.Raycast(ray, out hit))
        //    {
        //        return;
        //    }
        //    focusObs.transform.position = hit.point;
        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (!Physics.Raycast(ray, out hit))
        //    {
        //        return;
        //    }
        //    if (hit.collider.gameObject.CompareTag("Platform") && hit.normal.Equals(new Vector3(0,1,0)))
        //    {
        //        hit.collider.gameObject.tag = "Occupied";
        //        focusObs.transform.position = new Vector3(hit.collider.gameObject.transform.position.x, focusObs.transform.position.y, hit.collider.gameObject.transform.position.z);
        //        focusObs.gameObject.GetComponent<SphereCollider>().enabled = true;
        //    }
        //    else
        //    {
        //        Destroy(focusObs);
        //    }
        //    focusObs = null;
        //}
    }
    public void SetTowerToPlace(GameObject tower)
    {
        focusObs = Instantiate(tower, Vector3.zero, Quaternion.identity);
    }
}
