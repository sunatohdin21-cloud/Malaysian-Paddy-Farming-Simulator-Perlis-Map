
using UnityEngine;

namespace ExitaUtara
{
    public class VehicleGearSystem : MonoBehaviour
    {
        public enum Gear
        {
            Reverse = -1,
            Neutral = 0,
            Forward = 1
        }

        public Gear CurrentGear { get; private set; }
            = Gear.Neutral;

        public void GearForward()
        {
            CurrentGear = Gear.Forward;
        }

        public void GearReverse()
        {
            CurrentGear = Gear.Reverse;
        }

        public void GearNeutral()
        {
            CurrentGear = Gear.Neutral;
        }

        public int GetGearValue()
        {
            return (int)CurrentGear;
        }
    }
}
