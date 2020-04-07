using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContr : MonoBehaviour
{
    public Transform player;
    public float maxRange = 10f;

    public float AppliedPressure = 10f;
    public float ReducePressureSeen = 2.5f;
    public float ReducePressureHiden = 5f;

    public float ReduceCloseApproachHidden = 5f;
    float closeApproach = float.MaxValue;
    public float ReduceCloseApproachSeen = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }


    void Update()
    {
        RaycastHit hit;
        float pressure = 0;

        if (Physics.Raycast(transform.position, player.position - transform.position, out hit, maxRange))
        {
            if (hit.transform.CompareTag("Player"))
            {
                
                closeApproach = Mathf.Min(hit.distance, closeApproach);
                if(hit.distance > closeApproach)
                {
                    pressure = -ReducePressureSeen * Time.deltaTime;
                    closeApproach += ReduceCloseApproachSeen * Time.deltaTime;


                }
                else
                {
                    pressure = AppliedPressure * Time.deltaTime;

                }

            }
            else
            {
                pressure = -ReducePressureHiden * Time.deltaTime;
                closeApproach += ReduceCloseApproachHidden * Time.deltaTime;

            }
        }
        else
        {
            pressure = -ReducePressureHiden * Time.deltaTime;
            closeApproach += ReduceCloseApproachHidden * Time.deltaTime;

        }

        player.GetComponent<PlayerScript>().AddPressure(hit.distance, pressure);
    }
}
