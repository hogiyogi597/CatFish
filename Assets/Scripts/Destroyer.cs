using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFish
{
    public class Destroyer : MonoBehaviour
    {

        public void DestroyGameObject(GameObject target)
        {
            Destroy(target);
        }
    }
}