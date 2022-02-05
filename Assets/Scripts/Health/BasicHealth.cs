using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Enemies
{
    public class BasicHealth : IHealth
    {
        public sliderBar sb;
        public float health = 50;

        private void Start()
        {
            sb.sliderMax(health);
        }

        public override void TakeDamage(float damage)
        {
            health -= damage;

            sb.setSlider(health);

            if (health < 0.0000001)
            {
                UnityEngine.Debug.Log("I'm Dead");
            }
        }

        public override void HealDamage(float healing)
        {
            health += healing;
        }

        public override float GetHealth()
        {
            return health;
        }
    }
}
