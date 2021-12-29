using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;
    public static AudioManager instance = null;
    public float lowpitchRange = 0.95f;
    public float hifhpitchRange = 1.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    public void playSingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randompitch = Random.Range(lowpitchRange, hifhpitchRange);
        efxSource.pitch = randompitch;
        efxSource.clip = clips[randomIndex];
        efxSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
