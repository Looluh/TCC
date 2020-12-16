using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityStandardAssets.Utility;
using UnityEngine.SceneManagement;

public class RespawnBrain : MonoBehaviour 
{
    public static RespawnBrain instance;
    //private static RespawnBrain _instance;
    //public static RespawnBrain Instance { get { return _instance; } }
    public Vector3 lastCheckpointPos;//checkpoint
    public Vector3 playerStartPos;

    public float height;
    public float sfxVolume;
    public float musicVolume;
    public AudioMixer audioMix;

    //public SmoothFollow cameraScript;

    public int currentScene = 0;
    public GameObject player;

    public bool gameState;

    public bool keyA = false;
    public bool keyB = false;
    public bool keyC = false;
    public bool keyD = false;

    void Awake()//define volume e fov e guarda alterações q o player fizer -- verifica se já não existe um brain
    {
        height = 10;
        sfxVolume = 0;
        musicVolume = 0;

        //if (_instance != null && _instance != this)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    _instance = this;
        //}

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()//define volume, n funciona no awake
    {
        audioMix.SetFloat("sfxVolume", sfxVolume);
        audioMix.SetFloat("musicVolume", musicVolume);
        gameState = true;
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)//configura posição inicial na cena, verifica se é a primeira vez carregando a cena e se n é o menu
    {
        Debug.Log(mode);
        player = GameObject.FindGameObjectWithTag("Player");
        if (currentScene != scene.buildIndex && scene.buildIndex != 0)
        {
            print("aaaaaaaaaaaaaaSeráa???????");
            keyA = false;
            keyB = false;
            keyC = false;
            keyD = false;
            currentScene = scene.buildIndex;
            lastCheckpointPos = player.transform.position;
            playerStartPos = player.transform.position;
        }

        /*switch (scene.buildIndex)
        {
            case 1:
                Debug.Log(mode);
                if (currentScene != scene.buildIndex)
                {
                    print("aaaaaaaaaaaaaaSeráa???????");
                    currentScene = scene.buildIndex;
                    lastCheckpointPos = player.transform.position;//new Vector3(0, -0.5f, 0);
                }
                break;
            case 2:
                if (currentScene != scene.buildIndex)
                {
                    currentScene = scene.buildIndex;
                    lastCheckpointPos = new Vector3(510, 8.5f, 525);
                }
                break;
    }*/
        //if (scene.buildIndex == 1)
        //Debug.Log("Level Loaded");
        //Debug.Log(scene.name);
        //Debug.Log(mode);
    }

    public void ResetCheckpoint()
    {
        lastCheckpointPos = playerStartPos;
    }
}
