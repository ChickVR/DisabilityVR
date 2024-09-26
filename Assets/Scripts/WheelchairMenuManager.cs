using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelchairMenuManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    AudioClip head, feet, arms, bed, back;

    string headText = "Kelly should raise her head.";
    string backText = "Kelly should straighten her back.";
    string bedText = "The chair is too far from the bed. Kelly should move the chair closer before transfering.";
    string feetText = "Kelly has a wide, stable stance, and her left foot is between David's feet.";
    string armsText = "Kelly has a stable grip around David's back.";

    public GameObject wheelchairModel;
    AudioSource audioSource;

    private void OnEnable()
    {
        EventManager.OnObjectClicked += HandleObjectClicked;
        audioSource = GetComponent<AudioSource>();
        //transform.parent = null;
    }

    private void Start()
    {
        transform.parent = null;
        transform.position = Vector3.zero; 
        transform.Translate(transform.forward * 5);
    }

    private void OnDisable()
    {
        EventManager.OnObjectClicked -= HandleObjectClicked;
    }

    void HandleObjectClicked(string objectID)
    {
        switch (objectID)
        {
            case "Head":
                {
                    text.text = headText;
                    audioSource.clip = head;
                    audioSource.Play();
                    break;
                }
            case "Feet":
                {
                    audioSource.clip = feet;
                    text.text = feetText;
                    audioSource.Play();
                    break;
                }
            case "Back":
                {
                    audioSource.clip = back;
                    text.text = backText;
                    audioSource.Play();
                    break;
                }
            case "Bed":
                {
                    audioSource.clip = bed;
                    text.text = bedText;
                    audioSource.Play();
                    break;
                }
            case "Arms":
                {
                    audioSource.clip = arms;
                    text.text = armsText;
                    audioSource.Play();
                    break;
                }
        }
    }

    public void LoadModel(GameObject model)
    {
        GameObject.Destroy(wheelchairModel);
        // Load the correct model and put in the correct position
        GameObject go = GameObject.Instantiate(model);
        go.transform.parent = GameObject.Find("Scene").transform;
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;

        // Make spheres disappear
        GameObject.Destroy(GameObject.Find("Spheres"));
    }
}
