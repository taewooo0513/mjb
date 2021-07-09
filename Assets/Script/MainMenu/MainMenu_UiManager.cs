using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu_UiManager : MonoBehaviour
{
    [SerializeField] private Sprite[] infoButtonImages;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickedInfoButton(Text infoText)
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;

        Image image = button.GetComponent<Image>();

        if (image.sprite == infoButtonImages[0]) //초기 -> 누름
        {
            image.sprite = infoButtonImages[1];
            infoText.GetComponent<TextInfoInteract>().InfoOn();
        }
        else //누름 -> 초기
        {
            image.sprite = infoButtonImages[0];
            infoText.GetComponent<TextInfoInteract>().InfoOff();
        }
    }

    public void ClickedPlayButton(string GameName)
    {
        SceneManager.LoadScene(GameName);
    }

    public void ReturnTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
