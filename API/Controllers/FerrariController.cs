
using Microsoft.AspNetCore.Mvc;
using API.Controllers.API.Controllers;
using AutoMapper;
using API.Models.Entity;
using API.Models.DTOs.DictadorDto;
using API.Models.DTOs.FerrariDTO;
using API.Repository.IRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FerrariController : BaseController<FerrariEntity, FerrariDTO, CreateFerrariDTO>
    {
     
            public FerrariController(IFerrariRepository ferrariRepository,
                IMapper mapper, ILogger<IFerrariRepository> logger)
                : base(ferrariRepository, mapper, logger)
            {

            }
    }
}

