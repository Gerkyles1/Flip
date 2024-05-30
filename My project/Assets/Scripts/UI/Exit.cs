using UnityEngine;
using UnityEngine.UI;

namespace UIscripts
{
    public class exit : MonoBehaviour
    {
        void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(() => Application.Quit());
        }
    }

}