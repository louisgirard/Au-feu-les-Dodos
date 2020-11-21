using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{
    [System.Serializable] public class SentenceEvent : UnityEvent { }

    [System.Serializable]
    public struct sentenceAction
    {
        [TextArea(3, 10)]
        public string sentence;
        public SentenceEvent sentenceEvent;
    }

    public bool actionsEnabled = false;

    public string name;
    
    [TextArea(3,10)]
    public string[] sentences;

    public sentenceAction[] sentenceActions;
}
