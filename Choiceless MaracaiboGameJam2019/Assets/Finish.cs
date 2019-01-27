using UnityEngine;

namespace Choiceless.Scripts
{
    public class Finish : MonoBehaviour
    {
        #region Variables
        public GameObject TheEnd;
        private bool Finished = false;
        #endregion

        #region Unity Callbacks

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Frog" && !Finished)
            {
                Finished = true;
                GameManager.instance.playerMov.enabled = false;
                AudioManager.instance.audioSource.clip = AudioManager.instance.playList[1];
                AudioManager.instance.audioSource.Play();
                Animator anim = collision.GetComponent<Animator>();
                anim.enabled = true;
                TheEnd.SetActive(true);
                //anim.Play("Finish");
                anim.SetBool("Finish", true);
                Invoke("GameOver", 30f);
            }
        }

        #endregion

        #region Class Methods

        private void GameOver()
        {
            Application.Quit();
            Debug.Log("The End");
        }
        #endregion
    }
}
//By Sean González
