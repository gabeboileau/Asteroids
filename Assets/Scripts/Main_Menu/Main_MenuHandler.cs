using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Main_MenuHandler : MonoBehaviour
{

    public AudioMixer mainMixer;
    public GameObject howToImage;

    public AudioClip pointerOverSound;
    public AudioClip selectSound;
    public AudioClip mainMenuBackgroundSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.Play();
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene(1);
        ButtonPressedSound();
    }

    public void HowToButtonPressed()
    {
        howToImage.SetActive(true);
        ButtonPressedSound();
    }

    public void BackButtonPressed()
    {
        //Back Button pressed/ go back to main menu
        howToImage.SetActive(false);
    }

    public void CreditsButtonPressed()
    {
        Application.OpenURL("http://www.gabrienboileau.com/");
        ButtonPressedSound();
    }





    void ButtonPressedSound()
    {
        //Play select button
        audioSource.PlayOneShot(selectSound); 
    }  

    public void PointerEnter()
    {
        //TODO: Play sound
        audioSource.PlayOneShot(pointerOverSound);
    }




}
