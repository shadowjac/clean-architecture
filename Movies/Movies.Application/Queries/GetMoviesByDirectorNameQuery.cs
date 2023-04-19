using System;
using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Queries
{
    public class GetMoviesByDirectorNameQuery : IRequest<IEnumerable<MovieResponse>>
    {
        public GetMoviesByDirectorNameQuery(string directorName)
        {
            DirectorName = directorName;
        }

        public string DirectorName { get; set; }
    }
}

