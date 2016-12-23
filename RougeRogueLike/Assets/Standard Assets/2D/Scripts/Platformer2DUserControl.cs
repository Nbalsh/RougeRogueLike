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
		private bool attack;


        private void Awake()
        {
			m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
				m_Jump = Input.GetKeyDown (KeyCode.UpArrow);
            }
			if (!attack) {
				attack = Input.GetKeyDown (KeyCode.Space);
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
				m_Character.Attack (attack);
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
