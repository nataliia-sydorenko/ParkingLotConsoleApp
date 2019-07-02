using System;

namespace ParkingLot
{
    internal class Car : Vehicle
    {
        /// <inheritdoc/>
        public override double Rate { get => Settings.price * 2; set => this.Rate = value; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Type.GetType("ParkingLot.Car", false, true).Name + ", license number: " + this.Id;
        }
    }
}
