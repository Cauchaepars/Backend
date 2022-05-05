using System;
using System.Collections.Generic;
using System.Text;

namespace ITRR.Database.Repositories
{

	public class BaseRepository
	{
		protected readonly ITRRDbContext _context;

		public BaseRepository(ITRRDbContext context)
		{
			_context = context;
		}
	}
}
