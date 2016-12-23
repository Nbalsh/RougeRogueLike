using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
		private bool slowed;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
				if (Input.GetKeyDown(KeyCode.UpArrow)) {
					m_Jump = Input.GetKeyDown (KeyCode.UpArrow);
				}

            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.DownArrow);
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			if (h >= 0)
			{
				if (slowed) //TODO: move this logic to PlatformerCharacter2D and just pass slowed in to Move
				{
					h /= 2;
				}
				// Pass all parameters to the character control script.
				m_Character.Move (h, crouch, m_Jump);
			}
            m_Jump = false;
        }

		void OnCollisionEnter2D(Collision2D col)
		{
			if(col.gameObject.tag == "slow")
			{
				slowed = true;
			}
		}

		private void OnCollisionExit2D(Collision2D col)
		{
			if(col.gameObject.tag == "slow")
			{
				slowed = false;
			}
		}

    }
}
