using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapDestroy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private Renderer mapColor;
    private WaitForSeconds wait;
    private int count = 0;
    private float waitDelay;
    private float posX;
    private float posZ;

    // Start is called before the first frame update
    void Start()
    {
        mapColor = gameObject.GetComponent<Renderer>();
        waitDelay = 1f;
        wait = new WaitForSeconds(waitDelay);

        StartCoroutine(DestroyMap());
    }

    IEnumerator DestroyMap()
    {
        while (true)
        {
            switch (count)
            {
                case 0:
                    count++;
                    break;
                case 1:
                    mapColor.material.color = Color.yellow;
                    count++;
                    break;
                case 2:
                    mapColor.material.color = new Color(1, 0.45f, 0.08f);
                    count++;
                    break;
                case 3:
                    mapColor.material.color = Color.red;
                    count++;
                    break;
                case 4:
                    count = 0;
                    mapColor.material.color = new Color(1, 1, 1);
                    SetMapPos();

                    Fall_Gamemanager.score++;
                    ScoreInteract();

                    break;
            }
            yield return wait;
        }
    }

    private void ScoreInteract()
    {
        if (Fall_Gamemanager.score % 1 == 0 && transform.localScale.x > 20)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y, transform.localScale.z - 0.2f);
        }
        if (Fall_Gamemanager.score % 1 == 0)
        {
            Instantiate(enemyPrefab,
            new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z),
            Quaternion.identity);
        }
        if (Fall_Gamemanager.score % 7 == 0)
        {
            waitDelay -= 0.1f;
            wait = new WaitForSeconds(waitDelay);
        }
    }

    private void SetMapPos()
    {
        posX = Random.Range(-(transform.localScale.x / 2), transform.localScale.x / 2);
        posZ = Random.Range(-(transform.localScale.z / 2), transform.localScale.z / 2);

        if (Mathf.Abs(posX + posZ) > transform.localScale.x)
        {
            float a = (Mathf.Abs(posX + posZ) - transform.localScale.x) / 2;
            posX -= a;
            posZ -= a;
        }

        transform.position = new Vector3(posX, transform.position.y - 10, posZ);
    }
}
