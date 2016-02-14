using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        private bool interact = false, lastinteract = false;
        public float speed;
        bool run = false;
        private Rigidbody rigbod;
        Vector3 CharNextPos;
        private void Start()
        {
            //GetComponent<Animation>()["RunForward_NtrlFaceFwd"].speed = 0.30f;
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
            rigbod = GetComponent<Rigidbody>();
        }
        
        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C);
            run = Input.GetKey(KeyCode.LeftShift);
            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to moves:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h*m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (run)
            {
                speed = 4;
            }
            else
            {
                m_Move *= 0.5f;
                speed = 2;
            }


            if (Input.GetKeyDown(KeyCode.E))
                interact = true;
            else
                interact = false;

#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, run, interact);
            m_Jump = false;
            if(v > 0.1)
                rigbod.velocity = transform.forward * speed;
            else if(v < -0.1)
                rigbod.velocity = -transform.forward * speed;
        }
        void OnTriggerStay(Collider Col)
        {
            Debug.Log("Interact:" + interact);
            Debug.Log("Lastinteract:" + lastinteract);
            if (interact && lastinteract)
            {
                Col.gameObject.GetComponent<AudioSource>().Stop();
                lastinteract = false;
            }
            else if (interact)
            {
                Col.gameObject.GetComponent<AudioSource>().Play();
                lastinteract = true;
            }
        }
    }
}
