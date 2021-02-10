using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    private AudioSource AudioManager;
    private bool played1;
    private bool played2;
    private bool played3;

    private void Start()
    {
        AudioManager = GetComponent<AudioSource>();
        AudioManager.volume = 1f;
    }
    void Update()
    {
        if (!GameObject.Find("FeuerArtefakt") && !played1)
        {
            AudioManager.PlayOneShot(clip1);
            played1 = true;
        }
        if (!GameObject.Find("HeilungsArtefakt") && !played2)
        {
            AudioManager.PlayOneShot(clip2);
            played2 = true;
        }
        if (!GameObject.Find("ArtefaktSchild") && !played3)
        {
            AudioManager.PlayOneShot(clip3);
            played3 = true;
        }
    }
}
