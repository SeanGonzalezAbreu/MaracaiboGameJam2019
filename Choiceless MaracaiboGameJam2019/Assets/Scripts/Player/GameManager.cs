using UnityEngine;
using Choiceless.Scripts.Player;
using Choiceless.Scripts.Dialogues;
namespace Choiceless.Scripts
{
    public class GameManager : MonoBehaviour
    {
        #region Variables
        public static GameManager instance;
        public PlayerMov playerMov;

        #endregion

        #region Unity Callbacks
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                //Debug.LogWarning("Se ha instanciado el GameManager por segunda vez.");
            }
            DontDestroyOnLoad(transform.gameObject);

        }

        private void Start()
        {

        }

        private void Update()
        {

        }

        #endregion

        #region Class Methods

        #endregion
    }
}
//By Sean González
