using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stack_MovingBlock : MonoBehaviour
{
    public static Stack_MovingBlock currentBlock { get; private set; }
    public static Stack_MovingBlock lastBlock { get; private set; }
    public MoveDirection moveDirection { get; set; }
    public float lastSpeed;

    [SerializeField] private float speed = 1f;

    private void OnEnable()
    {
        if (lastBlock == null)
            lastBlock = GameObject.Find("StartBlock").GetComponent<Stack_MovingBlock>();

        if (this.gameObject != GameObject.Find("StartBlock"))
            currentBlock = this;

        GetComponent<Renderer>().material.color = GetRandomColor();

        if (lastBlock.gameObject != GameObject.Find("StartBlock").gameObject)
        {
            transform.localScale = new Vector3(lastBlock.transform.localScale.x,
            lastBlock.transform.localScale.y,
            lastBlock.transform.localScale.z);

            speed = lastBlock.lastSpeed;

        }
    }

    // Update is called once per frame

    void Update()
    {
        MoveRepeat();
    }

    private void MoveRepeat()
    {
        if (moveDirection == MoveDirection.Z)
        {
            if (transform.position.z >= 1.3f)
            {
                if(Mathf.Abs(speed) < 10)
                {
                    speed += 0.5f;
                }
                speed = -speed;
                transform.position = new Vector3(transform.position.x, transform.position.y, 1.3f);
            }
            else if (transform.position.z <= -1.3f)
            {
                if (Mathf.Abs(speed) < 10)
                {
                    speed -= 0.5f;
                }
                speed = -speed;
                transform.position = new Vector3(transform.position.x, transform.position.y, -1.3f);
            }

            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else
        {
            if (transform.position.x >= 1.3f)
            {
                if (Mathf.Abs(speed) < 10)
                {
                    speed += 0.5f;
                }
                speed = -speed;
                transform.position = new Vector3(1.3f, transform.position.y, transform.position.z);
            }
            else if (transform.position.x <= -1.3f)
            {
                if (Mathf.Abs(speed) < 10)
                {
                    speed -= 0.5f;
                }
                speed = -speed;
                transform.position = new Vector3(-1.3f, transform.position.y, transform.position.z);
            }

            transform.position += transform.right * Time.deltaTime * speed;
        }
    }

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }

    internal void Stop()
    {
        lastSpeed = speed;
        speed = 0;
        float hangover = GetHangover();

        float max = moveDirection == MoveDirection.Z ? lastBlock.transform.localScale.z : lastBlock.transform.localScale.x;

        if (Mathf.Abs(hangover) >= max)
        {
            lastBlock = null;
            currentBlock = null;
            Common_UiManager.isGameOver = true;
        }

        if (lastBlock != null)
        {
            float direction = hangover > 0 ? 1f : -1f;

            if (moveDirection == MoveDirection.Z)
            {
                SplitBlockOnZ(hangover, direction);
            }
            else
            {
                SplitBlockOnX(hangover, direction);
            }

            lastBlock = this;
            Common_UiManager.score++;
        }
    }

    private float GetHangover()
    {
        if (moveDirection == MoveDirection.Z)
        {
            return transform.position.z - lastBlock.transform.position.z;
        }
        else
        {
            return transform.position.x - lastBlock.transform.position.x;
        }
    }

    private void SplitBlockOnX(float hangover, float direction)
    {
        float newxSize = lastBlock.transform.localScale.x - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.x - newxSize;

        float newxPosition = lastBlock.transform.position.x + (hangover / 2);
        transform.localScale = new Vector3(newxSize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(newxPosition, transform.position.y, transform.position.z);

        float blockEdge = transform.position.x + (newxSize / 2f * direction);
        float fallingBlockzPosition = blockEdge + fallingBlockSize / 2f * direction;

        SpawnDropBlock(fallingBlockzPosition, fallingBlockSize);
    }

    private void SplitBlockOnZ(float hangover, float direction)
    {
        float newzSize = lastBlock.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z - newzSize;

        float newzPosition = lastBlock.transform.position.z + (hangover / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newzSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newzPosition);

        float blockEdge = transform.position.z + (newzSize / 2f * direction);
        float fallingBlockzPosition = blockEdge + fallingBlockSize / 2f * direction;

        SpawnDropBlock(fallingBlockzPosition, fallingBlockSize);
    }

    private void SpawnDropBlock(float fallingBlockzPosition, float fallingBlockSize)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        if (moveDirection == MoveDirection.Z)
        {
            cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
            cube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockzPosition);
        }
        else
        {
            cube.transform.localScale = new Vector3(fallingBlockSize, transform.localScale.y, transform.localScale.z);
            cube.transform.position = new Vector3(fallingBlockzPosition, transform.position.y, transform.position.z);
        }

        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;

        Destroy(cube.gameObject, 1f);
    }
}
