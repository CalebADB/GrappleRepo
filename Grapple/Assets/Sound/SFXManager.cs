using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class SFXManager : MonoBehaviour
    {
        public AudioClip buttonSound;
        public AudioClip collectableSound;
        public AudioClip intractableSound;
        public AudioClip characterJumpSound;


        [SerializeField]
        private AudioSource audioSource;


        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }


        void Update()
        {

        }

        public void PlaySFX(SFXType sfxType)
        {

            switch (sfxType)
            {
                case SFXType.Button:

                    audioSource.pitch = 1f;
                    audioSource.volume = 1f;
                    audioSource.clip = buttonSound;
                    audioSource.Play();

                    break;

                case SFXType.Collectable:

                    audioSource.pitch = 1f;
                    audioSource.volume = 1f;
                    audioSource.clip = collectableSound;
                    audioSource.Play();

                    break;

                case SFXType.Interactable:

                    audioSource.pitch = 1f;
                    audioSource.volume = 1f;
                    audioSource.clip = intractableSound;
                    audioSource.Play();

                    break;

                case SFXType.CharacterJump:

                    audioSource.pitch = 1f;
                    audioSource.volume = 1f;
                    audioSource.clip = characterJumpSound;
                    audioSource.Play();

                    break;

                default:
                    break;
            }

        }

        public enum SFXType
        {
            Button,
            Collectable,
            Interactable,
            CharacterJump
        }
    }
}
