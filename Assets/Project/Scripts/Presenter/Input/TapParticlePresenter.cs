using ThreeD_Sound_Game.Utility;
using UnityEngine;
using UniRx;

namespace ThreeD_Sound_Game.Presenter
{
    public class TapParticlePresenter : MonoBehaviour
    {
        [SerializeField]
        NoteInputPresenter noteInput;
        [SerializeField]
        GameObject particlePrefab;
        void Start()
        {
            for (int i = 0; i < 8; i++)
            {
                var block = i;
                noteInput.NoteInputDownObservables[i].Subscribe(_ =>
                {
                    var perticle = Instantiate(particlePrefab);
                    perticle.transform.position = BlockToPosSerializer.Serialize(block);
                });
            }
        }
    }
}
