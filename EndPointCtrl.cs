using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointCtrl : MonoBehaviour
{
    public Collider endPointCol;
    // Start is called before the first frame update
    void Start()
    {
        endPointCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(null == GameObject.FindWithTag("Coin"))
        {
            endPointCol.enabled = true;
        }
        
    }
}
