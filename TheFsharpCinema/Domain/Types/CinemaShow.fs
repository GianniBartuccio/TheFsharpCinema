namespace TheFsharpCinemaDomain.Domain

type CinemaShowId = CinemaShowId of int
type MovieTitle = MovieTitle of string

type CinemaShow =
    {
        Id: CinemaShowId
        MovieTitle: MovieTitle
        SeatingPlan: SeatingPlan
    }

module CinemaShow =
    let hasAvailableSeats cinemaShow =
        SeatingPlan.getAvailableSeats cinemaShow.SeatingPlan
        |> fun availableSeats -> availableSeats.Length > 0
