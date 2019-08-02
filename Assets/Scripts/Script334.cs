using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script334 : MonoBehaviour
{
    public int rayonAmount;
    public int rayDistance;
    public float stayTime;

    public Camera cam;
    public Vector2[] rpoints;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        rpoints = new Vector2[rayonAmount];
        GetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        CastRay();
    }

    void GetPoint()
    {
        float x = 0;
        float y = 0;
        for (int i = 0; i < rayonAmount; i++)
        {
            if (x > 1)
            {
                x = 0;
                y += 1 / Mathf.Sqrt(rayonAmount);
            }

            rpoints[i] = new Vector2(x,y);
            x += 1 / Mathf.Sqrt(rayonAmount);
        }

        
    }


    void CastRay()
    {
        for (int i = 0; i < rayonAmount; i++)
        {
            Ray ray;
            RaycastHit hit;
            Oclusion oc1;
            ray = cam.ViewportPointToRay(new Vector3(rpoints[i].x,rpoints[i].y,0));

            if(Physics.Raycast(ray,out hit, rayDistance))
            {
                if(oc1 = hit.transform.GetComponent<Oclusion>())
                {
                    oc1.HitOclude(stayTime);
                }
            }
        }
    }
}
