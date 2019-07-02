namespace ParkingLot
{
    public abstract class Vehicle
    {
        /// <value>Gets/sets the string value of vehicle license number.</value>
        public string Id { get; set; }

        /// <value>Gets/sets the start value of vehicle balance.</value>
        public double Balance { get; set; }

        /// <value>Gets/sets the value of rate for parking.</value>
        public virtual double Rate { get; set; }

        /// <value>Gets/sets the true value if vehicle is parked.</value>
        public bool IsParked { get; set; }

    }
}
