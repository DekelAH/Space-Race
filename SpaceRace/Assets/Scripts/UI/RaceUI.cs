using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using Assets.Infastructure;

namespace Assets.Scripts.UI
{
    public class RaceUI : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Button _startBtn;

        [SerializeField]
        private Button _cancelBtn;

        [SerializeField]
        private RaceManager _raceManager;

        #endregion

        #region Methods

        private void Start()
        {

        }

        public async void OnStartButtonPressed()
        {
            _startBtn.interactable = false;
            _raceManager.ResetRacersPositions();
            await _raceManager.StartRace();
            _startBtn.interactable = true;
        }

        public void OnCancelButtonPressed()
        {
            _raceManager.CancelRace();
        }

        #endregion

        #region Properties


        #endregion
    }
}
