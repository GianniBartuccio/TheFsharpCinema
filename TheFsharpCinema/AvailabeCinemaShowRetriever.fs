namespace TheFsharpCinemaDomain.Service

open TheFsharpCinemaDomain.Domain

module AvailableCinemaShowRetriever =
    let getAvailableShows cinema =
        cinema.CinemaShows
        |> List.where CinemaShow.hasAvailableSeats
