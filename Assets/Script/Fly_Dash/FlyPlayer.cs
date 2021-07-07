using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyPlayer : MonoBehaviour
{
    int score;
    public GameObject scoreui;
    public GameObject ui;
    public List<GameObject> objects = new List<GameObject>();
    public List<GameObject> BackGs = new List<GameObject>();

    private float NowSpeed = 0;
    public GameObject B;
    public GameObject BackG;
    private Vector2 CurPos, LastPos;
    private float NowTime;
    public float Speed;
    public float Power;
    private int num;
    // Start is called before the first frame update
    void Start()
    {
        num = 1;
        LastPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        score = (int)transform.position.x * 10;
        scoreui.GetComponent<Text>().text = score.ToString();
        if (transform.position.y <= -2)
        {
            ui.SetActive(true);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().useGravity = false;
        }
        if(objects.Count != 20)
        {
            objects.Add(Instantiate(B, new Vector3(transform.position.x + Random.Range(35, 40) * (objects.Count + 1), 0, transform.position.z), Quaternion.identity));

            BackGs.Add(Instantiate(BackG, new Vector3(transform.position.x+48*(BackGs.Count+1),-0.2f, 35),Quaternion.identity));
        }
        if (num != -1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
                GetComponent<Rigidbody>().AddForce(new Vector3(30, 0, 0), ForceMode.Impulse);
                num--;
            }
            if (Input.GetMouseButtonUp(0))
            {
                num--;
            }
        }
        else if (num == -1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().useGravity = false;
               
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                GetComponent<Rigidbody>().AddForce(new Vector3(5,-5,0),ForceMode.Impulse);
            }
            if (Input.GetMouseButtonUp(0))
            {
                GetComponent<Rigidbody>().useGravity = true;

                Debug.Log("gd");
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Boost"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(new Vector3(35, 0, 0), ForceMode.Impulse);
        }
        if (collision.transform.CompareTag("Jump"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(new Vector3(35, 0, 0), ForceMode.Impulse);

        }
    }
}
