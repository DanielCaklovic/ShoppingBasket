using ShoppingBasket.Model;
using ShoppingBasket.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Service.Common
{
    /// <summary>
    /// User service contract.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task<bool> CreateAsync(IUser model);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(Guid id, IUser model);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<IUser> GetByIdAsync(Guid id);
    }
}
