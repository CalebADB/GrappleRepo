using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace masterFeature
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;

        private MusicPlayingType musicPlayingType;
        private float initialVolume;
        private float initialPitch;
        private float timePassed_FadeOut = 0;


        private float fadeOutTime = 1.0f;
        private float fadeOutSmoothness = 1.0f;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            musicPlayingType = MusicPlayingType.Normal;
            initialPitch = audioSource.pitch;
            initialVolume = audioSource.volume;
        }


        void Update()
        {
            switch (musicPlayingType)
            {
                case MusicPlayingType.Normal:

                    break;

                case MusicPlayingType.Fading:

                    timePassed_FadeOut += Time.deltaTime;
                    if (timePassed_FadeOut >= fadeOutTime)
                    {
                        audioSource.volume = 0;

                        audioSource.Stop();
                        ResetAudioSource();

                        musicPlayingType = MusicPlayingType.Normal;
                    }
                    else
                    {
                        audioSource.volume = initialVolume - initialVolume * Mathf.Pow(timePassed_FadeOut / fadeOutTime, fadeOutSmoothness);
                    }

                    break;

                default:
                    break;
            }

        }

        public void PlayMusic()
        {
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
        }

        public void StopMusic(StopMusicType stopMusicType)
        {
            switch (stopMusicType)
            {
                case StopMusicType.Snap:

                    audioSource.Stop();

                    break;
                case StopMusicType.FadeOut:

                    FadeOut();

                    break;
                default:
                    break;
            }

        }

        public void ResetMusicSetting()
        {
            musicPlayingType = MusicPlayingType.Normal;
            audioSource.Stop();
            ResetAudioSource();
        }



        private void ResetAudioSource()
        {
            audioSource.pitch = initialPitch;
            audioSource.volume = initialVolume;
        }

        private void FadeOut()
        {
            musicPlayingType = MusicPlayingType.Fading;
            timePassed_FadeOut = 0;
        }

        private enum MusicPlayingType
        {
            Normal,
            Fading
        }

        public enum StopMusicType
        {
            Snap,
            FadeOut
        }
    }
}
