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

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
        OSCHandler.Instance.Init();
	}
	
	// Update is called once per frame
	void Update () {
        List<object> vals = new List<object>();
        vals.AddRange(new object[]{80.0f, 50.0f});

        OSCHandler.Instance.SendMessageToClient("PD", "/test/voice", vals);
	}
}
