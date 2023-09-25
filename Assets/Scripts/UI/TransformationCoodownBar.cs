using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TransformationCoodownBar : MonoBehaviour
{
    private PlayerMovement player;
    private Image cooldownBar;
    private AudioSource src;
    [SerializeField] AudioClip refillSound;
    private bool audioLock = false;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        cooldownBar = GetComponent<Image>();
        src = GetComponent<AudioSource>();
        cooldownBar.fillAmount = 1;
    }

    private void Update()
    {
        cooldownBar.fillAmount = Mathf.Clamp01((player.LastTimeSinceTransformation / player.TransformationDurantion));
        if (player.IsTransformed)
        {
            cooldownBar.fillAmount = 0;
            audioLock = false;
        }
        if (cooldownBar.fillAmount == 1)
        {
            if (!audioLock) {
                src.clip = refillSound;
                src.Play();
                audioLock = true;
            }
            Color newColor = cooldownBar.color;
            newColor.a = 1.0f;

            cooldownBar.color = newColor;
        }
        else
        {
            Color newColor = cooldownBar.color;
            newColor.a = 0.5f;

            cooldownBar.color = newColor;
        }
    }


}
