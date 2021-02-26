namespace TheFsharpCinemaDomain.Service

open TheFsharpCinemaDomain.Domain

type CinemaShowAvailableSeatRetriever =
    {
        GetAvailableSeats: CinemaShowId -> Seat list
    }

module CinemaShowAvailableSeatRetriever =
    let create getShow =
        let getAvailableSeats cinemaShowId =
            let cinemaShow = getShow cinemaShowId

            match cinemaShow with
            | Some show ->
                show.SeatingPlan
                |> SeatingPlan.getAvailableSeats
            | None -> List.empty

        {
            GetAvailableSeats = getAvailableSeats
        }
