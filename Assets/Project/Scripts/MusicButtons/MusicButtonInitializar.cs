using ThreeD_Sound_Game.MasterData;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ThreeD_Sound_Game.MusicButtons
{
    public class MusicButtonInitializar : MonoBehaviour
    {
        #region private property
        [SerializeField]
        TextMeshProUGUI musicNameText;
        [SerializeField]
        TextMeshProUGUI artistNameText;
        [SerializeField]
        Image coverImage;
        [SerializeField]
        TextMeshProUGUI difficultText;
        #endregion

        public void Init(MusicInfoModel musicInfo, string genre)
        {
            musicNameText.SetText(musicInfo.musicName);
            artistNameText.SetText(musicInfo.artistName);
            coverImage.sprite = musicInfo.coverImage;
            if (musicInfo.difficult < 10)
                difficultText.text += "<size=30><color=blue>" + musicInfo.difficult.ToString() + "</color></size> / 12";
            else
                difficultText.text += "<size=30><color=red>" + musicInfo.difficult.ToString() + "</color></size> / 12";
                Debug.Log(difficultText.text);
            gameObject.name = musicInfo.musicName;
            GetComponent<MusicLoader>().SetGenre(genre);
        }
    }
}
