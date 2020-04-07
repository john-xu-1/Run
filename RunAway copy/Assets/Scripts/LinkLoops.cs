using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkLoops : MonoBehaviour
{
    public List<GameObject> Links;
    int nextLink = 0;
    int lastLink = 0;
    public int LinkPathLength = 3;

    float lastTimeActive = float.NegativeInfinity;
    public float LinkWaitTime = 3;


   


    void Update()
    {
        if(Time.fixedTime > lastTimeActive + LinkWaitTime)
        {
            Links[nextLink].SetActive(true);
            nextLink = getIndex(nextLink, 1);

            if (Mathf.Abs((nextLink - lastLink) % Links.Count) > LinkPathLength)
            {
                Links[lastLink].SetActive(false);
                lastLink = getIndex(lastLink,1);
                //Links[lastLink].SetActive(true);
            }
            lastTimeActive = Time.fixedTime;
        }
    }

    private int getIndex(int current, int offset)
    {
        current += offset;
        while (current < 0)
        {
            current += Links.Count;
        }
        current = current % Links.Count;
        return current;
    }
}
