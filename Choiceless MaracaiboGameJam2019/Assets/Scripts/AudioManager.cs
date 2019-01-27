using UnityEngine;

namespace Choiceless.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        #region Variables
        [HideInInspector]
        public static AudioManager instance;

        public AudioClip[] playList;
        [HideInInspector]
        public AudioSource audioSource;
        #endregion

        #region Unity Callbacks

        private void Start()
        {
            audioSource.clip = playList[0];
            audioSource.loop = true;
            audioSource.Play();
        }

        private void Update()
        {
            if (true)
            {

            }
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
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }

        #endregion

        #region Class Methods

        #endregion
    }
}
//By Sean González
