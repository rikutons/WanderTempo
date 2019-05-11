using ThreeD_Sound_Game.Model;
using UnityEngine;
using UniRx;
namespace ThreeD_Sound_Game.Presenter{
	public class JudgeLineChangePresenter : MonoBehaviour {
		#region private property
        [SerializeField]
        SpriteRenderer[] lineRenderers;
        [SerializeField]
        Sprite focusedLineSprite;
        [SerializeField]
        Sprite unfocusedLineSprite;
        int beforeFocus;
		#endregion

		void Start () {
            beforeFocus = 0;
            SystemData.FocusLine.
                Subscribe(num =>
                {
                    ChangeFocus(num);
                });
		}
		
		void ChangeFocus(int newFocus)
        {
            lineRenderers[beforeFocus].sprite = unfocusedLineSprite;
            lineRenderers[newFocus].sprite = focusedLineSprite;
            beforeFocus = newFocus;
        }
	}
}
