using Cysharp.Threading.Tasks;
using SpaceRace.Data;
using System.Threading;
using UnityEngine;

namespace SpaceRace.Gameplay.Entities
{
    public class Spaceship : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Transform _spaceshipTransform;

        [SerializeField]
        private Transform _destinationTransform;

        [SerializeField]
        private Transform _startTransform;

        [SerializeField]
        private SpaceshipType _type;

        #endregion

        #region Methods

        public async UniTask<SpaceshipType> MoveSpaceship(CancellationTokenSource cancelToken, float speed)
        {
            var direction = (_destinationTransform.position - _spaceshipTransform.position).normalized;
            while (!cancelToken.IsCancellationRequested && Vector3.Distance(_spaceshipTransform.position, _destinationTransform.position) > 0.1f)
            {
                _spaceshipTransform.position += speed * Time.deltaTime * direction;
                await UniTask.Yield();
            }

            return _type;
        }

        public void ResetSpaceshipPosition()
        {
            _spaceshipTransform.position = _startTransform.position;
        }

        #endregion

        #region Properties

        public SpaceshipType Type => _type;

        #endregion
    }
}