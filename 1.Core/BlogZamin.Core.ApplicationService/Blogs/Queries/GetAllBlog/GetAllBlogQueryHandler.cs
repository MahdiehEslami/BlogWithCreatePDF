using BlogZamin.Core.Contract.Blogs.Queries;
using BlogZamin.Core.Contract.Blogs.Queries.GetAllBlog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Utilities;

namespace BlogZamin.Core.ApplicationService.Blogs.Queries.GetAllBlog
{
    public class GetAllBlogQueryHandler : QueryHandler<GetAllBlogQuery, PagedData<BlogQr>>
    {
        private readonly IBlogQueryRepository _blogQueryRepository;
        public GetAllBlogQueryHandler(ZaminServices zaminServices,
            IBlogQueryRepository blogQueryRepository) : base(zaminServices)
        {
            _blogQueryRepository = blogQueryRepository;
        }

        public override async Task<QueryResult<PagedData<BlogQr>>> Handle(GetAllBlogQuery query)
            => Result(await _blogQueryRepository.GetAllBlogQuery(query));
    }
}

