using UnityEngine;
using System;
using UnityEngine.UI;
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
        [SerializeField] private Sprite portrait;



        public string Name
        {
            get { return name; }
        }
        public string[] Dialogue
        {
            get { return dialogue; }
        }
        public Sprite Portrait
        {
            get { return portrait; }
        }
        #endregion
    }
}
//By Sean González
