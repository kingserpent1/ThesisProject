using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour 
{


//   public gameobject[] mx;
//   public uint musicchannels = 2;
    

    //public
    public bool isWorldPlaying = false;
<<<<<<< HEAD
    public bool isRadioPlaying = false;
    public bool isActivePlaying = false;

    public AudioMixerSnapshot snapWorld;
    public AudioMixerSnapshot snapRadio;
    public AudioMixerSnapshot snapMiscRadio;
    public AudioMixerSnapshot snapMiscWorld;
    
    //Time to fade out music
    public float fadeTime = 1.0f;

=======
    public bool isMusicPlaying = false;
    public bool isActivePlaying = false;

>>>>>>> master
    public AudioMixer musicMixer = null;
    public uint musicChannels = 2;
    public GameObject[] mx;
    public string groupPath = "mx";
    

    //private
    private AudioSource world, radio, active;
<<<<<<< HEAD
    private AudioClip worldMusic, radioMusic;
=======
>>>>>>> master
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
<<<<<<< HEAD
        isRadioPlaying = false;
        isActivePlaying = false;

       
        

        musicMixer = Resources.Load("Master") as AudioMixer;
=======
        isMusicPlaying = false;
        isActivePlaying = false;

        

        musicMixer = Resources.Load("Music") as AudioMixer;
>>>>>>> master
        mx = new GameObject[musicChannels];

        for (int i = 0; i < mx.Length; i++)
        {
            GameObject sourceObj = new GameObject("MusicChannel_" + i.ToString());
            sourceObj.transform.SetParent(this.transform);

<<<<<<< HEAD
            //AudioSource source = sourceObj.AddComponent<AudioSource>();
            //source.outputAudioMixerGroup = musicMixer.FindMatchingGroups(this.groupPath)[0];

            //Debug.Log("Source.outputAudioMixerGroup: " + source.outputAudioMixerGroup.name);
=======
            AudioSource source = sourceObj.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = musicMixer.FindMatchingGroups(this.groupPath)[0];

            Debug.Log("Source.outputAudioMixerGroup: " + source.outputAudioMixerGroup.name);
>>>>>>> master

            mx[i] = sourceObj;
        }
    }

    private void Awake()
    {
        AudioManager.instance.Create();
        
    }

<<<<<<< HEAD
    public void PlayWorldMusic(AudioSource worldSource, AudioClip worldClip)
    {
        world = worldSource;
        worldMusic = worldClip;
        world.Play();
        isWorldPlaying = true;
        snapMiscWorld.TransitionTo(fadeTime);
    }

    public void StopWorldMusic()
    {
         
        if (isRadioPlaying)
=======
    void PlayWorldMusic(GameObject other)
    {
        world = other.GetComponent<AudioSource>();
        
    }
    void StopWorldMusic()
    {
         
        if (isMusicPlaying)
>>>>>>> master
        {
            isWorldPlaying = false;
            world.Stop();
        }
<<<<<<< HEAD
        else if (!isRadioPlaying)
        {
            isRadioPlaying = false;
            //world.Play();
        }
    }

    public void PlayRadio(AudioSource radioSource, AudioClip radioClip)
    {
        
        radio = radioSource;
        radioMusic = radioClip;

        if (!isRadioPlaying)
        {
            isRadioPlaying = true;
            isWorldPlaying = false;
            radio.Stop();
            //StopWorldMusic();
            radio.Play();
            snapRadio.TransitionTo(fadeTime);
            snapMiscRadio.TransitionTo(fadeTime);
=======
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
>>>>>>> master

        }
        else if (radio.isPlaying) 
        {
<<<<<<< HEAD
            isRadioPlaying = false;
            
            PlayWorldMusic(world, worldMusic);
            snapWorld.TransitionTo(fadeTime);
            snapMiscWorld.TransitionTo(fadeTime);
            //radio.Stop();
        }
    }

    public void PlayFootSteps(AudioSource src, AudioClip[] clips)
    {
        src.clip = clips[Random.Range(0, clips.Length)];
        src.Play();
    }


    public void PlayDialogue(AudioSource dialogue, AudioClip[] lines, int i)
    {
            
            dialogue.clip = lines[i];

            if (!dialogue.isPlaying)
            {
                dialogue.Play();
            }
        
    }
=======
            isMusicPlaying = false;
            PlayWorldMusic(other);
            radio.Stop();
        }
    }
>>>>>>> master
}
