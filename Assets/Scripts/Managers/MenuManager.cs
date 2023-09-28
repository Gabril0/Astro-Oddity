using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Image howToPlay;
    [SerializeField] GameObject score;
    //MenuSounds
    [SerializeField] AudioClip menuConfirmSoundEffect;
    private AudioSource src;

    private void Start()
    {
        src = GetComponent<AudioSource>();
        src.clip = menuConfirmSoundEffect;
    }

    public void clickHowToPlay() {
        src.Play();
        howToPlay.gameObject.SetActive(true);
    }

    public void clickPlay() {
        src.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void clickStats() {
        src.Play();
        score.gameObject.SetActive(true);
    }

    public void clickExitScore() {
        src.Play();
        score.gameObject.SetActive(false);
    }

    public void clickExitHowToPlay() {
        src.Play();
        howToPlay.gameObject.SetActive(false);
    }

    public void clickClose() {
        src.Play();
        Application.Quit();
    }
}
