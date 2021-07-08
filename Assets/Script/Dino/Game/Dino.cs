using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    bool JumpOn = true;
    public GameObject Cam;
    public int Power;
    private float sec, nows;
    public GameObject obj;
    public float ClickTime;
    private float NowTime;
    public Vector2 StartPos, NowPos;
    int hp = 3;
    public GameObject EnemyObject;
    bool Slide = false;
    // Start is called before the first frame update
    void Start()
    {
        sec = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Animator>().SetBool("Slide", Slide);

        if (hp == 0)
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
        else
        {
            StartPos = new Vector2(0, 0);
            NowPos = new Vector2(0, 0);
        }
        if (StartPos.y - NowPos.y > 5f)
        {
            Slide = true;
        }
        if (Slide == true)
        {
            nows += Time.deltaTime;
            if (nows > sec)
            {
                Debug.Log("t");
                Slide = false;
                nows = 0;
            }
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
