using System;
using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Commands
{
    public class CreateMovieCommand : IRequest<MovieResponse>
    {
        public string? Name { get; set; }
        public string? DirectedBy { get; set; }
        public string? ReleaseYear { get; set; }
    }
}

