using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlaybackManager : MonoBehaviour
{
    [SerializeField]
    VideoClip intro, root, closing;

    VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        
        videoPlayer.clip = intro;
        videoPlayer.Play();
        videoPlayer.loopPointReached += HandleVideoCompletion;
    }

    void HandleVideoCompletion(VideoPlayer videoPlayer)
    {
        EventManager.TriggerVideoCompleted(videoPlayer.clip.name);
        switch (videoPlayer.clip.name)
        {
            case "Medopening":
                {
                    EventManager.TriggerIntroCompleted();
                    videoPlayer.clip = root;
                    break;
                }
            case "Medication_Administration_02":
                {
                    //EventManager.TriggerAnswerSubmitted();
                    videoPlayer.Stop();
                    videoPlayer.clip = closing;
                    videoPlayer.Play();
                    break;
                }
                // the other video switches are handled via UI
                // these are just the automatic ones
        }
    }

    public void HandleQuestion01(VideoClip clip)
    {
        // This is where the video player switches clips
        // This gets called through UI events
        EventManager.TriggerAnswerSubmitted();
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }

}
