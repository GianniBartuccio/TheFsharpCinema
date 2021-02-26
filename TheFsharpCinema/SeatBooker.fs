namespace TheFsharpCinemaDomain.Service

open TheFsharpCinemaDomain.Domain

module SeatBooker =
    let bookSeat getShowFromPersistence saveBookedSeatToPersistence cinemaShowId seatRow seatNumber =
        let cinemaShow = getShowFromPersistence cinemaShowId

        match cinemaShow with
        | Some cinemaShow ->
            let seatToBook = List.find(fun (seat : Seat) -> seat.SeatRow = seatRow && seat.SeatNumber = seatNumber) cinemaShow.SeatingPlan.Seats
            match seatToBook.Occupied with
            | true -> false
            | false -> saveBookedSeatToPersistence cinemaShowId seatToBook.SeatRow seatToBook.SeatNumber
        | None -> false

type SeatBooker =
    {
        BookSeat: CinemaShowId -> Seat -> Result<unit, string>
    }

module SeatBooker2 =
    let create getShow saveBookedSeat =
        let bookSeat cinemaShowId wantedSeat =
            getShow cinemaShowId
            |> Result.bind (fun cinemaShow ->
                let seatToBook =
                    cinemaShow.SeatingPlan.Seats
                    |> List.tryFind (fun seat ->
                        seat.SeatRow = wantedSeat.SeatRow && seat.SeatNumber = wantedSeat.SeatNumber
                    )

                match seatToBook with
                | Some seat -> saveBookedSeat cinemaShowId seat |> Ok
                | None -> "Seat does not exist" |> Error
            )

        {
            BookSeat = bookSeat
        }
