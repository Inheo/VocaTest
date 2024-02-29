using UnityEngine;
using VacoTest.Unit;

namespace VacoTest
{
    public class Restart : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Npc _npc;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Do();
            }
        }

        private void Do()
        {
            var data = _player.GetData();
            _player.ResetState();
            _npc.SetData(data);
            _npc.ResetState();
        }
    }
}