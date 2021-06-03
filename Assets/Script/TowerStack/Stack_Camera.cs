using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraMoveToOnBlock()
    {
        Vector3.Lerp(transform.position,
            new Vector3(transform.position.x, transform.position.y + Stack_MovingBlock.lastBlock.transform.localScale.y, transform.position.z),
            Time.deltaTime);
    }
}
