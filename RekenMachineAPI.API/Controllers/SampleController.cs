//using System.Data.Entity;
//using System.Threading.Tasks;
//using System.Web.Http;
//using RekenMachineAPI.Domain;
//using RekenMachineAPI.Service;

//namespace RekenMachineAPI.API.Controllers
//{
//    [RoutePrefix("api/samples")]
//    public class SampleController : BaseApiController
//    {
//        private readonly IService<Sample> _sampleService;

//        public SampleController(IService<Sample> sampleService)
//        {
//            _sampleService = sampleService;
//        }

//        [HttpGet, Route]
//        public async Task<IHttpActionResult> GetAll(string sort = null)
//        {
//            return Ok(await _sampleService.GetEf().ToListAsync());
//        }

//        [HttpGet, Route("{id}")]
//        public async Task<IHttpActionResult> Get(int id)
//        {
//            var sample = await _sampleService.GetAsyncEf(id);

//            if (sample == null)
//                return NotFound();

//            return Ok(sample);
//        }


//        [HttpPost, Route]
//        public async Task<IHttpActionResult> Post(Sample sample)
//        {
//            _sampleService.Add(sample);
//            await _sampleService.SaveChangesAsync();
//            return Ok();
//        }

//        [HttpPut, Route("{id}")]
//        public async Task<IHttpActionResult> Put(int id, Sample sample)
//        {
//            var sampleToUpdate = await _sampleService.GetAsyncEf(id);

//            if (sampleToUpdate == null)
//                return NotFound();

//            sampleToUpdate.Value = sample.Value;
//            sampleToUpdate.AnotherValue = sample.AnotherValue;
//            await _sampleService.SaveChangesAsync();

//            return Ok();
//        }

//        [HttpDelete, Route("{id}")]
//        public async Task<IHttpActionResult> Delete(int id)
//        {
//            var sampleToDelete = await _sampleService.GetAsyncEf(id);

//            if (sampleToDelete == null)
//                return NotFound();

//            _sampleService.Delete(sampleToDelete);
//            await _sampleService.SaveChangesAsync();

//            return Ok();
//        }
//    }    
//}