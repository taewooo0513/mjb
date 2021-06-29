using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_Camera : MonoBehaviour
{
    [HideInInspector] public static Stack_Camera instance;
    [SerializeField] private float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraMoveToOnBlock()
    {
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(transform.position.x, transform.position.y + Stack_MovingBlock.lastBlock.transform.localScale.y, transform.position.z),
            speed);
    }
}
