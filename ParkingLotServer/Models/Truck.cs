using System;

namespace ParkingLot
{
    internal class Truck : Vehicle
    {
        /// <inheritdoc/>
        public override double Rate { get => Settings.price * 5; set => this.Rate = value; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Type.GetType("ParkingLot.Truck", false, true).Name + ", license number: " + this.Id;
        }
    }
}
