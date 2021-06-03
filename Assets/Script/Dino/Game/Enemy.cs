﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,-(float)ManagerGame.instance.Speed * Time.deltaTime));
    }
    private void OnBecameInvisible()
    {
        Debug.Log("나감");
        Destroy(gameObject);
    }
}
