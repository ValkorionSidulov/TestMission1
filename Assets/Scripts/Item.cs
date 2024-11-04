using UnityEngine;

namespace Test
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private float m_Distance;
        [SerializeField] private Transform m_Target;

        private Rigidbody m_Rigidbody;
        private Parameters m_Parameters;

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Parameters = GameObject.Find("FirstPersonController").GetComponent<Parameters>();
        }

        private void OnMouseDown()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, m_Distance) && m_Parameters.IsItem == false)
            {
                m_Rigidbody.isKinematic = true;
                m_Parameters.IsItem = true;
                m_Rigidbody.MovePosition(m_Target.position);
            }
        }

        private void FixedUpdate()
        {
            if (m_Rigidbody.isKinematic == true)
            {
                this.gameObject.transform.position = m_Target.position;
                
                if(Input.GetKey(KeyCode.G))
                {
                    m_Rigidbody.useGravity = true;
                    m_Rigidbody.isKinematic = false;
                    m_Parameters.IsItem = false;
                    m_Rigidbody.AddForce(Camera.main.transform.forward * 200);
                }
            }
        }
    }
}
