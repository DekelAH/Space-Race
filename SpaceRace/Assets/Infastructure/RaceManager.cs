using UnityEngine;
using Cysharp.Threading.Tasks;
using SpaceRace.Gameplay.Entities;
using System.Threading;

namespace Assets.Infastructure
{
    public class RaceManager : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Spaceship _spaceshipOne;

        [SerializeField]
        private Spaceship _spaceshipTwo;

        [SerializeField]
        private Spaceship _spaceshipThree;

        [SerializeField]
        [Range(0.1f, 10f)]
        private float _minSpeed = 0.3f;

        [SerializeField]
        [Range(0.1f, 10f)]
        private float _maxSpeed = 0.5f;

        #endregion

        #region Fields

        private CancellationTokenSource _cancellationToken;

        #endregion

        #region Methods

        public async UniTask StartRace()
        {
            _cancellationToken = new CancellationTokenSource();

            var (raceWinner, r1, r2, r3) = await UniTask.WhenAny(

                 _spaceshipOne.MoveSpaceship(_cancellationToken, Random.Range(_minSpeed, _maxSpeed)),
                 _spaceshipTwo.MoveSpaceship(_cancellationToken, Random.Range(_minSpeed, _maxSpeed)),
                 _spaceshipThree.MoveSpaceship(_cancellationToken, Random.Range(_minSpeed, _maxSpeed))

                 );

            var racers = new[] { r1, r2, r3 };

            Debug.Log($"The Winner is: !~~ {racers[raceWinner]} ~~!");
        }

        public void ResetRacersPositions()
        {
            _spaceshipOne.ResetSpaceshipPosition();
            _spaceshipTwo.ResetSpaceshipPosition();
            _spaceshipThree.ResetSpaceshipPosition();
        }

        public void CancelRace()
        {
            _cancellationToken?.Cancel();
        }

        #endregion

        #region Properties

        #endregion
    }
}
