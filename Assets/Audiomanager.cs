using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Audiomanager : MonoBehaviour
{

    [Header("Audio Source")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("Audio Clips")]
    public AudioClip Background;
    public AudioClip BadFood;
    public AudioClip GoodFood;
    public AudioClip GameOver;
    public AudioClip babycows;

    private void Start()
    {
        MusicSource.clip = Background;
        MusicSource.Play();
    }

    public void PlayBadFood(AudioClip clip)
    {
        SFXSource.clip = BadFood;
        SFXSource.Play();
    }

    public void PlayGoodFood(AudioClip clip)
    {
        SFXSource.clip = GoodFood;
        SFXSource.Play();
    }
}
