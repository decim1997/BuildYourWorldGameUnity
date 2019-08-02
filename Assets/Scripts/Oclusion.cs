using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oclusion : MonoBehaviour
{
    Renderer myrender;
    public float displayTime;

    private void OnEnable()
    {
        myrender = gameObject.GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(displayTime > 0)
        {
            displayTime -= Time.deltaTime;
            myrender.enabled = true;
        }
        else
        {
            myrender.enabled = false;
        }
    }


    public void HitOclude(float time)
    {
        displayTime = time;
        myrender.enabled = true;
    }
}
