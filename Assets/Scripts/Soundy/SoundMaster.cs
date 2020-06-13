using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour
{
   [SerializeField]
   private AudioClip buttonDownSound, buttonUpSound;
   private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   public void PlayDownSound(){
       if(!audioSource.isPlaying){

           audioSource.PlayOneShot(buttonDownSound);

       }else{

           audioSource.Stop();
       }
       
   }

   public void PlayUpSound(){
        audioSource.PlayOneShot(buttonUpSound);
   }
}
