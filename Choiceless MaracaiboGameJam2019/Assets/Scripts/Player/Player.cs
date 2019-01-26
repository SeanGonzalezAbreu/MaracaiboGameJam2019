using UnityEngine;

namespace Choiceless.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        #region Variables
        [Range(1, 100)]
        [SerializeField]
        private float movementSpeed;

        #endregion

        #region Unity Callbacks

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
