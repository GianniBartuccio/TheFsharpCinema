namespace TheFsharpCinemaDomain.Domain

type SeatingPlan = { Seats : Seat list}
    with
    member this.GetAvailableSeats =
        List.filter(fun (seat : Seat) -> seat.Occupied = false) this.Seats