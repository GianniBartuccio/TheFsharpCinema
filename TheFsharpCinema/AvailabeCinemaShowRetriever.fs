module AvailableCinemaShowRetriever

    open TheFsharpCinemaDomain.Domain
    let getAvailableShows cinema =
        cinema.CinemaShows
        |> List.filter (fun cinemaShow -> cinemaShow.SeatingPlan.GetAvailableSeats.Length > 0)
        
        