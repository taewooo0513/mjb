using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_GameManager : MonoBehaviour
{
    private Stack_BlockSpanwer[] spawners;
    private Stack_BlockSpanwer currentSpawner;
    private int spawnerIndex;

    // Start is called before the first frame update
    private void Awake()
    {
        spawners = FindObjectsOfType<Stack_BlockSpanwer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (Stack_MovingBlock.currentBlock != null)
            {
                Stack_MovingBlock.currentBlock.Stop();
            }

            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];

            currentSpawner.SpawnBlock();
        }
    }
}
