using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Stack_GameManager : MonoBehaviour
{
    [SerializeField] private Text gameStartText;

    private Stack_BlockSpanwer[] spawners;
    private Stack_BlockSpanwer currentSpawner;
    private int spawnerIndex;

    // Start is called before the first frame update
    private void Awake()
    {
        spawners = FindObjectsOfType<Stack_BlockSpanwer>();

        if (!gameStartText.IsActive())
            gameStartText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (gameStartText.IsActive())
                    gameStartText.enabled = false;

                if (Stack_MovingBlock.currentBlock != null)
                {
                    Stack_MovingBlock.currentBlock.Stop();
                    Stack_Camera.instance.CameraMoveToOnBlock();
                }
                if (Stack_MovingBlock.lastBlock != null)
                {
                    spawnerIndex = spawnerIndex == 0 ? 1 : 0;
                    currentSpawner = spawners[spawnerIndex];

                    currentSpawner.SpawnBlock();
                }
            }
        }
    }
}
