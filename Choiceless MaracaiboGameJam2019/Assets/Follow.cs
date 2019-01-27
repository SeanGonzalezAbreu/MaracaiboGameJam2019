using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace SAGAMES
{
    public class Follow : MonoBehaviour
    {
        #region Variables
        private Transform Target;
        Rigidbody2D rb;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                StartCoroutine(HopHop(1f));
            }
        }


        private IEnumerator HopHop(float wait)
        {
            if (Target == null) yield return null;

            while (true)
            {
                if (Target == null) yield return null;

                Vector2 directionToTarget = Target.transform.position - transform.position;
                Vector2 normalizedDir = directionToTarget.normalized;
                Vector2 Velocity = normalizedDir * 40f;
                float distanceToTarget = directionToTarget.magnitude;
                if (distanceToTarget > 2f)
                {
                    rb.MovePosition(rb.position + Velocity * Time.fixedDeltaTime);
                }
                yield return new WaitForSeconds(Random.Range(wait*2,wait*4));

            }
        }
        #endregion

        #region Class Methods

        #endregion
    }
}
//By Sean González
