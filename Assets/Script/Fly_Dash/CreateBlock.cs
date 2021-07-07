using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public GameObject Obj;
    void Start()
    {
       obj = GameObject.Find("Muscle Cat (1)");
        Instantiate(Obj,new Vector3(Random.Range(-transform.localScale.x/2*8, transform.localScale.x/2*8)+transform.position.x, 0.001f,transform.position.z),Quaternion.identity,this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(obj.transform.position.x > transform.position.x + 50)
        {
            obj.GetComponent<FlyPlayer>().objects.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
      
    }
}
