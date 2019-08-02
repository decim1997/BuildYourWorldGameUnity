using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootAtMe : MonoBehaviour
{
    public Transform targetPos;
    public Text txtend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookatMe();
    }

    void lookatMe()
    {
        this.transform.LookAt(targetPos.position);

       if(this.targetPos.transform.position.y - this.transform.position.y <= 2)
        {
            txtend.fontSize = 30;
            txtend.color = Color.white;
           // txtend.transform.position = new Vector3(29.8f,-5.3f,0f);
            txtend.text = "Game Over";
        }
    }
}
