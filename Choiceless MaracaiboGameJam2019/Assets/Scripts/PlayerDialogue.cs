﻿using UnityEngine;
using Choiceless.Scripts.Dialogues;

namespace Choiceless.Scripts.Player
{
    public class PlayerDialogue : MonoBehaviour
    {
        #region Variables

        #endregion

        #region Unity Callbacks

        private void Start()
        {

        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                DialogueManager.instance.DisplayNextSentence();
            }
        }

        #endregion

        #region Class Methods

        #endregion
    }
}
//By Sean González