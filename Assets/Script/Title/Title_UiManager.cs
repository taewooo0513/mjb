using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_UiManager : MonoBehaviour
{
    [SerializeField] private GameObject credit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (credit.activeSelf && Input.GetMouseButtonDown(0))
        {
            credit.SetActive(false);
        }
    }

    public void ClickedGameStartButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickedCreditButton()
    {
        if (!credit.activeSelf)
        {
            credit.SetActive(true);
        }
    }
}
