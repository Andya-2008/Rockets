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

    bool isTransitioning = false;
    bool collisionDisabled = false;
    [SerializeField] bool rocket1;
    [SerializeField] bool rocket2;
    [SerializeField] bool rocket3;
    [SerializeField] bool rocket4;
    [SerializeField] Transform respawn1;
    [SerializeField] Transform respawn2;
    [SerializeField] Transform respawn3;
    [SerializeField] Transform respawn4;

    [SerializeField] bool sandBox;
    public GameObject myController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
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
            case "Friendly":
                Debug.Log("This thing is friendly");
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
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashParticles.Play();
        myController.GetComponent<PlayerController>().enabled = false;
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
                this.transform.position = respawn1.transform.position;
            }
            if (rocket2)
            {
                this.transform.position = respawn2.transform.position;
            }
            if (rocket3)
            {
                this.transform.position = respawn3.transform.position;
            }
            if (rocket4)
            {
                this.transform.position = respawn4.transform.position;
            }
            this.transform.rotation = Quaternion.identity;
            this.GetComponent<Rigidbody>().freezeRotation = true;
            this.GetComponent<Rigidbody>().freezeRotation = false;
            myController.GetComponent<PlayerController>().enabled = true;
            isTransitioning = false;
        }
        else
        {
            //Do stuff when die in game
        }
    }

}
