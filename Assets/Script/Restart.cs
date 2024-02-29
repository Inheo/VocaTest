using UnityEngine;

namespace VacoTest
{
    public class Restart : MonoBehaviour
    {
        [SerializeField] private GameFactory _factory;

        private void Start()
        {
            _factory.GetPlayer();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Do();
            }
        }

        private void Do()
        {
            var player = _factory.GetPlayer();
            var npc = _factory.GetNpc();
            var data = player.GetData();

            player.ResetState();
            npc.SetData(data);
            npc.ResetState();
        }
    }
}