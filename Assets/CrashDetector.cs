using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float invokedDelay = .5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool alreadyHit = false;
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Ground" && alreadyHit is false) {
            alreadyHit = true;
            FindObjectOfType<PlayerController>().DisableControls();
            Debug.Log("You hit your head!");
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", invokedDelay);
        }
    }
    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
