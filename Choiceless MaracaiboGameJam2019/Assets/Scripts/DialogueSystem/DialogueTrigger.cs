using UnityEngine;

namespace Choiceless.Scripts.Dialogues
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class DialogueTrigger : MonoBehaviour
    {
        #region Variables
        public DialogueTemplate dialogue;
        bool wasShowed = false;
        public bool showOnce = false;
        #endregion

        #region Unity Callbacks


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                if (showOnce && wasShowed) return;
                DialogueManager.instance.StartDialog(dialogue);
                wasShowed = true;
                Debug.Log(string.Format("Dialogo Activado"));
            }
        }

        #endregion

        #region Class Methods

        #endregion
    }
}
//By Sean González
