using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instance;
    public float Score;
    public double Speed = 4;
    public float PlusSpeed;
    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        Score +=6;
        if (Speed < 70)
        Speed += PlusSpeed;
    }
}
