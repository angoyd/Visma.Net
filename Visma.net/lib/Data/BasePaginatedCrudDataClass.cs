using ONIT.VismaNetApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace ONIT.VismaNetApi.Lib.Data
{
    public abstract class BasePaginatedCrudDataClass<T> : BaseCrudDataClass<T> where T : DtoPaginatedProviderBase, IProvideIdentificator
    {
        internal BasePaginatedCrudDataClass(VismaNetAuthorization auth) : base(auth)
        {
        }

        /// <summary>
        /// Gets all entities by splitting it into totalCount / pageSize tasks and fetching them in parallel.
        /// </summary>
        /// <returns></returns>
        /// <remarks>The order of the entities will be by the entity identificator. If the order matters to you, use OrderBy.</remarks>
        public override async Task<List<T>> All() => await VismaNetApiHelper.GetAllWithPagination<T>(ApiControllerUri, Authorization);

        /// <summary>
        ///     Retrieves all entities from Visma.Net.
        /// </summary>
        /// <returns>List of all entities</returns>
        public override async Task<List<T>> Find(NameValueCollection parameters) => await VismaNetApiHelper.GetAllWithPagination<T>(ApiControllerUri, Authorization, parameters);

        /// <summary>
        ///     Retrieves a single page of entities, in the order returned by the API.
        /// </summary>
        /// <param name="pageNumber">Page number, starting at 1</param>
        /// <param name="pageSize">Number of entities per page</param>
        /// <param name="parameters">Optional filter parameters</param>
        /// <returns>The entities on the page. Total count is available in metadata.totalCount on each entity.</returns>
        public virtual async Task<List<T>> GetPage(int pageNumber, int pageSize, NameValueCollection parameters = null) => await VismaNetApiHelper.GetPage<T>(ApiControllerUri, Authorization, pageNumber, pageSize, parameters);

        /// <summary>
        ///     Executes the action on all elements streamed from the API.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [Obsolete("This no longer works as intended. Use All() or Find() instead.", true)]
        public override Task ForEach(Action<T> action)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        ///     Executes the action on all elements streamed from the API.
        /// </summary>
        /// <param name="action">This action can be async.</param>
        /// <returns></returns>
        [Obsolete("This no longer works as intended. Use All() or Find() instead.", true)]
        public override Task ForEach(Func<T, Task> action)
        {
            return Task.FromResult(true);
        }


    }
}