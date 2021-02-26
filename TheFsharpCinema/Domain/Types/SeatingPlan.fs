namespace TheFsharpCinemaDomain.Domain

type SeatingPlan =
    {
        Seats: Seat list
    }

module SeatingPlan =
    let getAvailableSeats seatingPlan =
        seatingPlan.Seats
        |> List.where (fun seat -> not seat.Occupied)
