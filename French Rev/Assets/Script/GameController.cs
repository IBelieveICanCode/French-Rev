using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameController : MonoBehaviour
{
    //[SerializeField]
    //private Audio audioManager;

    public UnityEvent UIUpdate;

    public UnityEvent GameOver;

    public static GameController Instance;

    public Dude myDude;
    bool menu;
    public MyHead myHead;

    //public Audio AudioManager { get => audioManager; set => audioManager = value; }



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
        }
        //HUD.Instance.State = GameState.Play;
        //DontDestroyOnLoad(gameObject);
        //InitializeAudioManager();
        //GameController.Instance.AudioManager.PlayMusic(menu = false);
    }
    // Start is called before the first frame update
    void Start()
    {
        if(UIUpdate!=null)
            UIUpdate.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (UIUpdate != null)
            UIUpdate.Invoke();
    }

    /*
    private void InitializeAudioManager()
    {
        audioManager.SourceSFX = gameObject.AddComponent<AudioSource>();
        audioManager.SourceMusic = gameObject.AddComponent<AudioSource>();
        audioManager.SourceRandomPitchSFX = gameObject.AddComponent<AudioSource>();
        gameObject.AddComponent<AudioListener>();
    }
    */


}
