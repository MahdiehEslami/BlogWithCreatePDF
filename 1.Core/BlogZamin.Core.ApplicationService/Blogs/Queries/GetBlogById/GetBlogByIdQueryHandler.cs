using BlogZamin.Core.Contract.Blogs.Queries;
using BlogZamin.Core.Contract.Blogs.Queries.GetAllBlog;
using BlogZamin.Core.Contract.Blogs.Queries.GetBlogById;
using System;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Utilities;

namespace BlogZamin.Core.ApplicationService.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler : QueryHandler<GetBlogByIdQuery, BlogQr>
    {
        private readonly IBlogQueryRepository _blogQueryRepository;

        public GetBlogByIdQueryHandler(ZaminServices zaminServices,
                                       IBlogQueryRepository blogQueryRepository) : base(zaminServices)
        {
            _blogQueryRepository = blogQueryRepository;
        }

        public override async Task<QueryResult<BlogQr>> Handle(GetBlogByIdQuery query)
            => Result(await _blogQueryRepository.GetBlogByIdQuery(query));

    }
}
