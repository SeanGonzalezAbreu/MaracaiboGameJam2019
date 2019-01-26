using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Choiceless.Scripts.Dialogues
{
    public class DialogueManager : MonoBehaviour
    {
        #region
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI DialogueText;
        public static DialogueManager instance;
        public GameObject DialogBox;
        public Animator DialogAnim;
        private Queue<string> sentences;
        public AudioSource audioSource;
        #endregion
        #region Unity Callbacks
        private void Start()
        {
            sentences = new Queue<string>();

        }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
        #endregion
        public void StartDialog(DialogueData dialogue)
        {
            Debug.Log("Dialogo Iniciado con " + dialogue.Name);
            ShowDiagBox(true);
            GameManager.instance.playerMov.enabled = false;
            //GameManager.instance.playerAtk.enabled = false;
            nameText.text = dialogue.Name;
            sentences.Clear();
            foreach (string sentence in dialogue.Dialogue)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();

        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            Debug.Log(sentence);
            StopAllCoroutines();
            //DialogueText.text = sentence;
            StartCoroutine(TypeSentence(sentence));
        }
        IEnumerator<string> TypeSentence(string sentence)
        {
            DialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                DialogueText.text += letter;
                audioSource.Play();
                yield return null;
            }
        }
        private void EndDialogue()
        {
            Debug.Log("Termino la conversacion");
            FadeDiagBox();
            GameManager.instance.playerMov.enabled = true;
            //GameManager.instance.playerAtk.enabled = true;


        }
        private void ShowDiagBox(bool show)
        {
            DialogBox.SetActive(show);
            if (!show) return;
            DialogAnim.SetBool("ShowDiagBox", show);
        }
        private void FadeDiagBox()
        {
            DialogAnim.SetBool("ShowDiagBox", false);
        }
    }
}
//By Sean González
