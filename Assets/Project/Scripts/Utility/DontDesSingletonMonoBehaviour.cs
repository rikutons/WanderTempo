using UnityEngine;

namespace ThreeD_Sound_Game.Utility
{
    public class DontDesSingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T instance_;
        public static T Instance
        {
            get
            {
                if (instance_ == null)
                {
                    instance_ = FindObjectOfType<T>();
                }

                if (instance_ == null)
                {
                    instance_ = new GameObject(typeof(T).FullName).AddComponent<T>();
                    DontDestroyOnLoad(instance_);
                }
                return instance_ ?? new GameObject(typeof(T).FullName).AddComponent<T>();
            }
        }
    }
}
