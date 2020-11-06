using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    private AudioSource source;

    [SerializeField]
    private List<AudioClip> musics = new List<AudioClip>();

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameManager.startGame += PlayRandomMusic;
    }

    private void OnDisable()
    {
        GameManager.startGame -= PlayRandomMusic;
    }

    void PlayRandomMusic()
    {
        source.Play();
    }

}
