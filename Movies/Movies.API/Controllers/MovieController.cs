using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Commands;
using Movies.Application.Queries;
using Movies.Application.Responses;

namespace Movies.API.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieResponse>>> GetMoviersByDirectorName(string directorName)
        {
            var query = new GetMoviesByDirectorNameQuery(directorName);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieResponse>> CreateMovieAsync([FromBody] CreateMovieCommand movieCommand)
        {
            var result = await _mediator.Send(movieCommand);
            return Ok(result);
        }
    }
}

