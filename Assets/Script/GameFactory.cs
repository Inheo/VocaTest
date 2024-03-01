using UnityEngine;
using VacoTest.Unit;

namespace VacoTest
{
    public class GameFactory : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Npc _npcPrefab;

        private Player _player;
        private Npc _npc;

        public Player GetPlayer()
        {
            if (_player == null)
                _player = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);

            return _player;
        }

        public Npc GetNpc()
        {
            if (_npc == null)
                _npc = Instantiate(_npcPrefab, Vector3.zero, Quaternion.identity);

            return _npc;
        }
    }
}