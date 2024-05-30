using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip _buttonClick;
    [SerializeField] private AudioClip _flip;
    [SerializeField] private AudioClip _gameOver;
    [SerializeField] private AudioClip _goodObstacle;

    public void PlayGameOver()
    {
        _audioSource.PlayOneShot(_gameOver);
    }
    public void PlayGoodObstacle()
    {
        _audioSource.PlayOneShot(_goodObstacle);
    }

    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject");
            return;
        }

        if (_buttonClick == null)
        {
            Debug.LogError("Button click AudioClip not assigned in the inspector");
            return;
        }
        AddListenersToAllButtons(()=>_audioSource.PlayOneShot(_buttonClick));

    }
    public void PlayFlip()
    {
        _audioSource.PlayOneShot(_flip);
    }



    public void AddListenersToAllButtons(UnityAction action)
    {
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

        List<GameObject> allObjects = new List<GameObject>();

        foreach (GameObject rootObject in rootObjects)
        {
            GetAllChildObjects(rootObject, allObjects);
        }

        foreach (GameObject obj in allObjects)
        {
            Button button = obj.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(action);
            }
        }
    }

    private void GetAllChildObjects(GameObject parent, List<GameObject> allObjects)
    {
        allObjects.Add(parent);
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GetAllChildObjects(parent.transform.GetChild(i).gameObject, allObjects);
        }
    }
}
