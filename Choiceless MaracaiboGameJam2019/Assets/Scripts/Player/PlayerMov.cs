using UnityEngine;

namespace Choiceless.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMov : MonoBehaviour
    {
        #region Variables
        [Range(1, 100)]
        public float movementSpeed;
        [HideInInspector]
        public Vector2 dirMovement;
        private Rigidbody2D rb;
        [HideInInspector]
        public Animator animatorPlayer;
        //public MapInfo initialMapInfo;
        //public Rigidbody PlayerRigidbody
        //{
        //    get
        //    {
        //        return rb;
        //    }
        //    set
        //    {
        //        rb = value;
        //    }
        //}
        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animatorPlayer = GetComponent<Animator>();
        }
        private void Start()
        {

        }
        private void Update()
        {
            dirMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            if (Input.GetButtonDown("Fire1"))
            {
                movementSpeed = movementSpeed * 2;
            }
            else
            {
                movementSpeed = 5;
            }

            if (dirMovement != Vector2.zero)
            {
                animatorPlayer.SetFloat("MovY", dirMovement.y);
                animatorPlayer.SetFloat("MovX", dirMovement.x);
                animatorPlayer.SetBool("isMoving", true);
            }
            else
            {
                animatorPlayer.SetBool("isMoving", false);
            }

        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + dirMovement * movementSpeed * Time.deltaTime);
        }

        #endregion

        #region Class Methods

        #endregion
    }
}
//By Sean González
