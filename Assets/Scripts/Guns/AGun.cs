using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Guns
{
    public abstract class AGun: UnityEngine.MonoBehaviour
    {
        public abstract void Shoot();
        public abstract void Reload();
    }
}
