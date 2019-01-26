using UnityEngine;
using System;

namespace Choiceless.Scripts.Dialogues
{
    [Serializable]
    public struct DialogueData
    {
        #region Variables

        [Header("Properties")]
        [SerializeField] private string name;
        [TextArea(3, 10)]
        [SerializeField] private string[] dialogue;



        public string Name
        {
            get { return name; }
        }
        public string[] Dialogue
        {
            get { return dialogue; }
        }

        #endregion
    }
}
//By Sean González
