using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravGun : MonoBehaviour
{
    Transform CaptureItem;
    public Camera cam;
    public bool isActive = true;
    public float MaxRange = 100;

    Vector3 hitOffset;

    public Rigidbody PickableBody;

    public float gunPower; 

    private float itemDist;


    public float GGDamp = 0.5f;


    public LayerMask mask;
    void Start()
    {

    }

    
    void FixedUpdate()
    {
        if (isActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, MaxRange, mask))
                {
                    if (hit.transform.CompareTag("Pickable"))
                    {
                        CaptureItem = hit.transform;
                        hitOffset = hit.point - CaptureItem.transform.position;
                        itemDist = hit.distance;

                        
                    }
                    else
                    {
                        CaptureItem = null;
                        Debug.Log(hit.transform.name);
                    }
                }
            }
            if (Input.GetMouseButton(0) && CaptureItem)
            {

                Vector3 destination = cam.transform.position + cam.transform.forward.normalized * itemDist - hitOffset;

                float t = Time.deltaTime;
                float m = PickableBody.mass;
                float dx = destination.x - CaptureItem.position.x;
                float dy = destination.y - CaptureItem.position.y;
                float dz = destination.z - CaptureItem.position.z;
                float vx = PickableBody.velocity.x;
                float vy = PickableBody.velocity.y;
                float vz = PickableBody.velocity.z;
                float Fx = calcForce(t, m, vx, dx);
                float Fy = calcForce(t, m, vy, dy);
                float Fz = calcForce(t, m, vz, dz);

                Fx *= GGDamp;
                Fy *= GGDamp;
                Fz *= GGDamp;

                /*
                if (Fx > gunPower) Fx = gunPower;
                if (Fx < -gunPower) Fx = -gunPower;
                if (Fy > gunPower) Fy = gunPower + 9.81f * m;
                if (Fy < -gunPower) Fy = -gunPower;
                if (Fz > gunPower) Fz = gunPower;
                if (Fz < -gunPower) Fz = -gunPower;

                */

                Vector3 Force = new Vector3(Fx, Fy, Fz);
                //Force = Force.normalized;

                //Force *= gunPower;
                
                CaptureItem.GetComponent<Rigidbody>().AddForce(Force);


                Debug.Log(Force);

            }
        }
    }
    private static float calcForce(float t, float mass, float v, float dp) 
    {
        return mass * 2 * (dp - v * t) / (t*t);
    }
}
