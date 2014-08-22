using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Data
{
	public class EfUnitOfWork : IUnitOfWork
	{
		private readonly DbContext _dataContext;

		public EfUnitOfWork(DbContext dataContext)
		{
			this._dataContext = dataContext;
		}

		public void Commit()
		{
			try
			{
				this._dataContext.SaveChanges();
			}
			catch (DbEntityValidationException exception)
			{
				var details = new StringBuilder();
				foreach (var error in exception.EntityValidationErrors)
				{
					error.ValidationErrors.ToList().ForEach(err =>
							details.AppendLine(err.PropertyName + ":" + err.ErrorMessage));
				}
				throw new DbEntityValidationException("Validation Errors:" + details, exception);
			}
		}
	}
}
