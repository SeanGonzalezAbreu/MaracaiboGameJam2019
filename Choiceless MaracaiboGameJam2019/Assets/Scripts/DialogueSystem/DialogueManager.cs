using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


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
        public Image image;
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
        public void StartDialog(DialogueTemplate dialogue)
        {
            Debug.Log("Dialogo Iniciado con " + dialogue.Data.Name);
            ShowDiagBox(true);
            GameManager.instance.playerMov.animatorPlayer.SetBool("isMoving", false);
            GameManager.instance.playerMov.enabled = false;
            //GameManager.instance.playerAtk.enabled = false;
            image.sprite = dialogue.Data.Portrait;
            nameText.text = dialogue.Data.Name;
            sentences.Clear();
            foreach (string sentence in dialogue.Data.Dialogue)
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
        IEnumerator<WaitForSeconds> TypeSentence(string sentence)
        {
            DialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                DialogueText.text += letter;
                audioSource.Play();
                yield return new WaitForSeconds(.05f);
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
