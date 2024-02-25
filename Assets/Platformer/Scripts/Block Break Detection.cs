using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreakDetection : MonoBehaviour
{
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>().velocity.y > 0f)
        {
            RaycastHit hitInfo;
            
            if(Physics.Raycast(transform.position, Vector3.up, out hitInfo, 1f, layerMask))
            {
                Debug.Log(hitInfo.transform.name);
                hitInfo.transform.GetComponent<BlockImpact>().breakBlock();

                GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0f, GetComponent<Rigidbody>().velocity.z);
            }
        }
    }
}
