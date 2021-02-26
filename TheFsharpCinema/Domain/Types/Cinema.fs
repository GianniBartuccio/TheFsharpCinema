namespace TheFsharpCinemaDomain.Domain

type CinemaName = CinemaName of string

type Cinema =
    {
        Id: CinemaName
        CinemaShows: CinemaShow list
    }

