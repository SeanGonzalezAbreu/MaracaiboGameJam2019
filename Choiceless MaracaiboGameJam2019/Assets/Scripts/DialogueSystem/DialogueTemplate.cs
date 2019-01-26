using UnityEngine;
namespace Choiceless.Scripts.Dialogues
{
    [CreateAssetMenu(fileName = "New DialogueTemplate", menuName = "Choiceless/Data/Create Dialogue Teemplate")]
    public class DialogueTemplate : ScriptableObject
    {
        #region Variables

        [SerializeField]
        private DialogueData dialogueData;
        public DialogueData Data { get { return dialogueData; } }

        #endregion
    }
}
//By Sean González
