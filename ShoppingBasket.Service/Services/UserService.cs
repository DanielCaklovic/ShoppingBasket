using AutoMapper;
using Microsoft.Extensions.Logging;
using ShoppingBasket.DAL.Entities;
using ShoppingBasket.Model.Common;
using ShoppingBasket.Repository.Common;
using ShoppingBasket.Service.Common;
using System;
using System.Threading.Tasks;

namespace ShoppingBasket.Service
{
    /// <summary>
    /// User service.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Service.BaseService" />
    /// <seealso cref="ShoppingBasket.Service.Common.IUserService" />
    public class UserService : BaseService, IUserService
    {
        /// <summary>
        /// The user repository
        /// </summary>
        protected readonly IUserRepository UserRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UserService(IUserRepository userRepository,
            IMapper mapper,
            ILogger<UserService> logger)
            : base(mapper, logger)
        {
            this.UserRepository = userRepository;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(IUser model)
        {
            return await UserRepository.CreateAsync(Mapper.Map<User>(model));
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Guid id, IUser model)
        {
            return await UserRepository.UpdateAsync(id, Mapper.Map<User>(model));
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await UserRepository.DeleteAsync(id);
        }
        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IUser> GetByIdAsync(Guid id)
        {
            var entity = await UserRepository.GetByIdAsync(id);
            return Mapper.Map<IUser>(entity);
        }
    }
}
