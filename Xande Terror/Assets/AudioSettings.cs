using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer musicMixer;
    public void SetMusicVol(float musicVolume)
    {
        musicMixer.SetFloat("volume", musicVolume);
    }
}
