using UnityEngine;

namespace ThreeD_Sound_Game.Common
{
    public class SpriteFadeOuter : MonoBehaviour
    {
        [SerializeField]
        float startFadeSecond;
        [SerializeField]
        float endFadeSecond;
        [SerializeField]
        bool autoDestroy;
        [SerializeField]
        bool destroyWithParent;
        [SerializeField]
        new SpriteRenderer renderer;
        float time;

        void Start()
        {
            time = 0;
        }

        void Update()
        {
            time += Time.deltaTime;
            if (time > endFadeSecond)
            {
                if (autoDestroy)
                {
                    if (destroyWithParent)
                        Destroy(transform.parent.gameObject);
                    else
                        Destroy(gameObject);
                }
            }
            else if (time > startFadeSecond)
            {
                var alpha = (time - startFadeSecond) / (endFadeSecond - startFadeSecond) * -1f + 1;
                renderer.color = new Color(255, 255, 255, alpha);
            }
        }
    }
}
