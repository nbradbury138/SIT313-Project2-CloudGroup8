using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectWebServer.Models;

namespace SIT313Deploy.Controllers
{
    public class TaskModelsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Task
        [Authorize]
        public IQueryable<TaskModel> GetTask()
        {
            var userId = User.Identity.Name;
            return db.TaskModels.Where(task => task.User == userId);
        }

        // GET: api/Task/5
        [Authorize]
        [ResponseType(typeof(TaskModel))]
        public async Task<IHttpActionResult> GetTask(int id)
        {
            TaskModel taskModel = await db.TaskModels.FindAsync(id);
            if (taskModel == null)
            {
                return NotFound();
            }

            return Ok(taskModel);
        }

        // PUT: api/Task/5
        [Authorize]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTask(int id, TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskModel.Id)
            {
                return BadRequest();
            }

            db.Entry(taskModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Task
        [Authorize]
        [ResponseType(typeof(TaskModel))]
        public async Task<IHttpActionResult> PostTask(TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskModels.Add(taskModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = taskModel.Id }, taskModel);
        }

        // DELETE: api/Task/5
        [Authorize]
        [ResponseType(typeof(TaskModel))]
        public async Task<IHttpActionResult> DeleteTask(int id)
        {
            TaskModel taskModel = await db.TaskModels.FindAsync(id);
            if (taskModel == null)
            {
                return NotFound();
            }

            db.TaskModels.Remove(taskModel);
            await db.SaveChangesAsync();

            return Ok(taskModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskModelExists(int id)
        {
            return db.TaskModels.Count(e => e.Id == id) > 0;
        }
    }
}