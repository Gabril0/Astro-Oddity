using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Image howToPlay;

    public void clickHowToPlay() {
        howToPlay.gameObject.SetActive(true);
    }

    public void clickPlay() {
        SceneManager.LoadScene("SampleScene");
    }

    public void clickStats() {
        //WIP
    }

    public void clickExitHowToPlay() {
        howToPlay.gameObject.SetActive(false);
    }

    public void clickClose() {
        Application.Quit();
    }
}
