using System;

namespace Passenger.Core.Domain
{
    //
    // Summary:
    //     Klasa reprezentujaca model trasy przejazdu kierowcy 
    //
    public class Route
    {
        public Guid Id { get; protected set; }
        public Node StartNode { get; protected set; }
        public Node EndNode { get; protected set; }

    }
}