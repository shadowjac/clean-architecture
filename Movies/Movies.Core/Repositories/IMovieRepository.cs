﻿using System;
using Movies.Core.Entities;
using Movies.Core.Repositories.Base;

namespace Movies.Core.Repositories
{
	public interface IMovieRepository : IRepository<Movie>
	{
		Task<IEnumerable<Movie>> GetMoviesByDirectorNameAsync(string directorName);
	}
}

