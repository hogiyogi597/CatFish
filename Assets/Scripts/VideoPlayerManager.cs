using CatFish;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour {

    public string nextScene;
    private VideoPlayer vp;
    private AudioSource audio;

	// Use this for initialization
	void Start () {
        vp = GameObject.FindObjectOfType<VideoPlayer>();
        audio = GameObject.FindObjectOfType<AudioSource>();
        vp.loopPointReached += EndReached;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKeyDown)
            StartCoroutine(FadeOut(audio, 4f));
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        StartCoroutine(FadeOut(audio, 4f));
    }

    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        if(audioSource != null)
        {
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
        }
        GameObject.FindObjectOfType<SceneLoader>().LoadScene(nextScene);
    }

    IEnumerator Fade()
    {
        while(audio.volume > 0)
        {
            audio.volume -= 0.3f;
            yield return null;
        }
        GameObject.FindObjectOfType<SceneLoader>().LoadScene("Level1");
    }
}
