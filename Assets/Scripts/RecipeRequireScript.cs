using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeRequireScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {

        if(gameObject.name.Equals("PicAxePlan"))
        {
            BlockScript.havepickaxesplan = "y";
        }

        if(gameObject.name.Equals("ShowelPlan"))
        {
            BlockScript.haveShowePlan = "y";

        }

        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
