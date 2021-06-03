using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform stick;

    private Vector3 stickFirstPos;
    private Vector3 joyVec;
    private float radius;
    private bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<RectTransform>().sizeDelta.y * 0.5f;
        stickFirstPos = stick.transform.position;

        float can = transform.parent.GetComponent<RectTransform>().localScale.x;
        radius *= can;
    }

    void Update()
    {
        if (canMove) GameObject.FindWithTag("Player").GetComponent<Fall_Player>().Move();
    }

    public void Drag(BaseEventData _Data)
    {
        canMove = true;
        PointerEventData Data = _Data as PointerEventData;
        Vector3 pos = Data.position;

        joyVec = (pos - stickFirstPos).normalized;

        float dis = Vector3.Distance(pos, stickFirstPos);

        if (dis < radius)
            stick.position = stickFirstPos + joyVec * radius;

        player.eulerAngles = new Vector3(0, Mathf.Atan2(joyVec.x, joyVec.y) * Mathf.Rad2Deg, 0);
    }

    public void DragEnd()
    {
        stick.position = stickFirstPos;
        joyVec = Vector3.zero;
        canMove = false;
    }
}
