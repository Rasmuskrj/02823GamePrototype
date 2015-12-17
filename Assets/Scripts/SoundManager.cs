using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance
    {
        get;
        private set;
    }

    public AudioSource bingSound;
    public AudioSource blipSound;
    public AudioSource clickSound;
    public AudioSource breakBlockSound;
    public AudioSource paddleSound;
    public AudioSource yoDead;
    public AudioSource tokenFanfare;
    public AudioSource shotSound;
    public AudioSource boxDestroy;
    public AudioSource appleBoing;
    public float musicMsPerBeat = 200.0f;

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        OSCHandler.Instance.Init();
        SoundManager.Instance.MuteMusic();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SendFrequencyToPD()
    {
        Debug.Log("music BPM set to: " + musicMsPerBeat);
        OSCHandler.Instance.SendMessageToClient("PD", "/command/freq", musicMsPerBeat);
    }

    public void IncreaseMusicFrequency()
    {
        musicMsPerBeat -= 5.0f;
        if (musicMsPerBeat < 50.0f)
        {
            musicMsPerBeat = 50.0f;
        }
        SendFrequencyToPD();
    }

    public void SetMusicFrequency(float freq)
    {
        musicMsPerBeat = freq;
        SendFrequencyToPD();
    }

    public void MuteMusic()
    {
        OSCHandler.Instance.SendMessageToClient("PD", "/command/mute", 0.0f);
    }

    public void UnmuteMusic()
    {
        OSCHandler.Instance.SendMessageToClient("PD", "/command/unmute", 1.0f);
    }
}
