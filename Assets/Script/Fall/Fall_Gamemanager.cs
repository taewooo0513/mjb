using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall_Gamemanager : MonoBehaviour
{
    [HideInInspector] public static int score;
    [HideInInspector] public static bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isGameOver = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
