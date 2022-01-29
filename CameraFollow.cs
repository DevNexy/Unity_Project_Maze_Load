using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Transform camTransform;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = GetComponent<Transform>();
    }
    void LateUpdate()
    {
        camTransform.position = new Vector3(target.position.x, target.position.y, target.position.z);

        camTransform.LookAt(target);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
