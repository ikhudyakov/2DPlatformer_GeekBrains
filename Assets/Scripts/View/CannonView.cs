using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{

    public class CannonView : MonoBehaviour
    {
        public Transform _muzzleTransform;
        public Transform _emiterTransform;
        public List<LevelObjectView> _bullets;
    }
}