module TheFsharpCinemaDomain.CinemaShowAvailableSeatRetriever

    open TheFsharpCinemaDomain.Domain
    
    let GetAvailableSeats (getShowFromPersistence : CinemaShowId -> CinemaShow option) cinemaShowId =
        let cinemaShow = getShowFromPersistence cinemaShowId
        match cinemaShow with
        | Some show -> show.SeatingPlan.GetAvailableSeats
        | None -> List.empty