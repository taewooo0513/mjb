using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    bool JumpOn = true;
    public GameObject Cam;
    public int Power;
    public GameObject obj;
    public float ClickTime;
    private float NowTime;
    public Vector2 StartPos, NowPos;
    int hp = 3;
    public GameObject EnemyObject;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(hp == 0)
        {
            obj.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            StartPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            NowPos = Input.mousePosition;
        }
        if (StartPos.y - NowPos.y > 5f)
        {
            Debug.Log("정태영");
        }
        else
        {
            if (JumpOn)
            {
                if (Input.GetMouseButton(0))
                {
                    if (JumpOn)
                    {
                        if (ClickTime < NowTime)
                        {
                            if (gameObject.TryGetComponent(out Rigidbody rigidbody))
                            {
                                transform.GetComponent<Animator>().SetBool("Jump", JumpOn);
                                rigidbody.AddForce(new Vector3(0, Power, 0));
                                JumpOn = false;
                                NowTime = 0;
                            }
                        }
                    }
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    if (JumpOn)
                    {
                        if (gameObject.TryGetComponent(out Rigidbody rigidbody))
                        {
                            JumpOn = false;
                            transform.GetComponent<Animator>().SetBool("Jump", JumpOn);

                            rigidbody.AddForce(new Vector3(0, Power, 0));
                            NowTime = 0;
                        }
                    }
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            JumpOn = true;
            transform.GetComponent<Animator>().SetBool("Jump", JumpOn);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            hp--;
            Debug.Log("gd");
        }
    }
}
