using System.Collections.Generic;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class PublishersController : Controller
    {
        private readonly PublisherService _publisherService;

        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet, Route("list")]
        public ActionResult<List<Publisher>> Get() =>
            _publisherService.Get();

        [HttpGet("{id:length(24)}", Name = nameof(GetById))]
        [Route("id")]
        public ActionResult<Publisher> GetById(string id)
        {
            var publisher = _publisherService.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }

            return publisher;
        }

        [HttpGet("{name}", Name = nameof(GetByName))]
        [Route("name")]
        public ActionResult<Publisher> GetByName(string name)
        {
            var publisher = _publisherService.GetByName(name);
            if (publisher == null)
            {
                return NotFound();
            }

            return publisher;
        }

        [HttpPost]
        public ActionResult<Publisher> Create(Publisher publisher)
        {
            _publisherService.Create(publisher);
            return CreatedAtRoute("GetById", new { id = publisher.Id.ToString() }, publisher);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Publisher publisherIn)
        {
            var publisher = _publisherService.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            _publisherService.Update(id, publisherIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var publisher = _publisherService.GetById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            _publisherService.Remove(publisher.Id);
            return NoContent();
        }
    }
}