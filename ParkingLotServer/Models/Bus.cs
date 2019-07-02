using System;

namespace ParkingLot
{
    internal class Bus : Vehicle
    {
        /// <inheritdoc/>
        public override double Rate { get => Settings.price * 3.5; set => this.Rate = value; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Type.GetType("ParkingLot.Bus", false, true).Name + ", license number: " + this.Id;
        }
    }
}
