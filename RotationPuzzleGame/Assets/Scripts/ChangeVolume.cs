using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeVolume : MonoBehaviour
{
    public AudioSource source;
    public void SetLevel(float sliderValue)
    {
        source.volume = sliderValue;
    }
}
