using UnityEngine;

namespace VacoTest
{
    public class Restart : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Do();
            }
        }

        private void Do()
        {
            _player.ResetState();
        }
    }
}