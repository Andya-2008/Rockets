using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;
    public bool gameOver;

    bool isTransitioning = false;
    bool collisionDisabled = false;
    [SerializeField] bool rocket1;
    [SerializeField] bool rocket2;
    [SerializeField] bool rocket3;
    [SerializeField] bool rocket4;
    [SerializeField] bool bullet;
    [SerializeField] Transform respawn1;
    [SerializeField] Transform respawn2;
    [SerializeField] Transform respawn3;
    [SerializeField] Transform respawn4;
    [SerializeField] GameObject bulletBody;
    [SerializeField] bool sandBox;
    public GameObject Controller1;
    public GameObject Controller2;
    public GameObject Controller3;
    public GameObject Controller4;
    float bulletStartTime;
    void Start()
    {
        bulletStartTime=Time.time;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Time.time-bulletStartTime>=5 && bullet)
        {
            StartCrashSequence();
        }
        //RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;  // toggle collision
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisabled) { return; }

        switch (other.gameObject.tag)
        {
            case "Powerup":
                switch (other.gameObject.name)
                {
                    case "P_BulletSpeed(Clone)":
                        Debug.Log("`");
                        this.gameObject.GetComponent<GrabPowerup>().GrabbedPowerup(1);
                        break;
                    default:
                        break;
                }
                Destroy(other.gameObject);
                break;
            case "Friendly":
                break;
            case "Bullet":
                if (bullet)
                {
                    StartCrashSequence();
                }
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Player":
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        
        
        crashParticles.Play();
        if (rocket1)
        {
            Controller1.GetComponent<Movement>().enabled = false;
        }
        if (rocket2)
        {
            Controller2.GetComponent<Movement>().enabled = false;
        }
        if (rocket3)
        {
            Controller3.GetComponent<Movement>().enabled = false;
        }
        if (rocket4)
        {
            Controller4.GetComponent<Movement>().enabled = false;
        }
        if(bullet)
        {
            bulletBody.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;
        }
        if(!bullet)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(crash);
        }
        Invoke("Respawn", levelLoadDelay);
    
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void Respawn()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex);
        if (sandBox)
        {
            if (rocket1)
            {
                Controller1.GetComponent<Movement>().enabled = true;
                this.transform.position = respawn1.transform.position;
            }
            if (rocket2)
            {
                Controller2.GetComponent<Movement>().enabled = true;
                this.transform.position = respawn2.transform.position;
            }
            if (rocket3)
            {
                Controller3.GetComponent<Movement>().enabled = true;
                this.transform.position = respawn3.transform.position;
            }
            if (rocket4)
            {
                Controller4.GetComponent<Movement>().enabled = true;
                this.transform.position = respawn4.transform.position;
            }
            if(bullet)
            {
                Destroy(this.gameObject);
            }
            this.transform.rotation = Quaternion.identity;
            
            isTransitioning = false;
        }
        else
        {
            if(!gameOver)
            {
                if(rocket1)
                {
                    GameObject.Find("GameOverManager").GetComponent<GameOverManager>().GameOverStart(2);
                    GameObject.Find("Rocket2").GetComponent<CollisionHandler>().gameOver=true;
                    PlayerPrefs.SetInt("Rocket2Score", PlayerPrefs.GetInt("Rocket2Score")+1);
                }
                if(rocket2)
                {
                    GameObject.Find("GameOverManager").GetComponent<GameOverManager>().GameOverStart(1);
                    GameObject.Find("Rocket1").GetComponent<CollisionHandler>().gameOver=true;
                    PlayerPrefs.SetInt("Rocket1Score", PlayerPrefs.GetInt("Rocket1Score")+1);
                }
            }
            //Do stuff when die in game
        }
    }

}
