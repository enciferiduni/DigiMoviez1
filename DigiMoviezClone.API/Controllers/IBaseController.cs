using Microsoft.AspNetCore.Mvc;

namespace DigiMoviezClone.API.Controllers
{
    // T stands for response dto
    // Y stands for request dto
    // Tkey stands for primary key type
    public interface IBaseController<T,Y>
        where T : class
        where Y : class
    {
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<ActionResult<T>> GetById(long id);
        Task<ActionResult<T>> Create([FromBody] Y entity);
        Task<ActionResult<T>> Update(long id, [FromBody] Y entity);
        Task<ActionResult<T>> Delete(long id);
    }
}