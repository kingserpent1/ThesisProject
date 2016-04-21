using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour 
{


//   public gameobject[] mx;
//   public uint musicchannels = 2;
    

    //public
    public bool isWorldPlaying = false;
    public bool isMusicPlaying = false;
    public bool isActivePlaying = false;

    public AudioMixer musicMixer = null;
    public uint musicChannels = 2;
    public GameObject[] mx;
    public string groupPath = "mx";
    

    //private
    private AudioSource world, radio, active;
    //private GameObject projects, 

    
    
////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public static AudioManager _instance = null;

    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(AudioManager)) as AudioManager;

                if (_instance == null)
                {
                    GameObject obj = new GameObject("AudioManager");
                    _instance = obj.AddComponent(typeof(AudioManager)) as AudioManager;
                }

                _instance.Init();
            }

            return _instance;
        }
    }

    public void Create() { }
 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////   
    
    //Constructor
    private void Init()
    {
        isWorldPlaying = false;
        isMusicPlaying = false;
        isActivePlaying = false;

        

        musicMixer = Resources.Load("Music") as AudioMixer;
        mx = new GameObject[musicChannels];

        for (int i = 0; i < mx.Length; i++)
        {
            GameObject sourceObj = new GameObject("MusicChannel_" + i.ToString());
            sourceObj.transform.SetParent(this.transform);

            AudioSource source = sourceObj.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = musicMixer.FindMatchingGroups(this.groupPath)[0];

            Debug.Log("Source.outputAudioMixerGroup: " + source.outputAudioMixerGroup.name);

            mx[i] = sourceObj;
        }
    }

    private void Awake()
    {
        AudioManager.instance.Create();
        
    }

    void PlayWorldMusic(GameObject other)
    {
        world = other.GetComponent<AudioSource>();
        
    }
    void StopWorldMusic()
    {
         
        if (isMusicPlaying)
        {
            isWorldPlaying = false;
            world.Stop();
        }
        else if (!isMusicPlaying)
        {
            isMusicPlaying = false;
            
        }
    }

    public void PlayRadio(GameObject other)
    {
        radio = other.GetComponent<AudioSource>();
        if (!radio.isPlaying)
        {
            isMusicPlaying = true;
            StopWorldMusic();
            radio.Play();

        }
        else if (radio.isPlaying) 
        {
            isMusicPlaying = false;
            PlayWorldMusic(other);
            radio.Stop();
        }
    }
}
