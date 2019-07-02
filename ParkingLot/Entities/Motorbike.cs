using System;

namespace ParkingLot
{
    internal class Motorbike : Vehicle
    {
        /// <inheritdoc/>
        public override double Rate { get => Settings.price; set => this.Rate = value; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Type.GetType("ParkingLot.Motorbike", false, true).Name + ", license number: " + this.Id;
        }
    }
}
