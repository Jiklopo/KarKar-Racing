using Checkpoints;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
	public class LevelCompletedScreen : UIElement
	{
		[SerializeField] private TextMeshProUGUI finishText;
		[SerializeField] private Button menuButton;
		protected override void OnAwake()
		{
			menuButton.onClick.AddListener(GoToMenu);
			GameBus.OnLapCompleted += OnLapCompleted;
		}

		private void GoToMenu()
		{
			Time.timeScale = 1;
			SceneManager.LoadScene(0);
		}

		private void OnLapCompleted()
		{
			finishText.SetText($"Congratulations!\nYour position is {CheckpointsController.Instance.PlayerPos} / 4");
			Show();
		}

		protected override void OnShown()
		{
			Time.timeScale = 0;
		}
	}
}