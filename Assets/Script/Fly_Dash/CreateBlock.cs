using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Obj;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(Obj,new Vector3(Random.Range(-transform.localScale.x/2*8, transform.localScale.x/2*8)+transform.position.x, 0.001f,transform.position.z),Quaternion.identity,this.transform);
    }
}
