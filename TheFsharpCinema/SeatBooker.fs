module TheFsharpCinemaDomain.SeatBooker

    open TheFsharpCinemaDomain.Domain

    let BookSeat (getShowFromPersistence : CinemaShowId -> CinemaShow option ) (saveBookedSeatToPersistence : CinemaShowId -> int -> int -> bool ) cinemaShowId seatRow seatNumber =
        let cinemaShow = getShowFromPersistence cinemaShowId
        match cinemaShow with
        | Some cinemaShow ->
            let seatToBook = List.find(fun (seat : Seat) -> seat.SeatRow = seatRow && seat.SeatNumber = seatNumber) cinemaShow.SeatingPlan.Seats
            match seatToBook.Occupied with
            | true -> false
            | false -> saveBookedSeatToPersistence cinemaShowId seatToBook.SeatRow seatToBook.SeatNumber 
        | None -> false
