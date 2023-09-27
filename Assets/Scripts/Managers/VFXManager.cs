using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class VFXManager : MonoBehaviour
{
    private string sceneName;
    private PostProcessVolume postProcessVolume;
    private ColorGrading colorGrading;

    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();

        sceneName = SceneManager.GetActiveScene().name;
        postProcessVolume.enabled = true;
            if (sceneName == "Stage3")
            {
                colorGrading.temperature.value = 87f;
                colorGrading.tint.value = 32f;
            }
            if (sceneName == "Stage2")
            {
                colorGrading.temperature.value = 50f;
                colorGrading.tint.value = -43f;
            }
        if (sceneName == "Menu")
        {
            colorGrading.temperature.value = 0;
            colorGrading.tint.value = 0;
        }
        if (sceneName == "SampleScene")
        {
            colorGrading.temperature.value = -5f;
            colorGrading.tint.value = 20f;
        }

    }
}
