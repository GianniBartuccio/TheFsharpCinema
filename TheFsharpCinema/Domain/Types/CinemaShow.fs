namespace TheFsharpCinemaDomain.Domain

type CinemaShowId = int
type MovieTitle = string

type CinemaShow = { Id : CinemaShowId
                    MovieTitle : MovieTitle
                    SeatingPlan : SeatingPlan }