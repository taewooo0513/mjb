using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack_BlockSpanwer : MonoBehaviour
{
    [SerializeField] private Stack_MovingBlock blockPrefab;
    [SerializeField] private MoveDirection moveDir;

    public void SpawnBlock()
    {
        var block = Instantiate(blockPrefab);

        if(Stack_MovingBlock.lastBlock != null && Stack_MovingBlock.lastBlock.gameObject != GameObject.Find("StartBlock"))
        {
            float x = moveDir == MoveDirection.X ? transform.position.x : Stack_MovingBlock.lastBlock.transform.position.x;
            float z = moveDir == MoveDirection.Z ? transform.position.z : Stack_MovingBlock.lastBlock.transform.position.z;

            block.transform.position = new Vector3(x,
            Stack_MovingBlock.lastBlock.transform.position.y + blockPrefab.transform.localScale.y,
            z);
        }
        else
        {
            block.transform.position = transform.position;
        }

        block.moveDirection = moveDir;
    }
}