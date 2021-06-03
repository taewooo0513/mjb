using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Player : MonoBehaviour
{
    [SerializeField][Range(7, 15)]
    private int speed;
    private Transform map;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < map.position.y - 5f)
            Fall_Gamemanager.isGameOver = true;
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            transform.LookAt(collision.transform);
            rb.AddForce(Vector3.back * 15f, ForceMode.VelocityChange);
        }
    }
}
