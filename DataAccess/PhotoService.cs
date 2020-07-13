using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entries;

namespace DataAccess
{
    public interface IPhotoService
    {
        Task<Album[]> GetAllAlbumsAsync();
        Task<Photo[]> GetPhotosAsync(int albumId);
        Task<PhotoComment[]> GetCommentsAsync(int postId);
    }

    public class PhotoService : IPhotoService
    {
        private readonly IWebDataProvider _webDataProvider;

        public PhotoService(IWebDataProvider webDataProvider)
        {
            _webDataProvider = webDataProvider;
        }

        public Task<Album[]> GetAllAlbumsAsync()
        {
            return _webDataProvider.GetAsync<Album[]>("http://jsonplaceholder.typicode.com/albums");
        }
        public Task<Photo[]> GetPhotosAsync(int albumId)
        {
            return _webDataProvider.GetAsync<Photo[]>("http://jsonplaceholder.typicode.com/photos?albumId=" + albumId);
        }
        public Task<PhotoComment[]> GetCommentsAsync(int postId)
        {
            return _webDataProvider.GetAsync<PhotoComment[]>("http://jsonplaceholder.typicode.com/comments?postId=" + postId);
        }
    }
}
