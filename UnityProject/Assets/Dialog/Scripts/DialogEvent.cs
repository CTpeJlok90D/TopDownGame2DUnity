using UnityEngine;
using UnityEngine.Events;

namespace Dialog
{
    public class DialogEvent : MonoBehaviour
    {
        public Dialog Dialog;
        public UnityEvent Event;

        public void Awake()
        {
            Dialog.StoryEnded.AddListener(Event.Invoke);
        }
    }
}