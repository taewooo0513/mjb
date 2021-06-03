using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public float Timer;
    private float NowTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NowTime += Time.deltaTime;
        if(NowTime > Timer - ManagerGame.instance.Speed/50)
        {
            Instantiate(Enemy, transform);
            NowTime = 0;
        }
    }
}
